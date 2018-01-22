var FinancialManagerApp = angular.module('FinancialManagerApp', ['isoCurrency']);
FinancialManagerApp.controller('TransactionController',
    [
        '$scope', '$http', function ($scope, $http) {

            $scope.transactions = null;
            $scope.currencyList = null;

            //get currency list
            $http({
                method: 'POST',
                url: '/Home/GetCurrencyList'
            }).then(function (success) {
                $scope.currencyList = success.data;
            },
                function (error) {
                });

            //get categories
            $http({
                method: 'POST',
                url: '/Home/GetTransactions'
            }).then(function (success) {
                $scope.transactions = success.data;
                    $('#categories').show();
                    $('#spinner').hide();

                },
                function (error) {
                });

        }]);