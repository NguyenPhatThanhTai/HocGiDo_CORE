 showPassworld();

 function showPassworld() {
     document.getElementById("show").addEventListener("click", function() {
         document.getElementById("show").style = "display: none";
         document.getElementById("close").style = "display: block";
         document.getElementById("pass").type = "text";
     })
     document.getElementById("close").addEventListener("click", function() {
         document.getElementById("close").style = "display: none";
         document.getElementById("show").style = "display: block";
         document.getElementById("pass").type = "password";
     })
 }