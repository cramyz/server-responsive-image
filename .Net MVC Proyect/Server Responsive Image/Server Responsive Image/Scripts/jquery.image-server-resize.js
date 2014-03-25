;
(function ($) {
    $.fn.extend({
        /*
        * $.resizeInServer()
        * @Author               @cramyz (Camilo Nicolas Ramirez Valencia)
        * @description          jQuery method
        * @param {Object}       [settings] optional settings
        * @return {Collection}  All element selected by JQuery Selector
        */
        resizeInServer: function (userOption) {
            //Guardamos el listado de elementos
            var imagenes = $(this);

            //Opciones por defecto
            var defaultOption = {
                width: 'width',
                height: 'height',
                url: '/ResponsiveImages/GetResponsiveImages?',
                src: 'src='
            };
            //Hacemos merge por si el usuario sobre-escribio alguna opcion
            if (userOption != undefined) {
                $.extend(defaultOption, userOption);
            }
            //Vinculamos nuestra funcion al evento "resize"
            $(window).on('resize', function () {
                resizeasd();
            });
            //traemos las imagenes resizadas
            $(document).ready(function () {
                resizeasd();
            });
            return this;

            //Funcion encargada de cambiar los source de las imagenes respectivas
            function resizeasd() {
                //Recorremos las imagenes a rezisar
                imagenes.each(function () {
                    var srcImg = $(this).attr('data-src');
                    var url = defaultOption.url + defaultOption.src + srcImg + '&' + defaultOption.width + '=' + $(this).width() + '&' + defaultOption.height + '=' + $(this).height();
                    $(this).children('img').attr('src', url);
                });
            }
        }
    });
})(jQuery);