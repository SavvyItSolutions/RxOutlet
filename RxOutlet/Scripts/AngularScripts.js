
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
            url: "http://rxoutlet.azurewebsites.net/api/RxOutlet/Druglist",
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
        });
    }]);


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
            url: '../api/rxoutlet/UploadingPrescription',
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


$("#btnDel").click(function () {
    var PrescriptionDeatils = {
        "title": "Pre1",
        "description": "desc"
    };

    $.ajax({
        type: "POST",
        url: '../api/rxoutlet/UploadingPrescription',
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


var bla = $('#txt_name').val();

//Set
$('#txt_name').val(bla);

$("#btnRegister").click(function () {
    var Registration = {
        "Name": $('#txtName').val(),
        "Email": $('#txtEmail').val(),
        "PhoneNumber": $('#txtMobileNum').val(),
        "Password": $('#txtPassword').val(),
        "Captcha": $('#txtCaptcha').val()
    };

    $.ajax({
        type: "POST",
        url: '../api/rxoutlet/Registration',
        data: JSON.stringify(Registration),
        contentType: "application/json;charset=utf-8",
        sucess: function (data, status, xhr) {
            alert("The Result is : " + status + ":" + data);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
});

