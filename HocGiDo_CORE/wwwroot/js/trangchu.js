    var myIndex = 0;
    carousel();
    handel();

    function carousel() {
        var i;
        var x = document.getElementsByClassName("mySlides");
        var y = document.getElementsByClassName("nextCount");
        for (i = 0; i < x.length; i++) {
            y[i].classList.add("active");
            x[i].style.display = "none";
        }
        myIndex++;
        if (myIndex > x.length && myIndex > y.length) {
            myIndex = 1
        }
        x[myIndex - 1].style.display = "block";
        y[myIndex - 1].classList.remove("active");
        setTimeout(carousel, 2000); // Change image every 2 seconds
    }

    function handel() {
        $('.course').click(function() {
            if (this.id == "Html") {
                $(".loadHere").load('../../View/ds_baihoc.html')
            }
        })
    }