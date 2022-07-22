Customerapp.controller("BookFlowerController", function ($scope, getFlower, $http, $cookies, $location, $window, cfpLoadingBar) {

    BindFlowerList();
    BinDImages();
    var IMAGE_WIDTH = 405;
    function BindFlowerList()
    {
        var response = getFlower.getFlowerList();
        response.then(function (data)
        {
            $scope.FlowerList = data.data;
        }, function ()
        {

        });
    }

    $scope.Cancel = function () {
        $window.location.reload();
    }
        
    $scope.SaveFlower = function (Flower)
    {
        if ($window.confirm("Are you Sure You Want to Book Flower ?")) {

            var details = [];
            angular.forEach(Flower, function (value, key) {
                if (Flower[key].checked) {
                    details.push(Flower[key].FlowerID);
                }
            });

            if (details.length > 0) {
                var response = getFlower.SaveSelectedFlower(Flower);

                response.then(function (data)
                {
                    var result = data.data;

                    if (result == "Success") {
                        alert("Flower is Booked Successfully !!!");
                        $location.path('/BookingDetails');
                    }
                    else if (result == "Failed") {
                        alert("Booking Failed !!!");
                    }


                }, function () {

                });
            }
            else {
                alert("Please choose an Flowers");
            }
        }
    };

    function BinDImages()
    {
       
        $scope.IMAGE_LOCATION = "../UploadedFiles/";
        var response = getFlower.getFlowerList();

        response.then(function (data)
        {
            $scope.start();          
            $scope.galleryData = data.data;
            $scope.complete();
        }, function () {

        });

       
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

Customerapp.service("getFlower", function ($http, $cookies)
{
    this.getFlowerList = function ()
    {
        var response =
            $http({
                method: "GET",
                url: "/api/flowerdata",
                headers: { 'RequestVerificationToken': $cookies.get('EventChannel') }
            });
        return response;
    }

    this.SaveSelectedFlower = function (choice)
    {

        var details = [];
        angular.forEach(choice, function (value, key) {
            if (choice[key].checked) {
                details.push(choice[key].FlowerID);
            }
        });
       

        var response =
                   $http({
                       method: "POST",
                       url: "/BookFlower/BookFlower",
                       headers: { 'RequestVerificationToken': $cookies.get('EventChannel') },
                       data: { 'SelectedFlowerID': details }
                   });
        return response;

    }

});


