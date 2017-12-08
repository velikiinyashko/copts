// Write your JavaScript code.
jQuery(document).ready(function () {
    $('.btn-login').click(function () {
        $('.login').load('/cabinet/home/enter');
    });

    $('.btn-menu').click(function () {
        $('.menu').load('/cabinet/home/menu');
    });
});