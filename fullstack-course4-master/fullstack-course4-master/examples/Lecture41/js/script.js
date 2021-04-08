var message = "in global";


var a = function () {
  var message = "inside a";

  
  b();
}

function b() {
  console.log("b: message = " + message);
}


a();