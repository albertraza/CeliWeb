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
    isVIP: false,
    get getName() { return this.name }
};
var paymentTypeSelected = { id: 0, isForGroups: false};
var studentsSelected = [];
var studentSelected = {};

$("#js-groupForm").ready(function () {

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

$("#js-groupForm").ready(function () {

    var students = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/Api/Students?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#js-student').typeahead({
        minLenght: 1,
        highlight: true
    },
        {
            name: 'student',
            display: 'name',
            source: students
        }).on("typeahead:select", function (e, student) {

            if (student.groupOfStudentId === 0) {
                $("#js-students").append("<li class='list-group-item'>" +
                    student.name + " " + student.lastName + "</li>");
                $("#js-student").typeahead("val", "");

                groupDto.studentsIds.push(student.id);

                studentsSelected.push(student);
                studentSelected = student;
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
        if ($("#js-isVIP").is(":checked")) {
            return true;
        }
        else {
            if (paymentTypeSelected.isVIP) {
                return false;
            }
            else {
                return true;
            }
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

        if (groupDto.id !== 0) {
            return true;
        }
        else {
            if (studentSelected.groupOfStudentId !== 0) {
                return false;
            }
            else {
                return true;
            }
        }

    }, "El estudiante " + studentSelected.name + " ya pertenece a una familia.");

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


                // API request 
                if (groupDto.id === 0) {

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

                            paymentTypeSelected = {};
                            groupDto.studentsIds = [];
                            studentsId = [];

                        }).fail(function (e) {
                            toastr.error("Ha ocurrido un error.");
                        });
                } else {


                    $.ajax({
                        url: "/Api/Groups",
                        method: "put",
                        dataType: "json",
                        data: groupDto,
                        success: function (response, status, xhr) {
                            toastr.success("Familia Actualizada");

                            window.localStorage.setItem("gId", 0);
                            $("#js-students").empty();
                            $("#js-name").val("");
                            $("#js-paymentTypes").val("");

                            paymentTypeSelected = {};
                            groupDto.studentsIds = [];
                            groupDto.id = 0;
                            studentsId = [];

                        },
                        error: function (e) {
                            toastr.error("Ha ocurrido un error");
                        }

                    });

                }
            }
        });
});


// # End Group Section


// Index Group Table

$("#js-groupIndex").ready(function () {
    $("#js-listGroups").DataTable({
        ajax: {
            url: "/Api/Groups",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, group) {
                    return "<button id='js-group' class='btn btn-link' data-group-id=" +
                        group.id + ">" + data + "</button>";
                }
            }
        ]
    });
    $("#js-listGroups").on("click", "#js-group", function () {
        var button = $(this);
        window.localStorage.setItem("gId", button.attr("data-group-id"));
        window.location.assign("/Groups/Details/" + button.attr("data-group-id"));
    });
});

// End Index Group Table

// Details Groups

$("#js-Details").ready(function () {
    var groupId = window.localStorage.getItem("gId");

    if (window.localStorage.getItem("gId") !== "0" || window.localStorage.getItem("gId") != "0") {
        $.ajax({
            url: "/Api/Groups/" + groupId,
            method: "get",
            success: function (response) {

                if (response !== null) {
                    $("js-title").text(response.name);
                    $("#js-groupName").text(response.name);
                    $("#js-paymentType").text(response.paymentType.type);
                    $("#js-studentsAmount").text(response.students.length);
                    $("#js-paymentAmount").text(response.paymentType.amount);
                    $("#js-paymentDate").text(new Date(response.students[0].paymentDate).toUTCString());

                    $.each(response.students, function (index, student) {
                        $("#js-studentsInGroup").append("<li class='list-group-item'>" + student.name + " " + student.lastName +
                            "<button class='btn btn-link'><span id='js-student' data-student-id=" +
                            student.id + " class='glyphicon glyphicon-pencil'></span></button></li>");
                    });
                }

            }
        });
    }


    $("#js-studentsInGroup").on("click", "#js-student", function () {
        var button = $(this);
        window.location.assign("/Students/Details/" + button.attr("data-student-id"));
    });

    $("#js-modifyGroup").on("click", function () {
        window.localStorage.setItem("gId", groupId);
        window.location.assign("/Groups/Modify/" + groupDto.id);
    });
});

// End Details Groups


// modify Groups

$("#js-groupForm").ready(function () {

    if (window.localStorage.getItem("gId") !== "0" || window.localStorage.getItem("gId") != "0") {
        $.ajax({
            url: "/Api/Groups/" + window.localStorage.getItem("gId"),
            method: "get",
            success: function (response) {

                if (response !== null) {

                    groupDto = response;

                    studentsSelected = response.students;
                    paymentTypeSelected = response.paymentType;

                    $.each(response.students, function (index, student) {
                        studentsId.push(student.id);
                        groupDto.studentsIds.push(student.id);
                    });

                    $("js-groupTitle").text("Modificar Familia");
                    $("#js-name").val(response.name);
                    $("#js-paymentTypes").val(response.paymentType.type);

                    if (response.isVIP) {
                        $("#js-isVIP").prop("checked", true);
                    }
                    else {
                        $("#js-isVIP").prop("checked", false);
                    }

                    $.each(response.students, function (index, student) {
                        $("#js-students").append("<li class='list-group-item'>" + student.name + " " + student.lastName +
                            "<button class='btn btn-link'><span class='glyphicon glyphicon-trash'></span ></button ></li > ");
                    });
                }
            }
        });
    }
    else {
        studentsSelected = {};
        paymentTypeSelected = {};
        studentsId = [];
        groupDto.id = 0;
    }

});

// end modify Groups