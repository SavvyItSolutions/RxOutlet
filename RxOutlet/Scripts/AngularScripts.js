
$(document).ready(function ()    {
          $("#dialog-modal").dialog({
              autoOpen: false,
              modal: true,// to make background html page disable when popup get opened.
              width: 400,
              height: 400,

              show: {
                  effect: "shake",
                  duration: 100
              },
              hide: {
                  effect: "explode",
                  duration: 1000
              }
          });
          $("#modal-opener").click(function () {
              $("#dialog-modal").dialog("open");

          });
          });



//$("#dialog-modal").dialog({
//    autoOpen: false,
//    modal: true,// to make background html page disable when popup get opened.
//    width: 400,
//    height: 400,

//    show: {
//        effect: "shake",
//        duration: 100
//    },
//    hide: {
//        effect: "explode",
//        duration: 1000
//    }
//});
//$("#modal-opener").click(function () {
//    $("#dialog-modal").dialog("open");

//});


        

var search = {
    SearchText: 'asp',
    Type: [4, 2, 7],
    PageStart: 4,
    PageSize: 10
};



var app = angular.
    module("Drugs", ['ui.bootstrap','ui.grid', 'ui.grid.pagination','ui.grid.selection','ngTouch']).
    controller("DisplayDrugInfo", ['$log', '$scope', '$http', function ($log, $scope, $http) {
        $http({
            method: 'Get',
            url: "http://rxoutlet.azurewebsites.net/api/RxOutlet/Druglist",
            data: JSON.stringify(search)
        }).then(function (response) {
            $scope.Drug = response.data;
            $scope.viewby = 10;
            $scope.totalItems = response.data.DrugList.length;
         //   console.log(response.data.DrugList.length);
            $scope.currentPage = 4;
            $scope.itemsPerPage = $scope.viewby;
            $scope.maxSize = 5; //Number of pager buttons to show
            $scope.setPage = function (pageNo) {
                $scope.currentPage = pageNo;
            };
            $scope.pageChanged = function () {
                console.log('Page changed to: ' + $scope.currentPage);
            };
            $scope.setItemsPerPage = function (num) {
                $scope.itemsPerPage = num;
                $scope.currentPage = 1; //reset to first paghe
            }
        });
    }]);



/////// ng grid basic  ---- Working 


//app.controller("ngbasicCntrl", ['$scope', function ($scope) {
//    $scope.myData = [{
//        "firstName": "Cox",
//        "lastName": "Carney",
//        "company": "Enormo",
//        "employed": true
//    }, {
//        "firstName": "Lorraine",
//        "lastName": "Wise",
//        "company": "Comveyer",
//        "employed": false
//    }, {
//        "firstName": "Nancy",
//        "lastName": "Waters",
//        "company": "Fuelton",
//        "employed": false
//    }];
//}]);



/////// ng grid basic  ---- Working 




////// ng Grid CONNECT TO REST API 

app.service('ProductsService', ['$http', ProductsService]);
app.service('DrugService', ['$http', DrugService]);
   
//   function ProductsService($http) {
//       var self = this;
//       //// not working with the api of our type 
//       var baseUrl = 'HTTPS://API.BACKAND.COM/1/OBJECTS/';
//       var anonymousToken = {
//           'AnonymousToken': '78020290-5df3-44b8-9bdb-7b3b4fea2f25'
//       };
//       var objectName = 'products';

     

//       self.readAll = function (pageSize, pageNumber) {
//           return $http({
//               method: 'GET',
//               url: baseUrl + objectName,
//               params: {
//                   pageSize: pageSize,
//                   pageNumber: pageNumber
//               },
//               headers: anonymousToken
//           }).then(function (response) {
//               return response.data;
//           });
//       };
//       self.readOne = function (id) {
//           return $http({
//               method: 'GET',
//               url: baseUrl + objectName + '/' + id,
//               headers: anonymousToken
//           }).then(function (response) {
//               return response.data;
//           });
//       };
//       self.create = function (data) {
//           return $http({
//               method: 'POST',
//               url: baseUrl + objectName,
//               data: data,
//               params: {
//                   returnObject: true
//               },
//               headers: anonymousToken
//           }).then(function (response) {
//               return response.data;
//           });
//       };
//       self.update = function (id, data) {
//           return $http({
//               method: 'PUT',
//               url: baseUrl + objectName + '/' + id,
//               data: data,
//               headers: anonymousToken
//           }).then(function (response) {
//               return response.data;
//           });
//       };
//       self.delete = function (id) {
//           return $http({
//               method: 'DELETE',
//               url: baseUrl + objectName + '/' + id,
//               headers: anonymousToken
//           });
//       };
//   };


