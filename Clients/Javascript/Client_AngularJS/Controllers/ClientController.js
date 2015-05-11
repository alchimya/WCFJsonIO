/**
 * Created by Administrator on 12/03/2015.
 */
var clientController=angular.module('clientController',[]);
clientController.controller('ClientCtrl',function($scope,$http,$q){

    $scope.wcfAddress="http://localhost:60312/ServiceJSON.svc/MyMethod";

    $scope.inputData={
        Customer:{
            FirstName:'Steve',
            LastName: "Jobs"
        },
        Account:{UserName:'my_user_name',Password:'my_password'}
    };


    $scope.invokeWcf=function(wcfAddress,data){

        var deferred = $q.defer();
        $http({
            method: 'POST',
            headers:{'Content-Type':'application/json; charset=utf-8'},
            url:wcfAddress,
            data:JSON.stringify(data)

        })
            .success(function (data, status, headers, config) {
                deferred.resolve(data);
                console.log(data);
            })
            .error(function (data, status, headers, config) {
                deferred.reject(data);
                console.log(data);
            });
        return deferred.promise;

    };

});