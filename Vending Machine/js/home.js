var ds = new DataService();

function error(){
    alert("Something Bad Happened");
}

function refreshTable(items){
    let itemTable = $("#items");
    itemTable.empty();
    for(let i = 0; i< items.length; i++){
        const item = items[i];
        $(itemTable).append(formatItem(item));
    }
    totalMoney = 0;
}

function formatItem(item){
    var txt = '<div class="col-md-4 itemDiv" data-itemid="' + item.id + '"style="border: solid"  onmouseover="OnMouseIn (this)" onmouseout="OnMouseOut (this)""  > Item ID: ' 
    + item.id +'<br> Item Name: '+ item.name +'<br> Price: $'+item.price + '<br> Qty Remaining:' + item.quantity + '</div>' ;
    
    return txt; 
}

function OnMouseIn (elem) {
    elem.style.border = "2px solid black";
}
function OnMouseOut (elem) {
    elem.style.border = "solid";
}


function selectItem() {
    id = $(this).attr('data-itemid');
    $('#selection').val(id);
}

var totalMoney = 0
var addMoney = 0
var id = 0


function makePurchase(){
    ds.vendItem(getResults, totalMoney, id);
    
}

function getResults(results){
    $('#messages').val("Thank you!");
    $('#changeReturn').val(results);
    $('#moneyTotal').val('');
    $('#selection').val('');
    ds.getItems(refreshTable);
}


function changeReturn() {
    $('#messages').val('');
    $('#moneyTotal').val('');
    totalMoney = 0;
    $('#selection').val('');

}

function alertError(msg){
    alert(msg);
}

function moneyAppend(value) {
    $('#moneyTotal').val(onAddMoney(value));
}

function onAddMoney(value) {
    totalMoney = (Number(totalMoney) + Number(value)).toFixed(2);
       return totalMoney; 
}

$(document).ready(function(){
    ds.getItems(refreshTable, function() { alert('error');} );
    $(document).on("click", '#changeReturn', changeReturn);
    $(document).on("click", '#makePurchase', makePurchase); 
    $(document).on("click", ".itemDiv", selectItem); 
    });