Customerapp.controller("BookLightController", function ($scope, LightServices, $http, $cookies, $location, $window, cfpLoadingBar)
{
    var IMAGE_WIDTH = 405;
    $scope.IMAGE_LOCATION = "../UploadedFiles/";

    $scope.ShowLightService = function (LightType)
    {
        var response = LightServices.ShowLightList(LightType);
        response.then(function (data)
        {
            $scope.start();        
            $scope.LightingList = data.data;
            $scope.complete();
        }, function ()
        {

        });
    }

    $scope.scrollTo = function (image, ind) {
        $scope.listposition = { left: (IMAGE_WIDTH * ind * -1) + "px" };
        $scope.selected = image;
    };

    $scope.SaveLight = function (Light, LightingList) {
        if (Light.LightType == null || Light.LightType == undefined)
        {
            alert("Please select Food Type !");
        }
        else {
            var details = [];
            angular.forEach(LightingList, function (value, key)
            {
                if (LightingList[key].checked)
                {
                    details.push(LightingList[key].LightID);
                }
            });

            if (details.length > 0) {

               

                var response = LightServices.BookLight(Light.LightType, LightingList);
                response.then(function (data)
                {
                    var result = data.data;

                    if (result == "Success") {
                        alert("Light is Booked Successfully !!!");
                        $location.path('/BookFlower');
                    }
                    else if (result == "Failed") {
                        alert("Booking Failed !!!");
                    }


                }, function () {

                });
            }
            else {
                alert("Please choose a Light Type");
            }
        }

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

Customerapp.service("LightServices", function ($http, $cookies)
{
    this.ShowLightList = function (LightType) {
        var response =
            $http({
                method: "POST",
                url: "/BookLight/ShowFoodList",
                headers: { 'RequestVerificationToken': $cookies.get('EventChannel') },
                data: { 'LightType': LightType }
            });
        return response;
    };

    this.BookLight = function (BookingLight, LightingList) {

        var LightSelected = [];
        angular.forEach(LightingList, function (value, key) {
            if (LightingList[key].checked)
            {
                LightSelected.push(LightingList[key].LightID);
            }
        });

        var response =
           $http({
               method: "POST",
               url: "/BookLight/BookLight",
               headers: { 'RequestVerificationToken': $cookies.get('EventChannel') },
               data: { 'LightType': BookingLight, 'SelectedLight': LightSelected }
           });
        return response;
    };
});