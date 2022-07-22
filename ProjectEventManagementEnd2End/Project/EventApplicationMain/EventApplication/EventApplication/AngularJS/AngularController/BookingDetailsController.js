Customerapp.controller("BookingDetailsController", function ($scope, ShareData, BookingDetailsServices, $http, $cookies, $location, $window, cfpLoadingBar) {

    $scope.init = function () {
        $scope.StatusHide = true;
    };

    loadGrid();

    function loadGrid()
    {
        var response = BookingDetailsServices.BookingDetailsList();
        response.then(function (data)
        {
            $scope.start();
            $scope.myItems = data.data;
            $scope.complete();
        }, function ()
        {

        });

    }

    $scope.Cancel = function ()
    {
        $scope.StatusHide = true;
    };

    $scope.printDiv = function (divName) {

        var printContents = document.getElementById(divName).innerHTML;
        var popupWin = window.open('', '_blank', 'width=300,height=300');
        popupWin.document.open();
        loadTotalRecepit();
        popupWin.document.write('<html><head><link rel="stylesheet" type="text/css" href="style.css" /></head><body onload="window.print()">' + printContents + '</body></html>');
        popupWin.document.close();
    }

    $scope.alertOnSelectionChange = function (BookingNo)
    {
        if (BookingNo != null) {
            ShareData.value = BookingNo;
            $location.path('/TotalReceipt');
        }
        else
        {
            $location.path('/BookingDetails');
        }
    }

    $scope.DisplayOrderDetails = function (BookingNo)
    {
        if (BookingNo != null) {
            ShareData.value = BookingNo;
            $location.path('/OrderDetails');
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

});

Customerapp.service("BookingDetailsServices", function ($http, $cookies) {
        this.BookingDetailsList = function () {
            var response =
                $http({
                    method: "GET",
                    url: "/Booking/ShowBookingDetails",
                    headers: { 'RequestVerificationToken': $cookies.get('EventChannel') }
                });
            return response;
        };

        this.ShowTotalReceiptList = function (BookingNo) {
            var response =
                $http({
                    method: "POST",
                    url: "/TotalReceipt/TotalReceipt",
                    headers: { 'RequestVerificationToken': $cookies.get('EventChannel') },
                    data: { 'BookingNo': BookingNo }
                });
            return response;
        };

});

Customerapp.factory("ShareData", function () {
    return { value: 0 }
});
