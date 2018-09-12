
SpCam
    .controller('accCtrl', function ($q, $scope, $http, $window, $rootScope, $cookies, $location, accSvc) {

        $scope.uid = $cookies.uid;
        $scope.utoken = $cookies.utoken;
        var accBaseUrl = 'http://localhost:37364/';

        $scope.regUser = {};
        $scope.logn = {};

        $scope.hideSignInOptions = true;

        $scope.toSignInOrDashboard = function () {
            if ($cookies.uid && $cookies.utoken) {
                if ($cookies.urole == "Admin") {
                    $window.location.href = "/index.html";

                }
                else if ($cookies.urole == "Player") {
                    $window.location.href = "/PlayerIndex.html";

                } 
                else {
                    $window.location.href ='/Generalindex.html';
                }
            }
            else {
                alert('login failed');
            }
        }

        //register new user
        $scope.signUpUser = function () {
            var newUser = $scope.regUser;
            var User = {
                UserEmail: newUser.UserEmail,
                UserName: newUser.UserName,
                UserPassword: newUser.UserPassword,
                UserRole: 'Player'
            };
            accSvc.signUpUser(User)
                .then(function (data) {
                    alert(newUser.UserName + ",Your account has been created successfully. Click Ok to continue");
                    $window.location.href = "/Pages/PlayerInsert.html";
                })
        }

        $scope.getUserData = function () {
            $http.get(serviceBaseUrl + "odata/UserInfoes(" + $cookies.uid + ")"
            ).then(function (response) {
                $scope.user = response.data;
            }, function (error) {
                $scope.message = "Error : " + error.data;
            });
        }

        $scope.initialize = function () {
            $scope.current = {};
            //It Will Check Sign In Status
            if ($cookies.uid && $cookies.utoken) {
                $scope.hideSignInOptions = true;
            }
            else {
                $scope.hideSignInOptions = false;
            }
        }


        //login
        $scope.login = function () {
            var obj = { 'username': $scope.logn.Email, 'password': $scope.logn.UserPassword, 'grant_type': 'password' };

            Object.toparams = function ObjectsToParams(obj) {
                var p = [];
                for (var key in obj) {
                    p.push(key + '=' + encodeURIComponent(obj[key]));
                }
                return p.join('&');
            }

            $http({
                method: 'POST',
                url: accBaseUrl + "Token",
                data: Object.toparams(obj),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            }).then(function (response) {
                $cookies.uid = response.data.userid;
                $cookies.utoken = response.data.access_token;
                $cookies.urole = response.data.role;

                $scope.username = response.data.role;
                $scope.initialize();
                console.log($cookies);
                console.log($scope.hideSignInOptions);
                //$location.path('/product');

                //$scope.getUserData();
                $scope.toSignInOrDashboard();
            }, function () {
                $scope.message = "Username or Password is invalid!";
            });
        }

        //logout
        $scope.logout = function () {
            $scope.current = null;
            console.log($cookies);
            $cookies.uid = undefined;
            $cookies.urole = undefined;
            $cookies.utoken = undefined;
            $scope.initialize();
            console.log($cookies);
            console.log($scope.hideSignInOptions);

            $location.path('/Generalindex.html');
        }

    });