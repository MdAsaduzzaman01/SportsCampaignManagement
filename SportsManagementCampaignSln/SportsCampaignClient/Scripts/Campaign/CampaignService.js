/// <reference path="../angular.js" />
/// <reference path="../module/module.js" />

app.service("CampaignService", function ($http) {
    this.getCampaign = function () {
        return $http.get("http://localhost:37364/odata/Campaigns")
    };
    this.insertCampaign = function (Campaign) {
        var req = $http({
            method: 'Post',
            url: 'http://localhost:37364/odata/Campaigns',
            data: Campaign
        })
        return req;
    }
    this.updateCampaign = function (Campaign) {
        var res = $http({
            method: 'Put',
            url: 'http://localhost:37364/odata/Campaigns' + '(' + Campaign.CampaignId + ')',
            data: Campaign

        })
        return res;
    }
    this.deleteCampaign = function (Campaign) {
        var res = $http({
            url: 'http://localhost:37364/odata/Campaigns' + '(' + Campaign.CampaignId + ')',
            method: 'DELETE',
            data: Campaign
        })
        return res;
    }
})