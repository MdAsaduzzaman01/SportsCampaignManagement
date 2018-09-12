/// <reference path="../angular.js" />
/// <reference path="../module/module.js" />

app.service("ContactService", function ($http) {
    this.getAllContact = function () {
        return $http.get("http://localhost:37364/odata/Contacts")
    };
    this.insertContact = function (contact) {
        var req = $http({
            method: 'Post',
            url: 'http://localhost:37364/odata/Contacts',
            data: contact
        })
        return req;
    }
   
})