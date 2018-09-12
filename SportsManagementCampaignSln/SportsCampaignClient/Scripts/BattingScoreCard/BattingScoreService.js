/// <reference path="../angular.js" />
/// <reference path="../module/module.js" />

app.service("BattingScoreService", function ($http) {
    this.getBattingScore = function () {
        return $http.get("http://localhost:37364/odata/BattingScoreCards")
    };
    this.insertBattingScore = function (BTSC) {
        var req = $http({
            method: 'Post',
            url: 'http://localhost:37364/odata/BattingScoreCards',
            data: BTSC
        })
        return req;
    }
    this.updateBattingScore = function (BTSC) {
        var res = $http({
            method: 'Put',
            url: 'http://localhost:37364/odata/BattingScoreCards' + '(' + BTSC.BattingScoreCardId + ')',
            data: BTSC

        })
        return res;
    }
    this.deleteBattingScore = function (BTSC) {
        var res = $http({
            url: 'http://localhost:37364/odata/BattingScoreCards' + '(' + BTSC.BattingScoreCardId + ')',
            method: 'DELETE',
            data: BTSC
        })
        return res;
    }
})