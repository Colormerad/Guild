var ds = new DataService();
function formatRow(vehicle) {
    return `<div class="vehicleDetails container" id="vehicleDetailsContainer">      
               <table class="searchResults" id= "vehicleTable">
                   <tbody>
            <tr>
                  <td colspan="6"><p><strong>${vehicle.Year}  ${vehicle.MakeName} ${vehicle.ModelName}</strong></p></td>
                  <td style="text-align:left"><strong>Body Style:</strong></td>
                  <td style="text-align:left">${vehicle.BodyStyleName}</td>
                  <td style="text-align:left"><strong>Interior: </strong></td>
                  <td style="text-align:left">${vehicle.InteriorColorName}</td>
                  <td style="text-align:left"><strong>Sale Price: </strong></td>
                  <td style="text-align:left">$${vehicle.SalePrice}</td>
                  

            </tr>
            <tr>
                  <td colspan="6"><img width= "120" src="/Images/${vehicle.ImageFileName}"></td>
                  <td style="text-align:left"><strong>Trans: </strong></td>
                  <td style="text-align:left">${vehicle.TransmissionName}</td>
                  <td style="text-align:left"><strong>Mileage: </strong></td>
                  <td style="text-align:left">${vehicle.Mileage}</td>
                  <td style="text-align:left"><strong>MSRP: </strong></td>
                  <td style="text-align:left">$${vehicle.MSRP}</td>

             </tr>
             <tr>
                  <td colspan="6"></td>
                  <td style="text-align:left "><strong>Color: </strong></td>
                  <td style="text-align:left ">${vehicle.ExteriorColorName}</td>
                  <td style="text-align:left  "><strong>Vin #: </strong></td>
                  <td style="text-align:left  ">${vehicle.VIN}</td>
                  <td style="text-align:right " colspan="2"><button onclick="window.location.href='/vehicles/details/${vehicle.VehicleId}/'">Details</button></td>
                 
             </tr>
        </tbody>
        </table>
     </div>
<br>`;
}

function formatRowSales(vehicle) {
    return `<div class="vehicleDetails container" id="vehicleDetailsContainer">      
               <table style="width=100%" class="searchResults" id= "vehicleTableSales">
                   <tbody>
            <tr>
                  <td colspan="6"><p><strong>${vehicle.Year}  ${vehicle.MakeName} ${vehicle.ModelName}</strong></p></td>
                  <td style="text-align:left"><strong>Body Style:</strong></td>
                  <td style="text-align:left">${vehicle.BodyStyleName}</td>
                  <td style="text-align:left"><strong>Interior: </strong></td>
                  <td style="text-align:left">${vehicle.InteriorColorName}</td>
                  <td style="text-align:left"><strong>Sale Price: </strong></td>
                  <td style="text-align:left">$${vehicle.SalePrice}</td>
                  

            </tr>
            <tr>
                  <td colspan="6"><img width="120"  src="/Images/${vehicle.ImageFileName}"></td>
                  <td style="text-align:left"><strong>Trans: </strong></td>
                  <td style="text-align:left">${vehicle.TransmissionName}</td>
                  <td style="text-align:left"><strong>Mileage: </strong></td>
                  <td style="text-align:left">${vehicle.Mileage}</td>
                  <td style="text-align:left"><strong>MSRP: </strong></td>
                  <td style="text-align:left">$${vehicle.MSRP}</td>

             </tr>
             <tr>
                  <td colspan="6"></td>
                  <td style="text-align:left padding-bottom:1em"><strong>Color: </strong></td>
                  <td style="text-align:left padding-bottom:1em">${vehicle.ExteriorColorName}</td>
                  <td style="text-align:left  padding-bottom:1em"><strong>Vin #: </strong></td>
                  <td style="text-align:left  padding-bottom:1em">${vehicle.VIN}</td>
                  <td style="text-align:right padding-bottom:1em" colspan="2"><button onclick="window.location.href='/sales/purchase/${vehicle.VehicleId}/'">Purchase</button></td>
                 
             </tr>

        </tbody>
        </table>
     </div>
<br>`;
}

