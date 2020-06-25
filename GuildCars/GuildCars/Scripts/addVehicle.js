var ds = new DataService();

function formatDropDown(model) {
    return `<option value="${model.ModelId}">${model.ModelName}</option>
`;
}

function populateModels(data) {
    let modelDropDown = $('#Model');
    modelDropDown.empty();

    for (let i = 0; i < data.length; i++) {
        const result = data[i];
        $(modelDropDown).append(formatDropDown(result));
    }

}

function onChangeMake() {
    var searchquery = {
        Makeid: $("#vehicle_MakeId").val()     
    };
    ds.searchModels(searchquery, populateModels, alertError);
}



function alertError(msg) {
    alert(msg);
}

$(document).ready(function () {
    
    $(document).on("change", "#vehicle_MakeId", onChangeMake);
    onChangeMake(this);
});