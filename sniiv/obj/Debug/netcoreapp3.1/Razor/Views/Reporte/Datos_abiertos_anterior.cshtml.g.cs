#pragma checksum "E:\Azure\sniiv\Views\Reporte\Datos_abiertos_anterior.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f71c28c07dcf36561a2f335327c410a29c899bce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reporte_Datos_abiertos_anterior), @"mvc.1.0.view", @"/Views/Reporte/Datos_abiertos_anterior.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f71c28c07dcf36561a2f335327c410a29c899bce", @"/Views/Reporte/Datos_abiertos_anterior.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"caf6fc7e17390637ee7a4d1b16d5f6a3a119c2e3", @"/Views/_ViewImports.cshtml")]
    public class Views_Reporte_Datos_abiertos_anterior : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/util.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString("selected"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Azure\sniiv\Views\Reporte\Datos_abiertos_anterior.cshtml"
  
    ViewData["Title"] = "Datos abiertos";

    List<SelectListItem> aniosSubsidio = (List<SelectListItem>)ViewBag.aniosSubsidio;
    List<SelectListItem> mesesSubsidio = (List<SelectListItem>)ViewBag.mesesSubsidio;

    List<SelectListItem> aniosFinanciamiento = (List<SelectListItem>)ViewBag.aniosFinanciamiento;
    List<SelectListItem> mesesFinanciamiento = (List<SelectListItem>)ViewBag.mesesFinanciamiento;

    List<SelectListItem> aniosOferta = (List<SelectListItem>)ViewBag.aniosOferta;
    List<SelectListItem> mesesOferta = (List<SelectListItem>)ViewBag.mesesOferta;

    List<SelectListItem> aniosRegistro = (List<SelectListItem>)ViewBag.aniosRegistro;
    List<SelectListItem> mesesRegistro = (List<SelectListItem>)ViewBag.mesesRegistro;

    List<SelectListItem> aniosInventario = (List<SelectListItem>)ViewBag.aniosInventario;
    List<SelectListItem> mesesInventario = (List<SelectListItem>)ViewBag.mesesInventario;

    List<SelectListItem> aniosCnbv = (List<SelectListItem>)ViewBag.aniosCnbv;
    List<SelectListItem> mesesCnbv = (List<SelectListItem>)ViewBag.mesesCnbv;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f71c28c07dcf36561a2f335327c410a29c899bce6318", async() => {
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
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(function () {
            $('[id$=ddl_anio_s]').change(function () {
                mostrar_mes_s();
            });
            $('[id$=ddl_anio_f]').change(function () {
                mostrar_mes_f();
            });
            $('[id$=ddl_anio_ov]').change(function () {
                mostrar_mes_ov();
            });
            $('[id$=ddl_anio_rv]').change(function () {
                mostrar_mes_rv();
            });
            $('[id$=ddl_anio_di]').change(function () {
                mostrar_mes_di();
            });
            $('[id$=ddl_anio_cnbv]').change(function () {
                mostrar_mes_cnbv();
            });

            $('#tab-active').addClass('active');
            $("".lst"").click(function () {
                $(""#lbl_subtitulo"").text($(this).first().text());
            });
        });

        var anio, tipo;
        function mostrar_mes_s() {
            tipo = 1;
            anio = $('#ddl_anio_s').val();
            $.ge");
                WriteLiteral(@"tJSON(path + 'CatalogoAPI/GetMesDatosAbiertos/' + tipo + '/' + anio, function (json) {
                $('#ddl_mes_s').empty();
                $.each(json, function (key, obj) {
                    $('#ddl_mes_s').append($('<option></option>').attr('value', obj.id).text(obj.descripcion));
                });
            });
        }
        function mostrar_mes_f() {
            tipo = 2;
            anio = $('#ddl_anio_f').val();
            $.getJSON(path + 'CatalogoAPI/GetMesDatosAbiertos/' + tipo + '/' + anio, function (json) {
                $('#ddl_mes_f').empty();
                $.each(json, function (key, obj) {
                    $('#ddl_mes_f').append($('<option></option>').attr('value', obj.id).text(obj.descripcion));
                });
            });
        }
        function mostrar_mes_ov() {
            tipo = 3;
            anio = $('#ddl_anio_ov').val();
            $.getJSON(path + 'CatalogoAPI/GetMesDatosAbiertos/' + tipo + '/' + anio, function (json) {
                $('#ddl_mes_o");
                WriteLiteral(@"v').empty();
                $.each(json, function (key, obj) {
                    $('#ddl_mes_ov').append($('<option></option>').attr('value', obj.id).text(obj.descripcion));
                });
            });
        }
        function mostrar_mes_rv() {
            tipo = 4;
            anio = $('#ddl_anio_rv').val();
            $.getJSON(path + 'CatalogoAPI/GetMesDatosAbiertos/' + tipo + '/' + anio, function (json) {
                $('#ddl_mes_rv').empty();
                $.each(json, function (key, obj) {
                    $('#ddl_mes_rv').append($('<option></option>').attr('value', obj.id).text(obj.descripcion));
                });
            });
        }
        function mostrar_mes_di() {
            tipo = 5;
            anio = $('#ddl_anio_di').val();
            $.getJSON(path + 'CatalogoAPI/GetMesDatosAbiertos/' + tipo + '/' + anio, function (json) {
                $('#ddl_mes_di').empty();
                $.each(json, function (key, obj) {
                    $('#ddl_mes_di').append($(");
                WriteLiteral(@"'<option></option>').attr('value', obj.id).text(obj.descripcion));
                });
            });
        }
        function mostrar_mes_cnbv() {
            tipo = 7;
            anio = $('#ddl_anio_cnbv').val();
            $.getJSON(path + 'CatalogoAPI/GetMesDatosAbiertos/' + tipo + '/' + anio, function (json) {
                $('#ddl_mes_cnbv').empty();
                $.each(json, function (key, obj) {
                    $('#ddl_mes_cnbv').append($('<option></option>').attr('value', obj.id).text(obj.descripcion));
                });
            });
        }

        var formato = 1;
        function descargar_dato(tipo, anio, mes) {
            $.getJSON(path + 'ReporteAPI/GetDocumentoMes/' + tipo + '/' + anio + '/' + mes + '/' + formato, function (json) {
                var items = [];
                $.each(json, function (key, val) {
                    items.push(val);
                });
                window.open(items[0]);
            });
        }

        var name_file;
        functi");
                WriteLiteral(@"on descargarSubsidios() {
            name_file = $('[id$=ddl_anio_s]').val() + pad($('[id$=ddl_mes_s]').val(), 2) + '.csv';
            window.open(host_path + 'doc/datos_abiertos/subsidios/' + name_file);
        }
        function descargarFinanciamientos() {
            name_file = $('[id$=ddl_anio_f]').val() + pad($('[id$=ddl_mes_f]').val(), 2) + '.csv';
            window.open(host_path + 'doc/datos_abiertos/financiamientos/' + name_file);
        }
        function descargarOfertaVivienda() {
            name_file = $('[id$=ddl_anio_ov]').val() + pad($('[id$=ddl_mes_ov]').val(), 2) + '.csv';
            window.open(host_path + 'doc/datos_abiertos/oferta_vivienda/' + name_file);
        }
        function descargarRegistroVivienda() {
            name_file = $('[id$=ddl_anio_rv]').val() + pad($('[id$=ddl_mes_rv]').val(), 2) + '.csv';
            window.open(host_path + 'doc/datos_abiertos/registro_vivienda/' + name_file);
        }
        function descargarDiasInventario() {
            name_file = $('");
                WriteLiteral(@"[id$=ddl_anio_di]').val() + pad($('[id$=ddl_mes_di]').val(), 2) + '.csv';
            window.open(host_path + 'doc/datos_abiertos/dias_inventario/' + name_file);
        }
        function descargarCnbv() {
            name_file = $('[id$=ddl_anio_cnbv]').val() + pad($('[id$=ddl_mes_cnbv]').val(), 2) + '.csv';
            window.open(host_path + 'doc/datos_abiertos/cnbv/' + name_file);
        }
    </script>
");
            }
            );
            WriteLiteral(@"
<div class=""page-header"">
    <h2>Histórico de Datos Abiertos</h2>
</div>

<div id=""tabs"">
    <!-- Nav tabs -->
    <ul class=""nav nav-tabs"" role=""tablist"">
        <li role=""presentation"" id=""tab-active"" class=""lst""><a href=""#s"" aria-controls=""s"" role=""tab"" data-toggle=""tab"">Subsidios CONAVI</a></li>
        <li role=""presentation"" class=""lst""><a href=""#f"" aria-controls=""f"" role=""tab"" data-toggle=""tab"">Financiamientos de vivienda</a></li>
        <li role=""presentation"" class=""lst""><a href=""#ov"" aria-controls=""ov"" role=""tab"" data-toggle=""tab"">Inventario de Vivienda</a></li>
        <li role=""presentation"" class=""lst""><a href=""#rv"" aria-controls=""rv"" role=""tab"" data-toggle=""tab"">Registro de vivienda</a></li>
        <li role=""presentation"" class=""lst""><a href=""#di"" aria-controls=""di"" role=""tab"" data-toggle=""tab"">Días de inventario</a></li>
        <!--<li role=""presentation"" class=""lst""><a href=""#rh"" aria-controls=""rh"" role=""tab"" data-toggle=""tab"">Rezago habitacional</a></li>-->
        <li role=""presentati");
            WriteLiteral(@"on"" class=""lst""><a href=""#cg"" aria-controls=""cg"" role=""tab"" data-toggle=""tab"">Capas geográficas</a></li>
        <li role=""presentation"" class=""lst""><a href=""#cnbv"" aria-controls=""cnbv"" role=""tab"" data-toggle=""tab"">CNBV</a></li>
    </ul>
    <br />
    <!-- Tab panes -->
    <div class=""tab-content"">
        <div role=""tabpanel"" class=""tab-pane active"" id=""s"">
            <div class=""form-inline"">
                <div class=""form-group"">
                    <label>Año:</label>
                    ");
#nullable restore
#line 176 "E:\Azure\sniiv\Views\Reporte\Datos_abiertos_anterior.cshtml"
               Write(Html.DropDownList("ddl_anio_s", aniosSubsidio, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n                <div class=\"form-group\">\n                    <label>Mes:</label>\n                    ");
#nullable restore
#line 180 "E:\Azure\sniiv\Views\Reporte\Datos_abiertos_anterior.cshtml"
               Write(Html.DropDownList("ddl_mes_s", mesesSubsidio, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <button id=""btn_descargar_s"" type=""button"" class=""btn btn-default"" onclick=""descargar_dato(1,$('[id$=ddl_anio_s]').val(),$('[id$=ddl_mes_s]').val());"">
                    <span class=""glyphicon glyphicon-download-alt""></span> Descargar
                </button>
            </div>
        </div>

        <div role=""tabpanel"" class=""tab-pane"" id=""f"">
            <div class=""form-inline"">
                <div class=""form-group"">
                    <label>Año:</label>
                    ");
#nullable restore
#line 192 "E:\Azure\sniiv\Views\Reporte\Datos_abiertos_anterior.cshtml"
               Write(Html.DropDownList("ddl_anio_f", aniosFinanciamiento, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n                <div class=\"form-group\">\n                    <label>Mes:</label>\n                    ");
#nullable restore
#line 196 "E:\Azure\sniiv\Views\Reporte\Datos_abiertos_anterior.cshtml"
               Write(Html.DropDownList("ddl_mes_f", mesesFinanciamiento, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                </div>
                <button id=""btn_descargar_f"" type=""button"" class=""btn btn-default"" onclick=""descargar_dato(2,$('[id$=ddl_anio_f]').val(),$('[id$=ddl_mes_f]').val());"">
                    <span class=""glyphicon glyphicon-download-alt""></span> Descargar
                </button>
            </div>
        </div>

        <div role=""tabpanel"" class=""tab-pane"" id=""ov"">
            <div class=""form-inline"">
                <div class=""form-group"">
                    <label>Año:</label>
                    ");
#nullable restore
#line 209 "E:\Azure\sniiv\Views\Reporte\Datos_abiertos_anterior.cshtml"
               Write(Html.DropDownList("ddl_anio_ov", aniosOferta, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n                <div class=\"form-group\">\n                    <label>Mes:</label>\n                    ");
#nullable restore
#line 213 "E:\Azure\sniiv\Views\Reporte\Datos_abiertos_anterior.cshtml"
               Write(Html.DropDownList("ddl_mes_ov", mesesOferta, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <button id=""btn_descargar_ov"" type=""button"" class=""btn btn-default"" onclick=""descargar_dato(3,$('[id$=ddl_anio_ov]').val(),$('[id$=ddl_mes_ov]').val());"">
                    <span class=""glyphicon glyphicon-download-alt""></span> Descargar
                </button>
            </div>
        </div>

        <div role=""tabpanel"" class=""tab-pane"" id=""rv"">
            <div class=""form-inline"">
                <div class=""form-group"">
                    <label>Año:</label>
                    ");
#nullable restore
#line 225 "E:\Azure\sniiv\Views\Reporte\Datos_abiertos_anterior.cshtml"
               Write(Html.DropDownList("ddl_anio_rv", aniosRegistro, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n                <div class=\"form-group\">\n                    <label>Mes:</label>\n                    ");
#nullable restore
#line 229 "E:\Azure\sniiv\Views\Reporte\Datos_abiertos_anterior.cshtml"
               Write(Html.DropDownList("ddl_mes_rv", mesesRegistro, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <button id=""btn_descargar_rv"" type=""button"" class=""btn btn-default"" onclick=""descargar_dato(4,$('[id$=ddl_anio_rv]').val(),$('[id$=ddl_mes_rv]').val());"">
                    <span class=""glyphicon glyphicon-download-alt""></span> Descargar
                </button>
            </div>
        </div>

        <div role=""tabpanel"" class=""tab-pane"" id=""di"">
            <div class=""form-inline"">
                <div class=""form-group"">
                    <label>Año:</label>
                    ");
#nullable restore
#line 241 "E:\Azure\sniiv\Views\Reporte\Datos_abiertos_anterior.cshtml"
               Write(Html.DropDownList("ddl_anio_di", aniosInventario, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n                <div class=\"form-group\">\n                    <label>Mes:</label>\n                    ");
#nullable restore
#line 245 "E:\Azure\sniiv\Views\Reporte\Datos_abiertos_anterior.cshtml"
               Write(Html.DropDownList("ddl_mes_di", mesesInventario, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <button id=""btn_descargar_di"" type=""button"" class=""btn btn-default"" onclick=""descargar_dato(5,$('[id$=ddl_anio_di]').val(),$('[id$=ddl_mes_di]').val());"">
                    <span class=""glyphicon glyphicon-download-alt""></span> Descargar
                </button>
            </div>
        </div>

        <div role=""tabpanel"" class=""tab-pane"" id=""rh"">
            <div class=""form-inline"">
                <div class=""form-group"">
                    <label>Rezago:</label>
                    <select id=""ddl_rezago_rh"" class=""form-control"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f71c28c07dcf36561a2f335327c410a29c899bce21244", async() => {
                WriteLiteral("Estatal");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f71c28c07dcf36561a2f335327c410a29c899bce22510", async() => {
                WriteLiteral("Municipal");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </select>
                </div>
                <asp:Button ID=""btn_export"" class=""btn btn-default"" runat=""server"" Text=""Descargar"" OnClick=""btn_download"" />
            </div>
        </div>

        <div role=""tabpanel"" class=""tab-pane"" id=""cg"">
            <div class=""panel-group"" id=""accordion"" role=""tablist"" aria-multiselectable=""true"">
                <div class=""panel panel-default"">
                    <div class=""panel-heading"" role=""tab"" id=""headingOne"">
                        <h4 class=""panel-title"">
                            <a role=""button"" data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapseOne"" aria-expanded=""true"" aria-controls=""collapseOne"">
                                Perímetros de Contención Urbana 2018
                            </a>
                        </h4>
                    </div>
                    <div id=""collapseOne"" class=""panel-collapse collapse in"" role=""tabpanel"" aria-labelledby=""headingOne"">
                        <div class=""pan");
            WriteLiteral(@"el-body"">
                            <p>Mapas con los PCU de las localidades urbanas (igual o mayor de 15,000 hab) del Sistema Urbano Nacional.</p>
                            <div class=""row"">
                                <div class=""col-md-6"">
                                    <h3>SHP</h3>
                                    <div class=""list-group"">
                                        <a href=""https://sistemas.sedatu.gob.mx/repositorio/proxy/alfresco-noauth/api/internal/shared/node/DXsbGoZTTgG5ytFIlvu-LQ/content/PCU_2018_SHP.zip?a=true"" class=""list-group-item"">2018</a>
                                        <a href=""https://sistemas.sedatu.gob.mx/repositorio/proxy/alfresco-noauth/api/internal/shared/node/eTAspeO4RI2i09hhlXwLmg/content/PCU_2017_SHP.rar?a=true"" class=""list-group-item"">2017</a>
                                        <a href=""https://sistemas.sedatu.gob.mx/repositorio/proxy/alfresco-noauth/api/internal/shared/node/5gUvH-fRQO296iuU3Q2kng/content/PCU_2015_SHP.rar?a=true"" class=""list-g");
            WriteLiteral(@"roup-item"">2015</a>
                                        <a href=""https://sistemas.sedatu.gob.mx/repositorio/proxy/alfresco-noauth/api/internal/shared/node/m-AqF8sSTGysGiaZcNf-3g/content/PCU_2014_SHP.rar?a=true"" class=""list-group-item"">2014</a>
                                        <a href=""https://sistemas.sedatu.gob.mx/repositorio/proxy/alfresco-noauth/api/internal/shared/node/KMv6RCVhR3OE2ii5Y-IkFA/content/PCU_2013_SHP.rar?a=true"" class=""list-group-item"">2013</a>
                                    </div>
                                </div>
                                <div class=""col-md-6"">
                                    <h3>KMZ</h3>
                                    <div class=""list-group"">
                                        <a href=""https://sistemas.sedatu.gob.mx/repositorio/proxy/alfresco-noauth/api/internal/shared/node/mnrITkcrS7WLzZvlVnfUpA/content/PCU_2018_KMZ.zip?a=true"" class=""list-group-item"">2018</a>
                                        <a href=""https://sistemas.sedatu.");
            WriteLiteral(@"gob.mx/repositorio/proxy/alfresco-noauth/api/internal/shared/node/Uy-RvjA9SQqKt_iy_b7w0g/content/PCU_2017_KMZ.rar?a=true"" class=""list-group-item"">2017</a>
                                        <a href=""https://sistemas.sedatu.gob.mx/repositorio/proxy/alfresco-noauth/api/internal/shared/node/ZchOlyEHREue6-HuiW9_4w/content/PCU_2015_KMZ.rar?a=true"" class=""list-group-item"">2015</a>
                                        <a href=""https://sistemas.sedatu.gob.mx/repositorio/proxy/alfresco-noauth/api/internal/shared/node/i-WVJRrRT_W-sGljRf1GuQ/content/PCU_2014_KMZ.rar?a=true"" class=""list-group-item"">2014</a>
                                        <a href=""https://sistemas.sedatu.gob.mx/repositorio/proxy/alfresco-noauth/api/internal/shared/node/rD42J7YcRD6FHIQb03wZ3A/content/PCU_2013_KMZ.rar?a=true"" class=""list-group-item"">2013</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
          ");
            WriteLiteral("      </div>\n\n            </div>\n        </div>\n\n        <div role=\"tabpanel\" class=\"tab-pane\" id=\"cnbv\">\n            <div class=\"form-inline\">\n                <div class=\"form-group\">\n                    <label>Año:</label>\n                    ");
#nullable restore
#line 312 "E:\Azure\sniiv\Views\Reporte\Datos_abiertos_anterior.cshtml"
               Write(Html.DropDownList("ddl_anio_cnbv", aniosCnbv, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n                <div class=\"form-group\">\n                    <label>Mes:</label>\n                    ");
#nullable restore
#line 316 "E:\Azure\sniiv\Views\Reporte\Datos_abiertos_anterior.cshtml"
               Write(Html.DropDownList("ddl_mes_cnbv", mesesCnbv, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <button id=""btn_descargar_cnbv"" type=""button"" class=""btn btn-default"" onclick=""descargar_dato(7,$('[id$=ddl_anio_cnbv]').val(),$('[id$=ddl_mes_cnbv]').val());"">
                    <span class=""glyphicon glyphicon-download-alt""></span>Descargar
                </button>
            </div>
        </div>
    </div>
</div>");
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