//   app.controller("ngAPICtrl", ['ProductsService', '$scope', function (ProductsService, $scope) {
//       $scope.gridOptions = {
//           excludeProperties: '__metadata',
//       };

//       $scope.load = function () {
//           ProductsService.readAll().then(function (response) {
//               $scope.gridOptions.data = response.data;
//           });
//       }

//       $scope.load();
//   }]);


////// ng Grid CONNECT TO REST API 




   
////// ng Grid Pagination


  

//   function ProductsService($http) {

//       var self = this;
//       var baseUrl = 'https://api.backand.com/1/objects/';
//       var anonymousToken = {
//           'AnonymousToken': '78020290-5df3-44b8-9bdb-7b3b4fea2f25'
//       };

//       var objectName = 'products';

//       self.readAll = function (pageSize, pageNumber) {
//           return $http({
//               method: 'GET',
//               url: baseUrl + objectName,
//               params: {
//                   pageSize: pageSize,
//                   pageNumber: pageNumber
//               },
//               headers: anonymousToken
//           }).then(function (response) {
//               return response.data;
//           });
//       };

//       self.readOne = function (id) {
//           return $http({
//               method: 'GET',
//               url: baseUrl + objectName + '/' + id,
//               headers: anonymousToken
//           }).then(function (response) {
//               return response.data;
//           });
//       };

//       self.create = function (data) {
//           return $http({
//               method: 'POST',
//               url: baseUrl + objectName,
//               data: data,
//               params: {
//                   returnObject: true
//               },
//               headers: anonymousToken
//           }).then(function (response) {
//               return response.data;
//           });
//       };

//       self.update = function (id, data) {
//           return $http({
//               method: 'PUT',
//               url: baseUrl + objectName + '/' + id,
//               data: data,
//               headers: anonymousToken
//           }).then(function (response) {
//               return response.data;
//           });
//       };

//       self.delete = function (id) {
//           return $http({
//               method: 'DELETE',
//               url: baseUrl + objectName + '/' + id,
//               headers: anonymousToken
//           });
//       };

//   };


//   app.controller("ngPaginationCtrl", ['ProductsService', '$scope', function (ProductsService, $scope) {
//       $scope.gridOptions = {
//           excludeProperties: '__metadata',
//           enablePaginationControls: false
//       };

//       $scope.pagination = {
//           pageSize: 5,
//           pageNumber: 1,
//           totalItems: null,
//           getTotalPages: function () {
//               return Math.ceil(this.totalItems / this.pageSize);
//           },
//           nextPage: function () {
//               if (this.pageNumber < this.getTotalPages()) {
//                   this.pageNumber++;
//                   $scope.load();
//               }
//           },
//           previousPage: function () {
//               if (this.pageNumber > 1) {
//                   this.pageNumber--;
//                   $scope.load();
//               }
//           }
//       }

//       $scope.load = function () {
//           ProductsService.readAll($scope.pagination.pageSize, $scope.pagination.pageNumber).then(function (response) {
//               $scope.gridOptions.data = response.data;
//               $scope.pagination.totalItems = response.totalRows;

//           });
//       }

//       $scope.load();
//   }]);

////// ng Grid Pagination




