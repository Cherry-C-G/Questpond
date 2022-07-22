Adminapp.controller("FoodController", function ($scope, ShareFoodService, FoodService_GetData, SaveFoodService, $http, $cookies, $location, $window, cfpLoadingBar) {
    var favoriteCookie = $cookies.get('EventChannel');
    var config =
    {
        headers:
        {
            'RequestVerificationToken': favoriteCookie
        }
    };

    $scope.DishtypesList =
        [{
        id: '1',
        name: 'Deluxe'
        },
        {
        id: '2',
        name: 'Regular'
        }];



var url = $location.url();
if (url == "/AllFood") {
    ShowFood();
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

$scope.SaveFoodItems = function (Food) {
        
    $scope.IsFormSubmitted = true;
    $scope.Message = "";
    $scope.ChechFileValid($scope.SelectedFileForUpload);
    if ($scope.IsFormValid && $scope.IsFileValid) {
        SaveFoodService.SaveFileandData($scope.SelectedFileForUpload, Food).then
            (function (d)
            {
                alert("Food Added Successfully");
                $location.path('/AllFood');
            }, function (e) {
                alert(e);
            });
    }
    else {
        $scope.Message = "All the fields are required.";
    }
};

function ShowFood() {

    $http.get('/api/fooddata', config)
   .success(function (data, status, headers, config)
   {
       $scope.start();
       $scope.FoodList = data;
       $scope.complete();
   })
   .error(function (data, status, header, config) {
       alert(status);
   });
}

$scope.deleteFood = function (FoodID) {
    if ($window.confirm("Do you want Delete Food Item ?")) {
        $http.delete('/api/fooddata/' + FoodID, config)
        .success(function (data, status, headers, config) {
            if (data == "Success") {
                ShowFood();
            }
        })
        .error(function (data, status, header, config) {
            alert(status);
        });
    }
};

$scope.EditFood = function (FoodID)
{
    ShareFoodService.value = FoodID;
    $location.path('/FoodEdit');
}

$scope.Cancel = function () {
    $window.location.reload();
}


$scope.start = function ()
{
    cfpLoadingBar.start();
};

$scope.complete = function ()
{
    cfpLoadingBar.complete();
}

});

Adminapp.factory('SaveFoodService', function ($http, $q) {

    var fac = {};
    fac.SaveFileandData = function (file, Food) {
        var formData = new FormData();
        formData.append("file", file);
        formData.append("FoodType", Food.FoodType);
        formData.append("FoodName", Food.FoodName);
        formData.append("FoodCost", Food.FoodCost);
        formData.append("MealType", Food.LDType);
        formData.append("DishType", Food.Dishtypeselected);
        var defer = $q.defer();
        $http.post("/Food/SaveFood", formData,
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

Adminapp.controller("FoodEditController", function ($scope,UpdateFoodService, ShareFoodService,FoodService_GetData, $http, $cookies, $location, $window) {

    $scope.DishtypesList = [
       {
           value: '1',
           label: 'Deluxe'
       }, {
           value: '2',
           label: 'Regular'
       }];

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

    var response = FoodService_GetData.getFood(ShareFoodService.value);

    response.then(function (data) {

        $scope.Food = {};
        var Fooddata = data.data;
        $scope.Food.FoodID = Fooddata.FoodID;
        $scope.Food.FoodType = Fooddata.FoodType;
        $scope.Food.LDType = Fooddata.MealType;
        $scope.Food.Dishtypeselected = Fooddata.DishType;
        $scope.Food.FoodName = Fooddata.FoodName;
        $scope.Food.FoodFilePath = Fooddata.FoodFilePath;
        $scope.Food.FoodCost = Fooddata.FoodCost;

      

    }, function () {

        $location.path('/AllFood');
    });

    $scope.UpdateFoodData = function (Food)
    {

        var data = null;
        $scope.IsFormSubmitted = true;
        $scope.Message = "";
        if ($scope.SelectedFileForUpload == null) {

            var data = $scope.Food.FlowerFilePath;
            $scope.IsFormValid = true;
            $scope.IsFileValid = true;
        }
        else {
            var data = $scope.SelectedFileForUpload;
            $scope.ChechFileValid($scope.SelectedFileForUpload);
        }

        if ($scope.IsFormValid && $scope.IsFileValid) {
            UpdateFoodService.UpdateFood(data, Food).then(function (d) {
                alert("Food Updated Successfully");
                $location.path('/AllFood');
            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }

    };

    
});

Adminapp.factory('ShareFoodService', function ()
{
    return { value: 0 }
});

Adminapp.service("FoodService_GetData", function ($http, $cookies) {
    this.getFood = function (FoodID) {
        var response =
            $http({
                method: "GET",
                url: "/api/fooddata/" + FoodID,
                headers: { 'RequestVerificationToken': $cookies.get('EventChannel') }
            });
        return response;
    }

});

Adminapp.factory('UpdateFoodService', function ($http, $q) {

    var fac = {};
    fac.UpdateFood = function (file, Food) {
        var formData = new FormData();

        if (file != null)
        {
            formData.append("file", file);
        }

        formData.append("FoodID", Food.FoodID);
        formData.append("FoodType", Food.FoodType);
        formData.append("FoodName", Food.FoodName);
        formData.append("FoodCost", Food.FoodCost);
        formData.append("MealType", Food.LDType);
        formData.append("DishType", Food.Dishtypeselected);
        var defer = $q.defer();
        $http.post("/Food/UpdateFood", formData,
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