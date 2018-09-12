/// <reference path="../angular.js" />
/// <reference path="employeeservice.js" />

app.controller("EmployeeCtrl", function ($scope, EmployeeService) {
    loadEmployee();
    $scope.EmpList = true;
    function loadEmployee() {
        var GetRecord = EmployeeService.getAllEmployee();
        GetRecord.then(function (res) {
            $scope.AllEmployees = res.data.value;
        }, function () {
            alert("Data not retrive");
        })
    };
    $scope.CreateNew = function () {
        $scope.InsertEmployee = true;
        $scope.EmpList = false;
        $scope.divupdate = false;
        $scope.divDelete = false;
    }
    $scope.CloseInsert = function () {
        $scope.InsertEmployee = false;
        $scope.EmpList = true;
        $scope.divupdate = false;
        $scope.divDelete = false;
    }
    $scope.CloseUpdate = function () {
        $scope.InsertEmployee = false;
        $scope.EmpList = true;
        $scope.divupdate = false;
        $scope.divDelete = false;
    }
    $scope.CloseDelete = function () {
        $scope.InsertEmployee = false;
        $scope.EmpList = true;
        $scope.divupdate = false;
        $scope.divDelete = false;
    }
    $scope.insertData = function () {
        var Employee = {
            Name: $scope.Name,
            Age: $scope.Age,
            Gender: $scope.Gender,
            Email: $scope.Email,
            Phone: $scope.Phone,
            PresentAddress: $scope.PresentAddress,
            ParmanentAddress: $scope.ParmanentAddress,
            NID: $scope.NID
        };
        var inst = EmployeeService.insertEmployee(Employee);
        inst.then(function (res) {
            loadEmployee();           
            alert("Insert success")           
            $scope.InsertEmployee = false;
            $scope.EmpList = true;
        }, function () {
            alert("Not Inserted please try again !")
        })
    }
    $scope.updateData = function () {
        var Employee = {
            EmployeeId: $scope.EmployeeId,
            Name: $scope.Name,
            Age: $scope.Age,
            Gender: $scope.Gender,
            Email: $scope.Email,
            Phone: $scope.Phone,
            PresentAddress: $scope.PresentAddress,
            ParmanentAddress: $scope.ParmanentAddress,
            NID: $scope.NID
        };
        var upd = EmployeeService.updateEmployee(Employee);
        upd.then(function (res) {
            loadEmployee();
            alert("Updated successfull")
            $scope.divupdate = false;
            $scope.EmpList = true;
        }, function () {
            alert("Not Updated please try again !")
        })

    }
    $scope.updateEmployee = function (emp) {
        $scope.divupdate = true;
        $scope.EmpList = false;
        $scope.divDelete = false;
        $scope.EmployeeId = emp.EmployeeId
        $scope.Name = emp.Name;
        $scope.Age = emp.Age;
        $scope.Gender = emp.Gender;
        $scope.Email = emp.Email;
        $scope.Phone = emp.Phone;
        $scope.PresentAddress = emp.PresentAddress;
        $scope.ParmanentAddress = emp.ParmanentAddress;
        $scope.NID = emp.NID;


    }

    $scope.deleteEmployee = function (emp) {
        $scope.divDelete = true;
        $scope.divupdate = false;
        $scope.EmpList = false;
        $scope.EmployeeId = emp.EmployeeId;
        $scope.Name = emp.Name;
        $scope.Age = emp.Age;
        $scope.Gender = emp.Gender;
        $scope.Email = emp.Email;
        $scope.Phone = emp.Phone;
        $scope.PresentAddress = emp.PresentAddress;
        $scope.ParmanentAddress = emp.ParmanentAddress;
        $scope.NID = emp.NID;
    }
    $scope.deleteData = function () {
        var Employee = {
            EmployeeId: $scope.EmployeeId,
            Name: $scope.Name,
            Age: $scope.Age,
            Gender: $scope.Gender,
            Email: $scope.Email,
            Phone: $scope.Phone,
            PresentAddress: $scope.PresentAddress,
            ParmanentAddress: $scope.ParmanentAddress,
            NID: $scope.NID
        };
        var upd = EmployeeService.deleteEmployee(Employee);
        upd.then(function (res) {
            loadEmployee();
            alert("Delete successfull")
            $scope.divDelete = false;
            $scope.divupdate = false;
            $scope.EmpList = true;
        }, function () {
            alert("Not deleted please try again !")
        })

    }
})