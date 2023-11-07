$(function(){

    const CNPJS = document.querySelectorAll(".CNPJ")
    const CEPS = document.querySelectorAll(".CEP")

    $('.IE').mask('999.999.999.999');
    $('.CNPJ').mask('99.999.999/9999-99');
    $('.CEP').mask('99999-999');

    $('#myInput').keyup(function(){
        const val = $(this).val().replace(/[^0-9]/g, '');
        
        console.log('val', val);
            $('#IE').val(val);
            $(this).val($('#IE').masked());
            $('#CNPJ').val(val);
            $(this).val($('#CNPJ').masked());
            $('#CEP').val(val);
            $(this).val($('#CEP').masked());
    });
});