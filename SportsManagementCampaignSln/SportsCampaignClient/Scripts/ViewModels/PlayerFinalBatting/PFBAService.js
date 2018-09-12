app.service('PFBASrvc', function ($http) {
    this.getAllPlayer = function () {

        var request = $http({
            method: 'Get',
            url: 'http://localhost:37364/odata/PlayerFinalBattings'
        });
        return request;
    };
    this.getSinglePlayer = function (id) {
        var request = $http({
            method: 'GET',
            url: 'http://localhost:37364/odata/PlayerFinalBattings(' + id + ')'

        });
        return request;
    }
})