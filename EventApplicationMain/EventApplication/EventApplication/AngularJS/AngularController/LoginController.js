app.controller("LoginController", function ($scope, $http, $window, $cookies) {

    $scope.cuttext = false;
    $scope.copytext = false;
    $scope.pasttext = false;
    $scope.submitForm = function (Login)
    {
        var hash = calcMD5(Login.password).toUpperCase();
        $scope.Login.password = hash.toUpperCase();
    };

});