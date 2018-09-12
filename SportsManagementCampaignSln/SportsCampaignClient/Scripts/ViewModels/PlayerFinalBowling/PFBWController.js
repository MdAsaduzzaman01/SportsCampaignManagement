app.controller('PFBWCtrl', function ($scope, PFBWSrvc) {
    loadRecords();
    $scope.divBowlerList = true;
    function loadRecords() {
        var player = PFBWSrvc.getAllPlayerBW();
        player.then(function (result) {
            $scope.BWPlayers = result.data.value;

        }, function () {
            alert("Data not found");
        })
    };
    $scope.Close = function () {
        $scope.divBowlerDetails = false;
        $scope.divBowlerList = true;
    }
    $scope.getBowlerDetails = function (player) {
        var getSingle = PFBWSrvc.getSinglePlayerBW(player.PlayerId);
        getSingle.then(function (result) {
            $scope.divBowlerDetails = true;
            $scope.divBowlerList = false;
            var player = result.data;
            $scope.PlayerId = player.PlayerId;
            $scope.PlayerName = player.PlayerName;
            $scope.FatherName = player.FatherName;
            $scope.MotherName = player.MotherName;
            $scope.PlayerType = player.PlayerType;
            $scope.CampaignVenue = player.CampaignVenue;
            $scope.CampaignDate = player.CampaignDate;
            $scope.CampaignLevel = player.CampaignLevel;
            $scope.Ball1Total = player.Ball1Total;
            $scope.Ball2Total = player.Ball2Total;
            $scope.Ball3Total = player.Ball3Total;
            $scope.Ball4Total = player.Ball4Total;
            $scope.Ball5Total = player.Ball5Total;
            $scope.Ball6Total = player.Ball6Total;
            $scope.FinalScore = player.FinalScore;

        }, function (err) {
            alert(err);
        })
    }
})