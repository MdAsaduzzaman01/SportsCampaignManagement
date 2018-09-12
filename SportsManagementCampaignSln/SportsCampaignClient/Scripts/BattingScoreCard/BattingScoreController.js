
app.controller("BattingScoreCtrl", function ($scope, BattingScoreService, PlayerService) {
    loadBattingScore();
    loadAllPlayer();
    $scope.BTScoreList = true;
    function loadBattingScore() {
        var GetRecord = BattingScoreService.getBattingScore();
        GetRecord.then(function (res) {
            $scope.AllBattingScore = res.data.value;
        }, function () {
            alert("Data not retrive");
        })
    };
    function loadAllPlayer() {
        var GetPlayer = PlayerService.getAllPlayer();
        GetPlayer.then(function (res) {
            $scope.AllPlayers = res.data.value;
        }, function () {
            alert("Data not retrive");
        })
    };
    $scope.Cancel = function () {
        $scope.InsertBTScore = false;
        $scope.BTScoreList = true;
        $scope.divBTScoreupdate = false;
        $scope.divBTScoreDelete = false;
    }
    $scope.CreateNewBattingScore = function () {
        $scope.InsertBTScore = true;
        $scope.BTScoreList = false;
        $scope.divBTScoreupdate = false;
        $scope.divBTScoreDelete = false;
    }
    $scope.insertData = function () {
        var run = $scope.Runs;
        var out = $scope.Out;
        var sum = parseInt(run) + parseInt(out);
        var BTScore = {
            PlayerId: $scope.PlayerId,
            BallNumber: $scope.BallNumber,
            Runs: $scope.Runs,
            Out: $scope.Out,
            Total: sum
            
        };
        var inst = BattingScoreService.insertBattingScore(BTScore);
        inst.then(function (res) {
            loadBattingScore();
            alert("Insert success")
            $scope.InsertBTScore = false;
            $scope.BTScoreList = true;
        }, function () {
            alert("Not Inserted please try again !")
        })
    }
    $scope.updateData = function () {
        var run = $scope.Runs;
        var out = $scope.Out;
        var sum = parseInt(run) + parseInt(out);
        var BTScore = {
            BattingScoreCardId: $scope.BattingScoreCardId,
            PlayerId: $scope.PlayerId,
            BallNumber: $scope.BallNumber,
            Runs: $scope.Runs,
            Out: $scope.Out,
            Total: sum

        };
        var upd = BattingScoreService.updateBattingScore(BTScore);
        upd.then(function (res) {
            loadBattingScore();
            alert("Updated successfull")
            $scope.InsertBTScore = false;
            $scope.BTScoreList = true;
            $scope.divBTScoreupdate = false;
            $scope.divBTScoreDelete = false;
        }, function () {
            alert("Not Updated please try again !")
        })

    }
    $scope.updateBTScore = function (bt) {
        $scope.InsertBTScore = false;
        $scope.BTScoreList = false;
        $scope.divBTScoreupdate = true;
        $scope.divBTScoreDelete = false;
        $scope.BattingScoreCardId = bt.BattingScoreCardId;
        $scope.PlayerId = bt.PlayerId;
        $scope.BallNumber = bt.BallNumber;
        $scope.Runs = bt.Runs;
        $scope.Out = bt.Out;
        


    }

    $scope.deleteBtScore = function (bt) {
        $scope.InsertBTScore = false;
        $scope.BTScoreList = false;
        $scope.divBTScoreupdate = false;
        $scope.divBTScoreDelete = true;
        $scope.BattingScoreCardId = bt.BattingScoreCardId;
        $scope.PlayerId = bt.PlayerId;
        $scope.BallNumber = bt.BallNumber;
        $scope.Runs = bt.Runs;
        $scope.Out = bt.Out;
        $scope.Total = bt.Total;
    }
    $scope.deleteData = function () {
        var run = $scope.Runs;
        var out = $scope.Out;
        var sum = parseInt(run) + parseInt(out);
        var BTScore = {
            BattingScoreCardId: $scope.BattingScoreCardId,
            PlayerId: $scope.PlayerId,
            BallNumber: $scope.BallNumber,
            Runs: $scope.Runs,
            Out: $scope.Out,
            Total: sum

        };
        var upd = BattingScoreService.deleteBattingScore(BTScore);
        upd.then(function (res) {
            loadBattingScore();
            alert("Delete successfull")
            $scope.InsertBTScore = false;
            $scope.BTScoreList = true;
            $scope.divBTScoreupdate = false;
            $scope.divBTScoreDelete = false;
        }, function () {
            alert("Not deleted please try again !")
        })

    }
})