
Adminapp.config(function ($routeProvider) {

    $routeProvider.when('/',
    {
        templateUrl: '/Templates/Dashboard.html',
        controller: ''
    })
    .when('/Venue',
    {
        templateUrl: '/Templates/Venue.html',
        controller: 'VenueController'
    })
    .when('/AllVenue',
    {
        templateUrl: '/Templates/VenueShowall.html',
        controller: 'VenueController'
    })
     .when('/VenueEdit',
    {
        templateUrl: '/Templates/VenueEdit.html',
        controller: 'VenueEditController'
    })
    .when("/Equipment",
    {
        templateUrl: '/Templates/Equipment.html',
        controller: 'EquipmentController'
    })
    .when("/EquipmentEdit",
    {
        templateUrl: '/Templates/EquipmentEdit.html',
        controller: 'EquipmentEditController'
    })
    .when("/AllEquipment",
    {
        templateUrl: '/Templates/EquipmentShowall.html',
        controller: 'EquipmentController'
    })
    .when("/Food",
    {
        templateUrl: '/Templates/Food.html',
        controller: 'FoodController'
    })
    .when("/FoodEdit",
    {
        templateUrl: '/Templates/FoodEdit.html',
        controller: 'FoodEditController'
    })
    .when("/AllFood",
    {
        templateUrl: '/Templates/FoodShowall.html',
        controller: 'FoodController'
    })
   .when("/Lighting",
    {
        templateUrl: '/Templates/Lighting.html',
        controller: 'LightController'
    })
    .when("/LightEdit",
    {
        templateUrl: '/Templates/LightingEdit.html',
        controller: 'LightEditController'
    })
    .when("/AllLighting",
    {
        templateUrl: '/Templates/LightingShowall.html',
        controller: 'LightController'
    })
    .when("/Flower",
    {
        templateUrl: '/Templates/Flower.html',
        controller: 'FlowerController'
    })
    .when("/AllFlower",
    {
        templateUrl: '/Templates/FlowerShowall.html',
        controller: 'FlowerController'
    })
    .when('/FlowerEdit',
    {
        templateUrl: '/Templates/FlowerEdit.html',
        controller: 'FlowerEditController'
    })
    .when("/BookingApproval",
    {
        templateUrl: '/Templates/BookingApproval.html',
        controller: 'BookingApprovalController'
    })
    .when("/BookingSearch",
    {
        templateUrl: '/Templates/BookingSearch.html',
        controller: 'BookingApprovalController'
    })
    .when("/CustomerOrderDetails",
    {
        templateUrl: '/Templates/CustomerOrderDetails.html',
        controller: 'CustomerOrderDetailsController'
    })
    .otherwise({
        redirectTo: '/Login/Login'
    });
});

