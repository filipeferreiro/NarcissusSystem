$(function() {

    /* SCRIPT DO BANNER PRINCIPAL DA HOME */
    $('.container-banner').slick({
        slidesToShow:1,
        arrows:true,
        dots:false,
        infinite:true,
        autoplay: true,
        autoplaySpeed: 3000,
        responsive: [
            {
                breakpoint: 765,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: true,
                    autoplay: true,
                    autoplaySpeed: 2000,
                    arrows:false,
                    dots: true
                }
            }
        ]
    });

    $('.container-depoimentos').slick({
        centerMode: true,
        centerPadding: '0',
        slidesToShow: 1,
        arrows: false,
        dots: true,
    });

    $('.container-img-slider').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        fade: true,
        asNavFor: '.img-slider-nav',
        draggable: false,
        responsive: [
            {
                breakpoint: 450,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: false,
                    autoplay: false,
                    arrows: false,
                    dots: true,
                    draggable: true,
                }
            }
        ]
    });

    $('.img-slider-nav').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        asNavFor: '.container-img-slider',
        dots: false,
        centerMode: true,
        focusOnSelect: true,
        draggable: false
    });

    $('div.menu-mobile').click(function () {
        //O que vai acontecer quando clicarmos na nav.mobile!
        var listaMenu = $('div.menu-mobile ul');

        if (listaMenu.is(':hidden') == true) {
            //fa fa-times
            //fa fa-bars
            //var icone =  $('.botao-menu-mobile i');
            var icone = $('.botao-menu-mobile').find('i');
            icone.removeClass('fa-bars');
            icone.addClass('fa-times');
            listaMenu.slideToggle();
        }
        else {
            var icone = $('.botao-menu-mobile').find('i');
            icone.removeClass('fa-times');
            icone.addClass('fa-bars');
            listaMenu.slideToggle();
        }

    });

    /* imagem da tabela carrinho some em tela menor que 800px */

    var tela = $(window).width();
    if (tela < 805) {
        $('#some').remove();
    }

/*FUNÇÃO DO SISTEMA DE PESQUISA (-_-) */

    

     /*CONFIGURAÇÃO DO SISTEMA DE AJAX */

     $("input[name=pesquisa]").bind('keyup change input',function(){
        sendRequest();
    })

   $("body:not(.result-pesquisa)").click(function(){
    $('.result-pesquisa').fadeOut();
   })

   function pesquisa(pesquisa){
    $('#lupa').click(function(){
        location.href= "https://localhost/dev_web_completo/projeto_01_lojaVirtual/busca?pdt="+pesquisa
    })
   }



    function sendRequest(){
        $('form').ajaxSubmit({
            data:{'nome':$('input[name=pesquisa]').val()},
            success:function(data){
                $('.result-pesquisa').fadeIn();
                $('.result-produt ul').html(data);
                var busca = $('input[name=pesquisa]').val();
                var busca2 = busca.replace(" ","-");
                pesquisa(busca2);
                pesquisaEnter(busca2);
                
            }
        });
    };


    $(document).ready(function () {
        $('input').keypress(function (e) {
             var code = null;
             code = (e.keyCode ? e.keyCode : e.which);                
             return (code == 13) ? false : true;
        });
     });
 /*--------------------------------------------------------------------------------------- */
    
})