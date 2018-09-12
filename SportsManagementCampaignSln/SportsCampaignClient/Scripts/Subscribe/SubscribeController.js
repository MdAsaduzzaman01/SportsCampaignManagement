/// <reference path="../angular.js" />


app.controller("SubscriberCtrl", function ($scope, SubscribeService) {
    loadSubscriber();
    function loadSubscriber() {
        var GetRecord = SubscribeService.getAllSubscriber();
        GetRecord.then(function (res) {
            $scope.AllSubscriber = res.data.value;
        }, function () {
            alert("Data not retrive");
        })
    };
   
    $scope.insertData = function () {
        var Subscriber = {            
            Email: $scope.Email        
        };
        var inst = SubscribeService.insertSubscriber(Subscriber);
        inst.then(function (res) {
            alert("You have successfully subscribe. Now you will get regular update from us")
            $scope.Email = '';
           
        }, function () {
            alert("Not subscribe yet please check your email address and try again !")
        })
    }
    
})