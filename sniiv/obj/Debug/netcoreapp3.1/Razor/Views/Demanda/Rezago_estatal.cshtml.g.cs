#pragma checksum "D:\Resplado sedatu\Azure5\sniiv\Views\Demanda\Rezago_estatal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6045304cfed237d333f5dbc9c25c1273be7fc11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Demanda_Rezago_estatal), @"mvc.1.0.view", @"/Views/Demanda/Rezago_estatal.cshtml")]
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
#line 1 "D:\Resplado sedatu\Azure5\sniiv\Views\_ViewImports.cshtml"
using sniiv;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Resplado sedatu\Azure5\sniiv\Views\_ViewImports.cshtml"
using sniiv.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Resplado sedatu\Azure5\sniiv\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6045304cfed237d333f5dbc9c25c1273be7fc11", @"/Views/Demanda/Rezago_estatal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec35af421ca7f3dc8a2f18a41a548d91d9184c1b", @"/Views/_ViewImports.cshtml")]
    public class Views_Demanda_Rezago_estatal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/datatable2/datatables.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/datatable2/datatables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/echarts.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/echarts/echarts.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/util.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/data.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\Resplado sedatu\Azure5\sniiv\Views\Demanda\Rezago_estatal.cshtml"
  
    ViewData["Title"] = "Rezago estatal";
    List<SelectListItem> anios = (List<SelectListItem>)ViewBag.anios;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c6045304cfed237d333f5dbc9c25c1273be7fc116856", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6045304cfed237d333f5dbc9c25c1273be7fc118121", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c6045304cfed237d333f5dbc9c25c1273be7fc119346", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6045304cfed237d333f5dbc9c25c1273be7fc1110611", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6045304cfed237d333f5dbc9c25c1273be7fc1111802", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6045304cfed237d333f5dbc9c25c1273be7fc1112989", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script type=""text/javascript"">
        function changeChartMap(clave_estado) {
            var anio = $('[id$=ddl_anio]').val();
            $.getJSON(path + 'DemandaAPI/GetTotalRezagoEstatal/' + anio + '/' + clave_estado, function (json) {
                showChartMap(json);
            });
            $.getJSON(path + 'DemandaAPI/GetRezagoEstatal/' + anio, function (json) {
                var dataMap = json.map(x => ({ id: x.id_estado, name: x.estado, value: x.con_rezago, selected: false }));
                showMap(dataMap, json, clave_estado);
            });
        }

        $(function () {
            $('[id$=ddl_anio]').change(function () {
                createHousingRenaret();
            });
            createHousingRenaret();
        });

        function createHousingRenaret() {
            var anio = $('[id$=ddl_anio]').val();
            $.getJSON(path + 'DemandaAPI/GetRezagoEstatal/' + anio, function (data) {
                var columns = [
                    ");
                WriteLiteral(@"{
                        'data': 'estado',
                        'render': function (data, type, row) {
                            if (type === 'display') {
                                data = '<a id=""' + row.id_estado + '""  href=""#""  onclick=""changeChartMap(\'' + row.id_estado + '\');"">' + data + '</a>';
                            }
                            return data;
                        }
                    },
                    { 'data': 'con_rezago', render: function (data, type, row) { return addCommas(data); } },
                    { 'data': 'sin_rezago', render: function (data, type, row) { return addCommas(data); } },
                    { 'data': 'total', render: function (data, type, row) { return addCommas(data); } }

                ];
                var dataMap = data.map(x => ({ id: x.id_estado, name: x.estado, value: x.con_rezago }));
                var clave_estado = '00';
                showTable(data, columns);
                showMap(dataMap, data, cl");
                WriteLiteral(@"ave_estado);
                showChart(data);
            });
        }
        function showTable(data, columns) {
            var table = $('#table').DataTable({
                data: data,
                columns: columns,
                destroy: true,
                scrollY: '770px',
                scrollCollapse: true,
                paging: false,
                info: false,
                buttons: buttons,
                scrollX: true,
                footerCallback: function (row, data, start, end, display) {
                    var api = this.api();
                    // Remove the formatting to get integer data for summation
                    var intVal = function (i) {
                        return typeof i === 'string' ? i.replace(/[\$,]/g, '') * 1 : typeof i === 'number' ? i : 0;
                    };
                    // Total over all pages
                    total1 = api.column(1).data().reduce(function (a, b) { return intVal(a) + intVal(b); }, 0);
       ");
                WriteLiteral(@"             total2 = api.column(2).data().reduce(function (a, b) { return intVal(a) + intVal(b); }, 0);
                    total3 = api.column(3).data().reduce(function (a, b) { return intVal(a) + intVal(b); }, 0);
                    // Update footer
                    $(api.column(1).footer()).html(addCommas(total1));
                    $(api.column(2).footer()).html(addCommas(total2));
                    $(api.column(3).footer()).html(addCommas(total3));
                }
            });
            table.buttons().container().appendTo($('.col-sm-6:eq(0)', table.table().container()));
        }
        function showMap(dataMap, data, clave_estado) {
            for (var i = 0; i < dataMap.length; i++) {
                if (dataMap[i].id == clave_estado) {
                    dataMap[i].selected = true;
                }
            }
            var nacional = data
            var anio = $('[id$=ddl_anio]').val();
            var min = Math.min.apply(null, dataMap.map(x => x.value));");
                WriteLiteral(@"
            var max = Math.max.apply(null, dataMap.map(x => x.value));
            $.get('../js/maps/' + clave_nacional + '.json', function (mxJson) {
                echarts.registerMap('mx', mxJson);
                var map = echarts.init($('#map')[0]);
                map.setOption({
                    tooltip: tooltip,
                    selectedMode: 'single',
                    visualMap: {
                        min: min,
                        max: max,
                        left: 'left',
                        top: 'bottom',
                        text: ['max', 'min'],
                        inRange: {
                            color: rangeColor
                        },
                        calculable: true
                    },
                    toolbox: toolbox,
                    series: [{
                        name: clave_nacional,
                        type: 'map',
                        map: 'mx',
                        aspectScale: 1.0,
   ");
                WriteLiteral(@"                     label: {
                            emphasis: {
                                show: false
                            }
                        },
                        itemStyle: {
                            emphasis: {
                                areaColor: '#f7aa43',

                            }
                        },
                        data: dataMap
                    }]
                });
                map.on('click', function (params) {
                    if (params.data.selected) {
                        var clave_estado = params.data.id;
                        var nombre_estado = params.data.name;
                        $.getJSON(path + 'DemandaAPI/GetTotalRezagoEstatal/' + anio + '/' + clave_estado, function (json) {
                            showChartMap(json);
                        });
                    } else {
                        showChart(nacional);

                    }
                });
                //R");
                WriteLiteral(@"esponsive
                $(window).on('resize', function () {
                    map.resize();
                });
            });
        }
        function showChart(data) {
            //Crear objetos dinamicos var obj = JSON.parse(text);
            var legend1 = 'Con Rezago';
            var con_rezago = { 'name': legend1, 'value': data.map(function (x) { return x.con_rezago; }).sum() }
            var legend2 = 'Sin Rezago';
            var sin_rezago = { 'name': legend2, 'value': data.map(function (x) { return x.sin_rezago; }).sum() }
            var chart = echarts.init($('#chart')[0]);
            chart.setOption({
                color: baseColor,
                toolbox: toolbox2,
                tooltip: tooltip2,
                legend: {
                    orient: 'horizontal',
                    left: 0,
                    bottom: 0,
                    data: [con_rezago.name, sin_rezago.name]
                },
                title: {
                    text: 'Na");
                WriteLiteral(@"cional',
                    x: 'center'
                },

                series: [
                    {
                        name: 'Rezago Estatal',
                        type: 'pie',
                        selectedMode: 'single',
                        center: ['50%', '50%'],
                        label: {
                            normal: {
                                formatter: '{d}%',
                                position: 'inner'
                            }
                        },

                        data: [con_rezago, sin_rezago]

                    }
                ]

            });
            //Responsive
            $(window).on('resize', function () {
                chart.resize();
            });
        }
        function showChartMap(data) {
            //Crear objetos dinamicos var obj = JSON.parse(text);
            var legend1 = 'Con Rezago';
            var con_rezago = { 'name': legend1, 'value': data.con_rezago }
        ");
                WriteLiteral(@"    var legend2 = 'Sin Rezago';
            var sin_rezago = { 'name': legend2, 'value': data.sin_rezago }
            var chart = echarts.init($('#chart')[0]);
            chart.setOption({
                color: baseColor,
                toolbox: toolbox2,
                tooltip: tooltip2,
                legend: {
                    orient: 'horizontal',
                    left: 0,
                    bottom: 0,
                    data: [con_rezago.name, sin_rezago.name]
                },
                title: {
                    text: 'Estado de ' + data.estado,
                    x: 'center'
                },
                series: [
                    {
                        name: 'Rezago Estatal',
                        type: 'pie',
                        center: ['50%', '50%'],
                        label: {
                            normal: {
                                formatter: '{d}%',
                                position: 'inner'
            ");
                WriteLiteral(@"                }
                        },
                        data: [con_rezago, sin_rezago]
                    }
                ]
            });
            //Responsive
            $(window).on('resize', function () {
                chart.resize();
            });
        }
    </script>
");
            }
            );
            WriteLiteral("\r\n<div class=\"page-header\">\r\n    <h2>Rezago estatal<small> Número de viviendas</small></h2>\r\n</div>\r\n\r\n<div id=\"div-form\" class=\"form-inline\">\r\n    <div class=\"form-group\">\r\n        <label>Año:</label>\r\n        ");
#nullable restore
#line 252 "D:\Resplado sedatu\Azure5\sniiv\Views\Demanda\Rezago_estatal.cshtml"
   Write(Html.DropDownList("ddl_anio", anios, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>
</div>

<div class=""row"">
    <div class=""col-md-5"">
        <div id=""map""></div>
        <br />
        <div id=""chart""></div>
    </div>
    <div class=""col-md-7"">
        <table id=""table"" class=""table table-striped table-hover"" style=""width: 100%"">
            <thead>
                <tr>
                    <th>Estado</th>
                    <th>con Rezago</th>
                    <th>Sin Rezago</th>
                    <th>Total</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th>Total</th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </tfoot>
        </table>
    </div>
</div>

<br />
<div id=""info"" class=""row"">
    <div class=""col-md-12"">
        <div class=""panel-group"" role=""tablist"">
            <div class=""panel panel-info"">
                <div class=""panel-heading"" role=""tab"" id=""collapseListGroupHeading1"">
");
            WriteLiteral("                    <h4 class=\"panel-title\">\r\n                        <a href=\"#collapseListGroup1\"");
            BeginWriteAttribute("class", " class=\"", 11575, "\"", 11583, 0);
            EndWriteAttribute();
            WriteLiteral(@" role=""button"" data-toggle=""collapse"" aria-expanded=""true"" aria-controls=""collapseListGroup1"">
                            <span class=""glyphicon glyphicon-info-sign"" aria-hidden=""true""></span> Notas
                        </a>
                    </h4>
                </div>
                <div class=""panel-collapse collapse in"" role=""tabpanel"" id=""collapseListGroup1"" aria-labelledby=""collapseListGroupHeading1"" aria-expanded=""true""");
            BeginWriteAttribute("style", " style=\"", 12027, "\"", 12035, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <ul id=""notes"" class=""list-group"">
                        <li class=""list-group-item""><strong>Con rezago: </strong>Incluye viviendas con materiales constructivos en deterioro, regulares y/o con precariedad en espacios</li>
                        <li class=""list-group-item""><strong>Precariedad en espacios: </strong>Viviendas con hacinamiento, definido como aquellas viviendas en donde la relación (número de residentes) / (número de cuartos) es mayor a 2.5; además se considera una vivienda precaria en espacios, si no cuenta con excusado</li>
                        <li class=""list-group-item""><strong>Materiales deteriorados: </strong>Viviendas construidas con paredes de material de desecho, lámina de cartón, carrizo, bambú, palma, embarro o bajareque; también se incluyen en esta categoría viviendas construidas con techo con material de desecho, lámina de cartón, palma o paja</li>
                        <li class=""list-group-item""><strong>Materiales regulares: </strong>Viviendas cons");
            WriteLiteral(@"truidas con paredes de lámina metálica, de asbesto, o de madera; viviendas construidas con techo de lámina metálica o de asbesto, madera, tejamanil o teja; además de viviendas con piso de tierra</li>
                        <li class=""list-group-item"">Le recomendamos revisar también el cálculo de la <a href=""https://sistemas.sedatu.gob.mx/repositorio/proxy/alfresco-noauth/api/internal/shared/node/avMXRuMtQse3C9jMO8JKxw/content/Rezago_Habitacional.pdf?a=true"" target=""_blank"" title=""Metodología de Rezago Habitacional"">Metodología del Rezago Habitacional 2020</a> de la CONAVI</li>
                        <li id=""li_estatal"" class=""list-group-item"">Fuente: <strong>INEGI</strong></li>
                    </ul>
                </div>
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
