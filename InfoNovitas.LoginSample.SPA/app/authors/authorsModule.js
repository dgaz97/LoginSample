angular.module('authors', [])
    .controller('authorsOverviewCtrl', function ($scope, $http) {
        $http.get(serviceBase + "api/authors").success(function (result) {
            $scope.authors = result.authors;
        });
    })
    .controller('newAuthorCtrl', function ($scope, $http, userInfoService, $state) {
       
        $scope.addNewAuthor= function () {
                $http.post(serviceBase + "api/authors", $scope.author).then(function () {
                    $state.go('authorsOverview');
         });
        }
    })
    .controller('updateProductCtrl', function ($scope, $http, userInfoService, $state) {

        $scope.updateProduct = function () {
             $http.put(serviceBase + "api/authors", product).then(function () {
                 $state.go("productsOverview");
                });
        }
    });


