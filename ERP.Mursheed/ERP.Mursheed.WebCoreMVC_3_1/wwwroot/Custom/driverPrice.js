$(document).ready(function () {
    //$("#endDate").rules('add', { greaterThan: "#startDate" });

});
var day,
    startDate,
    endDate,
    routeRow,
    table = document.getElementById("routeTable"),
    tbody = document.getElementById("routeTable")
        .getElementsByTagName("tbody")[0],
    dayArrange,
    selectBox=`<select class="select2DropDown"><option></option><select/>`,
    dateArray=[],
    newRow = 'row',
    column = 'cell';

//$('.select2DropDown').select2({

//    language: {
//        inputTooShort: function () {
//            return 'Zəhmət olmasa bir hərf daxil edin';
//        },
//        noResults: function () {
//            return "Nətice yoxdur";
//        },
//        searching: function () {
//            return "Axtarılır...";
//        }
//    },
//    placeholder: "Secin"
//});
///#region endDate on change
$("#endDate").on("change",
    function () {
        // get date input's value
        startDate = new Date($('#startDate').val());
        endDate = new Date($('#endDate').val());
        // create date arr
        dateArray = getDateArray(startDate, endDate);
        // insert
        insertRouteRow(dateArray);
        console.log(dateArray);
    });
//#endregion endDate on change
///#region  dateArray
var getDateArray = function (start, end) {
    var arr = new Array();
    // var dt = new Date(start);
    // console.log(dt);
    while (start <= end) {
        arr.push(Date.parse(startDate).toString("M/d/yyyy")); //save only "M/d/yyyy" part
        start.setDate(start.getDate() + 1);
    }
    return arr;
}
//#endregion  dateArray
///#region Insert New Route Row
function insertRouteRow(dateArr) {
    for (let rowIndex = 0; rowIndex < dateArr.length; rowIndex++) {
        window[newRow + rowIndex] = tbody.insertRow(table.length);
        for (let cellIndex = 0; cellIndex < table.rows[0].cells.length; cellIndex++) {
            window[column + cellIndex] = window[newRow + rowIndex].insertCell(cellIndex);
            // console.log(window[column + cellIndex]);
        }
        // routeDate
        cell0.innerHTML=dateArr[rowIndex];
        cell1.innerHTML=selectBox;
        cell3.innerHTML=selectBox;
        initializeSelect2(selectBox);
    }
}
//#region initializeSelect2
function initializeSelect2() {
    $('.select2DropDown').select2({
        language: {
            inputTooShort: function () {
                return 'Zəhmət olmasa bir hərf daxil edin';
            },
            noResults: function () {
                return "Nətice yoxdur";
            },
            searching: function () {
                return "Axtarılır...";
            }
        },
        placeholder: "Secin"
    });
}
//#endregion

//#endregion Insert New Route Row
//jQuery.validator.addMethod("greaterThan",
//    function (value, element, params) {

//        if (!/Invalid|NaN/.test(new Date(value))) {
//            return new Date(value) > new Date($(params).val());
//        }

//        return isNaN(value) && isNaN($(params).val())
//            || (Number(value) > Number($(params).val()));
//    }, 'Must be greater than {0}.');