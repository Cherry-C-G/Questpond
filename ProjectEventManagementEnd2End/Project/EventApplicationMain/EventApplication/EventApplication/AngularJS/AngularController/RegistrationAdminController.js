app.controller("RegistrationController", function ($scope, $http, $window, $cookies) {

    var favoriteCookie = $cookies.get('EventChannel');
    var config =
    {
        headers:
        {
            'RequestVerificationToken': favoriteCookie
        }
    };

    $http.get('/api/country', config)
    .success(function (data, status, headers, config) {
        $scope.CountryList = data;
    })
    .error(function (data, status, header, config) {
        alert(status);
    });

    $scope.onCountryChange = function (ID) {


        $http.get('/api/state/' + ID, config)
            .success(function (data, status, headers, config) {
                $scope.StateList = data;
            })
    .error(function (data, status, header, config) {
        alert(status);
    });

    };

    $scope.onstateChange = function (ID) {

        $http.get('/api/city/' + ID, config)
        .success(function (data, status, headers, config) {
            $scope.CityList = data;
        })
       .error(function (data, status, header, config) {
           alert(status);
       });
    };

    $scope.selectDate = function (dt) {
        $scope.Dateofbirth = dt;
    }

    function UsernameCheck(Registration) {
        
        if (Registration.Username != null)
        {
            $http({
                url: '/api/checkadminusername/',
                method: "POST",
                data: $scope.Registration,
                headers: { 'RequestVerificationToken': $cookies.get('EventChannel') }
            })
            .then(function (response) {
                if (response.data == true) {

                    return true;
                }
                else {

                    return false;
                }
            },
            function (response) { // optional

            });
        }
    }


    $scope.onUsername = function sendData(Registration) {
        
        if (Registration.Username != null) {
            $http({
                url: '/api/checkadminusername/',
                method: "POST",
                data: $scope.Registration

            })
            .then(function (response) {
                if (response.data == true) {
                    $scope.Registration.Username = "";
                    alert("User name Already Exists");
                }
                else {
                }
            },
            function (response) { // optional
                // failed
            });
        }
    }


    $scope.RegisterAdmin = function (Registration, form1) {

        if ($window.confirm("Do you want Submit Form ?")) {
            if (form1.$valid) {

                if ($scope.Dateofbirth == null || $scope.Dateofbirth == undefined) {
                    alert("Please select Date of birth !");
                }
                else if (UsernameCheck(Registration) == true) {
                    $scope.Registration.Username = "";
                    alert("User name Already Exists");
                }
                else {

                    var date = $scope.Dateofbirth.split('/');
                    $scope.d = (date[0]);
                    $scope.m = (date[1]);
                    $scope.y = (date[2]);

                    var value = $scope.y + '-' + $scope.m + '-' + $scope.d;

                    var data = {
                        ID: 0,
                        Name: Registration.FullName,
                        Address: Registration.Address,
                        City: Registration.CityID,
                        State: Registration.StateID,
                        Country: Registration.CountryID,
                        Mobileno: Registration.mobileno,
                        EmailID: Registration.EmailID,
                        Username: Registration.Username,
                        Password: OnPasswordChange(Registration.password),
                        ConfirmPassword: OnPasswordChange(Registration.confirmPassword),
                        Gender: Registration.rbtGender,
                        Birthdate: value
                    };

                    $http.post('/CreateAdminUser/RegisterAdmin', data, config)
                      .success(function (data, status, headers, config) {
                          if (data == "Success")
                          {
                              alert('User Registered Successfully');
                              $window.location.href = "/login/login";
                          }
                      })
                     .error(function (data, status, header, config) {
                         alert(status);
                     });



                }
            }
            else {
                alert("Please Fill all Details Properly");
            }
        }

    };

    function OnPasswordChange(password) {
        if (password != null) {
            var password = password;
            if (password != "") {
                var hash = calcMD5(password).toUpperCase();
                return hash.toUpperCase();
            }
        }
    }

    function OnconfirmPasswordChange(confirmPassword) {
        if (confirmPassword != null) {
            var password = confirmPassword;
            if (password != "") {
                var hash = calcMD5(password).toUpperCase();
                return hash.toUpperCase();
            }
        }
    }


});