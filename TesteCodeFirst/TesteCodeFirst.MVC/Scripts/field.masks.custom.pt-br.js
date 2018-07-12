$(function () {
    $('.campoValorMonetario').autoNumeric({ aSep: '.', aDec: ',', aSign: '', mDec: 2 });
    $(".campoCPF").mask("999.999.999-99");
    $(".campoTelefone").mask("(99)99999-9999");
});