//// ng grid Filter 

   app.controller("FilterCntrl", ['ProductsService', '$scope', function (ProductsService, $scope) {
       $scope.sort = [];
       $scope.filter = [];
       $scope.pagination = {
           pageSize: 5,
           pageNumber: 1,
           totalItems: null,
           getTotalPages: function () {
               return Math.ceil(this.totalItems / this.pageSize);
           },
           nextPage: function () {
               if (this.pageNumber < this.getTotalPages()) {
                   this.pageNumber++;
                   $scope.load();
               }
           },
           previousPage: function () {
               if (this.pageNumber > 1) {
                   this.pageNumber--;
                   $scope.load();
               }
           }
       }

       $scope.gridOptions = {
           excludeProperties: '__metadata',
           enablePaginationControls: false,
           useExternalSorting: true,
           useExternalFiltering: true,
           enableFiltering: true,
           onRegisterApi: function (gridApi) {
               $scope.gridApi = gridApi;
               //declare the events




               $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                   $scope.sort = [];
                   angular.forEach(sortColumns, function (sortColumn) {
                       $scope.sort.push({
                           fieldName: sortColumn.name,
                           order: sortColumn.sort.direction
                       });
                   });
                   $scope.load();
               });


               $scope.gridApi.core.on.filterChanged($scope, function () {
                   $scope.filter = [];

                   var grid = this.grid;
                   angular.forEach(grid.columns, function (column) {
                       var fieldName = column.field;
                       var value = column.filters[0].term;
                       var operator = "contains";
                       if (value) {
                           if (fieldName == "id") operator = "equals";
                           else if (fieldName == "price") operator = "greaterThanOrEqualsTo";
                           $scope.filter.push({
                               fieldName: fieldName,
                               operator: operator,
                               value: value
                           })
                       }
                   });

                   $scope.load();
               });
           }
       };



       $scope.load = function () {
           ProductsService.readAll($scope.pagination.pageSize, $scope.pagination.pageNumber, $scope.sort, $scope.filter).then(function (response) {
               $scope.gridOptions.data = response.data;
               $scope.pagination.totalItems = response.totalRows;

           });
       }

       $scope.load();
   }]);


     
          

   function ProductsService($http) {

       var self = this;
       var baseUrl = 'https://api.backand.com/1/objects/';
       var anonymousToken = {
           'AnonymousToken': '78020290-5df3-44b8-9bdb-7b3b4fea2f25'
       };

       var objectName = 'products';

       self.readAll = function (pageSize, pageNumber, sort, filter) {
           return $http({
               method: 'GET',
              url: baseUrl + objectName,
               params: {
                   pageSize: pageSize,
                   pageNumber: pageNumber,
                   sort: sort,
                   filter: filter
               },
               headers: anonymousToken
           }).then(function (response) {
               return response.data;
           });
       };

       self.readOne = function (id) {
           return $http({
               method: 'GET',
               url: baseUrl + objectName + '/' + id,
               headers: anonymousToken
           }).then(function (response) {
               return response.data;
           });
       };

       self.create = function (data) {
           return $http({
               method: 'POST',
               url: baseUrl + objectName,
               data: data,
               params: {
                   returnObject: true
               },
               headers: anonymousToken
           }).then(function (response) {
               return response.data;
           });
       };

       self.update = function (id, data) {
           return $http({
               method: 'PUT',
               url: baseUrl + objectName + '/' + id,
               data: data,
               headers: anonymousToken
           }).then(function (response) {
               return response.data;
           });
       };

       self.delete = function (id) {
           return $http({
               method: 'DELETE',
               url: baseUrl + objectName + '/' + id,
               headers: anonymousToken
           });
       };

   };

///// ng grid Filter




///// ng grid with our api url 


