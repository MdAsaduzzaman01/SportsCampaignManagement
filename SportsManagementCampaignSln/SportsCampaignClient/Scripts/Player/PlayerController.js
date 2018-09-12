/// <reference path="../angular.js" />
/// <reference path="playerservice.js" />


app.controller("PlayerCtrl", function ($scope, PlayerService, CampaignService) {
    loadAllPlayer();
    loadCampaign();
    $scope.divPlayerList = true;
    function loadAllPlayer() {
        var GetPlayer = PlayerService.getAllPlayer();
        GetPlayer.then(function (res) {
            $scope.AllPlayers = res.data.value;
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
        $scope.divInsertPlayer = false;
        $scope.divUpdatePlayer = false;
        $scope.divDeletePlayer = false;
        $scope.divPlayerList = true;
    }

    $scope.insertData = function () {
        var Player = {
            PlayerName: $scope.PlayerName,
            FatherName: $scope.FatherName,
            MotherName: $scope.MotherName,
            DateOfBirth: $scope.DateOfBirth,
            BirthCertificateNumber: $scope.BirthCertificateNumber,
            Age: $scope.Age,
            EducationalQualification: $scope.EducationalQualification,
            PlayerType: $scope.PlayerType,
            Height: $scope.Height,
            Weight: $scope.Weight,
            Religion: $scope.Religion,
            Phone: $scope.Phone,
            HomePhone: $scope.HomePhone,
            PresentAddress: $scope.PresentAddress,
            PermanentAddress: $scope.PermanentAddress,
            CampaignId: $scope.CampaignId
        };
        var inst = PlayerService.insertPlayer(Player);
        inst.then(function (res) {
            loadAllPlayer();
            alert("Insert success")
            
        }, function () {
            alert("Not Inserted please try again !")
        })
    }
    $scope.updateData = function () {
        var Player = {
            PlayerId: $scope.PlayerId,
            PlayerName: $scope.PlayerName,
            FatherName: $scope.FatherName,
            MotherName: $scope.MotherName,
            DateOfBirth: $scope.DateOfBirth,
            BirthCertificateNumber: $scope.BirthCertificateNumber,
            Age: $scope.Age,
            EducationalQualification: $scope.EducationalQualification,
            PlayerType: $scope.PlayerType,
            Height: $scope.Height,
            Weight: $scope.Weight,
            Religion: $scope.Religion,
            Phone: $scope.Phone,
            HomePhone: $scope.HomePhone,
            PresentAddress: $scope.PresentAddress,
            PermanentAddress: $scope.PermanentAddress,
            CampaignId: $scope.CampaignId
        };
        var upd = PlayerService.updatePlayer(Player);
        upd.then(function (res) {
            loadAllPlayer();
            alert("Updated successfull")
            $scope.divInsertPlayer = false;
            $scope.divUpdatePlayer = false;
            $scope.divDeletePlayer = false;
            $scope.divPlayerList = true;
        }, function () {
            alert("Not Updated please try again !")
        })

    }
    $scope.updatePlayer = function (player) {
        $scope.divInsertPlayer = false;
        $scope.divUpdatePlayer = true;
        $scope.divDeletePlayer = false;
        $scope.divPlayerList = false;
        $scope.PlayerId = player.PlayerId;
        $scope.PlayerName = player.PlayerName;
        $scope.FatherName = player.FatherName;
        $scope.MotherName = player.MotherName;
        $scope.DateOfBirth = player.DateOfBirth;
        $scope.BirthCertificateNumber = player.BirthCertificateNumber;
        $scope.Age = player.Age;
        $scope.EducationalQualification = player.EducationalQualification;
        $scope.PlayerType = player.PlayerType;
        $scope.Height = player.Height;
        $scope.Weight = player.Weight
        $scope.Religion = player.Religion;
        $scope.Phone = player.Phone;
        $scope.HomePhone = player.HomePhone;
        $scope.PresentAddress = player.PresentAddress;
        $scope.PermanentAddress = player.PermanentAddress
        $scope.CampaignId = player.CampaignId;
        
    }

    $scope.deletePlayer = function (player) {
        $scope.divInsertPlayer = false;
        $scope.divUpdatePlayer = false;
        $scope.divDeletePlayer = true;
        $scope.divPlayerList = false;
        $scope.PlayerId = player.PlayerId;
        $scope.PlayerName = player.PlayerName;
        $scope.FatherName = player.FatherName;
        $scope.MotherName = player.MotherName;
        $scope.DateOfBirth = player.DateOfBirth;
        $scope.BirthCertificateNumber = player.BirthCertificateNumber;
        $scope.Age = player.Age;
        $scope.EducationalQualification = player.EducationalQualification;
        $scope.PlayerType = player.PlayerType;
        $scope.Height = player.Height;
        $scope.Weight = player.Weight
        $scope.Religion = player.Religion;
        $scope.Phone = player.Phone;
        $scope.HomePhone = player.HomePhone;
        $scope.PresentAddress = player.PresentAddress;
        $scope.PermanentAddress = player.PermanentAddress
        $scope.CampaignId = player.CampaignId;
    }
    $scope.deleteData = function () {
        var Player = {
            PlayerId: $scope.PlayerId,
            PlayerName: $scope.PlayerName,
            FatherName: $scope.FatherName,
            MotherName: $scope.MotherName,
            DateOfBirth: $scope.DateOfBirth,
            BirthCertificateNumber: $scope.BirthCertificateNumber,
            Age: $scope.Age,
            EducationalQualification: $scope.EducationalQualification,
            PlayerType: $scope.PlayerType,
            Height: $scope.Height,
            Weight: $scope.Weight,
            Religion: $scope.Religion,
            Phone: $scope.Phone,
            HomePhone: $scope.HomePhone,
            PresentAddress: $scope.PresentAddress,
            PermanentAddress: $scope.PermanentAddress,
            CampaignId: $scope.CampaignId
        };
        var upd = PlayerService.deletePlayer(Player);
        upd.then(function (res) {
            loadAllPlayer();
            alert("Delete successfull")
            $scope.divInsertPlayer = false;
            $scope.divUpdatePlayer = false;
            $scope.divDeletePlayer = false;
            $scope.divPlayerList = true;
        }, function () {
            alert("Not deleted please try again !")
        })

    }
})