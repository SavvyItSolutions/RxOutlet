var app = angular.module('myApp', ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider

    .when('/', {
        templateUrl: '/FillNewPrescription.html',
        controller: 'FillNewPrescriptionController',
        activetab: 'FillNewPrescription'
    })

    .when('/RefillPrescription', {
        templateUrl: '/RefillPrescription.html',
        controller: 'RefillPrescriptionController',
        activetab: 'RefillPrescription'
    })

    .when('/TransferPrescription', {
        templateUrl: '/TransferPrescription.html',
        controller: 'TransferPrescriptionController',
        activetab: 'TransferPrescription'
    })

    .otherwise({ redirectTo: '/' });
});

app.controller('myCtrl', function ($scope) {
        $scope.myObj = {
            "color": "white",
            "background-color": "coral",
            "font-size": "20px",
            "padding": "10px",

        }
    });



app.controller('FillNewPrescriptionController', function ($scope) {
    $scope.message = "FillNewPrescription";
    $scope.image = "Images/img1.jpg";
});

app.controller('RefillPrescriptionController', function ($scope) {
    $scope.message = "RefillPrescription";
    //$scope.image = "https://www.google.com/images/srpr/logo11w.png";
    $scope.image = "Images/slide1.jpg";
});

app.controller('TransferPrescriptionController', function ($scope) {
    $scope.message = "TransferPrescription";
    $scope.image = "Images/slide2.jpg";
});



app.controller('HeaderController', function ($scope, $location) {
    $scope.isActive = function (viewLocation) {
        return viewLocation === $location.path();
    };
});