// https://github.com/angular-ui/ui-grid/wiki/Defining-columns   --- column definitions and propertie





   app.controller("ServiceCntrl", ['DrugService', '$scope', function (DrugService, $scope) {

       $scope.sort = [];
       $scope.filter = [];
       $scope.pagination = {
           pageSize:5,
           pageNumber: 1,
           totalItems: null,
           getTotalPages: function () {
               return Math.ceil(this.totalItems / this.pageSize);
           },
           nextPage: function () {
               if (this.pageNumber < this.getTotalPages()) {
                   this.pageNumber++;
                   $scope.load();
               }
           },
           previousPage: function () {
               if (this.pageNumber > 1) {
                   this.pageNumber--;
                   $scope.load();
               }
           }
       }
     
      
     
       $scope.gridOptions = {
           excludeProperties: '__metadata',
           columnDefs: [
              { field: 'Select',
      
       cellTemplate: '<div class="ngSelectionCell"><input tabindex="-1" class="ngSelectionCheckbox" type="checkbox" ng-checked="row.selected" /> </div>'
   },
              { field: 'DrugTypeID', displayName: 'DrugTypeID', width: "25%" },
      { field: 'DrugCount', displayName: 'DrugCount', visible: true },
       { field: 'DrugTypeName', displayName: 'DrugTypeName', width: "25%" },
        {
            field: 'edit',
            cellTemplate: '<button id="editBtn" type="button" class="btn-small glyphicon glyphicon-pencil" ng-click="grid.appScope.editUser(row.entity)" ></button> '
        },



       ],
           enablePaginationControls: false,
           useExternalSorting: true,
           useExternalFiltering: true,
           enableFiltering: true,
           onRegisterApi: function (gridApi) {
               $scope.gridApi = gridApi;
               //declare the events
               $scope.toggleCheckerAll = function (checked) {
                   for (var i = 0; i < $scope.gridData.length; i++) {
                       $scope.gridData[i].checker = checked;
                   }
               };

               $scope.toggleChecker = function (checked) {
                   var rows = $scope.gridOptions.$gridScope.renderedRows,
                       allChecked = true;

                   for (var r = 0; r < rows.length; r++) {
                       if (rows[r].entity.checker !== true) {
                           allChecked = false;
                           break;
                       }
                   }
                   if (!$scope.gridOptions.$gridScope.checker)
                       $scope.gridOptions.$gridScope.checker = {};

                   $scope.gridOptions.$gridScope.checker.checked = allChecked;
               };


               $scope.editUser = function (data) {
                   alert('Edit Value' );
               }
               $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                   $scope.sort = [];
                   angular.forEach(sortColumns, function (sortColumn) {
                       $scope.sort.push({
                           fieldName: 'DrugTypeID',
                           //fieldName: sortColumn.name,
                           order: sortColumn.sort.direction
                       });
                   });
                   $scope.load();
               });

               $scope.gridApi.core.on.filterChanged($scope, function () {
                   $scope.filter = [];

                   var grid = this.grid;
                   angular.forEach(grid.columns, function (column) {
                       var fieldName = column.field;
                       var value = column.filters[0].term;
                       var operator = "contains";
                       if (value) {
                       
                           if (fieldName == "DrugTypeID") operator = "equals";
                           else if (fieldName == "DrugCount") operator = "greaterThanOrEqualsTo";
                           $scope.filter.push({
                               fieldName: fieldName,
                               operator: operator,
                               value: value
                           })
                       }
                   });

                   $scope.load();
               });
           }
       };

       $scope.load = function () {
           DrugService.readAll($scope.pagination.pageSize, $scope.pagination.pageNumber, $scope.sort, $scope.filter).then(function (response) {
               $scope.gridOptions.data = response.DrugList;
               $scope.pagination.totalItems = response.DrugList.length;

           });
       }

       $scope.load();
   }]);


   function DrugService($http) {

       var self = this;
       var baseUrl = 'http://localhost:64404/api/RxOutlet/GetDrugTypes';
       var anonymousToken = {
           'AnonymousToken': '78020290-5df3-44b8-9bdb-7b3b4fea2f25'
       };

       var objectName = 'products';

       self.readAll = function (pageSize, pageNumber, sort, filter) {
           return $http({
               method: 'GET',
               url: baseUrl ,
               params: {
                   pageSize: pageSize,
                   pageNumber: pageNumber,
                   sort: sort,
                   filter: filter
               },
               headers: anonymousToken
           }).then(function (response) {
               return response.data;
           });
       };

       self.readOne = function (id) {
           return $http({
               method: 'GET',
               url: baseUrl + objectName + '/' + id,
               headers: anonymousToken
           }).then(function (response) {
               return response.data;
           });
       };

       self.create = function (data) {
           return $http({
               method: 'POST',
               url: baseUrl + objectName,
               data: data,
               params: {
                   returnObject: true
               },
               headers: anonymousToken
           }).then(function (response) {
               return response.data;
           });
       };

       self.update = function (id, data) {
           return $http({
               method: 'PUT',
               url: baseUrl + objectName + '/' + id,
               data: data,
               headers: anonymousToken
           }).then(function (response) {
               return response.data;
           });
       };

       self.delete = function (id) {
           return $http({
               method: 'DELETE',
               url: baseUrl + objectName + '/' + id,
               headers: anonymousToken
           });
       };

   };





















   //app.controller("ServiceCntrl", ['DrugService', '$scope', function (DrugService, $scope) {
   //    $scope.sort = [];
   //    $scope.filter = [];
   //    $scope.pagination = {
   //        pageSize: 5,
   //        pageNumber: 1,
   //        totalItems: null,
   //        getTotalPages: function () {
   //            return Math.ceil(this.totalItems / this.pageSize);
   //        },
   //        nextPage: function () {
   //            if (this.pageNumber < this.getTotalPages()) {
   //                this.pageNumber++;
   //                $scope.load();
   //            }
   //        },
   //        previousPage: function () {
   //            if (this.pageNumber > 1) {
   //                this.pageNumber--;
   //                $scope.load();
   //            }
   //        }
   //    }


     
   //    $scope.gridOptions = {

   //        excludeProperties: '__metadata',
   //        enablePaginationControls: false,
   //        useExternalSorting: true,
   //        useExternalFiltering: true,
   //        enableFiltering: true,
   //   //          columnDefs: [
   //   //{field: 'DrugCount', displayName: 'DrugCount', visible:true},
   //   //{field:'DrugTypeID', displayName:'DrugTypeID',width: "10%"},
   //   // { field: 'DrugTypeName', displayName: 'DrugTypeName', width: "60%" }
   //   //     ],
   //        onRegisterApi: function (gridApi) {
   //            $scope.gridApi = gridApi;
   //            //declare the events

   //            $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
   //                $scope.sort = [];
   //                angular.forEach(sortColumns, function (sortColumn) {
   //                    $scope.sort.push({
   //                        fieldName: sortColumn.name,
   //                        order: sortColumn.sort.direction
   //                    });
   //                });
   //                $scope.load();
   //            });

   //            $scope.gridApi.core.on.filterChanged($scope, function () {
   //                $scope.filter = [];

   //                var grid = this.grid;
   //                angular.forEach(grid.columns, function (column) {
   //                    var fieldName = column.field;
   //                    var value = column.filters[0].term;
   //                    var operator = "contains";
   //                    if (value) {
   //                        if (fieldName == "DrugTypeID") operator = "equals";
   //                        else if (fieldName == "DrugCount") operator = "greaterThanOrEqualsTo";
   //                        $scope.filter.push({
   //                            fieldName: fieldName,
   //                            operator: operator,
   //                            value: value
   //                        })
   //                    }
   //                });

   //                $scope.load();
   //            });
   //        }
   //    };



   //    $scope.load = function () {
   //        DrugService.readAll($scope.pagination.pageSize, $scope.pagination.pageNumber, $scope.sort, $scope.filter).then(function (response) {
   //            $scope.gridOptions.data = response.DrugList;
   //            $scope.pagination.totalItems = response.DrugList.length;//response.totalRows;

   //        });
   //    }

   //    $scope.load();
   //}]);


   //function DrugService($http) {

   //    var self = this;
   //    var baseUrl = 'http://localhost:64404/api/RxOutlet/GetDrugTypes';
   //    var anonymousToken = {
   //        'AnonymousToken': '78020290-5df3-44b8-9bdb-7b3b4fea2f25'
   //    };

   //    var objectName = 'products';

   //    self.readAll = function (pageSize, pageNumber, sort, filter) {
   //        return $http({
   //            method: 'GET',
   //            url: baseUrl,
   //            params: {
   //                pageSize: pageSize,
   //                pageNumber: pageNumber,
   //                sort: sort,
   //                filter: filter
   //            },
   //            headers: anonymousToken
   //        }).then(function (response) {
   //            return response.data;
   //        });
   //    };

   //    self.readOne = function (id) {
   //        return $http({
   //            method: 'GET',
   //            url: baseUrl + objectName + '/' + id,
   //            headers: anonymousToken
   //        }).then(function (response) {
   //            return response.data;
   //        });
   //    };

   //    self.create = function (data) {
   //        return $http({
   //            method: 'POST',
   //            url: baseUrl + objectName,
   //            data: data,
   //            params: {
   //                returnObject: true
   //            },
   //            headers: anonymousToken
   //        }).then(function (response) {
   //            return response.data;
   //        });
   //    };

   //    self.update = function (id, data) {
   //        return $http({
   //            method: 'PUT',
   //            url: baseUrl + objectName + '/' + id,
   //            data: data,
   //            headers: anonymousToken
   //        }).then(function (response) {
   //            return response.data;
   //        });
   //    };

   //    self.delete = function (id) {
   //        return $http({
   //            method: 'DELETE',
   //            url: baseUrl + objectName + '/' + id,
   //            headers: anonymousToken
   //        });
   //    };

   //};


