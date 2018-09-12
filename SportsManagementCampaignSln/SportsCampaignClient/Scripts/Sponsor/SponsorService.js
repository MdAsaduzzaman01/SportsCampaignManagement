/// <reference path="../angular.js" />
/// <reference path="../module/module.js" />

app.service("SponsorService", function ($http) {
    this.getSponsorList = function () {
        return $http.get("http://localhost:37364/odata/Sponsors")
    };
    this.insertSponsor = function (spnsor) {
        var req = $http({
            method: 'Post',
            url: 'http://localhost:37364/odata/Sponsors',
            data: spnsor
        })
        return req;
    }
    this.updateSponsor = function (spnsor) {
        var res = $http({
            method: 'Put',
            url: 'http://localhost:37364/odata/Sponsors' + '(' + spnsor.SponsorId + ')',
            data: spnsor

        })
        return res;
    }
    this.deleteSponsor = function (spnsor) {
        var res = $http({
            url: 'http://localhost:37364/odata/Sponsors' + '(' + spnsor.SponsorId + ')',
            method: 'DELETE',
            data: spnsor
        })
        return res;
    }
})