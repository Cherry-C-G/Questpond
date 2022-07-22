
Customerapp.config(function ($routeProvider) {

    $routeProvider.when('/',
    {
        templateUrl: '/Templates/CustomerDashboard.html',
        controller: ''
    })
    .when("/BookVenue",
    {
        templateUrl: '/Templates/BookVenue.html',
        controller: 'BookVenueController'
    })
    .when("/BookEquipment",
    {
        templateUrl: '/Templates/BookEquipment.html',
        controller: 'BookEquipmentController'
    })
     .when("/BookFood",
    {
        templateUrl: '/Templates/BookFood.html',
        controller: 'BookFoodController'
    })
    .when("/BookLighting",
    {
        templateUrl: '/Templates/BookLighting.html',
        controller: 'BookLightController'
    })
    .when("/BookFlower",
    {
        templateUrl: '/Templates/BookFlower.html',
        controller: 'BookFlowerController'
    })
    .when("/TotalReceipt",
    {
        templateUrl: '/Templates/TotalReceipt.html',
        controller: 'TotalReceiptController'
    })
    .when("/BookingDetails",
    {
        templateUrl: '/Templates/BookingDetails.html',
        controller: 'BookingDetailsController'
    })
     .when("/OrderDetails",
    {
        templateUrl: '/Templates/OrderDetails.html',
        controller: 'OrderDetailsController'
    })
    .otherwise({
        redirectTo: '/Login/Login'
    });
});

