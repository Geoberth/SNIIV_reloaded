#pragma checksum "C:\Users\pe.norberto.rojas\source\repos\Geoberth\SNIIV_reloaded\sniiv\Views\Cubo\Financiamiento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "956d293368a11625a80b2d55b8c85b36b02b2a2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cubo_Financiamiento), @"mvc.1.0.view", @"/Views/Cubo/Financiamiento.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\pe.norberto.rojas\source\repos\Geoberth\SNIIV_reloaded\sniiv\Views\_ViewImports.cshtml"
using sniiv;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\pe.norberto.rojas\source\repos\Geoberth\SNIIV_reloaded\sniiv\Views\_ViewImports.cshtml"
using sniiv.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\pe.norberto.rojas\source\repos\Geoberth\SNIIV_reloaded\sniiv\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"956d293368a11625a80b2d55b8c85b36b02b2a2b", @"/Views/Cubo/Financiamiento.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec35af421ca7f3dc8a2f18a41a548d91d9184c1b", @"/Views/_ViewImports.cshtml")]
    public class Views_Cubo_Financiamiento : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/plotly/plotly-basic-latest.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery-1.11/jquery-ui.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery-1.11/jquery.ui.touch-punch.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/pivottable/pivot.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/pivottable/pivot.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/plotly/plotly_renderers.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery-base64/jquery.base64.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/util.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/cubo.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/cubo_v2.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\pe.norberto.rojas\source\repos\Geoberth\SNIIV_reloaded\sniiv\Views\Cubo\Financiamiento.cshtml"
  
    ViewData["Title"] = "Financiamiento";
    List<SelectListItem> anios = (List<SelectListItem>)ViewBag.anios;
    string fecha = ViewBag.fecha;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "956d293368a11625a80b2d55b8c85b36b02b2a2b8571", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "956d293368a11625a80b2d55b8c85b36b02b2a2b9792", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "956d293368a11625a80b2d55b8c85b36b02b2a2b10978", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "956d293368a11625a80b2d55b8c85b36b02b2a2b12200", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "956d293368a11625a80b2d55b8c85b36b02b2a2b13466", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "956d293368a11625a80b2d55b8c85b36b02b2a2b14653", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <!-- jqueryBase64 -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "956d293368a11625a80b2d55b8c85b36b02b2a2b15869", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "956d293368a11625a80b2d55b8c85b36b02b2a2b16973", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "956d293368a11625a80b2d55b8c85b36b02b2a2b18161", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "956d293368a11625a80b2d55b8c85b36b02b2a2b19428", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $(""#myBtn"").click(function () {
                $(""#myModal"").modal();
            });
        });
    </script>
    <script type=""text/javascript"">
        function mostrarCubo(isDefault) {
            variables = []; dimensionesSelect = [];
            //IE no soporta parametros opcionales
            if (typeof (isDefault) === 'undefined') isDefault = false;

            anio_inicio = $('#ddl_inicio').val();
            anio_fin = $('#ddl_fin').val();
            if (anio_inicio != anio_fin)
                variables.push('anio');

            clave_estado = ($('#ddl_estado').val() == null) ? '0' : $('#ddl_estado').val();
            clave_municipio = ($('#ddl_municipio').val() == null) ? '0' : $('#ddl_municipio').val();
            if (clave_estado == '00')
                variables.push('estado');
            if (clave_municipio == '000')
                variables.push('municipio');

            $.each($(""input[na");
                WriteLiteral(@"me='variable']:checked""), function () {
                variables.push($(this).val());
            });

            dimensionesSelect = isDefault ? ['organismo', 'modalidad', 'tipo_credito'] : variables;
            if (dimensionesSelect.length > 0) {
                if (dimensionesSelect.length > limite)
                    mostrarMensaje('Sólo puede seleccionar ' + limite + ' variables');
                else {
                    var numberFormat = $.pivotUtilities.numberFormat;
                    var intFormat = numberFormat({ digitsAfterDecimal: digitsAfterDecimal });
                    var decimalFormat = numberFormat({ prefix: prefix });
                    var cols = isDefault ? ['modalidad', 'tipo_credito'] : [];
                    var rows = isDefault ? ['organismo'] : [];
                    var hidden = traerDimensionesHidden(anio_inicio, anio_fin);
                    var tpl = $.pivotUtilities.aggregatorTemplates;
                    var renderers = $.extend($.pivotUtilities.r");
                WriteLiteral(@"enderers,
                        $.pivotUtilities.plotly_renderers);

                    var functionsConfig = {
                        renderers: renderers,
                        cols: cols,
                        rows: rows,
                        hiddenAttributes: hidden,
                        aggregators: {
                            'acciones': function () { return tpl.sum(intFormat)(['acciones']) },
                            'monto': function () { return tpl.sum(decimalFormat)(['monto']) }
                        },
                        sorters: {
                            mes: $.pivotUtilities.sortAs(lstMes),
                            modalidad: $.pivotUtilities.sortAs(['Viviendas nuevas', 'Viviendas existentes', 'Mejoramientos', 'Otros programas']),
                            grupo_organismo: $.pivotUtilities.sortAs(['Onavis', 'Entidades financieras', 'Subsidios federales', 'Otros organismos', 'Organismos estatales', 'Programas emergentes'])
                        ");
                WriteLiteral(@"},
                        rendererName: ""Mapa de calor""
                    };
                    $("".load"").show();

                    $.getJSON(path + 'CuboAPI/GetFinanciamiento/' + traerAnios(anio_inicio, anio_fin) + '/' + clave_estado + '/' + clave_municipio + '/' + dimensionesSelect)
                        .done(function (mps) {
                            if (mps.length > 0)
                                $('#output').pivotUI(mps, functionsConfig, true);
                            else
                                mostrarMensaje('No hay datos, favor de cambiar su busqueda');
                        })
                        .always(function () {
                            $("".load"").hide();
                        });

                    crearNotas(dimensionesSelect);
                }
            }
            else
                mostrarMensaje('Seleccione al menos un indicador');
        }

        function crearNotas(dimensionesSelect) {
            var notas = $");
                WriteLiteral(@"('#notes');
            notas.empty();
            var rango_salarial = false;
            $.each(dimensionesSelect, function (index, value) {
                switch (value) {
                    case 'rango_salarial':
                        if (!rango_salarial)
                            notas.append('<li class=""list-group-item"">' + nota_rango_salarial + '</li>');
                        rango_salarial = true;
                        break;
                    case 'valor_vivienda':
                        if (!rango_salarial)
                            notas.append('<li class=""list-group-item"">' + nota_rango_salarial + '</li>');
                        notas.append('<li class=""list-group-item""><small><strong>Económica.</strong> Hasta 118 UMA</small></li>');
                        notas.append('<li class=""list-group-item""><small><strong>Popular.</strong> Mayor a 118 UMA hasta 200 UMA</small></li>');
                        notas.append('<li class=""list-group-item""><small><strong>Tradiciona");
                WriteLiteral(@"l.</strong> Mayor a 200 UMA hasta 350 UMA</small></li>');
                        notas.append('<li class=""list-group-item""><small><strong>Media.</strong> Mayor a 350 UMA hasta 750 UMA</small></li>');
                        notas.append('<li class=""list-group-item""><small><strong>Residencial.</strong> Mayor a 750 UMA hasta 1,500 UMA</small></li>');
                        notas.append('<li class=""list-group-item""><small><strong>Residencial plus.</strong> Mayor a 1,500 UMA</small></li>');
                        rango_salarial = true;
                        break;
                    case 'modalidad':
                        notas.append('<li class=""list-group-item"">Las modalidades; Vivienda nueva y Vivienda existente incluyen cofinanciamientos y subsidios ligados a un crédito</li>');
                        notas.append('<li class=""list-group-item"">La modalidad Mejoramientos incluye créditos y subsidios para Ampliaciones y Rehabilitaciones</li>');
                        notas.append('<li class=""li");
                WriteLiteral(@"st-group-item"">La modalidad Otros programas incluye créditos y subsidios para Pago de pasivos y Lotes con servicios</li>');
                        break;
                    case 'tipo_credito':
                        notas.append('<li class=""list-group-item"">En Cofinanciamientos y Subsidios se incorporan más de una acción (crédito y subsidio)</li>');
                        notas.append('<li class=""list-group-item"">El Crédito Individual equivale a una unidad de vivienda</li>');
                        break;
                    case 'poblacion_indigena':
                        var poblacion = 'Información con base en el “Catálogo de Localidades Indígenas 2015”.' +
                            ' Cabe señalar que no se considera la clasificación de 14 municipios recientemente dados de alta por el' +
                            ' Instituto Nacional de Estadística y Geografía (INEGI): San Quintín-B.C., San Felipe-B.C., Seybaplaya-Cam.,' +
                            ' Dzitbalché-Cam., Capitán Luis Án");
                WriteLiteral(@"gel Vidal-Chis., Rincón Chamula San Pedro-Chis., El Parral-Chis.,' +
                            ' Emiliano Zapata-Chis., Mezcalapa-Chis., Honduras de la Sierra-Chis., Coatetelco-Mor., Xoxocotla-Mor.,' +
                            ' Hueyapan-Mor., Puerto Morelos-Qroo.; mientras que ya no se consideran 7 municipios de la clasificación del' +
                            ' “Catálogo de Localidades Indígenas 2010” siendo Buenaventura-Chih., Santa Isabel-Chih., Temósachic-Chih.,' +
                            ' Matías Romero Avendaño-Oax., San Francisco Chindúa-Oax, San Nicolás de los Ranchos-Pue. y General Plutarco Elías Calles-Son.';
                        notas.append('<li class=""list-group-item"">' + poblacion + '</li>');
                        break;
                    case 'zona':
                        var zona = 'Las siguientes clasificaciones se retoman de la metodología para el Índice de Desarrollo Humano Municipal en México,' +
                            ' publicado por el Programa de las ");
                WriteLiteral(@"Naciones Unidas para el Desarrollo (PNUD):';
                        notas.append('<li class=""list-group-item"">' + zona + '</li>');
                        notas.append('<li class=""list-group-item""><small><strong>Rural.</strong> Corresponde a los municipios con más del 50% de la población que reside en localidades menores a 2 mil 500 habitantes.</small></li>');
                        notas.append('<li class=""list-group-item""><small><strong>Semiurbano.</strong> Corresponde a los municipios con más del 50% de la población que reside en localidades entre 2 mil 500 y 14 mil 999 habitantes.</small></li>');
                        notas.append('<li class=""list-group-item""><small><strong>Urbano.</strong> Refiere a los municipios con más del 50% de la población que reside en localidades de 15 mil habitantes y más.</small></li>');
                        notas.append('<li class=""list-group-item""><small><strong>Mixto.</strong> Corresponde a los municipios cuya población se reparte en las categorías anteriores, si");
                WriteLiteral(@"n que alguna tenga más del 50%.</small></li>');
                        break;
                    default:
                        break;
                }
            });
            if (notas.children().length > 0)
                $('#info').show();
            else
                $('#info').hide();
        }
    </script>
");
            }
            );
            WriteLiteral("\r\n<div class=\"page-header\">\r\n    <h2>\r\n        Financiamientos <small>");
#nullable restore
#line 169 "C:\Users\pe.norberto.rojas\source\repos\Geoberth\SNIIV_reloaded\sniiv\Views\Cubo\Financiamiento.cshtml"
                          Write(fecha);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</small>
    </h2>
</div>

<div class=""alert alert-info alert-dismissible"" role=""alert"" style=""display: none"">
    <button type=""button"" class=""close"" aria-label=""Close"" onclick=""$('.alert').hide()""><span aria-hidden=""true"">&times;</span></button>
    <strong>¡Atento!</strong><span class=""lbl_msj""></span>
</div>

<div class=""alert alert-success"" role=""alert"">
    <strong>Da clic en el botón para ver el tutorial de como utilizar los cubos dinámicos &nbsp;&nbsp;&nbsp;</strong>
    <button type=""button"" class=""btn btn-success"" id=""myBtn"">Abrir Tutorial</button>
</div>
<div class=""modal fade"" id=""myModal"" role=""dialog"">
    <div class=""modal-dialog modal-lg"">

        <div class=""modal-content"">
            <div class=""modal-header"" style=""background-color: #0C231E !important;"">
                <button type=""button"" class=""btn btn-modal btn-lg"" data-dismiss=""modal"" style=""background-color: #123b32 !important; "">Cerrar Tutorial</button>
            </div>
            <div class=""modal-body"">
 ");
            WriteLiteral(@"               <div class=""embed-responsive embed-responsive-16by9"">
                    <iframe src=""/Inicio/Tutorial_cubos""></iframe>
                </div>
            </div>
        </div>

    </div>
</div>

<div class=""row"">
    <div class=""col-md-2"">
        <div class=""form-group"">
            <label>Año:</label>
            ");
#nullable restore
#line 203 "C:\Users\pe.norberto.rojas\source\repos\Geoberth\SNIIV_reloaded\sniiv\Views\Cubo\Financiamiento.cshtml"
       Write(Html.DropDownList("ddl_inicio", anios, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <label>a:</label>\r\n            ");
#nullable restore
#line 207 "C:\Users\pe.norberto.rojas\source\repos\Geoberth\SNIIV_reloaded\sniiv\Views\Cubo\Financiamiento.cshtml"
       Write(Html.DropDownList("ddl_fin", anios, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
    </div>

    <div class=""col-md-4"">
        <div class=""form-group"">
            <label>Estado:</label>
            <select id=""ddl_estado"" class=""form-control""></select>
        </div>
        <div id=""dv_municipio"" class=""form-group"">
            <label>Municipio:</label>
            <select id=""ddl_municipio"" class=""form-control""></select>
        </div>
    </div>

    <div class=""col-md-4"">
        <div class=""form-group"">
            <label>Variables:</label>
            <div class=""div-var"">
                <div class=""checkbox"">
                    <label>
                        <input type=""checkbox"" name=""variable"" value=""modalidad"">Modalidad
                    </label>
                </div>
                <div class=""checkbox"">
                    <label>
                        <input type=""checkbox"" name=""variable"" value=""tipo_credito"">Tipo de crédito
                    </label>
                </div>
                <div class=""checkbox"">
   ");
            WriteLiteral(@"                 <label>
                        <input type=""checkbox"" name=""variable"" value=""grupo_organismo"">Grupo de organismo
                    </label>
                </div>
                <div class=""checkbox"">
                    <label>
                        <input type=""checkbox"" name=""variable"" value=""organismo"">Organismo
                    </label>
                </div>
                <div class=""checkbox"">
                    <label>
                        <input type=""checkbox"" name=""variable"" value=""destino_credito"">Destino del crédito
                    </label>
                </div>
                <div class=""checkbox"">
                    <label>
                        <input type=""checkbox"" name=""variable"" value=""mes"">Mes
                    </label>
                </div>
                <div class=""checkbox"">
                    <label>
                        <input type=""checkbox"" name=""variable"" value=""genero"">Sexo
                    </label>
     ");
            WriteLiteral(@"           </div>
                <div class=""checkbox"">
                    <label>
                        <input type=""checkbox"" name=""variable"" value=""rango_edad"">Grupos de edad
                    </label>
                </div>
                <div class=""checkbox"">
                    <label>
                        <input type=""checkbox"" name=""variable"" value=""rango_salarial"">Rango salarial
                    </label>
                </div>
                <div class=""checkbox"">
                    <label>
                        <input type=""checkbox"" name=""variable"" value=""valor_vivienda"">Valor de la vivienda
                    </label>
                </div>
                <div class=""checkbox"">
                    <label>
                        <input type=""checkbox"" name=""variable"" value=""poblacion_indigena"">Población indígena
                    </label>
                </div>
                <div class=""checkbox"">
                    <label>
                        <i");
            WriteLiteral(@"nput type=""checkbox"" name=""variable"" value=""zona"">Zona
                    </label>
                </div>
            </div>
        </div>
    </div>

    <div class=""col-md-2"">
        <div class=""form-group"">
            <button type=""button"" id=""btn_aceptar"" data-loading-text=""Loading..."" class=""btn btn-default btn-block"">Aceptar</button>
            <a id=""financiamiento"" class=""btn btn-default btn-block btn-export"" href=""#"" role=""button"">Descargar</a>
        </div>
    </div>
</div>

<div class=""load""><br /><br /><h5>Cargando información del cubo...</h5></div>
<div id=""output"" class=""table-responsive""></div>

<br />
<div id=""info"" class=""row"">
    <div class=""col-md-12"">
        <div class=""panel-group"" role=""tablist"">
            <div class=""panel panel-info"">
                <div class=""panel-heading"" role=""tab"" id=""collapseListGroupHeading1"">
                    <h4 class=""panel-title"">
                        <a href=""#collapseListGroup1""");
            BeginWriteAttribute("class", " class=\"", 16367, "\"", 16375, 0);
            EndWriteAttribute();
            WriteLiteral(@" role=""button"" data-toggle=""collapse"" aria-expanded=""true"" aria-controls=""collapseListGroup1"">
                            <span class=""glyphicon glyphicon-info-sign"" aria-hidden=""true""></span>Notas
                        </a>
                    </h4>
                </div>
                <div class=""panel-collapse collapse in"" role=""tabpanel"" id=""collapseListGroup1"" aria-labelledby=""collapseListGroupHeading1"" aria-expanded=""true""");
            BeginWriteAttribute("style", " style=\"", 16818, "\"", 16826, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <ul id=\"notes\" class=\"list-group\"></ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