function formatRowEdit(vehicle) {
    
    return `<div class="vehicleDetails container" id="vehicleDetailsContainer">      
               <table style="width=100%" class="searchResults" id= "vehicleTableEdit">
                   <tbody>
                        <tr>
                  <td colspan="6"><p><strong>${vehicle.Year}  ${vehicle.MakeName} ${vehicle.ModelName}</strong></p></td>
                  <td style="text-align:left"><strong>Body Style:</strong></td>
                  <td style="text-align:left">${vehicle.BodyStyleName}</td>
                  <td style="text-align:left"><strong>Interior: </strong></td>
                  <td style="text-align:left">${vehicle.InteriorColorName}</td>
                  <td style="text-align:left"><strong>Sale Price: </strong></td>
                  <td style="text-align:left">$${vehicle.SalePrice}</td>
                  

            </tr>
            <tr>
                  <td colspan="6"><img width="120" width= "120" src="/Images/${vehicle.ImageFileName}"></td>
                  <td style="text-align:left"><strong>Trans: </strong></td>
                  <td style="text-align:left">${vehicle.TransmissionName}</td>
                  <td style="text-align:left"><strong>Mileage: </strong></td>
                  <td style="text-align:left">${vehicle.Mileage}</td>
                  <td style="text-align:left"><strong>MSRP: </strong></td>
                  <td style="text-align:left">$${vehicle.MSRP}</td>

             </tr>
             <tr>
                  <td colspan="6"></td>
                  <td style="text-align:left padding-bottom:1em"><strong>Color: </strong></td>
                  <td style="text-align:left padding-bottom:1em">${vehicle.ExteriorColorName}</td>
                  <td style="text-align:left  padding-bottom:1em"><strong>Vin #: </strong></td>
                  <td style="text-align:left  padding-bottom:1em">${vehicle.VIN}</td>
                  <td style="text-align:right  padding-bottom:1em" colspan="2"><button onclick="window.location.href='/admin/editvehicle/${vehicle.VehicleId}/'">Edit</button></td>
                 
             </tr>
            
        </tbody>
        </table>
     </div>
<br>`;
}

function formatRowSalesResultsTable(result) {
    return ` <tr>
                <td>${result.UserName}</td>
                <td>$${result.TotalSales}</td>
                <td>${result.TotalVehicles}</td>
            </tr> `;
            
}
function refreshTableSalesResults(data) {
    let resultsTable = $("#SalesResultsTable>tbody");
    resultsTable.empty();
    
    for (let i = 0; i < data.length; i++) {
        const result = data[i];
        $(resultsTable).append(formatRowSalesResultsTable(result));
    }
}
function onSubmitSearchOrders(e) {
    e.preventDefault(); //stop browser from reloading the page

    let searchquery = {
        UserName: $("#Id").val(),
        MinOrderDate: $("#FromDate").val(),
        MaxOrderDate: $("#ToDate").val()     
    };
    ds.searchSalesResults(searchquery, refreshTableSalesResults, alertError);

}

function refreshTable(data) {
    let vehicleTable = $("#vehicleTable>tbody");

    vehicleTable.empty();
    for (let i = 0; i < data.length; i++) {
        const vehicle = data[i];
        $(vehicleTable).append(formatRow(vehicle));
    }
}

function refreshTableSales(data) {
    let vehicleTable = $("#vehicleTableSales>tbody");
    vehicleTable.empty();
    for (let i = 0; i < data.length; i++) {
        const vehicle = data[i];
        $(vehicleTable).append(formatRowSales(vehicle));
    }
}
function refreshTableEdit(data) {
    

    let vehicleTable = $("#vehicleTableEdit>tbody");
    vehicleTable.empty();
    for (let i = 0; i < data.length; i++) {
        const vehicle = data[i];
        $(vehicleTable).append(formatRowEdit(vehicle));
    }
}

function onSubmitSearchVehicle(e) {
    e.preventDefault(); //stop browser from reload ing the page
  
    let searchquery = {
        SearchField: $("#searchinput").val(),
        PriceMin: $("#minPrice").val(),
        PriceMax: $("#maxPrice").val(),
        YearMin: $("#minYear").val(),
        YearMax: $("#maxYear").val(),
        Condition: 'New'
    };
    ds.searchVehicles(searchquery, refreshTable, alertError);

}

function onSubmitSearchUsedVehicle(e) {
    e.preventDefault();
    let searchquery = {
        SearchField: $("#searchinput").val(),
        PriceMin: $("#minPrice").val(),
        PriceMax: $("#maxPrice").val(),
        YearMin: $("#minYear").val(),
        YearMax: $("#maxYear").val(),
        Condition: 'Used'
    };
    ds.searchVehicles(searchquery, refreshTable, alertError);
}

function onSubmitSearchAllVehicle(e) {
    e.preventDefault();
    let searchquery = {
        SearchField: $("#searchinput").val(),
        PriceMin: $("#minPrice").val(),
        PriceMax: $("#maxPrice").val(),
        YearMin: $("#minYear").val(),
        YearMax: $("#maxYear").val(),
        Condition: 'ALL'
    };
    ds.searchVehicles(searchquery, refreshTableSales, alertError);
}

function onSubmitSearchEditVehicle(e) {
    e.preventDefault();
    let searchquery = {
        SearchField: $("#searchinput").val(),
        PriceMin: $("#minPrice").val(),
        PriceMax: $("#maxPrice").val(),
        YearMin: $("#minYear").val(),
        YearMax: $("#maxYear").val(),
        Condition: 'ALL'
    };
    ds.searchVehicles(searchquery, refreshTableEdit, alertError);
}

function alertError(msg) {
    alert(msg);
}

$(document).ready(function () {
    $(document).on("click", "#submitButton", onSubmitSearchVehicle);
    $(document).on("click", "#submitUsedButton", onSubmitSearchUsedVehicle);
    $(document).on("click", "#submitAllButton", onSubmitSearchAllVehicle);
    $(document).on("click", "#submitEditButton", onSubmitSearchEditVehicle);
    $(document).on("click", "#submitSearchOrdersButton", onSubmitSearchOrders);
});