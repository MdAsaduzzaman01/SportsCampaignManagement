/// <reference path="../angular.js" />


app.controller("FBowlingCtrl", function ($scope, FBowlingService, BowlingScoreService) {
    loadFBowling();
    loadBowlingScore();
    $scope.FBowlingList = true;
    function loadFBowling() {
        var GetRecord = FBowlingService.getFBowlingScore();
        GetRecord.then(function (res) {
            $scope.getAllFBowling = res.data.value;
        }, function () {
            alert("Data not retrive");
        })
    };
    function loadBowlingScore() {
        var GetRecord = BowlingScoreService.getBowlingScore();
        GetRecord.then(function (res) {
            $scope.AllBowlingScore = res.data.value;
        }, function () {
            alert("Data not retrive");
        })
    };
    $scope.Cancel = function () {
        $scope.divInsertFBowling = false;
        $scope.FBowlingList = true;
        $scope.divDeleteFBowling = false;
        $scope.divUpdateFBowling = false;

    }
    $scope.CreateFBowling = function () {
        $scope.divInsertFBowling = true;
        $scope.FBowlingList = false;
        $scope.divDeleteFBowling = false;
        $scope.divUpdateFBowling = false;

    }
    $scope.insertData = function () {
        var b1 = $scope.Ball1Total;
        var b2 = $scope.Ball2Total;
        var b3 = $scope.Ball3Total;
        var b4 = $scope.Ball4Total;
        var b5 = $scope.Ball5Total;
        var b6 = $scope.Ball6Total;
        var sum = parseInt(b1) + parseInt(b2) + parseInt(b3) + parseInt(b4) + parseInt(b5) + parseInt(b6);
        var FBowling = {
            PlayerId: $scope.PlayerId,
            Ball1Total: $scope.Ball1Total,
            Ball2Total: $scope.Ball2Total,
            Ball3Total: $scope.Ball3Total,
            Ball4Total: $scope.Ball4Total,
            Ball5Total: $scope.Ball5Total,
            Ball6Total: $scope.Ball6Total,
            FinalScore: sum
        };
        var inst = FBowlingService.insertFBowlingScore(FBowling);
        inst.then(function (res) {
            loadFBowling();
            alert("Insert success")
            $scope.divInsertFBowling = false;
            $scope.FBowlingList = true;
            $scope.divDeleteFBowling = false;
            $scope.divUpdateFBowling = false;
        }, function () {
            alert("Not Inserted please try again !")
        })
    }
    $scope.updateData = function () {
        var b1 = $scope.Ball1Total;
        var b2 = $scope.Ball2Total;
        var b3 = $scope.Ball3Total;
        var b4 = $scope.Ball4Total;
        var b5 = $scope.Ball5Total;
        var b6 = $scope.Ball6Total;
        var sum = parseInt(b1) + parseInt(b2) + parseInt(b3) + parseInt(b4) + parseInt(b5) + parseInt(b6);
        var FBowling = {
            FinalBowlingScoreId:  $scope.FinalBowlingScoreId,
            PlayerId: $scope.PlayerId,
            Ball1Total: $scope.Ball1Total,
            Ball2Total: $scope.Ball2Total,
            Ball3Total: $scope.Ball3Total,
            Ball4Total: $scope.Ball4Total,
            Ball5Total: $scope.Ball5Total,
            Ball6Total: $scope.Ball6Total,
            FinalScore: sum
        };
        var upd = FBowlingService.updateFBowlingScore(FBowling);
        upd.then(function (res) {
            loadFBowling();
            alert("Updated successfull")
            $scope.divInsertFBowling = false;
            $scope.FBowlingList = true;
            $scope.divDeleteFBowling = false;
            $scope.divUpdateFBowling = false;
        }, function () {
            alert("Not Updated please try again !")
        })

    }
    $scope.updateFBowlinging = function (fbowl) {
        $scope.divInsertFBowling = false;
        $scope.FBowlingList = false;
        $scope.divDeleteFBowling = false;
        $scope.divUpdateFBowling = true;
        $scope.FinalBowlingScoreId = fbowl.FinalBowlingScoreId;
        $scope.PlayerId = fbowl.PlayerId;
        $scope.Ball1Total = fbowl.Ball1Total;
        $scope.Ball2Total = fbowl.Ball2Total;
        $scope.Ball3Total = fbowl.Ball3Total;
        $scope.Ball4Total = fbowl.Ball4Total;
        $scope.Ball5Total = fbowl.Ball5Total;
        $scope.Ball6Total = fbowl.Ball6Total;
        
    }

    $scope.deleteFBowling = function (fbowl) {
        $scope.divInsertFBowling = false;
        $scope.FBowlingList = false;
        $scope.divDeleteFBowling = true;
        $scope.divUpdateFBowling = false;
        $scope.FinalBowlingScoreId = fbowl.FinalBowlingScoreId;
        $scope.PlayerId = fbowl.PlayerId;
        $scope.Ball1Total = fbowl.Ball1Total;
        $scope.Ball2Total = fbowl.Ball2Total;
        $scope.Ball3Total = fbowl.Ball3Total;
        $scope.Ball4Total = fbowl.Ball4Total;
        $scope.Ball5Total = fbowl.Ball5Total;
        $scope.Ball6Total = fbowl.Ball6Total;
        $scope.FinalScore = fbowl.FinalScore;
    }
    $scope.deleteData = function () {
        var FBowling = {
            FinalBowlingScoreId: $scope.FinalBowlingScoreId,
            PlayerId: $scope.PlayerId,
            Ball1Total: $scope.Ball1Total,
            Ball2Total: $scope.Ball2Total,
            Ball3Total: $scope.Ball3Total,
            Ball4Total: $scope.Ball4Total,
            Ball5Total: $scope.Ball5Total,
            Ball6Total: $scope.Ball6Total,
            FinalScore: $scope.FinalScore
        }
        var upd = FBowlingService.deleteFBowlingScore(FBowling);
        upd.then(function (res) {
            loadFBowling();
            alert("Delete successfull")
            $scope.divInsertFBowling = false;
            $scope.FBowlingList = true;
            $scope.divDeleteFBowling = false;
            $scope.divUpdateFBowling = false;
        }, function () {
            alert("Not deleted please try again !")
        })

    }
})