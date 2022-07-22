Customerapp.controller("OrderDetailsController", function ($scope, $window, GetOrderDetails, ShareData, $http, $cookies, $location, $window, cfpLoadingBar) {
    loadTotalRecepit();

    function loadTotalRecepit() {

        var BookingNo = ShareData.value;
        if (BookingNo != null) {
            var response = GetOrderDetails.ShowOrder(BookingNo);
            response.then(function (data)
            {
                $scope.start();

                var data = data.data;

                if (data == "Failed")
                {
                    $location.path('/BookingDetails');
                }
                else {

                    $scope.TotalVenueList = data.TotalVenueList;
                    $scope.TotalEquipmentList = data.TotalEquipmentList;
                    $scope.TotalFoodList = data.TotalFoodList;
                    $scope.TotalFlowerList = data.TotalFlowerList;
                    $scope.TotalLightList = data.TotalLightList;
                    $scope.TotalAmount = data.TotalAmount;
                    $scope.BookingNo = data.BookingNo;
                    $scope.BookingDate = data.BookingDate
                }

                $scope.complete();
            }, function ()
            {

            });
        }
        else {
            $location.path('/BookingDetails');
        }

    }

    $scope.start = function () {
        cfpLoadingBar.start();
    };

    $scope.complete = function () {
        cfpLoadingBar.complete();
    }

    $scope.printDiv = function (divName) {

        var printContents = document.getElementById(divName).innerHTML;
        var popupWin = window.open('', '_blank', 'width=300,height=300');
        popupWin.document.open();
        loadTotalRecepit();
        popupWin.document.write('<html><head><link rel="stylesheet" type="text/css" href="style.css" /></head><body onload="window.print()">' + printContents + '</body></html>');
        popupWin.document.close();
    }
});

Customerapp.service("GetOrderDetails", function ($http, $cookies)
{
    this.ShowOrder = function (BookingNo) {
        var response =
            $http({
                method: "POST",
                url: "/OrderDetails/OrderDisplay",
                headers: { 'RequestVerificationToken': $cookies.get('EventChannel') },
                data: { 'BookingNo': BookingNo }
            });
        return response;
    };

});