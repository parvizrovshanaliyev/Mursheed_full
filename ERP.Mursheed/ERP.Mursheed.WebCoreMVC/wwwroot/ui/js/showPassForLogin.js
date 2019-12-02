

var view = document.querySelector(".view")
var view_confrim = document.querySelector(".view_confrim")



view.addEventListener("click", function(){
  var x = document.getElementById("password_input");
  if (x.type === "password") {
    x.type = "text";
  } else {
    x.type = "password";
  }
})

