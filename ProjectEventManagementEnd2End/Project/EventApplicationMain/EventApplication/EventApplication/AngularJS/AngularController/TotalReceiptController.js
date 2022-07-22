Customerapp.controller("TotalReceiptController", function ($scope, TotalReceipt, ShareData, $http, $cookies, $location, $window, cfpLoadingBar) {

    loadTotalRecepit();

    function loadTotalRecepit() {

        var BookingNo = ShareData.value;
        if (BookingNo != null)
        {
            
            var response = TotalReceipt.ShowTotalReceiptList(BookingNo);
          
            response.then(function (data)
            {
                var data = data.data;

                if (data.data != "Failed") {
                    $scope.TotalVenueCost = data.TotalVenueCost;
                    $scope.TotalEquipmentCost = data.TotalEquipmentCost;
                    $scope.TotalFoodCost = data.TotalFoodCost;
                    $scope.TotalFlowerCost = data.TotalFlowerCost;
                    $scope.TotalLightCost = data.TotalLightCost;
                    $scope.TotalAmount = data.TotalAmount;
                    $scope.BookingNo = data.BookingNo;
                    $scope.BookingDate = data.BookingDate

                } else {
                    $location.path('/BookingDetails');
                }
            }, function ()
            {

            });
        }
        else
        {
            $location.path('/BookingDetails');
        }

    }

    $scope.printDiv = function (divName)
    {
        
        var printContents = document.getElementById(divName).innerHTML;
        var popupWin = window.open('', '_blank', 'width=300,height=300');
        popupWin.document.open();
        loadTotalRecepit();
        popupWin.document.write('<html><head><link rel="stylesheet" type="text/css" href="style.css" /></head><body onload="window.print()">' + printContents + '</body></html>');
        popupWin.document.close();
    }

    $scope.start = function () {
        cfpLoadingBar.start();
    };

    $scope.complete = function () {
        cfpLoadingBar.complete();
    }
});


Customerapp.service("TotalReceipt", function ($http, $cookies) {
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