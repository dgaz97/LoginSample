angular.module('products', [])
    .controller('productsOverviewCtrl', function ($scope, $http, Service) {
        $http.get(serviceBase + "api/products").success(function (products) {
            $scope.products = products;
        });

        $scope.update = function (br) {
            var data = $scope.showdetails(br);
            $scope.foo = Service.foo;
            Service.foo = data;
        }
         $scope.showdetails = function(id){
         var found = $scope.products.filter(function(product){ return product.id === id });
         return found;
     };

    })
    .controller('newProductCtrl', function ($scope, $http, userInfoService, $state) {
        $scope.product = {
            price: 0
        }
        $scope.addNewProduct = function () {
                $http.post(serviceBase + "api/products", $scope.product).then(function () {
                    $state.go('productsOverview');
                });
        }
    })
    .controller('updateProductCtrl', function ($scope, $http, userInfoService, $state, Service) {
        var product = Service.foo[0];
        $scope.name = product.name
        $scope.description = product.description;
        $scope.price = product.price;

        $scope.updateProduct = function () {
            product.name = $scope.name;
            product.description = $scope.description;
            product.price = $scope.price;

             $http.put(serviceBase + "api/products", product).then(function () {
                 $state.go("productsOverview");
                });
        }
    });


