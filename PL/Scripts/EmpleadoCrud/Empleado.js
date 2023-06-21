$(document).ready(function () {
    GetAll();
    EstadoGetAll();
})


function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:59638/api/Empleado/GetAll',

        success: function (result) { 
            $('#Empleado tbody').empty();
            $.each(result.Objects, function (i, empleado) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> <button class="btn btn-warning" onclick="GetById(' + empleado.IdEmpleado + ')"><span class="glyphicon glyphicon-edit"></span></button></td>'
                    + "<td  id='id' class='text-center' style='display: none;'>" + empleado.IdEmpleado + "</td>"
                    + "<td class='text-center'>" + empleado.NumeroNomina + "</td>"
                    + "<td class='text-center'>" + empleado.Nombre +" " + empleado.ApellidoPaterno + " " + empleado.ApellidoMaterno + "</td>"
                    + "<td class='text-center'>" + empleado.Estado.Nombre + "</td>"
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.IdEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'
                    + "</tr>";
                $("#Empleado tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.ErrorMessage);
        }
    });
};

function EstadoGetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:59638/api/Estado/GetAll',
        success: function (result) {
            $("#ddlEstado").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, estado) {
                $("#ddlEstado").append('<option value="'+ estado.IdEstado + '">' + estado.Nombre + '</option>');
            });
        }
    });
}

function AbrirModal() {
    $("#modalPromociones").modal("show");
}

function CerrarModal() {
    $('#modalPromociones').modal('hide');
    $('#ddlEstado').empty();
    $('#modalPromociones').click(function () {
        $('input[type="text"]').val('')
        $.ajax({
            type: 'GET',
            url: 'http://localhost:59638/api/Estado/GetAll',
            success: function (result) {
                $("#ddlEstado").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
                $.each(result.Objects, function (i, estado) {
                    $("#ddlEstado").append('<option value="' + estado.IdEstado + '">' + estado.Nombre + '</option>');
                });
            }
        });
    });
}



function Add() {
    var empleado = {
        IdEmpleado: 0,
        NumeroNomina: $('#txtNumeroNomina').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val(),
        Estado: {
            IdEstado: $('#ddlEstado').val()
        }
    }
    $.ajax({
        type: 'POST',
        url: 'http://localhost:59638/api/Empleado/Add',
        dataType: 'json',
        data: empleado,
        success: function (result) {
            alert('Se Ingreso Correctamente el empleado');
            $('#modal').modal();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
}

function Update() {
    var empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(),
        NumeroNomina: $('#txtNumeroNomina').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val(),
        Estado: {
            IdEstado: $('#ddlEstado').val()
        }
    }
    $.ajax({
        type: 'POST',
        url: 'http://localhost:59638/api/Empleado/Update',
        dataType: 'json',
        data: empleado,
        success: function (result) {
            alert('Se actualizo corretamente el empleado');
            $('#modal').modal();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
}

function Modal() {
    if ($("#txtIdEmpleado").val() == 0) {
        Add();
    }
    else {
        Update();
    }
}

function GetById(IdEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:59638/api/Empleado/GetById/' + IdEmpleado,
        success: function (result) {
            $('#txtIdEmpleado').val(result.Object.IdEmpleado);
            $('#txtNumeroNomina').val(result.Object.NumeroNomina);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtApellidoPaterno').val(result.Object.ApellidoPaterno);
            $('#txtApellidoMaterno').val(result.Object.ApellidoMaterno);
            $('#ddlEstado').val(result.Object.Estado.IdEstado);
            $('#modalPromociones').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
}

function Eliminar(IdEmpleado) {

    if (confirm("¿Estas seguro de eliminar el empleado seleccionado?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:59638/api/Empleado/Delete/' + IdEmpleado,
            success: function (result) {
                $('#modal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
}