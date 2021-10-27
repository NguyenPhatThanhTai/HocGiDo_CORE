clickItems();
chanceInf();

function clickItems() {
    var items = document.querySelectorAll('.items');
    var view = document.querySelectorAll('.view');
    items[0].classList.add("active");
    view[0].style.display = 'block';
    items.forEach(function(current, index) {
        items[index].addEventListener("click", function() {
            items.forEach(function(curr, i) {
                items[i].classList.remove("active");
            })
            view.forEach(function(curr, i) {
                view[i].style.display = 'none';
            });
            items[index].classList.add("active");
            if (items[index].id == 'detail') {
                document.getElementsByClassName('detail')[0].style.display = 'block';
            }
            if (items[index].id == 'save') {
                document.getElementsByClassName('save')[0].style.display = 'block';
            }
        });
    });
}

function chanceInf() {
    document.getElementById("chance_inf").addEventListener("click", function() {
        var inputs = document.querySelectorAll('.inf');
        inputs.forEach(function(current, index) {
            if (inputs[index].type == 'password') {
                inputs[index].type = "text";
            }
            inputs[index].disabled = false;
        })
    })
}