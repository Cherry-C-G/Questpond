Customerapp.controller("BookEquipmentController", function ($scope, getEquipment, $http, $cookies, $location, $window, cfpLoadingBar) {

    BindEquipmentList();
    BinDImages();
    var IMAGE_WIDTH = 405;
    function BindEquipmentList()
    {
        var response = getEquipment.getEquipmentList();
        response.then(function (data)
        {
            $scope.EquipmentList = data.data;

        }, function ()
        {

        });
    }
        
    $scope.SaveEquipment = function (Equipment)
    {
        if ($window.confirm("Are you Sure You Want to Book Equipment ?")) {

            var details = [];
            angular.forEach(Equipment, function (value, key) {
                if (Equipment[key].checked) {
                    details.push(Equipment[key].EquipmentID);
                }
            });

            if (details.length > 0) {
                var response = getEquipment.SaveSelectedEquipment(Equipment);

                response.then(function (data)
                {
                    var result = data.data;

                    if (result == "Success") {
                        alert("Equipment is Booked Successfully !!!");
                        $location.path('/BookFood');
                    }
                    else if (result == "Failed") {
                        alert("Booking Failed !!!");
                    }


                }, function () {

                });
            }
            else {
                alert("Please choose an Equipments");
            }
        }
    };

    $scope.Cancel = function () {
        $window.location.reload();
    }


    function BinDImages()
    {
        $scope.IMAGE_LOCATION = "../UploadedFiles/";
        var response = getEquipment.getEquipmentList();
        response.then(function (data)
        {
            $scope.start();       
            $scope.galleryData = data.data;
            $scope.complete();
        }, function ()
        {

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

Customerapp.service("getEquipment", function ($http, $cookies)
{
    this.getEquipmentList = function ()
    {
        var response =
            $http({
                method: "GET",
                url: "/api/equipmentdata",
                headers: { 'RequestVerificationToken': $cookies.get('EventChannel') }
            });
        return response;
    }

    this.SaveSelectedEquipment = function (choice)
    {

        var details = [];
        angular.forEach(choice, function (value, key) {
            if (choice[key].checked) {
                details.push(choice[key].EquipmentID);
            }
        });
       

        var response =
                   $http({
                       method: "POST",
                       url: "/BookEquipment/BookEquipment",
                       headers: { 'RequestVerificationToken': $cookies.get('EventChannel') },
                       data: { 'SelectedEquipmentsID': details }
                   });
        return response;

    }

});


