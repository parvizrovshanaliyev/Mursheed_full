
$(document).ready(function () {
    //$("#endDate").rules('add', { greaterThan: "#startDate" });
   
    //onChangeFromRouteSelect();
});
var day,
    selectedRow = null,
    childElement = null,
    fromToRouteModel = {
        FromRouteId: 0,
        ToRouteId: 0,
        DriverId: $("#Id").val()
    },
    dateArray = [],
    ticketViewModel = {
        RouteIds: [],
        DriverId: fromToRouteModel.DriverId,
        TotalPrice: 0,
        DateFromTo: {
            StartDate: '',
            EndDate: ''
        }
    },
    fromRoutes,
    routeCost,
    fromRouteId,
    toRouteId,
    startDate,
    endDate,
    routePrice = 0,
    routeRow,
    table = document.getElementById("routeTable"),
    tbody = document.getElementById("routeTable")
        .getElementsByTagName("tbody")[0],
    selectBoxFromRoutes = `<select onchange="onChangeSelect(this)"  class="select2DropDown fromRoutes"><option></option><select/>`,
    selectBoxToRoutes = `<select onchange="onChangeSelect(this)" class="select2DropDown toRoutes"><option></option><select/>`,
    routeIds = [],
    routeId = 0,
    newRow = "row",
    column = "cell";
const select2DropDownFromRoutes = ".select2DropDown.fromRoutes",
    select2DropDownToRoutes = ".select2DropDown.toRoutes";


//#region endDate on change
$("#endDate").on("change",
    function () {
        // get date input's value
        startDate = new Date($("#startDate").val());
        endDate = new Date($("#endDate").val());
        // create date arr
        dateArray = getDateArray(startDate, endDate);
        //
        ticketViewModel.DateFromTo.StartDate = dateArray[0];
        ticketViewModel.DateFromTo.EndDate = dateArray.slice(-1)[0];
        // insert
        insertRow(dateArray);
        console.log(ticketViewModel);
    });
//#endregion endDate on change
//#region  dateArray
var getDateArray = function (start, end) {
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
        window.cell0.className = "routeId";
        window.cell1.innerHTML = dateArr[rowIndex];
        window.cell2.innerHTML = selectBoxFromRoutes;
        window.cell4.innerHTML = selectBoxToRoutes;
        window.cell6.innerHTML = 0;
        window.cell6.className = "routePrice";
    }
    //
    initializeSelect2();
    // get from routes
    fillToSelect();
}
//
//
function fillToSelect() {
    if (fromToRouteModel.DriverId !== null) {
        $.ajax({
            url: `/Select2/GetFromRoute`,
            data: { model: fromToRouteModel },
            type: "POST",
            success: function (response) {
                initializeSelect2(select2DropDownFromRoutes, response.items);
                //SwalUtility.Success();

            }
        }).fail(function () {
            SwalUtility.Fail();
        });
    }
}
//
function onChangeSelect(selectBox) {
    selectedRow = selectBox.parentElement.parentElement;
    if ($(selectBox).hasClass("fromRoutes")) {
        fromToRouteModel.FromRouteId = $(selectBox).val();
        
        childElement = $(selectedRow).find(select2DropDownToRoutes);
        // clear child select To Routes
        clearSelect(childElement);
        
        if (fromToRouteModel.FromRouteId !== 0
            && fromToRouteModel.DriverId !== 0
            && fromToRouteModel.FromRouteId !== ''
            && fromToRouteModel.DriverId !== '') {
            $.ajax({
                url: `/Select2/GetToRouteForFromRoute`,
                data: { model: fromToRouteModel },
                type: "POST"
            }).done(function (response) {
               
                initializeSelect2(childElement, response.items);
            }).fail(function (response) {
                SwalUtility.Fail();
            });
            fromToRouteModel.FromRouteId = 0;
        }
    } else if ($(selectBox).hasClass("toRoutes")) {
        fromToRouteModel.ToRouteId = $(selectBox).val();
        childElement = $(selectedRow).find(select2DropDownFromRoutes);
        clearSelect();
        fromToRouteModel.FromRouteId = $(childElement).val();

        if (fromToRouteModel.FromRouteId !== 0
            && fromToRouteModel.ToRouteId !== 0
            && fromToRouteModel.DriverId !== 0
            && fromToRouteModel.ToRouteId !== ''
            && fromToRouteModel.DriverId !== ''
            && fromToRouteModel.FromRouteId !== '') {
            $.ajax({
                url: `/Select2/GetToCostForRoute`,
                data: { model: fromToRouteModel },
                type: "POST"
            }).done(function (response) {
                selectedRow.cells[0].innerHTML = response.id;
                selectedRow.cells[5].innerHTML = response.info;
                selectedRow.cells[6].innerHTML = response.cost;
            }).fail(function (response) {
                SwalUtility.Fail();
            });
            fromToRouteModel.ToRouteId = 0;
            fromToRouteModel.FromRouteId = 0;
        }
    }
}
//
function clearSelect(element) {
    $(element).empty().append(`<option></option>`);
    selectedRow.cells[5].innerHTML = '';
    selectedRow.cells[6].innerHTML = 0;
    selectedRow.cells[0].innerHTML = '';
}
//
//#region initializeSelect2
function initializeSelect2(element, data) {
    $(".select2DropDown").select2({
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
function onHire(btn) {
   
    $(table).find("td.routeId").each(function () {
        if (this.innerHTML !== '') {
            routeIds.push(Number(this.innerHTML));
        }
    });
    $(table).find("td.routePrice").each(function () {
        if (this.innerHTML!== '') {
            routePrice += Number(this.innerHTML);
        }
    });
    ticketViewModel.RouteIds = routeIds;
    ticketViewModel.TotalPrice = routePrice;
    console.log(routePrice);
    console.log(routeIds);
    console.log(ticketViewModel);
    $.ajax({
        url: `/DriverPrice/Ticket`,
        data: { model: ticketViewModel },
        type: "POST"
    }).done(function (response) {
        window.swal({
            type: 'success',
            title: 'Əməliyyat yerinə yetirildi',
            text: `Ride id: ${response.rideId} Total Price : ${response.totalPrice}`,
            showConfirmButton: true
            //timer: 1000
        });
    }).fail(function (response) {
        SwalUtility.Fail();
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