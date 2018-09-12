app.service('PFALSrvc', function ($http) {
    this.getAllPlayerAL = function () {

        var request = $http({
            method: 'Get',
            url: 'http://localhost:37364/odata/PlayerFinalAlrounders'
        });
        return request;
    };
    this.getSinglePlayerAL = function (id) {
        var request = $http({
            method: 'GET',
            url: 'http://localhost:37364/odata/PlayerFinalAlrounders(' + id + ')'

        });
        return request;
    }
})