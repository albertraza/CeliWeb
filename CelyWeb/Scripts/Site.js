"use strict";

var studentsId = [];


function readURL(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $("#ImgDetalle")
                .attr("src", e.target.result);
        };

        reader.readAsDataURL(input.files[0]);
    }

}


// # Groups Section

var groupDto = {
    id: 0,
    name: null,
    studentsIds: [],
    paymentTypeId: 0,
    isVIP: false
};
var paymentTypeSelected;
var studentSelected;

$(document).ready(function () {

    var paymentTypes = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('type'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/Api/Payments?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#js-paymentTypes').typeahead({
        minLenght: 3,
        highlight: true
    }, {
            name: 'paymentType',
            display: 'type',
            source: paymentTypes
        }).on("typeahead:select", function (e, paymentType) {
            groupDto.paymentTypeId = paymentType.id;
            paymentTypeSelected = paymentType;
        });


});

$(document).ready(function () {

    var students = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/Api/Students?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#js-student').typeahead({
        minLenght: 3,
        highlight: true
    },
        {
            name: 'student',
            display: 'name',
            source: students
        }).on("typeahead:select", function (e, student) {

            $("#js-students").append("<li class='list-group-item'>" + student.name + " " + student.lastName + "</li>");
            $("#js-student").typeahead("val", "");

            groupDto.studentsIds.push(student.id);
        });

    $("#newGroup").submit(function (e) {

        e.preventDefault();

        groupDto.name = $("#js-name").val();

        if ($("#js-isVIP").is(":checked")) {
            groupDto.isVIP = true;
        }
        else {
            groupDto.isVIP = false;
        }

        $.ajax({
            url: "/Api/Groups",
            method: "post",
            data: groupDto
        })
            .done(function (data) {

                toastr.success("Familia añadida!");

                $("#js-students").empty();
                $("#js-name").val("");
                $("#js-paymentTypes").val("");

                groupDto.studentsIds = [];

            }).fail(function (e) {
                toastr.error("Ha ocurrido un error.");
            });

    });
});

// # End Group Section