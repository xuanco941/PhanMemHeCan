// Framework
document.addEventListener("DOMContentLoaded", function(event) {

    const showNavbar = (toggleId, navId, bodyId, headerId) => {
        const toggle = document.getElementById(toggleId),
            nav = document.getElementById(navId),
            bodypd = document.getElementById(bodyId),
            headerpd = document.getElementById(headerId)

        // Validate that all variables exist
        if (toggle && nav && bodypd && headerpd) {
            toggle.addEventListener('click', () => {
                // show navbar
                nav.classList.toggle('show')
                    // change icon
                toggle.classList.toggle('bi-x')
                    // add padding to body
                bodypd.classList.toggle('body-pd')
                    // add padding to header
                headerpd.classList.toggle('body-pd')
            })
        }
    }

    showNavbar('header-toggle', 'nav-bar', 'body-pd', 'header')

    /*===== LINK ACTIVE =====*/
    const linkColor = document.querySelectorAll('.nav_link')

    function colorLink() {
        if (linkColor) {
            linkColor.forEach(l => l.classList.remove('active'))
            this.classList.add('active')
        }
    }
    linkColor.forEach(l => l.addEventListener('click', colorLink))

    // Your code to run since DOM is loaded and ready
});
// 


// click ra element khac
$(document).on("click", function() {
    $(".menu").hide();
});
// click vao element profile
$(document).ready(function() {
    $(".header_img").on("click", function(event) {
        event.stopPropagation();
        $(".menu").slideToggle("fast");
    });

})

//
$("#formButton").click(function() {
    $("#form1").slideToggle('fast');
});

// modal them
var btn_them = document.getElementById('btn_Them');
var modal = document.getElementById('ModalThem');
var span = document.getElementsByClassName('close')[0];

btn_them.onclick = function(){
    modal.style.display = "block";
}


span.onclick = function(){
    modal.style.display = "none";
}

// window.onclick = function(event){
//         if(event.target == modal){
//             modal.style.display = "none";
//         }
// }
modal.onclick = function(){
    modal.style.display = "none";
}

//modal sua
var btn_sua = document.getElementById('btn_Sua');
var modalS = document.getElementById('ModalSua');
var spanS = document.getElementsByClassName('closeS')[0];
btn_sua.onclick = function(){
    modalS.style.display = "block";
}

spanS.onclick = function(){
    modalS.style.display = "none";
}

// window.onclick = function(event){
//     if(event.target == modalS){
//         modalS.style.display = "none";
//     }
// }
modalS.onclick = function(){
    modalS.style.display = "none";
}

//modal xoa
var btn_Xoa = document.getElementById('btn_Xoa');
var modalXoa = document.getElementById('Xoa');
var spanXoa = document.getElementsByClassName('closeX')[0];
// var btn_khong = document.getElementById('btnK');
btn_Xoa.onclick = function(){
    modalXoa.style.display = "block";
}

spanXoa.onclick = function(){
    modalXoa.style.display = "none";
}

// window.onclick = function(event){
//     if(event.target == modalXoa){
//         modalXoa.style.display = "none";
//     }
// }
modalXoa.onclick = function(){
    modalXoa.style.display = "none";
}