//// Smart Table


   app.controller("pipeCtrl", ['Resource', function (service) {

       var ctrl = this;

       this.displayed = [];

       this.callServer = function callServer(tableState) {

           ctrl.isLoading = true;

           var pagination = tableState.pagination;

           var start = pagination.start || 0;     // This is NOT the page number, but the index of item in the list that you want to use to display the table.
           var number = pagination.number || 10;  // Number of entries showed per page.

           service.getPage(start, number, tableState).then(function (result) {
               ctrl.displayed = result.data;
               tableState.pagination.numberOfPages = result.numberOfPages;//set the number of pages so the pagination can update
               ctrl.isLoading = false;
           });
       };

   }]);


   app.factory('Resource', ['$q', '$filter', '$timeout', function ($q, $filter, $timeout) {

       //this would be the service to call your server, a standard bridge between your model an $http

       // the database (normally on your server)
       var randomsItems = [];

       function createRandomItem(id) {
           var heroes = ['Batman', 'Superman', 'Robin', 'Thor', 'Hulk', 'Niki Larson', 'Stark', 'Bob Leponge'];
           return {
               id: id,
               name: heroes[Math.floor(Math.random() * 7)],
               age: Math.floor(Math.random() * 1000),
               saved: Math.floor(Math.random() * 10000)
           };

       }

       for (var i = 0; i < 1000; i++) {
           randomsItems.push(createRandomItem(i));
       }


       //fake call to the server, normally this service would serialize table state to send it to the server (with query parameters for example) and parse the response
       //in our case, it actually performs the logic which would happened in the server
       function getPage(start, number, params) {

           var deferred = $q.defer();

           var filtered = params.search.predicateObject ? $filter('filter')(randomsItems, params.search.predicateObject) : randomsItems;

           if (params.sort.predicate) {
               filtered = $filter('orderBy')(filtered, params.sort.predicate, params.sort.reverse);
           }

           var result = filtered.slice(start, start + number);

           $timeout(function () {
               //note, the server passes the information about the data set size
               deferred.resolve({
                   data: result,
                   numberOfPages: Math.ceil(filtered.length / number)
               });
           }, 1500);


           return deferred.promise;
       }

       return {
           getPage: getPage
       };

   }]);


