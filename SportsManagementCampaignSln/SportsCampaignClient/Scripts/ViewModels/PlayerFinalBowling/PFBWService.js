app.service('PFBWSrvc', function ($http) {
    this.getAllPlayerBW = function () {

        var request = $http({
            method: 'Get',
            url: 'http://localhost:37364/odata/PlayerFinalBowlings'
        });
        return request;
    };
    this.getSinglePlayerBW = function (id) {
        var request = $http({
            method: 'GET',
            url: 'http://localhost:37364/odata/PlayerFinalBowlings(' + id + ')'

        });
        return request;
    }
})