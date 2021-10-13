    var myIndex = 0;
    carousel();
    handel();

    function carousel() {
        var mySlides = document.querySelectorAll(".mySlides");
        var count = document.getElementsByClassName("nextCount");
        count[0].classList.add("active");
        var i = 0;
        setInterval(function () {
            mySlides[i].style = "margin-left: -100%;";
            i++;
            if (i < mySlides.length) {
                count[i].classList.add("active");
            }
            if (i == mySlides.length) {
                i = 0;
                mySlides[0].style = "margin-left: 0;";
                mySlides[1].style = "margin-left: 0;";
                mySlides[2].style = "margin-left: 0;";
                count[1].classList.remove("active");
                count[2].classList.remove("active");
            }
        }, 2000);
    }

    function handel() {
        $('.course').click(function() {
            if (this.id == "Html") {
                $(".loadHere").load('../../View/ds_baihoc.html')
            }
        })
    }