//// smart table 





app.controller("SupplierNameCntrl", ['$log', '$scope', '$http', function ($log, $scope, $http) {
    $http({
        method: 'Get',
        url: "http://rxoutlet.azurewebsites.net/api/RxOutlet/GetSupplierName",
        data: JSON.stringify(search)
    }).then(function (response) {
        $scope.SuppilerName = response.data;
       // alert(response.data.length);
        console.log("DrugObject" + response.data);
        console.log("DrugList" + response.data.DrugList);

    });
}]);

app.controller("DrugTypeCntrl", ['$log', '$scope', '$http', function ($log, $scope, $http) {
    $http({
        method: 'Get',
        url: "http://rxoutlet.azurewebsites.net/api/RxOutlet/GetDrugTypes",
        data: JSON.stringify(search),
                
    }).then(function (response) {
        $scope.DrugType = response.data;
       // alert(response.data.length);
        console.log("DrugObject" + response.data);
        console.log("DrugList" + response.data.DrugList);
    });

}]);



app.controller("ProductDetailsCntrl", ['$log', '$scope', '$http', function ($log, $scope, $http) {
    function GetURLParameter(sParam) {
        var sPageURL = window.location.href;
        var indexOfLastSlash = sPageURL.lastIndexOf("/");

        if (indexOfLastSlash > 0 && sPageURL.length - 1 != indexOfLastSlash)
            return sPageURL.substring(indexOfLastSlash + 1);
        else
            return 0;
    }
    $http({
        method: 'Get',
        url: "http://rxoutlet.azurewebsites.net/api/RxOutlet/GetProductDetails/" + GetURLParameter("0"),
        data: JSON.stringify(search),
    }).then(function (response) {
        $scope.ProductInfo = response.data;
      //  alert(response.data.length);
        console.log("DrugObject" + response.data);
        console.log("DrugList" + response.data.DrugList.ImageNum);
    });
    $scope.qty = 1;
    $scope.increment = function () {
    $scope.qty++;
    };
    $scope.decrement = function () {
    $scope.qty--;
    };
}]);






app.controller("CartItemsCntrl", ['$log', '$scope', '$http', function ($log, $scope, $http) {
    
var usrName = "@HttpContext.Current.User.Identity.Name";
    
    $http({
        method: 'Get',
        url: "http://rxoutlet.azurewebsites.net/api/RxOutlet/GetCartItems/" + usrName,
        data: JSON.stringify(search),
    }).then(function (response) {
        $scope.CartItems = response.data;
       // alert(response.data.length);
        console.log("DrugObject" + response.data);
        console.log("DrugList" + response.data.DrugList);
    });
}]);



app.controller("PresListCntrl", ['$log', '$scope', '$http', function ($log, $scope, $http) {
    $http({
        method: 'Get',
        url: "http://rxoutlet.azurewebsites.net/api/RxOutlet/GetPrescriptionList",
        // url: "http://localhost:64404/api/RxOutlet/GetPrescriptionList",
        data: JSON.stringify(search),
    }).then(function (response) {
        $scope.PrescriptionList = response.data;
      //  alert(PrescriptionList.GetPrescriptionList.Title);

        // alert(response.data.length);
        console.log("DrugObject" + response.data);
        console.log("DrugList" + response.data.DrugList);
    });
}]);





$(document).ready(function () {
    $.ajax({

        url: "http://rxoutlet.azurewebsites.net/api/RxOutlet/GetDrugNamesSearch",
        success: function (data) {
            var List = [];
            //alert(data);
            for (i = 0; i < data.length; i++) {
                List.push(data[i].SupplierName)                    
            }
            $('#autocomplete').autocomplete({
                lookup: List
            });
        },
       // error: function (msg) { alert("error"); alert(msg); }
    });
});


var count = 1;
var countEl = document.getElementById("count");
function plus() {
    count++;
    countEl.value = count;
}
function minus() {
    if (count > 1) {
        count--;
        countEl.value = count;
    }
}



