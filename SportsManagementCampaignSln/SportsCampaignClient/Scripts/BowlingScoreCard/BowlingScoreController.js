
app.controller("BowlingScoreCtrl", function ($scope, BowlingScoreService, PlayerService) {
    loadBowlingScore();
    loadAllPlayer();
    $scope.BWScoreList = true;
    function loadBowlingScore() {
        var GetRecord = BowlingScoreService.getBowlingScore();
        GetRecord.then(function (res) {
            $scope.AllBowlingScore = res.data.value;
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
        $scope.InsertBWScore = false;
        $scope.BWScoreList = true;
        $scope.divBWScoreupdate = false;
        $scope.divBWScoreDelete = false;
    }
    $scope.CreateNewBowlingScore = function () {
        $scope.InsertBWScore = true;
        $scope.BWScoreList = false;
        $scope.divBWScoreupdate = false;
        $scope.divBWScoreDelete = false;
    }
    $scope.insertData = function () {
        var run = $scope.Runs;
        var length = $scope.Length;
        var line = $scope.Line;
        var speed = $scope.Speed;
        var wckts = $scope.Wicket;
        var sum = parseInt(run) + parseInt(length) + parseInt(line) + parseInt(speed) + parseInt(wckts);
        var BWScore = {
            PlayerId: $scope.PlayerId,
            Level: $scope.Level,
            BallNumber: $scope.BallNumber,
            Length: $scope.Length,
            Line: $scope.Line,
            Speed: $scope.Speed,
            Runs: $scope.Runs,
            Wicket: $scope.Wicket,
            Total: sum

        };
        var inst = BowlingScoreService.insertBowlingScore(BWScore);
        inst.then(function (res) {
            loadBowlingScore();
            alert("Insert success")
            $scope.InsertBWScore = false;
            $scope.BWScoreList = true;
            $scope.divBWScoreupdate = false;
            $scope.divBWScoreDelete = false;
        }, function () {
            alert("Not Inserted please try again !")
        })
    }
    $scope.updateData = function () {
        var run = $scope.Run;
        var length = $scope.Lengths;
        var line = $scope.Lines;
        var speed = $scope.Speeds;
        var wckts = $scope.Wickets;
        var sum = parseInt(run) + parseInt(length) + parseInt(line) + parseInt(speed) + parseInt(wckts);
        var BWScore = {
            BowlingScoreCardId: $scope.BowlingScoreCardIds,
            PlayerId: $scope.PlayerIds,
            Level:$scope.Level,
            BallNumber: $scope.BallNumbers,
            Length: $scope.Lengths,
            Line: $scope.Lines,
            Speed: $scope.Speeds,
            Runs: $scope.Run,
            Wicket: $scope.Wickets,
            Total: sum
        };
        var upd = BowlingScoreService.updateBowlingScore(BWScore);
        upd.then(function (res) {
            loadBowlingScore();
            alert("Updated successfull")
            $scope.InsertBWScore = false;
            $scope.BWScoreList = true;
            $scope.divBWScoreupdate = false;
            $scope.divBWScoreDelete = false;
        }, function () {
            alert("Not Updated please try again !")
        })

    }
    $scope.updateBWScore = function (bt) {
        $scope.InsertBWScore = false;
        $scope.BWScoreList = false;
        $scope.divBWScoreupdate = true;
        $scope.divBWScoreDelete = false;

        $scope.BowlingScoreCardIds = bt.BowlingScoreCardId;
        $scope.PlayerIds = bt.PlayerId;
        $scope.Level = bt.Level;
        $scope.BallNumbers = bt.BallNumber;
        $scope.Lengths = bt.Length;
        $scope.Lines = bt.Line;
        $scope.Speeds = bt.Speed;
        $scope.Run = bt.Runs;
        $scope.Wickets = bt.Wicket;
    }

    $scope.deleteBWScore = function (bt) {
        $scope.InsertBWScore = false;
        $scope.BWScoreList = false;
        $scope.divBWScoreupdate = false;
        $scope.divBWScoreDelete = true;

        $scope.BowlingScoreCardId = bt.BowlingScoreCardId;
        $scope.PlayerId = bt.PlayerId;
        $scope.Level = bt.Level;
        $scope.BallNumber = bt.BallNumber;
        $scope.Length = bt.Length;
        $scope.Line = bt.Line;
        $scope.Speed = bt.Speed;
        $scope.Runs = bt.Runs;
        $scope.Wicket = bt.Wicket;
        $scope.Total = bt.Total;
    }
    $scope.deleteData = function () {
        //var run = $scope.Runs;
        //var length = $scope.Length;
        //var line = $scope.Line;
        //var speed = $scope.Speed;
        //var wckts = $scope.Wicket;
        //var sum = parseInt(run) + parseInt(length) + parseInt(line) + parseInt(speed) + parseInt(wckts);
        var BWScore = {
            BowlingScoreCardId: $scope.BowlingScoreCardId,
            PlayerId: $scope.PlayerId,
            BallNumber: $scope.BallNumber,
            Length: $scope.Length,
            Line: $scope.Line,
            Speed: $scope.Speed,
            Runs: $scope.Runs,
            Wicket: $scope.Wicket,
            Total: $scope.Total
           };
        var upd = BowlingScoreService.deleteBowlingScore(BWScore);
        upd.then(function (res) {
            loadBowlingScore();
            alert("Delete successfull")
            $scope.InsertBWScore = false;
            $scope.BWScoreList = true;
            $scope.divBWScoreupdate = false;
            $scope.divBWScoreDelete = false;
        }, function () {
            alert("Not deleted please try again !")
        })

    }
})