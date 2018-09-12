/// <reference path="../angular.js" />
/// <reference path="../module/module.js" />

app.service("SubscribeService", function ($http) {
    this.getAllSubscriber = function () {
        return $http.get("http://localhost:37364/odata/Subscribes")
    };
    this.insertSubscriber = function (sub) {
        var req = $http({
            method: 'Post',
            url: 'http://localhost:37364/odata/Subscribes',
            data: sub
        })
        return req;
    }
   
})