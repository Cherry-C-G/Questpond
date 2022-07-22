Customerapp.controller("BookVenueController", function ($scope, getEventService, $http, $cookies, $location, $window, cfpLoadingBar) {

    var IMAGE_WIDTH = 405;

    BindEventTypeDropdown();
    BingVenueList();
    BinDImages();


    $scope.hideSubmit = true;
    $scope.hideBooking = false;
    $scope.ChkBookingDate = false;
    $scope.BookingDateValid = false;
    function BindEventTypeDropdown() {
        var response = getEventService.getEventList();
        response.then(function (data) {
            $scope.EventList = data.data;
        }, function () {

        });

    }

    function BingVenueList() {
        var response = getEventService.getVenueList();
        response.then(function (data) {
            $scope.VenueList = data.data;
        }, function () {

        });
    }

    $scope.CheckBooking = function (Book, form1) {
        if (form1.$valid) {

            if ($scope.BookingDate == null || $scope.BookingDate == undefined) {
                alert("Please select Date of BookingDate !");
            }
            else {

                if ($scope.BookingDate == "" || $scope.BookingDate == undefined) {
                    alert("Please select Date of BookingDate");

                }
                else {
                    var response = getEventService.checkbookingavailability(Book);
                    response.then(function (data) {
                        var result = data.data;

                        if (result == "Available") {
                            $scope.hideSubmit = false;
                            $scope.hideBooking = true;
                            alert("Booking is Available You Can Book your Event !!!");
                        }
                        else {
                            $scope.hideSubmit = true;
                            $scope.hideBooking = false;
                            alert("Booking is Not Available on '" + BookingDate.value + "'  Selected Date !!!");
                        }

                    }, function () {

                    });
                }
            }
        }
        else {
            alert("All Fields Are Mandatory !");
        }
    }

    $scope.selectDate = function (dt) {
        $scope.BookingDate = dt;
    }

    $scope.BookingEvent = function (Book, form1) {
        if ($window.confirm("Are you Sure You Want to Book Event ?")) {
            if ($scope.BookingDate == null || $scope.BookingDate == undefined) {
                alert("Please select Date of birth !");
            }
            else {

                var response = getEventService.bookEvent(Book);
                response.then(function (data) {
                    var result = data.data;

                    if (result != "" && result != undefined)
                    {
                        alert("Your Booking ID :- '" + result + "' and Booking Date :- '" + BookingDate.value + "' Has been done Successfully !!!");
                        $location.path('/BookEquipment');
                    }
                    else if (result == "Failed") {
                        $scope.hideSubmit = true;
                        $scope.hideBooking = false;
                        alert("Booking Failed !!!");
                    }

                }, function () {

                });

            }
        }

    };

    function BinDImages() {

        $scope.IMAGE_LOCATION = "../UploadedFiles/";
        var response = getEventService.getVenueList();
        response.then(function (data) {
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

Customerapp.service("getEventService", function ($http, $cookies) {
    this.getEventList = function () {
        var response =
            $http({
                method: "GET",
                url: "/api/eventdata",
                headers: { 'RequestVerificationToken': $cookies.get('EventChannel') }
            });
        return response;
    }

    this.getVenueList = function () {
        var response =
            $http({
                method: "GET",
                url: "/api/venuedata",
                headers: { 'RequestVerificationToken': $cookies.get('EventChannel') }
            });
        return response;
    }



    this.checkbookingavailability = function (Book) {
        var data = {
            EventTypeID: Book.EventSelected,
            VenueID: Book.Venueselected,
            GuestCount: Book.NoofGuest,
            BookingDate: BookingDate.value
        };

        var response =
           $http({
               method: "POST",
               url: "/Booking/CheckBooking/",
               headers: {
                   'RequestVerificationToken': $cookies.get('EventChannel')
               },
               data: data

           });
        return response;

    }

    this.bookEvent = function (Book) {
        var data = {
            EventTypeID: Book.EventSelected,
            VenueID: Book.Venueselected,
            GuestCount: Book.NoofGuest,
            BookingDate: BookingDate.value
        };

        var response =
           $http({
               method: "POST",
               url: "/Booking/BookEvent/",
               headers: {
                   'RequestVerificationToken': $cookies.get('EventChannel')
               },
               data: data

           });
        return response;
    }



});