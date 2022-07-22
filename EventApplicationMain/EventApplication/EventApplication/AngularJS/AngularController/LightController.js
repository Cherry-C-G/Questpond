Adminapp.controller("LightController", function ($scope, ShareLightData, SaveLigthService, $http, $cookies, $location, $window, cfpLoadingBar) {
    var favoriteCookie = $cookies.get('EventChannel');
    var config =
    {
        headers:
        {
            'RequestVerificationToken': favoriteCookie
        }
    };


    var url = $location.url();
    if (url == "/AllLighting") {
        ShowLight();
    }

    // Variables
    $scope.Message = "";
    $scope.FileInvalidMessage = "";
    $scope.SelectedFileForUpload = null;
    $scope.FileDescription = "";
    $scope.IsFormSubmitted = false;
    $scope.IsFileValid = false;
    $scope.IsFormValid = false;

    //Form Validation
    $scope.$watch("form1.$valid", function (isValid) {
        $scope.IsFormValid = isValid;
    });

    $scope.ChechFileValid = function (file) {
        var isValid = false;
        if ($scope.SelectedFileForUpload != null) {
            if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') && file.size <= (512 * 1024)) {
                $scope.FileInvalidMessage = "";
                isValid = true;
            }
            else {
                $scope.FileInvalidMessage = "Selected file is Invalid. (only file type png, jpeg and gif and 512 kb size allowed)";
            }
        }
        else {
            $scope.FileInvalidMessage = "Image required!";
        }
        $scope.IsFileValid = isValid;
    };

    $scope.selectFileforUpload = function (file) {
        $scope.SelectedFileForUpload = file[0];
    }

    $scope.SaveLighting = function (Light) {

        $scope.IsFormSubmitted = true;
        $scope.Message = "";
        $scope.ChechFileValid($scope.SelectedFileForUpload);
        if ($scope.IsFormValid && $scope.IsFileValid) {
            SaveLigthService.SaveFileandData($scope.SelectedFileForUpload, Light).then
                (function (d) {
                    alert("Lighting Saved Successfully");
                    $location.path('/AllLighting');
                }, function (e) {
                    alert(e);
                });
        }
        else {
            $scope.Message = "All the fields are required.";
        }
    };

    function ShowLight() {

        $http.get('/api/lightdata', config)
       .success(function (data, status, headers, config)
       {
           $scope.start();
           $scope.LightList = data;
           $scope.complete();
       })
       .error(function (data, status, header, config) {
           alert(status);
       });
    }

    $scope.deleteLight = function (LightID) {
        if ($window.confirm("Do you want Delete this Light ?")) {
            $http.delete('/api/lightdata/' + LightID, config)
            .success(function (data, status, headers, config) {
                if (data == "Success") {
                    ShowLight();
                }
            })
            .error(function (data, status, header, config) {
                alert(status);
            });
        }
    };

    $scope.EditLight = function (LightID) {
        ShareLightData.value = LightID;
        $location.path('/LightEdit');
    }

    $scope.Cancel = function () {
        $window.location.reload();
    }


    $scope.start = function () {
        cfpLoadingBar.start();
    };

    $scope.complete = function () {
        cfpLoadingBar.complete();
    }


});

Adminapp.controller("LightEditController", function ($scope, GetLightData, ShareLightData, UpdateLigthService, $http, $cookies, $location, $window) {


    // Variables
    $scope.Message = "";
    $scope.FileInvalidMessage = "";
    $scope.SelectedFileForUpload = null;
    $scope.FileDescription = "";
    $scope.IsFormSubmitted = false;
    $scope.IsFileValid = false;
    $scope.IsFormValid = false;

    //Form Validation
    $scope.$watch("form1.$valid", function (isValid) {
        $scope.IsFormValid = isValid;
    });

    $scope.ChechFileValid = function (file) {
        var isValid = false;
        if ($scope.SelectedFileForUpload != null) {
            if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') && file.size <= (512 * 1024)) {
                $scope.FileInvalidMessage = "";
                isValid = true;
            }
            else {
                $scope.FileInvalidMessage = "Selected file is Invalid. (only file type png, jpeg and gif and 512 kb size allowed)";
            }
        }
        else {
            $scope.FileInvalidMessage = "Image required!";
        }
        $scope.IsFileValid = isValid;
    };

    $scope.selectFileforUpload = function (file) {
        $scope.SelectedFileForUpload = file[0];
    }

    var response = GetLightData.getLight(ShareLightData.value);

    response.then(function (data) {
        $scope.Light = {};
        var LightData = data.data;
        $scope.Light.LightID = LightData.LightID;
        $scope.Light.LightType = LightData.LightType;
        $scope.Light.LightName = LightData.LightName;
        $scope.Light.LightCost = LightData.LightCost;
        $scope.Light.LightFilePath = LightData.LightFilePath;
    }, function ()
    {
        $location.path('/AllLighting');
    });

    $scope.Updatelight = function (Light) {

        var data = null;
        $scope.IsFormSubmitted = true;
        $scope.Message = "";
        if ($scope.SelectedFileForUpload == null) {

            var data = $scope.Light.LightFilePath;
            $scope.IsFormValid = true;
            $scope.IsFileValid = true;
        }
        else {
            var data = $scope.SelectedFileForUpload;
            $scope.ChechFileValid($scope.SelectedFileForUpload);
        }

        if ($scope.IsFormValid && $scope.IsFileValid) {
            UpdateLigthService.UpdateLigth(data, Light).then(function (d) {
                alert("Lighting Updated Successfully");
                $location.path('/AllLighting');
            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }

    };



});

Adminapp.factory('SaveLigthService', function ($http, $q) {

    var fac = {};
    fac.SaveFileandData = function (file, Light) {
        var formData = new FormData();
        formData.append("file", file);
        formData.append("LightType", Light.LightType);
        formData.append("LightName", Light.LightName);
        formData.append("LightCost", Light.LightCost);
        var defer = $q.defer();
        $http.post("/Light/SaveLight", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (d) {
            defer.resolve(d);
        })
        .error(function () {
            defer.reject("Error While Process!");
        });

        return defer.promise;

    }
    return fac;

});

Adminapp.factory("UpdateLigthService", function ($http, $q) {

    var fac = {};
    fac.UpdateLigth = function (file, Light) {
        var formData = new FormData();

        if (file != null) {
            formData.append("file", file);
        }

        formData.append("LightID", Light.LightID);
        formData.append("LightType", Light.LightType);
        formData.append("LightName", Light.LightName);
        formData.append("LightCost", Light.LightCost);
        var defer = $q.defer();
        $http.post("/Light/UpdateLight", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (d) {
            defer.resolve(d);
        })
        .error(function () {
            defer.reject("Error While Process!");
        });

        return defer.promise;

    }
    return fac;

});

Adminapp.factory("ShareLightData", function () {
    return { value: 0 }
});

Adminapp.service("GetLightData", function ($http, $cookies) {

    this.getLight = function (LightID)
    {
        var response =
           $http({
               method: "GET",
               url: "/api/lightdata/" + LightID,
               headers: { 'RequestVerificationToken': $cookies.get('EventChannel') }
           });
        return response;

    };


});