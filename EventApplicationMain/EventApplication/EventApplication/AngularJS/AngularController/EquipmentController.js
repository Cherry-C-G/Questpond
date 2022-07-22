Adminapp.controller("EquipmentController", function ($scope, EquipmentSave, $http, $cookies, $location, $window, ShareEquipmentData, cfpLoadingBar)
{
    var favoriteCookie = $cookies.get('EventChannel');
    var config =
    {
        headers:
        {
            'RequestVerificationToken': favoriteCookie
        }
    };


    var url = $location.url();
    if (url == "/AllEquipment") {
        ShowEquipment();
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

    $scope.SaveEquipment = function (Equipment) {
        $scope.IsFormSubmitted = true;
        $scope.Message = "";
        $scope.ChechFileValid($scope.SelectedFileForUpload);
        if ($scope.IsFormValid && $scope.IsFileValid) {
            EquipmentSave.SaveEquipmentService($scope.SelectedFileForUpload, Equipment).then(function (d) {
                alert("Equipment Saved Successfully");
                $location.path('/AllEquipment');
            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }
    };

    function ShowEquipment() {

        $http.get('/api/equipmentdata', config)
       .success(function (data, status, headers, config)
       {
           $scope.start();
           $scope.EquipmentList = data;
           $scope.complete();

       })
       .error(function (data, status, header, config) {
           alert(status);
       });
    }

    $scope.deleteEquipment = function (EquipmentID)
    {
        if ($window.confirm("Do you want Delete Venue ?"))
        {
            $http.delete('/api/equipmentdata/' + EquipmentID, config)
                         .success(function (data, status, headers, config)
                         {
                             if (data == "Success") {
                                 ShowEquipment();
                             }
                         })
                        .error(function (data, status, header, config)
                        {
                            alert(status);
                        });
        }
    };

    $scope.EditEquipment = function (Equipment) {
        ShareEquipmentData.value = Equipment;
        $location.path('/EquipmentEdit');
    };

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

Adminapp.factory('EquipmentSave', function ($http, $q) {

    var fac = {};
    fac.SaveEquipmentService = function (file, Equipment) {
        var formData = new FormData();
        formData.append("file", file);
        //We can send more data to server using append         
        formData.append("EquipmentName", Equipment.EquipmentName);
        formData.append("EquipmentCost", Equipment.EquipmentCost);

        var defer = $q.defer();
        $http.post("/Equipment/SaveEquipment", formData,
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

Adminapp.factory("ShareEquipmentData", function ()
{
    return { value: 0 }
});

Adminapp.factory("EquipmentUpdateData", function ($http, $q)
{
    var fac = {};
    fac.updateEquipmentData = function (file, Equipment)
    {
        var formData = new FormData();
        if (file != null) {
            formData.append("file", file);
        }
        formData.append("EquipmentName", Equipment.EquipmentName);
        formData.append("EquipmentCost", Equipment.EquipmentCost);
        formData.append("EquipmentID", Equipment.EquipmentID);

        var defer = $q.defer();
        $http.post("/Equipment/UpdateEquipment", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (d) {
            defer.resolve(d);
        })
        .error(function () {
            defer.reject("Equipment Update failed! Please try again");
        });

        return defer.promise;

    };
    return fac;
});

Adminapp.service("EquipmentService_GetData", function ($http, $cookies)
{
    this.GetEquipment = function (EquipmentID) {
        var response =
            $http({
                method: "GET",
                url: "/api/equipmentdata/" + EquipmentID,
                headers: { 'RequestVerificationToken': $cookies.get('EventChannel') }
            });
        return response;
    }


});




Adminapp.controller("EquipmentEditController", function ($scope, EquipmentService_GetData, EquipmentUpdateData, $http, $cookies, $location, $window, ShareEquipmentData, cfpLoadingBar) {
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

    var response = EquipmentService_GetData.GetEquipment(ShareEquipmentData.value);

    response.then(function (data) {
        $scope.Equipment = {};
        var Equdata = data.data;
        $scope.Equipment.EquipmentID = Equdata.EquipmentID;
        $scope.Equipment.EquipmentName = Equdata.EquipmentName;
        $scope.Equipment.EquipmentCost = Equdata.EquipmentCost;
        $scope.Equipment.EquipmentFilePath = Equdata.EquipmentFilePath;

    }, function () {

        $location.path('/AllEquipment');
    });


    $scope.UpdateEquipment = function (Equipment)
    {
        var data = null;
        $scope.IsFormSubmitted = true;
        $scope.Message = "";
        if ($scope.SelectedFileForUpload == null) {

            var data = $scope.Equipment.EquipmentFilePath;
            $scope.IsFormValid = true;
            $scope.IsFileValid = true;
        }
        else {
            var data = $scope.SelectedFileForUpload;
            $scope.ChechFileValid($scope.SelectedFileForUpload);
        }

        if ($scope.IsFormValid && $scope.IsFileValid) {
            EquipmentUpdateData.updateEquipmentData(data, Equipment).then(function (d) {
                alert("Equipment Updated Successfully");
                $location.path('/AllEquipment');
            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }
    };


});