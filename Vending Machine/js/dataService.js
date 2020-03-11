var DataService = function(){
    var self = this;
    

    self.getItems =function(callback, myErrorFunc){
        $.ajax({
            url:'https://tsg-vending.herokuapp.com/items',
            method: 'GET',
            success: callback,
            error: myErrorFunc,
        });
    }
    self.vendItem = function(callback, totalMoney, id, myErrorFunc){
        $.ajax({
            //async: false,
            headers : {
                'Content-Type' : 'application/json',
                "Accept": "*/*",
               },
            url:'https://tsg-vending.herokuapp.com/money/' + totalMoney + '/item/' + id,
            method: 'POST',
            success: callback,
            //data: JSON.stringify(data),
            //success: function (data, textStatus, xhr) {
              //  alert(JSON.stringify("Your change is quarters: " + data.quarters + " dimes: "  + data.dimes + " nickels: " + data.nickels + " pennies: " + data.pennies)); 
                //callback;
                //results = data;
                //return results;
           // },
            error: function (data, responseText, message){
                var error422 = JSON.parse(data.responseText);
                alert(JSON.stringify(error422.message));
            }
        
        });
    }
}



