/// <reference path="../angular.js" />
/// <reference path="../module/module.js" />

app.service("EmployeeService", function ($http) {
    this.getAllEmployee = function () {
        return $http.get("http://localhost:37364/odata/Employees")
    };
    this.insertEmployee = function (Employee) {
        var req = $http({
            method: 'Post',
            url: 'http://localhost:37364/odata/Employees',
            data: Employee
        })
        return req;
    }
    this.updateEmployee = function (Employee) {
        var res = $http({
            method: 'Put',
            url: 'http://localhost:37364/odata/Employees' + '(' + Employee.EmployeeId + ')',
            data: Employee

        })
        return res;
    }
    this.deleteEmployee = function (Employee) {
        var res = $http({
            url: 'http://localhost:37364/odata/Employees' + '(' + Employee.EmployeeId + ')',
            method: 'DELETE',
            data: Employee
        })
        return res;
    }
})