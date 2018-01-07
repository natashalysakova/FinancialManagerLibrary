var FinancialManagerApp = angular.module('FinancialManagerApp', ['isoCurrency']);
FinancialManagerApp.controller('CategoryController',
    [
        '$scope', '$http', function ($scope, $http) {

            $scope.categories = null;
            $scope.currencyList = null;
            $scope.name = "";
            $scope.plannedAmount = 0;
            $scope.currency = "UAH";

            //get currency list
            $http({
                method: 'POST',
                url: '/Home/GetCurrencyList'
            }).then(function (success) {
                $scope.currencyList = success.data;
            },
                function (error) {
                });
            $http({
                method: 'POST',
                url: '/Home/GetCategories'
            }).then(function (success) {
                $scope.categories = success.data;
            },
                function (error) {
                });

            $scope.addCategory = function () {

                $scope.inputModel = {
                    Name: $scope.name,
                    PlannedAmount: $scope.plannedAmount,
                    Currency: $scope.currency
                };

                $http.post('/Home/AddCategory', { model: $scope.inputModel })
                    .then(
                    function (success) {
                        // handle success here
                        $scope.categories = success.data;
                    },
                    function (error) {
                    });
            };

            $scope.deleteCategory = function (item) {
                $http.post('/Home/DeleteCategory', { id: item.Id })
                    .then(
                    function (data, status, headers, config) {
                        // handle success here
                        if (data.status === 200) {
                            var index = $scope.categories.indexOf(item);
                            $scope.categories.splice(index, 1);
                        }
                    },
                    function (error) {
                    });
            };

            $scope.makeEditable = function (item) {
                var selector = $('#categories #' + item.Id);
                var editElements = $(selector).find('.edit');
                editElements.show();
                $(selector).find('.view').hide();
            }

            $scope.makeReadonly = function (item) {
                var selector = $('#categories #' + item.Id);
                $(selector).find('.view').show();
                $(selector).find('.edit').hide();
            }

            $scope.saveChanges = function (item) {

                $scope.inputModel = {
                    Id: item.Id,
                    Name: item.Name,
                    PlannedAmount: item.PlannedAmount,
                    Currency: item.Currency
                };

                $http.post('/Home/EditCategory', { model: $scope.inputModel })
                    .then(
                        function (success) {
                            // handle success here
                            $scope.categories = success.data;
                            $scope.makeReadonly(item);
                        },
                        function (error) {
                        });
            }
        }



    ]);