$(document).ready(function () {
    // This button will increment the value
    $('.qtyplus').click(function (e) {
        // Stop acting like a button
        e.preventDefault();
        // Get the field name
        fieldName = $(this).attr('field');
        // Get its current value
        var currentVal = parseInt($('input[name=' + fieldName + ']').val());
        // If is not undefined
        if (!isNaN(currentVal)) {
            // Increment
            $('input[name=' + fieldName + ']').val(currentVal + 1);
        } else {
            // Otherwise put a 0 there
            $('input[name=' + fieldName + ']').val(0);
        }
    });
    // This button will decrement the value till 0
    $(".qtyminus").click(function (e) {
        // Stop acting like a button
        e.preventDefault();
        // Get the field name
        fieldName = $(this).attr('field');
        // Get its current value
        var currentVal = parseInt($('input[name=' + fieldName + ']').val());
        // If it isn't undefined or its greater than 0
        if (!isNaN(currentVal) && currentVal > 0) {
            // Decrement one
            $('input[name=' + fieldName + ']').val(currentVal - 1);
        } else {
            // Otherwise put a 0 there
            $('input[name=' + fieldName + ']').val(0);
        }
    });
});


$(document).ready(function () {
   
    $(".btnSubmit").click(function () {
        alert("hi");
        var PrescriptionDeatils = {
            "title": "Pre1",
            "description": "desc"
        };

        $.ajax({
            type: "POST",
            url: 'http://rxoutlet.azurewebsites.net/api/rxoutlet/UploadingPrescription',
            // url: 'http://localhost:64404/api/rxoutlet/UploadingPrescription',
            data: JSON.stringify(PrescriptionDeatils),
            contentType: "application/json;charset=utf-8",
            sucess: function (data, status, xhr) {
                alert("The Result is : " + status + ":" + data);
            },
            error: function (xhr) {
                alert(xhr.responseText);
            }
        });
    });

});




$("#btnRegister").click(function () {

    var Registration = {
        "Name": $('#txtName').val(),
        "Email": $('#txtEmail').val(),
        "MobileNum": $('#txtMobileNum').val(),
        "Password":$('#txtPassword').val()
    };
    $.ajax({
        type: "POST",
        url: 'http://rxoutlet.azurewebsites.net/api/RxOutlet/SignUp',
      // url: '../api/RxOutlet/SignUp',
        data: JSON.stringify(Registration),
        contentType: "application/json;charset=utf-8",
        sucess: function (data, status, xhr) {
            //Id.value = "Thank you for Signing Up. We have sent an email to your authorized email address, xxx.<br>"
            //"Please activate the account by clicking the link in the email and login below.";
          //  window.location.href = "http://localhost:64404/Account/Login";
            window.location.href =   "http://rxoutlet.azurewebsites.net/Account/Login";

            $('#p1').show();


  
         
        },
        error: function (xhr) {
            alert("Error : "+xhr.responseText);
        }

   
    });

    //$("#txtName").val("");
    //$("#txtEmail").val("");
    //$("#txtMobileNum").val("");
    //$("#txtPassword").val("");sujeeth
  
    //$("#txtConfirmPassword").val("");
    //$("#txtCaptcha").val("");
});




          

     
  
      






//$("#btnLogin").click(function () {
//    var isChecked = document.getElementById("chkbxRememberMe").checked;
//    var Login = {
//        "Email": $('#txtLoginEmail').val(),
//        "Password":$('#txtLoginPwd').val(),
//        "RememberMe": isChecked
//    }; 
//    $.ajax({
//        type: "POST",
//      // url: 'http://rxoutlet.azurewebsites.net/api/RxOutlet/Login/',
//      url: 'http://localhost:64404/api/RxOutlet/Login/',
//      data: JSON.stringify(Login),
    
//      contentType: "application/json;charset=utf-8",
//      dataType: "json",
//      success: function (data) {
        

//      },
//      error: function () {
//          alert('error');

//      }

//      //error: function (  textStatus, errorThrown)  {
         
//      //    alert('inValid Login');
//      //},
//      //  success: function (data) {
//      //      alert('Valid Login');
//      //      //window.location.href = "http://localhost:64404/Prescription/Upload";
//      //  },
       
       
//        //error: function(xhr, textStatus, errorThrown) {
//        //    alert('Invalid Login');
//        //    window.location.href = "http://localhost:64404/Account/Login";
//        //}
//    });

  







    //$("#txtLoginEmail").val("");
    //$("#txtLoginPwd").val("");
    //if ($("txtLoginPwd").val() ='') {
    //    alert("Not a valid Number");
    //} else { }
  
//});







//app.service("service", function ($http) {
//    //Function to call get genre web api call  
//    this.GetEmployee = function () {
//        var req = $http.get('http://localhost:64404/api/RxOutlet/GetPrescriptionList');
//        return req;
//    }
//});



//app.service("employeeservice", function ($http) {
//    //Function to call get genre web api call  
//    this.GetEmployee = function () {
//        var req = $http.get('api/EmployeesAPI');
//        return req;
//    }
//});

//http://www.c-sharpcorner.com/article/filtering-in-ui-grid-with-angularjs-and-webapi/

