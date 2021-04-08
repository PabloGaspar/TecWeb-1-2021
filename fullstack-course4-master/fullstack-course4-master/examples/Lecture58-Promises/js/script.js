
function prepareOrder(){
  return "none";
}

let promiseOrder = new Promise((resolve, reject)=>{
  var order = prepareOrder();
  setTimeout(function(){
    if(order === "chicken"){
      resolve(`your order is: ${order}`); 
    } else{
      reject('something went wrong')
    }
  },3000);
});


promiseOrder.then((orderMessage) =>{
  console.log(`Promise succesfully resolved ${orderMessage}`)
}).catch((errorMessage)=>{
  console.log(`Promise failed ${errorMessage}`)
});


console.log("this is after the promise");

