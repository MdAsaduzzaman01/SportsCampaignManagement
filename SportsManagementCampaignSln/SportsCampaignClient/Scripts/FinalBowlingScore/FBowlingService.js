/// <reference path="../angular.js" />
/// <reference path="../module/module.js" />

app.service("FBowlingService", function ($http) {
    this.getFBowlingScore = function () {
        return $http.get("http://localhost:37364/odata/FinalBowlingScores")
    };
    this.insertFBowlingScore = function (FBowlingScore) {
        var req = $http({
            method: 'Post',
            url: 'http://localhost:37364/odata/FinalBowlingScores',
            data: FBowlingScore
        })
        return req;
    }
    this.updateFBowlingScore = function (FBowlingScore) {
        var res = $http({
            method: 'Put',
            url: 'http://localhost:37364/odata/FinalBowlingScores' + '(' + FBowlingScore.FinalBowlingScoreId + ')',
            data: FBowlingScore

        })
        return res;
    }
    this.deleteFBowlingScore = function (FBowlingScore) {
        var res = $http({
            url: 'http://localhost:37364/odata/FinalBowlingScores' + '(' + FBowlingScore.FinalBowlingScoreId + ')',
            method: 'DELETE',
            data: FBowlingScore
        })
        return res;
    }
})