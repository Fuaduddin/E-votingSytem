/// Constant data
const division = data;
const disctrict = districts;




$('#division').append($('<option/>').attr("value", " ").text("Please Select a Zone"));

$(function () {
    $.each(division, function (i, option) {
        $('#division').append($('<option/>').attr("value", option.name).text(option.name));
    });
});

$("#val-skill").change(function () {
    var id = "";
    // var division = document.getElementById("val-skill");
    debugger
    var divisionname = $("#val-skill option:selected").text();
    $('#distrcict').empty();
    $.each(data, function (i, option) {
        if (option.name == divisionname) {
            id = option.id;
        }
    });
    $.each(districts, function (i, district) {
        if (district.division_id == id) {
            $('#distrcict').append($('<option/>').attr("value", district.name).text(district.name));
        }
    });
});