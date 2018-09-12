/// <reference path="../angular.js" />
/// <reference path="../module/module.js" />

app.service("BowlingScoreService", function ($http) {
    this.getBowlingScore = function () {
        return $http.get("http://localhost:37364/odata/BowlingScoreCards")
    };
    this.insertBowlingScore = function (BWSC) {
        var req = $http({
            method: 'Post',
            url: 'http://localhost:37364/odata/BowlingScoreCards',
            data: BWSC
        })
        return req;
    }
    this.updateBowlingScore = function (BWSC) {
        var res = $http({
            method: 'Put',
            url: 'http://localhost:37364/odata/BowlingScoreCards' + '(' + BWSC.BowlingScoreCardId + ')',
            data: BWSC

        })
        return res;
    }
    this.deleteBowlingScore = function (BWSC) {
        var res = $http({
            url: 'http://localhost:37364/odata/BowlingScoreCards' + '(' + BWSC.BowlingScoreCardId + ')',
            method: 'DELETE',
            data: BWSC
        })
        return res;
    }
})