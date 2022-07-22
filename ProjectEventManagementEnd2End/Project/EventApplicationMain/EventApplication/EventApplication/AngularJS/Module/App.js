
var app = angular.module("AppModule", ['igCharLimit', 'ngCookies', 'angular-loading-bar', 'ngAnimate']);
var Adminapp = angular.module("VenueModule", ['ngRoute', 'trNgGrid', 'ngCookies', 'angular-loading-bar', 'ngAnimate']);
var Customerapp = angular.module("CustomerModule", ['ngRoute', 'AngularPrint', 'trNgGrid', 'ngCookies', 'VenueModule', 'AppModule' , 'angular-loading-bar', 'ngAnimate']);



