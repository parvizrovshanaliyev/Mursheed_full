$(document).ready(function () {
    //$("#endDate").rules('add', { greaterThan: "#startDate" });
});
var day,
    startDate,
    endDate,
    routeRow,
    routeTable,
    routeTableTbody,
    dayArrange,
    selectBox,
    newRow,
    column = 'cell';



//jQuery.validator.addMethod("greaterThan",
//    function (value, element, params) {

//        if (!/Invalid|NaN/.test(new Date(value))) {
//            return new Date(value) > new Date($(params).val());
//        }

//        return isNaN(value) && isNaN($(params).val())
//            || (Number(value) > Number($(params).val()));
//    }, 'Must be greater than {0}.');
//#region endDate on change
$("#endDate").on("change",
    function () {
        startDate = new Date($('#startDate').val());
        endDate = new Date($('#endDate').val());
        console.log(endDate.getDate() - startDate.getDate());
        // insert
        dayArrange = endDate.getDate() - startDate.getDate() + 1;
        insertRouteRow(dayArrange);
    });
//#endregion endDate on change

//#region Insert New Route Row
function insertRouteRow(dayArrange) {
    routeTable = document.getElementById("routeTable");

    for (var i = 0; i < dayArrange; i++) {
        $("#routeTable").find("tbody").append(`<tr>
                                      <th scope="row">TEST</th>
                                      <td>
                                        <select>
                                               <option value="0">All cities</option>
                                               <option value="1">Baku</option>
                                               <option value="2">Qazax</option>
                                               <option value="3">Ganja</option>
                                               <option value="4">Shaki</option>
                                        </select>
                                      </td>
                                      <td>
                                      time
                                      </td>
                                      <td>
                                        <select>
                                                <option value="0">All cities</option>
                                                <option value="1">Baku</option>
                                                <option value="2">Qazax</option>
                                                <option value="3">Ganja</option>
                                                <option value="4">Shaki</option>
                                        </select>
                                      </td>
                                      <td>TEST</td>
                                      <td>TEST</td>
                                    </tr>`);
    }
    


}
//#endregion Insert New Route Row