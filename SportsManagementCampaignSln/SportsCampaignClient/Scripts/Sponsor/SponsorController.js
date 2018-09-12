/// <reference path="../angular.js" />


app.controller("SponsorCtrl", function ($scope, SponsorService, CampaignService) {
    loadSponsor();
    loadCampaign();
    $scope.SpList = true;
    function loadSponsor() {
        var GetRecord = SponsorService.getSponsorList();
        GetRecord.then(function (res) {
            $scope.SponsorList = res.data.value;
        }, function () {
            alert("Data not retrive");
        })
    };
    function loadCampaign() {
        var GetRecord = CampaignService.getCampaign();
        GetRecord.then(function (res) {
            $scope.AllCampaigns = res.data.value;
        }, function () {
            alert("Data not retrive");
        })
    };
    $scope.Cancel = function () {
        $scope.InsertSponsor = false;
        $scope.SpList = true;
        $scope.divupdateSp = false;
        $scope.divDeleteSp = false;
    }
    $scope.CreateNewSp = function () {
        $scope.InsertSponsor = true;
        $scope.SpList = false;
        $scope.divupdateSp = false;
        $scope.divDeleteSp = false;
    }
    $scope.insertData = function () {
        var Sponsor = {
            CampaignId: $scope.CampaignId,
            CompanyName: $scope.CompanyName,
            CompanyAddress: $scope.CompanyAddress,
            AmountToPay: $scope.AmountToPay
           
        };
        var inst = SponsorService.insertSponsor(Sponsor);
        inst.then(function (res) {
            loadSponsor();
            alert("Insert success")
            $scope.InsertSponsor = false;
            $scope.SpList = true;
            $scope.divupdateSp = false;
            $scope.divDeleteSp = false;
        }, function () {
            alert("Not Inserted please try again !")
        })
    }
    $scope.updateData = function () {
        var Sponsor = {
            SponsorId: $scope.SponsorId,
            CampaignId: $scope.CampaignId,
            CompanyName: $scope.CompanyName,
            CompanyAddress: $scope.CompanyAddress,
            AmountToPay: $scope.AmountToPay
        };
        var upd = SponsorService.updateSponsor(Sponsor);
        upd.then(function (res) {
            loadSponsor();
            alert("Updated successfull")
            $scope.InsertSponsor = false;
            $scope.SpList = true;
            $scope.divupdateSp = false;
            $scope.divDeleteSp = false;
        }, function () {
            alert("Not Updated please try again !")
        })

    }
    $scope.updateSponsor = function (sp) {
        $scope.InsertSponsor = false;
        $scope.SpList = false;
        $scope.divupdateSp = true;
        $scope.divDeleteSp = false;
        $scope.SponsorId = sp.SponsorId
        $scope.CampaignId = sp.CampaignId;
        $scope.CompanyName = sp.CompanyName;
        $scope.CompanyAddress = sp.CompanyAddress;
        $scope.AmountToPay = sp.AmountToPay;
        


    }

    $scope.deleteSponsor = function (sp) {
        $scope.InsertSponsor = false;
        $scope.SpList = false;
        $scope.divupdateSp = false;
        $scope.divDeleteSp = true;
        $scope.SponsorId = sp.SponsorId
        $scope.CampaignId = sp.CampaignId;
        $scope.CompanyName = sp.CompanyName;
        $scope.CompanyAddress = sp.CompanyAddress;
        $scope.AmountToPay = sp.AmountToPay;
    }
    $scope.deleteData = function () {
        var Sponsor = {
            SponsorId: $scope.SponsorId,
            CampaignId: $scope.CampaignId,
            CompanyName: $scope.CompanyName,
            CompanyAddress: $scope.CompanyAddress,
            AmountToPay: $scope.AmountToPay

        };
        var upd = SponsorService.deleteSponsor(Sponsor);
        upd.then(function (res) {
            loadSponsor();
            alert("Delete successfull")
            $scope.InsertSponsor = false;
            $scope.SpList = true;
            $scope.divupdateSp = false;
            $scope.divDeleteSp = false;
        }, function () {
            alert("Not deleted please try again !")
        })

    }
})