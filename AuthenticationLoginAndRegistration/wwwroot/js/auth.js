
var input = document.getElementsByTagName("input");
var submitBtn = document.getElementById("registerSubmit");

submitBtn.onclick = function () {


    for (let i = 0; i < input.length; i++) {

        if (input[i].value == "") {

            //input[i].style.borderColor = "red";
            input[i].style.border = '1px solid red';
            alert("Complete all input field to proceed");
            console.log("submit was clicked")
            break;

        }
        else {
            input[i].style.border = 'none';
        }
    }

};
