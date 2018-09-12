/// <reference path="../angular.js" />
/// <reference path="campaignservice.js" />
/// <reference path="../employee/employeeservice.js" />

app.controller("CampaignCtrl", function ($scope, CampaignService, EmployeeService) {
    loadCampaign();
    loadEmployee();
    $scope.CamList = true;
    function loadCampaign() {
        var GetRecord = CampaignService.getCampaign();
        GetRecord.then(function (res) {
            $scope.AllCampaigns = res.data.value;
        }, function () {
            alert("Data not retrive");
        })
    };
    function loadEmployee() {
        var GetEmp = EmployeeService.getAllEmployee();
        GetEmp.then(function (res) {
            $scope.AllEmployees = res.data.value;
        }, function () {
            alert("Data not retrive");
        })
    };
    $scope.Cancle = function () {
        $scope.divInsertCam = false;
        $scope.CamList = true;
        $scope.divDeleteCam = false;
        $scope.divUpdateCam = false;
    };
   
    $scope.CreateCampaign = function () {
        $scope.divInsertCam = true;
        $scope.CamList = false;
        $scope.divDeleteCam = false;
        $scope.divUpdateCam = false;
            
    }
    $scope.insertData = function () {
        var Campaign = {
            CampaignName: $scope.CampaignName,
            CampaignDate: $scope.CampaignDate,
            CampaignVenue: $scope.CampaignVenue,
            CampaignLevel: $scope.CampaignLevel,
            EmployeeId: $scope.EmployeeId
        };
        var inst = CampaignService.insertCampaign(Campaign);
        inst.then(function (res) {
            loadCampaign();
            alert("Insert success")
            $scope.CamList = true;
            $scope.divInsertCam = false;
            $scope.divDeleteCam = false;
            $scope.divUpdateCam = false;
        }, function () {
            alert("Not Inserted please try again !")
        })
    }
    $scope.updateData = function () {
        $scope.divInsertCam = false;
        var Campaign = {
            CampaignId: $scope.CampaignId,
            CampaignName: $scope.CampaignName,
            CampaignDate: $scope.CampaignDate,
            CampaignVenue: $scope.CampaignVenue,
            CampaignLevel: $scope.CampaignLevel,
            EmployeeId: $scope.EmployeeId
        };
        var upd = CampaignService.updateCampaign(Campaign);
        upd.then(function (res) {
            loadCampaign();
            alert("Updated successfull")
            $scope.CamList = true;
            $scope.divInsertCam = false;
            $scope.divDeleteCam = false;
            $scope.divUpdateCam = false;
        }, function () {
            alert("Not Updated please try again !")
        })

    }
    $scope.updateCampaign = function (cam) {
        $scope.CamList = false;
        $scope.divUpdateCam = true;
        $scope.divDeleteCam = false;
        $scope.CampaignId = cam.CampaignId;
        $scope.CampaignName = cam.CampaignName;
        $scope.CampaignDate = cam.CampaignDate;
        $scope.CampaignVenue = cam.CampaignVenue;
        $scope.CampaignLevel = cam.CampaignLevel;
        $scope.EmployeeId = cam.EmployeeId;
    }

    $scope.deleteCampaign = function (cam) {
        $scope.divDeleteCam = true;
        $scope.divUpdateCam = false;
        $scope.CamList = false;
        $scope.CampaignId = cam.CampaignId;
        $scope.CampaignName = cam.CampaignName;
        $scope.CampaignDate = cam.CampaignDate;
        $scope.CampaignVenue = cam.CampaignVenue;
        $scope.CampaignLevel = cam.CampaignLevel;
        $scope.EmployeeId = cam.EmployeeId;
    }
    $scope.deleteData = function () {
        var Campaign = {
            CampaignId: $scope.CampaignId,
            CampaignName: $scope.CampaignName,
            CampaignDate: $scope.CampaignDate,
            CampaignVenue: $scope.CampaignVenue,
            CampaignLevel: $scope.CampaignLevel,
            EmployeeId: $scope.EmployeeId
        };
        var upd = CampaignService.deleteCampaign(Campaign);
        upd.then(function (res) {
            loadCampaign();
            alert("Delete successfull")
            $scope.CamList = true;
            $scope.divInsertCam = false;
            $scope.divDeleteCam = false;
            $scope.divUpdateCam = false;
        }, function () {
            alert("Not deleted please try again !")
        })

    }
})