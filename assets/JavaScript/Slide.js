let temp = 0;

function controller(x) {
    temp = temp + x;
    slideShow(temp);
}

slideShow(temp);


function slideShow(num) {

    let totalslides = document.querySelectorAll(".Slidecontect");
    if (num == totalslides.length) {
        num = 0;
        temp = 0;
    }
    if (num < 0) {
        num - totalslides.length - 1;
        temp = totalslides.length - 1;
    }

    for (let i = 0; i < totalslides.length; i++)
    {
        /*totalslides[i].style.display = "none";*/
    }
    //totalslides[temp].style.display = "block";
}
