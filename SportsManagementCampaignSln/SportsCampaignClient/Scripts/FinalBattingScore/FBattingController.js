/// <reference path="../angular.js" />


app.controller("FBattingCtrl", function ($scope, FBatitngService, BattingScoreService) {
    loadFBatting();
    loadBattingScore();
    $scope.FBattingList = true;
    function loadFBatting() {
        var GetRecord = FBatitngService.getFBattingScore();
        GetRecord.then(function (res) {
            $scope.getAllFBtiings = res.data.value;
        }, function () {
            alert("Data not retrive");
        })
    };
    function loadBattingScore() {
        var GetRecord = BattingScoreService.getBattingScore();
        GetRecord.then(function (res) {
            $scope.AllBattingScore = res.data.value;
        }, function () {
            alert("Data not retrive");
        })
    };
    $scope.Cancel = function () {
        $scope.divInsertFBatting = false;
        $scope.FBattingList = true;
        $scope.divDeleteFBatting = false;
        $scope.divUpdateFBatting = false;
    }
    $scope.CreateFBatting = function () {
        $scope.divInsertFBatting = true;
        $scope.FBattingList = false;
        $scope.divDeleteFBatting = false;
        $scope.divUpdateFBatting = false;

    }
    $scope.insertData = function () {
        var b1 = $scope.Ball1Total;
        var b2 = $scope.Ball2Total;
        var b3 = $scope.Ball3Total;
        var b4 = $scope.Ball4Total;
        var b5 = $scope.Ball5Total;
        var b6 = $scope.Ball6Total;
        var sum = parseInt(b1) + parseInt(b2) + parseInt(b3) + parseInt(b4) + parseInt(b5) + parseInt(b6);
        var FBatting = {
            PlayerId: $scope.PlayerId,
            Ball1Total: $scope.Ball1Total,
            Ball2Total: $scope.Ball2Total,
            Ball3Total: $scope.Ball3Total,
            Ball4Total: $scope.Ball4Total,
            Ball5Total: $scope.Ball5Total,
            Ball6Total: $scope.Ball6Total,
            FinalScore: sum
        };
        var inst = FBatitngService.insertFBattingScore(FBatting);
        inst.then(function (res) {
            loadFBatting();
            alert("Insert success")
            $scope.divInsertFBatting = false;
            $scope.FBattingList = true;
            $scope.divDeleteFBatting = false;
            $scope.divUpdateFBatting = false;
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
        var FBatting = {
            FinalBattingScoreId:  $scope.FinalBattingScoreId,
            PlayerId: $scope.PlayerId,
            Ball1Total: $scope.Ball1Total,
            Ball2Total: $scope.Ball2Total,
            Ball3Total: $scope.Ball3Total,
            Ball4Total: $scope.Ball4Total,
            Ball5Total: $scope.Ball5Total,
            Ball6Total: $scope.Ball6Total,
            FinalScore: sum
        };
        var upd = FBatitngService.updateFBatting(FBatting);
        upd.then(function (res) {
            loadFBatting();
            alert("Updated successfull")
            $scope.divInsertFBatting = false;
            $scope.FBattingList = true;
            $scope.divDeleteFBatting = false;
            $scope.divUpdateFBatting = false;
        }, function () {
            alert("Not Updated please try again !")
        })

    }
    $scope.updateFBatting = function (fbat) {
        $scope.divInsertFBatting = false;
        $scope.FBattingList = false;
        $scope.divDeleteFBatting = false;
        $scope.divUpdateFBatting = true;
        $scope.FinalBattingScoreId = fbat.FinalBattingScoreId;
        $scope.PlayerId = fbat.PlayerId;
        $scope.Ball1Total = fbat.Ball1Total;
        $scope.Ball2Total = fbat.Ball2Total;
        $scope.Ball3Total = fbat.Ball3Total;
        $scope.Ball4Total = fbat.Ball4Total;
        $scope.Ball5Total = fbat.Ball5Total;
        $scope.Ball6Total = fbat.Ball6Total;
        $scope.FinalScore = fbat.FinalScore;
    }

    $scope.deleteFBatting = function (fbat) {
        $scope.divInsertFBatting = false;
        $scope.FBattingList = false;
        $scope.divDeleteFBatting = true;
        $scope.divUpdateFBatting = false;
        $scope.FinalBattingScoreId = fbat.FinalBattingScoreId;
        $scope.PlayerId = fbat.PlayerId;
        $scope.Ball1Total = fbat.Ball1Total;
        $scope.Ball2Total = fbat.Ball2Total;
        $scope.Ball3Total = fbat.Ball3Total;
        $scope.Ball4Total = fbat.Ball4Total;
        $scope.Ball5Total = fbat.Ball5Total;
        $scope.Ball6Total = fbat.Ball6Total;
        $scope.FinalScore = fbat.FinalScore;
    }
    $scope.deleteData = function () {
        var FBatting = {
            FinalBattingScoreId: $scope.FinalBattingScoreId,
            PlayerId: $scope.PlayerId,
            Ball1Total: $scope.Ball1Total,
            Ball2Total: $scope.Ball2Total,
            Ball3Total: $scope.Ball3Total,
            Ball4Total: $scope.Ball4Total,
            Ball5Total: $scope.Ball5Total,
            Ball6Total: $scope.Ball6Total,
            FinalScore: $scope.FinalScore
        }
        var upd = FBatitngService.deleteFBattingscore(FBatting);
        upd.then(function (res) {
            loadFBatting();
            alert("Delete successfull")
            $scope.divInsertFBatting = false;
            $scope.FBattingList = true;
            $scope.divDeleteFBatting = false;
            $scope.divUpdateFBatting = false;
        }, function () {
            alert("Not deleted please try again !")
        })

    }
})