app.controller('PFALCtrl', function ($scope, PFALSrvc) {
    loadRecords();
    $scope.divALrounderList = true;
    function loadRecords() {
        var player = PFALSrvc.getAllPlayerAL();
        player.then(function (result) {
            $scope.ALPlayers = result.data.value;

        }, function () {
            alert("Data not found");
        })
    };
    $scope.Close = function () {
        $scope.divAllRounderDetails = false;
        $scope.divALrounderList = true;
    }
    $scope.getAllRounderDetails = function (player) {
        var getSingle = PFALSrvc.getSinglePlayerAL(player.PlayerId);
        getSingle.then(function (result) {
            $scope.divAllRounderDetails = true;
            $scope.divALrounderList = false;
            var player = result.data;
            $scope.PlayerId = player.PlayerId;
            $scope.PlayerName = player.PlayerName;
            $scope.FatherName = player.FatherName;
            $scope.MotherName = player.MotherName;
            $scope.PlayerType = player.PlayerType;
            $scope.CampaignVenue = player.CampaignVenue;
            $scope.CampaignDate = player.CampaignDate;
            $scope.CampaignLevel = player.CampaignLevel;
            $scope.BattingFinalScore = player.BattingFinalScore;
            $scope.BowlingFinalScore = player.BowlingFinalScore;
            $scope.TotalScore = player.TotalScore;
            

        }, function (err) {
            alert(err);
        })
    }
})