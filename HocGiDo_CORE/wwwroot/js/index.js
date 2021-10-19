$(document).ready(function() {
    sideBarOC();
    dropDownUser();
    openSidePhone();
})

function sideBarOC() {
    var btn = document.querySelector("#btn");
    var sideBar = document.querySelector(".sideBar");
    var bxsearch = document.querySelector(".bx-search");

    btn.onclick = function() {
        sideBar.classList.toggle("active");
    }

    bxsearch.onclick = function() {
        sideBar.classList.toggle("active");
    }
}

function openSidePhone() {
    var openSide = document.getElementById("openMenu");
    openSide.onclick = function () {
        document.getElementById("Side").classList.add("active");
    }

    var closeMenu = document.getElementById("closeMenu");
    closeMenu.onclick = function () {
        document.getElementById("Side").classList.remove("active");
    }
}

function dropDownUser() {
    document.addEventListener('click', e => {
        const isDropDownHover = e.target.matches("[data-dropdown-user]")
        if (!isDropDownHover && e.target.closest('[data-dropdown]') != null) return;

        let currentDropdown;
        if (isDropDownHover) {
            currentDropdown = e.target.closest('[data-dropdown]')
            currentDropdown.classList.toggle('active');
        }

        document.querySelectorAll("[data-dropdown].active").forEach(dropdown => {
            if (dropdown === currentDropdown) return;
            dropdown.classList.remove('active');
        })
    })
}