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
var paymentTypeSelected = { id: 0, isForGroups: false};
var studentsSelected = [];

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

            if (student.groupOfStudentId !== 0) {
                $("#js-students").append("<li class='list-group-item'>" + student.name + " " + student.lastName + "</li>");
                $("#js-student").typeahead("val", "");

                groupDto.studentsIds.push(student.id);

                studentsSelected.push(student);
            }
        });


        // start custom validation methods

    $.validator.addMethod("validPaymentType", function () {

        if (paymentTypeSelected.id && paymentTypeSelected.id !== 0) {
            return true;
        }
        else {
            return false;
        }
    }, "Selecciona un Tipo de Pago Valido.");

    $.validator.addMethod("isForGroupsValidator", function () {

        return paymentTypeSelected.isForGroups;

    }, "El Tipo de pago debe ser familiar.");

    $.validator.addMethod("isVIPValidator", function () {
        if ($("#js-isVIP").is(":checked")) {
            if (paymentTypeSelected.isVIP) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return true;
        }
    }, "Debes seleccionar un metodo de pago tipo VIP");


    $.validator.addMethod("isVIPCheckedValidator", function () {
        if (!$("js-isVIP").is(":checked")) {
            if (paymentTypeSelected.isVIP) {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    }, "La familia debe ser VIP para aceptar el Tipo de pago.");

    $.validator.addMethod("validStudent", function () {
        if (groupDto.studentsIds.length != 0) {
            return true;
        }
        else {
            return false;
        }

    }, "Selecciona un Estudiante Valido.");

    $.validator.addMethod("studentGroupValidation", function () {
        for (var i = 0; i < studentsSelected.length, i++;) {
            if (studentsSelected[i].groupOfStudentId !== 0 || studentsSelected[i].groupOfStudentId !== null) {
                return false;
            }
            else {
                return true;
            }
        }
    }, "El estudiante seleccionado ya pertenece a una familia.");

    // end custom validation methods

    $("#newGroup").validate({
        submitHandler: function () {

            groupDto.name = $("#js-name").val();

            if ($("#js-isVIP").is(":checked")) {
                groupDto.isVIP = true;
            }
            else {
                groupDto.isVIP = false;
            }


            // API communications
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
        }
    });
});

// # End Group Section