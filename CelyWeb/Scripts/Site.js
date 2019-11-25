
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



$(document).ready(function () {

    var studentsName = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/Api/Students?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#remote .typeahead').typeahead(null, {
        name: 'studentName',
        display: 'Name',
        source: studentsName
    });

});