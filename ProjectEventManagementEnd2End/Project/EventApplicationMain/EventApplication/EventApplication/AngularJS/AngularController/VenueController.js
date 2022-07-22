

Adminapp.controller("VenueController", function ($scope, VenueSaveService, ShareData, VenueService, $http, $cookies, $location, $window, cfpLoadingBar) {

    var favoriteCookie = $cookies.get('EventChannel');
    var config =
    {
        headers:
        {
            'RequestVerificationToken': favoriteCookie
        }
    };


   
    LoadVenuedata();
    



    function LoadVenuedata()
    {
        var url = $location.url();
        if (url == "/AllVenue")
        {
            
            ShowVenue();
            
        }
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

    //File Select event 
    $scope.selectFileforUpload = function (file) {
        $scope.SelectedFileForUpload = file[0];
    }

    //Save File
    $scope.SaveFile = function (Venue) {
        $scope.IsFormSubmitted = true;
        $scope.Message = "";
        $scope.ChechFileValid($scope.SelectedFileForUpload);
        if ($scope.IsFormValid && $scope.IsFileValid) {
            VenueSaveService.SaveDataVenue($scope.SelectedFileForUpload, Venue).then(function (d)
            {
                alert("Venue Added Successfully");
                $location.path('/AllVenue');
            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }
    };

    //Clear form 
    function ClearForm() {
        $scope.FileDescription = "";
        //as 2 way binding not support for File input Type so we have to clear in this way
        //you can select based on your requirement
        angular.forEach(angular.element("input[type='file']"), function (inputElem) {
            angular.element(inputElem).val(null);
        });

        $scope.form1.$setPristine();
        $scope.IsFormSubmitted = false;
    }

    function ShowVenue()
    {



        $http.get('/api/venuedata', config)
       .success(function (data, status, headers, config)
       {
           $scope.start();
           $scope.VenueList = data;
           $scope.complete();
       })
       .error(function (data, status, header, config) {
           alert(status);
       });
    }

    $scope.deleteVenue = function (VenueID) {
        if ($window.confirm("Do you want Delete Venue ?")) {
            $http.delete('/api/venuedata/' + VenueID, config)
                         .success(function (data, status, headers, config) {
                             if (data == "Success") {
                                 ShowVenue();
                             }
                         })
                        .error(function (data, status, header, config) {
                            alert(status);
                        });
        }
    };

    $scope.EditVenue = function (Venue) {
        ShareData.value = Venue;
        $location.path('/VenueEdit');
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

Adminapp.controller("VenueEditController", function ($scope, VenueEditService, ShareData, VenueService, $http, $cookies, $location, $window, cfpLoadingBar)
{
    $scope.Message = "";
    $scope.FileInvalidMessage = "";
    $scope.SelectedFileForUpload = null;
    $scope.FileDescription = "";
    $scope.IsFormSubmitted = false;
    $scope.IsFileValid = false;
    $scope.IsFormValid = false;

    LoadingVenueData();


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

    function LoadingVenueData()
    {
        var response = VenueService.getVenue(ShareData.value.VenueID);
        response.then(function (data)
        {

            $scope.start();
            $scope.Venue = {};
            var venuedata = data.data;
            $scope.Venue.VenueID = venuedata.VenueID;
            $scope.Venue.Venuename = venuedata.VenueName;
            $scope.Venue.VenueCost = venuedata.VenueCost;
            $scope.Venue.VenueFilePath = venuedata.VenueFilePath;
            $scope.complete();
        }, function () {
            $location.path('/AllVenue');
        });
    }

    $scope.UpdateVenueData = function (Venue)
    {
        var data=null;
        $scope.IsFormSubmitted = true;
        $scope.Message = "";
        if ($scope.SelectedFileForUpload == null) {
            
            var data = $scope.Venue.VenueFilePath;
            $scope.IsFormValid = true;
            $scope.IsFileValid = true;
        }
        else
        {
            var data = $scope.SelectedFileForUpload;
            $scope.ChechFileValid($scope.SelectedFileForUpload);
        }

        if ($scope.IsFormValid && $scope.IsFileValid)
        {
            VenueEditService.updateVenue(data, Venue).then(function (d) {
                alert("Venue Updated Successfully");
                $location.path('/AllVenue');
            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }
    };

    $scope.start = function () {
        cfpLoadingBar.start();
    };

    $scope.complete = function () {
        cfpLoadingBar.complete();
    }

});

Adminapp.factory('VenueSaveService', function ($http, $q) {

    var fac = {};
    fac.SaveDataVenue = function (file, Venue)
    {
        var formData = new FormData();
        formData.append("file", file);   
        formData.append("VenueName", Venue.VenueName);
        formData.append("VenueCost", Venue.VenueCost);

        var defer = $q.defer();
        $http.post("/Venue/SaveVenue", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (d)
        {
            defer.resolve(d);
        })
        .error(function ()
        {
            defer.reject("Venue Save failed! Please try again");
        });

        return defer.promise;

    }
    return fac;
});

Adminapp.factory('VenueEditService', function ($http, $q)
{
    var fac = {};
    fac.updateVenue = function (file, Venue) {
        var formData = new FormData();
        if (file != null)
        {
            formData.append("file", file);
        }

        formData.append("VenueName", Venue.Venuename);
        formData.append("VenueCost", Venue.VenueCost);
        formData.append("VenueID", Venue.VenueID);
        
        var defer = $q.defer();
        $http.post("/Venue/UpdateVenue", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (d)
        {
            defer.resolve(d);
        })
        .error(function ()
        {
            defer.reject("Venue Update failed! Please try again");
        });

        return defer.promise;
    }
    return fac;

});

Adminapp.service("VenueService", function ($http, $cookies)
{
   

    this.getVenue = function (VenueID)
    {
        var response =
            $http({
                method: "GET",
                url: "/api/venuedata/" + VenueID,
                headers: {'RequestVerificationToken': $cookies.get('EventChannel')}
            });
        return response;
    }

});

Adminapp.factory("ShareData", function () {
    return { value: 0 }
});