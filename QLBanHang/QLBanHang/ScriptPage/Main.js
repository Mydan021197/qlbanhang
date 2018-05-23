


$(document).ready(function () {
    $("#search").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/TrangChu/dsSP",
                dataType: "json",
                data: { search: $("#search").val() },
                success: function (listSP) {
                    response($.map(listSP, function (item) {
                        return { value: item.tensp + ' ' +item.Id};
                    }));
                },
                error: function (error, status) {
                    alert("lỗi");
                }
            });
        }, select: function (event, ui) {           
            var tensp = ui.item.value.split(' ');
            $("#xemttSP").attr("href", "/TrangChu/Details/" + tensp[tensp.length - 1] + "");
        }, minLength: 0
    }).focus(function () {
        $(this).autocomplete("search", "");
    });
});