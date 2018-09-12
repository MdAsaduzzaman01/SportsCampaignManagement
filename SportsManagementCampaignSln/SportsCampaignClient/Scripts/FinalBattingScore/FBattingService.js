/// <reference path="../angular.js" />
/// <reference path="../module/module.js" />

app.service("FBatitngService", function ($http) {
    this.getFBattingScore = function () {
        return $http.get("http://localhost:37364/odata/FinalBattingScores")
    };
    this.insertFBattingScore = function (FBattingScore) {
        var req = $http({
            method: 'Post',
            url: 'http://localhost:37364/odata/FinalBattingScores',
            data: FBattingScore
        })
        return req;
    }
    this.updateFBatting = function (FBattingScore) {
        var res = $http({
            method: 'Put',
            url: 'http://localhost:37364/odata/FinalBattingScores' + '(' + FBattingScore.FinalBattingScoreId + ')',
            data: FBattingScore

        })
        return res;
    }
    this.deleteFBattingscore = function (FBattingScore) {
        var res = $http({
            url: 'http://localhost:37364/odata/FinalBattingScores' + '(' + FBattingScore.FinalBattingScoreId + ')',
            method: 'DELETE',
            data: FBattingScore
        })
        return res;
    }
})