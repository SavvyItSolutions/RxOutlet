
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





var search = {
    SearchText: 'asp',
    Type: [4, 2, 7],
    PageStart: 4,
    PageSize: 10
};



var app = angular.
    module("Drugs", ['ui.bootstrap','ui.grid', 'ui.grid.pagination','ui.grid.selection']).
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
        url: 'http://rxoutlet.azurewebsites.net/api/RxOutlet/Registration',
      // url: '../api/RxOutlet/Registration',
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



$("#btnLogin").click(function () {
    var isChecked = document.getElementById("chkbxRememberMe").checked;
    var Login = {
        "Email": $('#txtLoginEmail').val(),
        "Password":$('#txtLoginPwd').val(),
        "RememberMe": isChecked
    };

    var Email = $('#txtLoginEmail').val();
    var pswd=$('#txtLoginPwd').val();
 
    $.ajax({
        type: "POST",
       url: 'http://rxoutlet.azurewebsites.net/api/RxOutlet/Login/',
    //  url: 'http://localhost:64404/api/RxOutlet/Login/',
        data: JSON.stringify(Login),
        contentType: "application/json;charset=utf-8",
        success: function (data, status, xhr) {
            if (Email == 'test@gmail.com' && pswd == 'test') {
                window.location.href = "http://rxoutlet.azurewebsites.net/Admin/AdminPage";
              //  window.location.href = "http://localhost:64404/Admin/AdminPage"
            }
            else
                window.location.href = "http://rxoutlet.azurewebsites.net/Prescription/Upload";
            //    window.location.href = "http://localhost:64404/Prescription/Upload";

        },
        error: function (err) {
            alert("error - " + err);
        },
      

    });

  

    //$("#txtLoginEmail").val("");
    //$("#txtLoginPwd").val("");
    //if ($("txtLoginPwd").val() ='') {
    //    alert("Not a valid Number");
    //} else { }
  
});


//app.service("service", function ($http) {
//    //Function to call get genre web api call  
//    this.GetEmployee = function () {
//        var req = $http.get('http://localhost:64404/api/RxOutlet/GetPrescriptionList');
//        return req;
//    }
//});



app.service("employeeservice", function ($http) {
    //Function to call get genre web api call  
    this.GetEmployee = function () {
        var req = $http.get('api/EmployeesAPI');
        return req;
    }
});

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

