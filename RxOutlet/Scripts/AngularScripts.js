
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



app.controller("PresListCntrl", ['$log', '$scope', '$http', function ($log, $scope, $http) {
    $http({
        method: 'Get',
        url: "http://rxoutlet.azurewebsites.net/api/RxOutlet/GetPrescriptionList",
        data: JSON.stringify(search),
    }).then(function (response) {
        $scope.PrescriptionList = response.data;
        alert(PrescriptionList.GetPrescriptionList.Title);

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



  

//$("#btnPrescriptionUpload").click(function () {
//    //e.preventDefault(); // <------------------ stop default behaviour of button
//    //var element = this;    
//    //$.ajax({
//    //    url: "/Prescription/Upload",
//    //    type: "POST",
    
//    //    dataType: "json",
//    //    traditional: true,
//    //    contentType: "application/json; charset=utf-8",
//    //    success: function (data) {
//    //        if (data.status == "Success") {
//    //            alert("Done");
//    //            $(element).closest("form").submit(); //<------------ submit form
//    //        } else {
//    //            alert("Error occurs on the Database level!");
//    //        }
//    //    },
//    //    error: function () {
//    //        alert("An error has occured!!!");
//    //    }
//    //});

//    //$.ajax({
//    //    type: "POST",
//    //    url:  '../api/rxoutlet/imagePath',
        
//    //    contentType: "application/json;charset=utf-8",
//    //    sucess: function (data,status, xhr) {
//    //        alert(data);
//    //    },
//    //    error: function (xhr) {
//    //        alert(xhr.responseText);
//    //    }
//    //});



//    //var path;
    
//    //var frm = $("#send-contact"),  // our form
//    //           url = frm.attr("GetImageURL"),  // our post action
//    //           data = frm.serialize();     // our data to be posted

//    //$.post(url, data, function (data) {
//    //    // data has our returned Json from our view
//    // path=   $("#txtPrescriptionDescription").text(data.imageUrl); // just to see it, do what you want
//    //   // no more loading as we have what we need
//    //});



//    var PrescriptionDeatils = {
//        "title": $('#txtPrescriptionTitle').val(),
//        "description": $("#txtPrescriptionDescription").val()
//    };
   
//    $.ajax({
//        type: "POST",
//        url: '../api/rxoutlet/UploadingPrescription',
//        data: JSON.stringify(PrescriptionDeatils),
//        contentType: "application/json;charset=utf-8",
//        success: function (data) {
//            if (data.status == "Success") {
//                alert("Done");
//                $(element).closest("form").submit(); //<------------ submit form
//            } else {
//                alert("Error occurs on the Database level!");
//            }
//        },
//        //sucess: function (data, status, xhr) {
//        //    alert("The Result is : " + status + ":" + data);
//        //},
//        error: function (xhr) {
//            alert(xhr.responseText);
//        }
//    });
//});


$("#btnRegister").click(function () {


    //function Encrypt(str) {
    //    if (!str) str = $('#txtPassword').val();
    //    str = (str == "undefined" || str == "null") ? "" : str;
    //    try {
    //        var key = 146;
    //        var pos = 0;
    //        ostr = '';
    //        while (pos < str.length) {
    //            ostr = ostr + String.fromCharCode(str.charCodeAt(pos) ^ key);
    //            pos += 1;
    //        }

    //        return ostr;
    //    } catch (ex) {
    //        return '';
    //    }
    //}

    var Registration = {
        "Name": $('#txtName').val(),
        "Email": $('#txtEmail').val(),
        "MobileNum": $('#txtMobileNum').val(),
        "Password":$('#txtPassword').val()
    };
    $.ajax({
        type: "POST",
        url: 'http://rxoutlet.azurewebsites.net/api/RxOutlet/Registration',
        //url: '../api/Account/Register',
        data: JSON.stringify(Registration),
        contentType: "application/json;charset=utf-8",
        sucess: function (data, status, xhr) {
          
        },
        error: function (xhr) {
            alert("Error : "+xhr.responseText);
        }

    //    error: function (err) {
    //    alert("error - " + err);
    //},
    //success: function () {
    //    window.location.href = "http://localhost:64404/Prescription/Upload";
    //}
    });

    //$("#txtName").val("");
    //$("#txtEmail").val("");
    //$("#txtMobileNum").val("");
    //$("#txtPassword").val("");sujeeth
  
    //$("#txtConfirmPassword").val("");
    //$("#txtCaptcha").val("");
});



$("#btnLogin").click(function () {
  
    var Login = {
        "Email": $('#txtLoginEmail').val(),
        "Password":$('#txtLoginPwd').val(),
        "RememberMe":false
    };

    var Email = $('#txtLoginEmail').val();
    var pswd=$('#txtLoginPwd').val();
    //var previousValue = $('#txtLoginPwd').val();
    //$("#txtLoginPwd").keyup(function (e) {
    //    var currentValue = $(this).val();
    //    if (currentValue != previousValue) {
    //        previousValue = currentValue;
    //        alert("Value changed!");
    //    }
    //});
    $.ajax({
        type: "POST",
        url: 'http://rxoutlet.azurewebsites.net/api/RxOutlet/Login/',
        data: JSON.stringify(Login),
        contentType: "application/json;charset=utf-8",

       
        error: function (err) {
            alert("error - " + err);
        },
        success: function () {
            if (Email == 'test@gmail.com' && pswd == 'test') {
                window.location.href = "http://rxoutlet.azurewebsites.net/Admin/AdminPage";
            }
            else
                window.location.href = "http://rxoutlet.azurewebsites.net/Prescription/Upload";
        }

    });

  

    //$("#txtLoginEmail").val("");
    //$("#txtLoginPwd").val("");
    //if ($("txtLoginPwd").val() ='') {
    //    alert("Not a valid Number");
    //} else { }
  
});