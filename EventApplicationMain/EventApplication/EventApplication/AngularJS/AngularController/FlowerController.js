Adminapp.controller("FlowerController", function ($scope, FlowerSaveService, ShareDataFlower, FlowerService_GetData, $http, $cookies, $location, $window, cfpLoadingBar) {

    var favoriteCookie = $cookies.get('EventChannel');
    var config =
    {
        headers:
        {
            'RequestVerificationToken': favoriteCookie
        }
    };

    var url = $location.url();
    if (url == "/AllFlower") {
        ShowFlower();
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

    //File Select event 
    $scope.selectFileforUpload = function (file) {
        $scope.SelectedFileForUpload = file[0];
    }

    //Save File
    $scope.SaveFile = function (Flower)
    {
        $scope.IsFormSubmitted = true;
        $scope.Message = "";
        $scope.ChechFileValid($scope.SelectedFileForUpload);
        if ($scope.IsFormValid && $scope.IsFileValid)
        {
            FlowerSaveService.SaveDataFlower($scope.SelectedFileForUpload, Flower).then(function (d)
            {
                alert("Flower Saved Successfully");
                $location.path('/AllFlower');
            }, function (e)
            {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }
    };

    //Clear form 
    function ClearForm() {
        $scope.FileDescription = "";
        //as 2 way binding not support for File input Type so we have to clear in this way
        //you can select based on your requirement
        angular.forEach(angular.element("input[type='file']"), function (inputElem) {
            angular.element(inputElem).val(null);
        });

        $scope.form1.$setPristine();
        $scope.IsFormSubmitted = false;
    }

    function ShowFlower()
    {

        $http.get('/api/flowerdata', config)
       .success(function (data, status, headers, config)
       {
           $scope.start();
           $scope.FlowerList = data;
           $scope.complete();
       })
       .error(function (data, status, header, config)
       {
           alert(status);
       });
    }

    $scope.deleteFlower = function (FlowerID)
    {
        if ($window.confirm("Do you want Delete Flower ?"))
        {
            $http.delete('/api/flowerdata/' + FlowerID, config)
             .success(function (data, status, headers, config)
             {
                 if (data == "Success")
                 {
                     ShowFlower();
                 }
             })
            .error(function (data, status, header, config)
            {
              alert(status);
            });
        }
    };

    $scope.EditFlower = function (Flower) {
        ShareDataFlower.value = Flower;
        $location.path('/FlowerEdit');
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

Adminapp.factory('FlowerSaveService', function ($http, $q) {

    var facdata = {};
    facdata.SaveDataFlower = function (file, Flower) {
        var formData = new FormData();
        formData.append("file", file);
        formData.append("FlowerName", Flower.FlowerName);
        formData.append("FlowerCost", Flower.FlowerCost);

        var defer = $q.defer();
        $http.post("/Flower/SaveFlower", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (d) {
            defer.resolve(d);
        })
        .error(function () {
            defer.reject("Flower Save failed! Please try again");
        });

        return defer.promise;

    }
    return facdata;


});

Adminapp.service("FlowerService_GetData", function ($http, $cookies)
{
    this.getFlower = function (FlowerID) {
        var response =
            $http({
                method: "GET",
                url: "/api/flowerdata/" + FlowerID,
                headers: { 'RequestVerificationToken': $cookies.get('EventChannel') }
            });
        return response;
    }

});

Adminapp.factory("ShareDataFlower", function () {
    return { value: 0 }
});

Adminapp.factory('FlowerUpdateService', function ($http, $q)
{
    debugger;

    var fac = {};
    fac.updateFlower = function (file, Flower) {
        var formData = new FormData();
        if (file != null)
        {
            formData.append("file", file);
        }

        formData.append("FlowerName", Flower.FlowerName);
        formData.append("FlowerCost", Flower.FlowerCost);
        formData.append("FlowerID", Flower.FlowerID);

        var defer = $q.defer();
        $http.post("/Flower/UpdateFlower", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (d) {
            defer.resolve(d);
        })
        .error(function () {
            defer.reject("Flower Update failed! Please try again");
        });

        return defer.promise;
    }
    return fac;

});

Adminapp.controller("FlowerEditController", function ($scope, FlowerUpdateService, ShareDataFlower, FlowerService_GetData, $http, $cookies, $location, $window) {
    $scope.Message = "";
    $scope.FileInvalidMessage = "";
    $scope.SelectedFileForUpload = null;
    $scope.FileDescription = "";
    $scope.IsFormSubmitted = false;
    $scope.IsFileValid = false;
    $scope.IsFormValid = false;

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

    var response = FlowerService_GetData.getFlower(ShareDataFlower.value.FlowerID);

    response.then(function (data) {
        $scope.Flower = {};
        var flowerdata = data.data;
        $scope.Flower.FlowerID = flowerdata.FlowerID;
        $scope.Flower.FlowerName = flowerdata.FlowerName;
        $scope.Flower.FlowerCost = flowerdata.FlowerCost;
        $scope.Flower.FlowerFilePath = flowerdata.FlowerFilePath;

    }, function () {

        $location.path('/AllFlower');
    });

    $scope.UpdateFlowerData = function (Flower) {
        var data = null;
        $scope.IsFormSubmitted = true;
        $scope.Message = "";
        if ($scope.SelectedFileForUpload == null)
        {

            var data = $scope.Flower.FlowerFilePath;
            $scope.IsFormValid = true;
            $scope.IsFileValid = true;
        }
        else {
            var data = $scope.SelectedFileForUpload;
            $scope.ChechFileValid($scope.SelectedFileForUpload);
        }

        if ($scope.IsFormValid && $scope.IsFileValid) {
            FlowerUpdateService.updateFlower(data, Flower).then(function (d)
            {
                alert("Flower Updated Successfully");
                $location.path('/AllFlower');
            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }
    };


});