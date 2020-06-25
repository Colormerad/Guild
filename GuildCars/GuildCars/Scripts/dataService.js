var DataService = function () {
    var self = this;

    self.searchVehicles = function (searchterms, callback, myErrorFunc) {
        $.ajax({
            headers: {
                "Accept": "*/*",
                "dataType": 'application/json',
                "contentType": 'application/json'
            },
            url: 'https://localhost:44319/vehicleapi/search/',
            method: 'POST',
            data: searchterms,
            success: function (data) {
                callback(data);
            },
            error: function (jqXHR, error, errorThrown) {
                alert(jqXHR.status);
            }
        });
    }

    self.searchSalesResults = function (searchterms, callback, myErrorFunc) {
        $.ajax({
            headers: {
                "Accept": "*/*",
                "dataType": 'application/json',
                "contentType": 'application/json'
            },
            url: 'https://localhost:44319/orderapi/search/',
            method: 'POST',
            data: searchterms,
            success: function (data) {
                callback(data);
            },
            error: function (jqXHR, error, errorThrown) {
                alert(jqXHR.status);
            }
        });
    }

    self.searchModels = function (searchterms, callback, myErrorFunc) {
        $.ajax({
            headers: {
                "Accept": "*/*",
                "dataType": 'application/json',
                "contentType": 'application/json'
            },
            url: 'https://localhost:44319/Modelapi/search/',
            method: 'POST',
            data: searchterms,
            success: function (data) {
                callback(data);
            },
            error: function (jqXHR, error, errorThrown) {
                alert(jqXHR.status);
            }
        });
    }

    self.addVehicle = function (searchterms, callback, myErrorFunc) {
        $.ajax({
            headers: {
                "Accept": "*/*",
                "dataType": 'application/json',
                "contentType": 'application/json'
            },
            url: 'https://localhost:44319/vehicleapi/add/',
            method: 'POST',
            data: searchterms,
            success: function (data) {
                callback(data);
            },
            error: function (jqXHR, error, errorThrown) {
                alert(jqXHR.status);
            }
        });
    }
} 