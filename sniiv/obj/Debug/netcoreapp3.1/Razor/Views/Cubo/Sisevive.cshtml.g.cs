#pragma checksum "E:\Azure\sniiv\Views\Cubo\Sisevive.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2285d981b5716d46e80606b9f7fe54d02afea48"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cubo_Sisevive), @"mvc.1.0.view", @"/Views/Cubo/Sisevive.cshtml")]
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
#line 1 "E:\Azure\sniiv\Views\_ViewImports.cshtml"
using sniiv;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Azure\sniiv\Views\_ViewImports.cshtml"
using sniiv.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Azure\sniiv\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2285d981b5716d46e80606b9f7fe54d02afea48", @"/Views/Cubo/Sisevive.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"caf6fc7e17390637ee7a4d1b16d5f6a3a119c2e3", @"/Views/_ViewImports.cshtml")]
    public class Views_Cubo_Sisevive : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "E:\Azure\sniiv\Views\Cubo\Sisevive.cshtml"
  
    ViewData["Title"] = "SISEVIVE";
    List<SelectListItem> anios = (List<SelectListItem>)ViewBag.anios;
    string fecha = ViewBag.fecha;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n");
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2285d981b5716d46e80606b9f7fe54d02afea488246", async() => {
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
                WriteLiteral("\n");
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2285d981b5716d46e80606b9f7fe54d02afea489465", async() => {
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
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2285d981b5716d46e80606b9f7fe54d02afea4810649", async() => {
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
                WriteLiteral("\n");
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c2285d981b5716d46e80606b9f7fe54d02afea4811869", async() => {
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
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2285d981b5716d46e80606b9f7fe54d02afea4813133", async() => {
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
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2285d981b5716d46e80606b9f7fe54d02afea4814318", async() => {
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
                WriteLiteral("\n    <!-- jqueryBase64 -->\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2285d981b5716d46e80606b9f7fe54d02afea4815530", async() => {
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
                WriteLiteral("\n\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2285d981b5716d46e80606b9f7fe54d02afea4816630", async() => {
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
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c2285d981b5716d46e80606b9f7fe54d02afea4817816", async() => {
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
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2285d981b5716d46e80606b9f7fe54d02afea4819081", async() => {
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

            $.each($(""input[name='variable']:checked""), ");
                WriteLiteral(@"function () {
                variables.push($(this).val());
            });

            dimensionesSelect = isDefault ? ['estado', 'programa'] : variables;
            if (dimensionesSelect.length > 0) {
                if (dimensionesSelect.length > limite)
                    mostrarMensaje('Sólo puede seleccionar ' + limite + ' variables');
                else {
                    var numberFormat = $.pivotUtilities.numberFormat;
                    var intFormat = numberFormat({ digitsAfterDecimal: digitsAfterDecimal });
                    var decimalFormat = numberFormat({ prefix: prefix });
                    var cols = isDefault ? ['estado'] : [];
                    var rows = isDefault ? [] : [];
                    var colOrder = isDefault ? ""value_z_to_a"" : ""key_a_to_z"";
                    var rendererName = isDefault ? ""Gráfica de barras"" : ""Tabla"";
                    var hidden = traerDimensionesHidden(anio_inicio, anio_fin);
                    var tpl = $.pivotUtilities.aggregatorTempla");
                WriteLiteral(@"tes;
                    var renderers = $.extend($.pivotUtilities.renderers,
                        $.pivotUtilities.plotly_renderers);

                    var functionsConfig = {
                        renderers: renderers,
                        cols: cols,
                        rows: rows,
                        hiddenAttributes: hidden,
                        aggregators: {
                            'acciones': function () { return tpl.sum(intFormat)(['viviendas']) },
                        },
                        sorters: {
                            mes: $.pivotUtilities.sortAs(lstMes),
                            pcu: $.pivotUtilities.sortAs(lstPCU)
                        },
                        colOrder: colOrder,
                        rendererName: rendererName
                    };
                    $("".load"").show();

                    $.getJSON(path + 'CuboAPI/GetSisevive/' + traerAnios(anio_inicio, anio_fin) + '/' + clave_estado + '/' + clave_municipio + '/' + dimension");
                WriteLiteral(@"esSelect)
                        .done(function (mps) {
                            if (mps.length > 0)
                                $('#output').pivotUI(mps, functionsConfig, true);
                            else
                                mostrarMensaje('No hay datos, favor de cambiar su busqueda');
                        })
                        .always(function () {
                            $("".load"").hide();
                        });
                    //crearNotas(dimensionesSelect);
                }
            }
            else
                mostrarMensaje('Seleccione al menos un indicador');
        }
    </script>
");
            }
            );
            WriteLiteral("\n<div class=\"page-header\">\n    <h2>\n        SISEVIVE <small>");
#nullable restore
#line 108 "E:\Azure\sniiv\Views\Cubo\Sisevive.cshtml"
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
                <div c");
            WriteLiteral(@"lass=""embed-responsive embed-responsive-16by9"">
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
#line 142 "E:\Azure\sniiv\Views\Cubo\Sisevive.cshtml"
       Write(Html.DropDownList("ddl_inicio", anios, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n        <div class=\"form-group\">\n            <label>a:</label>\n            ");
#nullable restore
#line 146 "E:\Azure\sniiv\Views\Cubo\Sisevive.cshtml"
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
                        <input type=""checkbox"" name=""variable"" value=""mes"">Mes
                    </label>
                </div>
                <div class=""checkbox"">
                    <label>
                        <input type=""checkbox"" name=""variable"" value=""clima"">Clima
                    </label>
                </div>
                <div class=""checkbox"">
                    <label>
                        <input typ");
            WriteLiteral(@"e=""checkbox"" name=""variable"" value=""pcu"">PCU´s
                    </label>
                </div>

                <div class=""checkbox"">
                    <label>
                        <input type=""checkbox"" name=""variable"" value=""programa"">Programa
                    </label>
                </div>
                <div class=""checkbox"">
                    <label>
                        <input type=""checkbox"" name=""variable"" value=""tipologia_vivienda"">Tipología de vivienda
                    </label>
                </div>
                <div class=""checkbox"">
                    <label>
                        <input type=""checkbox"" name=""variable"" value=""idg"">IDG
                    </label>
                </div>
                <div class=""checkbox"">
                    <label>
                        <input type=""checkbox"" name=""variable"" value=""grupo"">Grupo
                    </label>
                </div>
            </div>
        </div>
    </div>

    <div class=""col-md-2"">
        <div");
            WriteLiteral(@" class=""form-group"">
            <button type=""button"" id=""btn_aceptar"" data-loading-text=""Loading..."" class=""btn btn-default btn-block"">Aceptar</button>
            <a id=""sisevive"" class=""btn btn-default btn-block btn-export"" href=""#"" role=""button"">Descargar</a>
        </div>
    </div>
</div>

<div class=""load""><br /><br /><h5>Cargando información del cubo...</h5></div>
<div id=""output"" class=""table-responsive""></div>");
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
