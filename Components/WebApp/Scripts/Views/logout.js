$("#logout").click(function () {
    sessionStorage.clear();
    window.location.href = "/Home/Index";
});
