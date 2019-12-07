$(document).ready(function() {
    //$("#endDate").rules('add', { greaterThan: "#startDate" });
    onChangeFromRouteSelect();
});
var day,
    selectedRow = null,
    fromRoutes,
    routeCost,
    fromRouteId,
    driverId = $("#Id").val(),
    startDate,
    endDate,
    routeRow,
    table = document.getElementById("routeTable"),
    tbody = document.getElementById("routeTable")
        .getElementsByTagName("tbody")[0],
    dayArrange,
    selectBoxFromRoutes = `<select onchange="onChangeSelect(this)"  class="select2DropDown fromRoutes"><option></option><select/>`,
    selectBoxToRoutes = `<select onchange="onChangeSelect(this)" class="select2DropDown toRoutes"><option></option><select/>`,
    dateArray = [],
    newRow = "row",
    column = "cell";


//#region endDate on change
$("#endDate").on("change",
    function() {
        // get date input's value
        startDate = new Date($("#startDate").val());
        endDate = new Date($("#endDate").val());
        // create date arr
        dateArray = getDateArray(startDate, endDate);
        // insert
        insertRouteRow(dateArray);
        //console.log(dateArray);
    });
//#endregion endDate on change
//#region  dateArray
var getDateArray = function(start, end) {
    const arr = new Array();
    // var dt = new Date(start);
    // console.log(dt);
    while (start <= end) {
        arr.push(Date.parse(startDate).toString("M/d/yyyy")); //save only "M/d/yyyy" part
        start.setDate(start.getDate() + 1);
    }
    return arr;
};

//#endregion  dateArray
//#region Insert New Route Row
function insertRouteRow(dateArr) {
    for (let rowIndex = 0; rowIndex < dateArr.length; rowIndex++) {
        window[newRow + rowIndex] = tbody.insertRow(table.length);
        for (let cellIndex = 0; cellIndex < table.rows[0].cells.length; cellIndex++) {
            window[column + cellIndex] = window[newRow + rowIndex].insertCell(cellIndex);
            // console.log(window[column + cellIndex]);
        }
        // routeDate
        window.cell0.innerHTML = dateArr[rowIndex];
        window.cell1.innerHTML = selectBoxFromRoutes;
        window.cell3.innerHTML = selectBoxToRoutes;
    }

    // get from routes
    getFromRoutes(driverId);
}
//
function getFromRoutes(driverId) {
    if (driverId !== null) {
        $.ajax({
            url: `/Select2/GetFromRoute/${driverId}`,
            type: "POST"
        }).done(function(response) {
            //console.log(response.items);
            initializeSelect2(response.items);
            //Swal.fire({
            //    type: "success",
            //    text: response.message,
            //    showConfirmButton: false,
            //    timer: 1500
            //});
        }).fail(function(response) {
            //window.Swal.fire({
            //    title: "Xəta!",
            //    type: "error",
            //    text: response.message,
            //    showConfirmButton: true
            //});
        });
    }
}
//
//
function onChangeSelect(selectBox) {
    
}
//
//#region initializeSelect2
function initializeSelect2(data) {
    $(".select2DropDown").select2({
        language: {
            inputTooShort: function() {
                return "Zəhmət olmasa bir hərf daxil edin";
            },
            noResults: function() {
                return "Nətice yoxdur";
            },
            searching: function() {
                return "Axtarılır...";
            }
        },
        closeOnSelect: true,
        allowClear: true,
        placeholder: "Secin"
    });
    $(".select2DropDown.fromRoutes").select2({
        language: {
            inputTooShort: function() {
                return "Zəhmət olmasa bir hərf daxil edin";
            },
            noResults: function() {
                return "Nətice yoxdur";
            },
            searching: function() {
                return "Axtarılır...";
            }
        },
        closeOnSelect: true,
        allowClear: true,
        placeholder: "Secin",
        data: data
    });
}
//#endregion
function onChangeFromRouteSelect() {
    $(document).on("change",
        ".select2DropDown.fromRoutes",
        function() {
            fromRouteId = $(this).val();
            if (fromRouteId !== null && driverId !== null) {
                $.ajax({
                    url: `/Select2/GetToRouteForFromRoute`,
                    data: {
                        fromRouteId: fromRouteId,
                        driverId: driverId
                    },
                    type: "POST"
                }).done(function(response) {
                    console.log(response.items);
                    $(".select2DropDown.toRoutes").select2({
                        language: {
                            inputTooShort: function() {
                                return "Zəhmət olmasa bir hərf daxil edin";
                            },
                            noResults: function() {
                                return "Nətice yoxdur";
                            },
                            searching: function() {
                                return "Axtarılır...";
                            }
                        },
                        closeOnSelect: true,
                        allowClear: true,
                        placeholder: "Secin",
                        data: response.items
                    });
                }).fail(function(response) {
                });
            }
        });
}
//#endregion Insert New Route Row
//jQuery.validator.addMethod("greaterThan",
//    function (value, element, params) {

//        if (!/Invalid|NaN/.test(new Date(value))) {
//            return new Date(value) > new Date($(params).val());
//        }

//        return isNaN(value) && isNaN($(params).val())
//            || (Number(value) > Number($(params).val()));
//    }, 'Must be greater than {0}.');