Adminapp.controller("BookingApprovalController", function ($scope, ShareData, BookingDetailsServices, $http, $cookies, $location, $window, cfpLoadingBar) {


    $scope.init = function () {
        $scope.StatusHide = true;
    };

    loadGrid();

    function loadGrid() {
        var response = BookingDetailsServices.BookingDetailsList();
        response.then(function (data)
        {
            $scope.start();
            $scope.myItems = data.data;
            $scope.complete();
        }, function () {

        });

    }


    $scope.mySelectedItems = [];
    $scope.alertOnSelectionChange = function (id, BookingApproval) {
        $scope.$watch("mySelectedItems.BookingID", function () {
            if (id != null) {
                $scope.Status = {};
                $scope.StatusHide = false;
                $scope.BookingID = id;
                if (BookingApproval != null || BookingApproval != undefined) {
                    if (BookingApproval == "Approved") {
                        $scope.Status.LDType = "A";
                    }
                    else if (BookingApproval == "Pending") {
                        $scope.Status.LDType = "P";
                    }
                    else if (BookingApproval == "Cancelled") {
                        $scope.Status.LDType = "C";
                    }
                }
            }
        });
    };

    $scope.UpdateStatus = function (status) {
        var response = BookingDetailsServices.UpdateStatusService(status.LDType, $scope.BookingID)


        response.then(function (data) {
            var result = data.data;

            if (result == "Success") {
                $scope.StatusHide = true;
                alert("Status Updated Successfully !!!");
                $window.location.reload();
            }
            else if (result == "Failed") {
                alert("Booking Failed !!!");
            }

        });

    }

    $scope.Cancel = function () {
        $scope.StatusHide = true;
    };

    $scope.DisplayOrderDetails = function (BookingNo) {
        if (BookingNo != null) {
            ShareData.value = BookingNo;
            $location.path('/CustomerOrderDetails');
        }
        else {
            $location.path('/BookingApproval');
        }
    }

    $scope.start = function () {
        cfpLoadingBar.start();
    };

    $scope.complete = function () {
        cfpLoadingBar.complete();
    }
});

Adminapp.service("BookingDetailsServices", function ($http, $cookies) {
    this.BookingDetailsList = function () {
        var response =
            $http({
                method: "GET",
                url: "/Booking/ShowBookingDetailsAdmin",
                headers: { 'RequestVerificationToken': $cookies.get('EventChannel') }
            });
        return response;
    };

    this.UpdateStatusService = function (Status, BookingID) {
        var response =
         $http({
             method: "POST",
             url: "/Booking/UpdateBookingStatus",
             headers: { 'RequestVerificationToken': $cookies.get('EventChannel') },
             data: { 'BookingID': BookingID, 'BookingStatus': Status }
         });
        return response;
    }



});


Adminapp.factory("ShareData", function () {
    return { value: 0 }
});
