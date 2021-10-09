    $("#bai1").click(function() {
        document.getElementById("load").style = "display: inline";
        setTimeout(function() {
            $(".loadHere").load('../../View/baihoc.html')
            document.getElementById("load").style = "display: none";
        }, 3000);
    })