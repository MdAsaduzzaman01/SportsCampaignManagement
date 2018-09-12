/// <reference path="../angular.js" />
/// <reference path="../module/module.js" />

app.service("PlayerService", function ($http) {
    this.getAllPlayer = function () {
        return $http.get("http://localhost:37364/odata/Players")
    };
    this.insertPlayer = function (Player) {
        var req = $http({
            method: 'Post',
            url: 'http://localhost:37364/odata/Players',
            data: Player
        })
        return req;
    }
    this.updatePlayer = function (Player) {
        var res = $http({
            method: 'Put',
            url: 'http://localhost:37364/odata/Players' + '(' + Player.PlayerId + ')',
            data: Player

        })
        return res;
    }
    this.deletePlayer = function (Player) {
        var res = $http({
            url: 'http://localhost:37364/odata/Players' + '(' + Player.PlayerId + ')',
            method: 'DELETE',
            data: Player
        })
        return res;
    }
})