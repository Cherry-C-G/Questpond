Customerapp.controller("BookFoodController", function ($scope, FoodServices, $http, $cookies, $location, $window, cfpLoadingBar) {

    var IMAGE_WIDTH = 405;
    $scope.IMAGE_LOCATION = "../UploadedFiles/";
    $scope.DishtypesList =
     [{
         id: '1',
         name: 'Deluxe'
     },
     {
         id: '2',
         name: 'Regular'
     }];
    $scope.MealShow = true;
    $scope.DishShow = true;

    $scope.SubmitShow = true;
    $scope.OnFoodClick = function () {
        $scope.MealShow = false;
        if ($scope.Food.FoodType != null || $scope.Food.FoodType != undefined && $scope.Food.LDType != null || $scope.Food.LDType != undefined && $scope.Food.Dishtypeselected != null || $scope.Food.Dishtypeselected != undefined) {

            var Food = {
                FoodType: $scope.Food.FoodType,
                DishType: $scope.Food.Dishtypeselected,
                MealType: $scope.Food.LDType
            };

            var response = FoodServices.ShowFoodList(Food);
            response.then(function (data) {
                $scope.galleryData = data.data;
            }, function () {

            });
        }
    }

    $scope.OnMealClick = function () {
        $scope.DishShow = false;

        if ($scope.Food.FoodType != null || $scope.Food.FoodType != undefined && $scope.Food.LDType != null || $scope.Food.LDType != undefined && $scope.Food.Dishtypeselected != null || $scope.Food.Dishtypeselected != undefined) {

            var Food = {
                FoodType: $scope.Food.FoodType,
                DishType: $scope.Food.Dishtypeselected,
                MealType: $scope.Food.LDType
            };

            var response = FoodServices.ShowFoodList(Food);
            response.then(function (data) {
                $scope.galleryData = data.data;
            }, function () {

            });
        }
    }


    $scope.OnChangeDish = function () {
        if ($scope.Food.FoodType == null || $scope.Food.FoodType == undefined) {
            alert("Please select Food Type !");
        }
        else if ($scope.Food.LDType == null || $scope.Food.LDType == undefined) {
            alert("Please select Meal Type !");
        }
        else if ($scope.Food.Dishtypeselected == null || $scope.Food.Dishtypeselected == undefined) {
            alert("Please select Dish Type !");
        }
        else {
            var Food = {
                FoodType: $scope.Food.FoodType,
                DishType: $scope.Food.Dishtypeselected,
                MealType: $scope.Food.LDType
            };

            var response = FoodServices.ShowFoodList(Food);
            response.then(function (data)
            {
                $scope.start();
                $scope.galleryData = data.data;
                $scope.FoodList = data.data;
                $scope.complete();
            }, function ()
            {

            });
            $scope.SubmitShow = false;
        }
    }

    $scope.SaveFood = function (Food, FoodList) {
        if ($scope.Food.FoodType == null || $scope.Food.FoodType == undefined) {
            alert("Please select Food Type !");
        }
        else if ($scope.Food.LDType == null || $scope.Food.LDType == undefined) {
            alert("Please select Meal Type !");
        }
        else if ($scope.Food.Dishtypeselected == null || $scope.Food.Dishtypeselected == undefined) {
            alert("Please select Dish Type !");
        }
        else {
            var details = [];
            angular.forEach(FoodList, function (value, key) {
                if (FoodList[key].checked) {
                    details.push(FoodList[key].FoodID);
                }
            });

            if (details.length > 0) {
                var Food = {
                    FoodType: $scope.Food.FoodType,
                    DishType: $scope.Food.Dishtypeselected,
                    MealType: $scope.Food.LDType
                };

                var response = FoodServices.BookFood(Food, FoodList);
                response.then(function (data) {
                    var result = data.data;

                    if (result == "Success") {
                        alert("Food is Booked Successfully !!!");
                        $location.path('/BookLighting');
                    }
                    else if (result == "Failed") {
                        alert("Booking Failed !!!");
                    }


                }, function () {

                });
            }
        }

    }

    $scope.Cancel = function () {
        $window.location.reload();
    }

    $scope.scrollTo = function (image, ind) {
        $scope.listposition = { left: (IMAGE_WIDTH * ind * -1) + "px" };
        $scope.selected = image;
    };

    $scope.start = function () {
        cfpLoadingBar.start();
    };

    $scope.complete = function () {
        cfpLoadingBar.complete();
    }

});

Customerapp.service("FoodServices", function ($http, $cookies) {
    this.ShowFoodList = function (Food) {
        var response =
            $http({
                method: "POST",
                url: "/BookFood/ShowFoodList",
                headers: { 'RequestVerificationToken': $cookies.get('EventChannel') },
                data: JSON.stringify(Food)
            });
        return response;
    };

    this.BookFood = function (Food, FoodList) {

        var FoodSelected = [];
        angular.forEach(FoodList, function (value, key)
        {
            if (FoodList[key].checked)
            {
                FoodSelected.push(FoodList[key].FoodID);
            }
        });


        var response =
           $http({
               method: "POST",
               url: "/BookFood/BookFood",
               headers: { 'RequestVerificationToken': $cookies.get('EventChannel') },
               data: { 'Food': Food, 'SelectedFood': FoodSelected }
           });
        return response;
    };


});