//app.controller("DataController", function ($scope, service, $filter, $window) {
//    GetEmployee();

//    function GetEmployee() {
//        debugger
//        service.GetEmployee().then(function (result) {
//            $scope.Employees = result.data;
//            console.log($scope.Employees);
//        }, function (error) {
//            $window.alert('Oops! Something went wrong while fetching genre data.');
//        })
//    }
//    //Used to bind ui-grid    
//    $scope.selectedItem = null;
//    $scope.gridOptions = {
//        enableRowSelection: true,
//        paginationPageSizes: [5, 10, 20, 30, 40],
//        paginationPageSize: 10,
//        enableSorting: true,
//        columnDefs: [{
//            name: 'photo',
//            enableSorting: false,
//            field: 'PhotoPath',
//            cellTemplate: "<img width=\"50px\" ng-src=\"{{grid.getCellValue(row, col)}}\" lazy-src>"
//        }, {
//            name: 'First Name',
//            field: 'FirstName',
//            headerCellClass: 'tablesorter-header-inner'
//        }, {
//            name: 'Last Name',
//            field: 'LastName',
//            headerCellClass: 'tablesorter-header-inner'
//        }, {
//            name: 'Title',
//            field: 'Title',
//            headerCellClass: 'tablesorter-header-inner'
//        }, {
//            name: 'City',
//            field: 'City',
//            headerCellClass: 'tablesorter-header-inner'
//        }, {
//            name: 'Country',
//            field: 'Country',
//            headerCellClass: 'tablesorter-header-inner'
//        }, {
//            name: 'Notes',
//            field: 'Notes',
//            headerCellClass: 'tablesorter-header-inner'
//        }],
//        data: 'Employees'
//    };
//});



//$("#btnLogin").click(function () {
//    var isChecked = document.getElementById("chkbxRememberMe").checked;
//    var Login = {
//        "Email": $('#txtLoginEmail').val(),
//        "Password":$('#txtLoginPwd').val(),
//        "RememberMe": isChecked
//    };
//    var Email=$('#txtLoginEmail').valhttp://rxoutlet.azurewebsites.net/();
//    var pswd = $('#txtLoginPwd').val();
//    $.ajax({
//        type: 'POST',
//        url: 'http://rxoutlet.azurewebsites.net/api/RxOutlet/Login/',
//      //  url: 'http://localhost:64404/api/RxOutlet/Login/',
//        contentType: 'application/json; charset=utf-8',
//        data: JSON.stringify(Login),
//        dataType: 'text json',

//        success: function () {
          
//                if (Email == 'test@gmail.com' && pswd == 'test') {
                   
//                       window.location.href = "Admin/AdminPage";
//                    // window.location.href = "http://localhost:64404/Admin/AdminPage"
//                }
//                else
                    
//                window.location.href = "http://rxoutlet.azurewebsites.net/Prescription/Upload";
//               //  window.location.href = "http://localhost:64404/Prescription/Upload";
            
//        },
//        error: function(xhr, textStatus, errorThrown) {
//                    alert('Invalid Login');
//                    window.location.href = "http://rxoutlet.azurewebsites.net/Account/Login";
//                }
//    });
//});






app.controller("cntrl", function ($scope) {
    $scope.gridOptions = {
        paginationPageSizes: [25, 50, 75],
        paginationPageSize: 5,
        columnDefs: [
        { field: 'name' },
        { field: 'age' },
        { field: 'location' }
        ],
        onRegisterApi: function (gridApi) {
            $scope.grid1Api = gridApi;
        }
    };
    $scope.users = [
    { name: "Madhav Sai", age: 10, location: 'Nagpur' },
    { name: "Suresh Dasari", age: 30, location: 'Chennai' },
    { name: "Rohini Alavala", age: 29, location: 'Chenn ai' },
    { name: "Praveen Kumar", age: 25, location: 'Bangalore' },
    { name: "Sateesh Chandra", age: 27, location: 'Vizag' },
    { name: "Siva Prasad", age: 38, location: 'Nagpur' },
    { name: "Sudheer Rayana", age: 25, location: 'Kakinada' },
    { name: "Honey Yemineni", age: 7, location: 'Nagpur' },
    { name: "Mahendra Dasari", age: 22, location: 'Vijayawada' },
    { name: "Mahesh Dasari", age: 23, location: 'California' },
    { name: "Nagaraju Dasari", age: 34, location: 'Atlanta' },
    { name: "Gopi Krishna", age: 29, location: 'Repalle' },
    { name: "Sudheer Uppala", age: 19, location: 'Guntur' },
    { name: "Sushmita", age: 27, location: 'Vizag' }
    ];
    $scope.gridOptions.data = $scope.users;
});