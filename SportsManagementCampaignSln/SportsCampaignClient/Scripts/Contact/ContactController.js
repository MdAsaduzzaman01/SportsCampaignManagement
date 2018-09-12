/// <reference path="../angular.js" />


app.controller("ContactCtrl", function ($scope, ContactService) {
    loadContact();
    function loadContact() {
        var GetRecord = ContactService.getAllContact();
        GetRecord.then(function (res) {
            $scope.AllContact = res.data.value;
        }, function () {
            alert("Data not retrive");
        })
    };

    $scope.insertData = function () {
        var Contact = {
            Subject: $scope.Subject,
            Name: $scope.Name,
            Email: $scope.Email,
            Message: $scope.Message
        };
        var inst = ContactService.insertContact(Contact);
        inst.then(function (res) {
            alert("Your Message has been sent. We will contact with you as soon as possible")
            $scope.Subject = '';
            $scope.Name = '';
            $scope.Email = '';
            $scope.Message = '';

        }, function () {
            alert("Please recheck your message and try again")
        })
    }

})