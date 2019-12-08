﻿$(document).ready(function() {
    //$("#endDate").rules('add', { greaterThan: "#startDate" });
    //onChangeFromRouteSelect();
});
var day,
    selectedRow = null,
    childElement = null,
    fromRoutes,
    routeCost,
    fromRouteId,
    toRouteId,
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
    routeIds = [],
    newRow = "row",
    column = "cell";
const select2DropDownFromRoutes = ".select2DropDown.fromRoutes",
      select2DropDownToRoutes = ".select2DropDown.toRoutes";


//#region endDate on change
$("#endDate").on("change",
    function() {
        // get date input's value
        startDate = new Date($("#startDate").val());
        endDate = new Date($("#endDate").val());
        // create date arr
        dateArray = getDateArray(startDate, endDate);
        // insert
        insertRow(dateArray);
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
function insertRow(dateArr) {
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
    //
    initializeSelect2();
    // get from routes
    fillToSelect(driverId);
}
//
//
function fillToSelect(driverId) {
    if (driverId !== null) {
        $.ajax({
            url: `/Select2/GetFromRoute/${driverId}`,
            type: "POST"
        }).done(function (response) {
            initializeSelect2(select2DropDownFromRoutes, response.items);
            //$(".select2DropDown").select2({
            //    data: response.items
            //});
        }).fail(function (response) {
        });
    }
}
//
function onChangeSelect(selectBox) {
    selectedRow = selectBox.parentElement.parentElement;
    if ($(selectBox).hasClass("fromRoutes")) {
        fromRouteId = $(selectBox).val();
        console.log(`fromRouteId:${fromRouteId}`);
        
        childElement = $(selectedRow).find(select2DropDownToRoutes);
        //console.log(`selectedRow :${selectedRow.sectionRowIndex}`);
        //console.log($(selectedRow).find(select2DropDownToRoutes).val());
        if (fromRouteId !== null && driverId !== null) {
            $.ajax({
                url: `/Select2/GetToRouteForFromRoute`,
                data: {
                    fromRouteId: fromRouteId,
                    driverId: driverId
                },
                type: "POST"
            }).done(function (response) {
                //console.log(response.items);
                initializeSelect2(childElement, response.items);
            }).fail(function (response) {
            });
            fromRouteId = null;
        }
    } else if ($(selectBox).hasClass("toRoutes")) {
        toRouteId = $(selectBox).val();
        childElement = $(selectedRow).find(select2DropDownFromRoutes);
        fromRouteId = $(childElement).val();
        //console.log(fromRouteId, toRouteId);
        //console.log(`selectedRow :${selectedRow.sectionRowIndex}`);
        if (fromRouteId !== null && driverId !== null && toRouteId !== null) {
            $.ajax({
                url: `/Select2/GetToCostForRoute`,
                data: {
                    fromRouteId: fromRouteId,
                    driverId: driverId,
                    toRouteId: toRouteId
                },
                type: "POST"
            }).done(function (response) {
                //console.log(response);
                //selectedRow.cells[2].innerHTML = `fromRouteId:${fromRouteId}-toRouteId:${toRouteId}`;
                selectedRow.cells[4].innerHTML = response.info;
                selectedRow.cells[5].innerHTML = response.cost;
            }).fail(function (response) {
            });
            fromRouteId = null;
        }
    }
}
//
//#region initializeSelect2
function initializeSelect2(element,data) {
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
    $(element).select2({
        language: {
            inputTooShort: function () {
                return "Zəhmət olmasa bir hərf daxil edin";
            },
            noResults: function () {
                return "Nətice yoxdur";
            },
            searching: function () {
                return "Axtarılır...";
            }
        },
        closeOnSelect: true,
        allowClear: true,
        placeholder: "Secin",
        data: data
    });
    childElement = null;
}
//#endregion
function onChangeFromRouteSelect() {
    $(document).on("change",
        ".select2DropDown.fromRoutes",
        function() {
            
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