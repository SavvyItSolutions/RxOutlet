
    $(function () {

        $("#dialog-modal").dialog({
            autoOpen: false,
            modal:true,// to make background html page disable when popup get opened.
            width: 400,
            height:400,

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

        
var search = {
    SearchText: 'asp',
    Type: [4, 2, 7],
    PageStart: 4,
    PageSize: 10
};


var app = angular.
    module("Drugs", ['ui.bootstrap']).
    controller("DisplayDrugInfo", ['$log', '$scope', '$http', function ($log, $scope, $http) {
        $http({
            method: 'Get',
            url: "http://localhost:64404/api/RxOutlet/Druglist",
            data: JSON.stringify(search)
        }).then(function (response) {
            $scope.Drug = response.data;

            $scope.viewby = 10;
            $scope.totalItems = response.data.DrugList.length;
            console.log(response.data.DrugList.length);
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

            //    alert(response.data);
            //console.log("DrugObject"+response.data);
            //console.log("DrugList" + response.data.DrugList);
            //console.log("DrugName" + response.data.DrugList[1].DrugName);
        });
    }]);


app.controller("SupplierNameCntrl", ['$log', '$scope', '$http', function ($log, $scope, $http) {
    $http({
        method: 'Get',
        url: "http://localhost:64404/api/RxOutlet/GetSupplierName",
        data: JSON.stringify(search)
    }).then(function (response) {
        $scope.SuppilerName = response.data;
        alert(response.data.length);
        console.log("DrugObject" + response.data);
        console.log("DrugList" + response.data.DrugList);

        //console.log("DrugName" + response.data.DrugList[1].DrugName);
        //    console.log("length" + $scope.SuppilerName.length);
        //    for (var i = 0; i <= $scope.SuppilerName.length; i++) {
        //        console.log($scope.items.length);
        //        if ($scope.selectedName.value === $scope.items[i].name) {
        //            console.log($scope.items[i].name + "forif" + true);
        //            break;
        //        }
        //        else {
        //            console.log($scope.items[i].name + "forelse " + false);
        //            break;
        //        }
        //    }


    });

    
}]);


app.controller("SearchDrugCntrl", ['$log', '$scope', '$http', function ($log, $scope, $http) {
    $http({
        method: 'Get',
        url: "http://localhost:64404/api/RxOutlet/GetDrugNamesSearch",
        data: JSON.stringify(search)
    }).then(function (response) {
        $scope.SearchDrug = response.data;
        alert(response.data.length);
        console.log("DrugSearchObject" + response.data);
        console.log("DrugSearchList" + response.data.DrugList);
    });
}]);



$(document).ready(function () {
    $.ajax({

        url: "http://localhost:64404/api/RxOutlet/Druglist",
        success: function (data) {
            var List = [];
            //alert(data);
            for (i = 0; i < data.DrugList.length; i++) {
                List.push(data.DrugList[i].DrugName)
            }
            $('#autocomplete').autocomplete({
                lookup: List,
                onSelect: function (suggestion) {
                    alert(suggestion.DrugList);
                    var thehtml = '<strong>Currency Name:</strong> ' + suggestion.DrugList + ' <br> <strong>Symbol:</strong> ' + suggestion.data;
                    $('#outputcontent').html(thehtml);
                }
            });
            //$("#myText").autocomplete({
            //    source: List,
            //});
        },
        error: function (msg) { alert("error"); alert(msg); }
    });
});

