#pragma checksum "E:\Azure\sniiv\Views\Demanda\Poblacion_historico.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b06d590479158e8ee5c2a41bcfd3da1d6643d50b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Demanda_Poblacion_historico), @"mvc.1.0.view", @"/Views/Demanda/Poblacion_historico.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b06d590479158e8ee5c2a41bcfd3da1d6643d50b", @"/Views/Demanda/Poblacion_historico.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"caf6fc7e17390637ee7a4d1b16d5f6a3a119c2e3", @"/Views/_ViewImports.cshtml")]
    public class Views_Demanda_Poblacion_historico : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "E:\Azure\sniiv\Views\Demanda\Poblacion_historico.cshtml"
  
    ViewData["Title"] = "Histórico de población";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    <!-- DataTables -->\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b06d590479158e8ee5c2a41bcfd3da1d6643d50b6722", async() => {
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
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b06d590479158e8ee5c2a41bcfd3da1d6643d50b7985", async() => {
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
                WriteLiteral("\n\n    <!-- ECharts -->\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b06d590479158e8ee5c2a41bcfd3da1d6643d50b9193", async() => {
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
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b06d590479158e8ee5c2a41bcfd3da1d6643d50b10456", async() => {
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
                WriteLiteral("\n\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b06d590479158e8ee5c2a41bcfd3da1d6643d50b11643", async() => {
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
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b06d590479158e8ee5c2a41bcfd3da1d6643d50b12828", async() => {
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
        var barChart;
        var toolbox = {
            show: true,
            orient: 'vertical',
            left: 'right',
            top: 'center',
            showTitle: false,
            feature: {
                magicType: { show: true, type: ['line', 'bar'] },
                restore: { show: true },
                saveAsImage: { show: true }
            }
        }
        var height_table = '320px';
        var columns = ['1990', '1995', '2000', '2005', '2010', '2015', '2020'];
        var sum = [0, 0, 0, 0, 0, 0, 0];
        var percentage_change = [, 0, 0, 0, 0, 0, 0];

        $(function () {
            showPopulation();
        });

        function showPopulation() {
            $.getJSON(path + 'DemandaAPI/GetPoblacionEstatal', function (data) {
                showTable(data);
                showChart(data);
            });
        }

        function showTable(data) {
            var columns = [
                {
                    'data': 'esta");
                WriteLiteral(@"do',
                    'render': function (data, type, row) {
                        if (type === 'display') {
                            data = '<a id=""' + row.clave_estado + '"" href=""#"" data-toggle=""modal"" data-target=""#mdl"" onclick=""selectMunicipality(\'' + row.clave_estado + '\', \'' + data + '\');"">' + data + '</a>';
                        }
                        return data;
                    }
                },
                { 'data': '1990', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '1995', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2000', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2005', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2010', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2015', render: function (data, type, row) { return addCommas(data");
                WriteLiteral(@"); } },
                { 'data': '2020', render: function (data, type, row) { return addCommas(data); } }
            ];

            var table = $('#table').DataTable({
                data: data,
                columns: columns,
                destroy: true,
                scrollY: height_table,
                scrollCollapse: true,
                paging: false,
                info: false,
                buttons: ['excel'],
                scrollX: true,
                fixedColumns: true
            });
            table.buttons().container().appendTo($('.col-sm-6:eq(0)', table.table().container()));
        }

        function showChart(data) {
            $.each(data, function (i, item) {
                $.each(columns, function (j, value) {
                    sum[j] += item[value];

                });
            });
            for (var i = 0; i < (sum.length - 1); i++) {
                percentage_change[i + 1] = percentageChange(sum[i + 1], sum[i]);
            }

            var percentage_");
                WriteLiteral(@"change_aux = percentage_change.slice();
            percentage_change_aux.shift();
            var percentage_change_max = Math.ceil(Math.max.apply(Math, percentage_change_aux));

            barChart = echarts.init($('#barChart')[0]);

            $(window).on('resize', function () {
                barChart.resize();
            });

            barChart.setOption({
                color: baseColor,
                toolbox: toolbox,
                tooltip: {
                    trigger: 'axis',
                    axisPointer: { type: 'shadow' }
                },
                legend: {
                    data: ['población', 'porcentaje']
                },
                xAxis: [
                    {
                        data: columns
                    }
                ],
                yAxis: [
                    {
                        type: 'value',
                        name: 'habitantes (millones)',
                        axisLabel: {
                            formatter: function");
                WriteLiteral(@" (a) {
                                return a / 1000000; // echarts.format.addCommas(a);
                            }
                        }
                    },
                    {
                        type: 'value',
                        name: 'porcentaje',
                        min: 0,
                        max: percentage_change_max,
                        axisLabel: {
                            formatter: '{value} %'
                        }
                    }
                ],
                series: [
                    {
                        name: 'población',
                        type: 'bar',
                        data: sum
                    },
                    {
                        name: 'porcentaje',
                        type: 'line',
                        yAxisIndex: 1,
                        data: percentage_change
                    }
                ]
            }, true);
        }

        function selectMunicipality(clave_estado, nombre_esta");
                WriteLiteral(@"do) {
            changeTitle(nombre_estado);
            $.getJSON(path + 'DemandaAPI/GetPoblacionMunicipal/' + clave_estado, function (data) {
                showTable2(data);
                showChart2(data);
            });
        }

        function showTable2(data) {
            var columns = [
                { 'data': 'municipio' },
                { 'data': '1990', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '1995', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2000', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2005', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2010', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2015', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2020', render: function (data, type, row) { return a");
                WriteLiteral(@"ddCommas(data); } }
            ];

            var table = $('#table2').DataTable({
                data: data,
                columns: columns,
                destroy: true,
                scrollY: height_table,
                scrollCollapse: true,
                paging: false,
                info: false,
                buttons: ['excel'],
                scrollX: true,
                fixedColumns: true
            });
            table.buttons().container().appendTo($('.col-sm-6:eq(0)', table.table().container()));
        }

        function showChart2(data) {
            sum = [0, 0, 0, 0, 0, 0, 0];
            $.each(data, function (i, item) {
                $.each(columns, function (j, value) {
                    sum[j] += item[value];

                });
            });

            for (var i = 0; i < (sum.length - 1); i++) {
                percentage_change[i + 1] = percentageChange(sum[i + 1], sum[i]);
            }

            var percentage_change_aux = percentage_change.slice();
   ");
                WriteLiteral(@"         percentage_change_aux.shift();
            var percentage_change_max = Math.ceil(Math.max.apply(Math, percentage_change_aux));

            barChart = echarts.init($('#barChart2')[0]);

            $(window).on('resize', function () {
                barChart.resize();
            });

            barChart.setOption({
                color: baseColor,
                toolbox: toolbox,
                tooltip: {
                    trigger: 'axis',
                    axisPointer: { type: 'shadow' }
                },
                legend: {
                    data: ['población', 'porcentaje']
                },
                xAxis: [
                    {
                        data: columns
                    }
                ],
                yAxis: [
                    {
                        type: 'value',
                        name: 'habitantes (millones)',
                        axisLabel: {
                            formatter: function (a) {
                                ret");
                WriteLiteral(@"urn a / 1000000; // echarts.format.addCommas(a);
                            }
                        }
                    },
                    {
                        type: 'value',
                        name: 'porcentaje',
                        min: 0,
                        max: percentage_change_max,
                        axisLabel: {
                            formatter: '{value} %'
                        }
                    }
                ],
                series: [
                    {
                        name: 'población',
                        type: 'bar',
                        data: sum
                    },
                    {
                        name: 'porcentaje',
                        type: 'line',
                        yAxisIndex: 1,
                        data: percentage_change
                    }
                ]
            }, true);
        }
    </script>
");
            }
            );
            WriteLiteral(@"
<div class=""page-header"">
    <h2>Histórico de población</h2>
</div>

<div class=""row"">
    <div class=""col-md-12"">
        <div id=""barChart"" class=""chart2""></div>
    </div>
    <div class=""col-md-12"">
        <table id=""table"" class=""table table-striped table-hover"" style=""width: 100%"">
            <thead>
                <tr>
                    <th>Estado</th>
                    <th>1990</th>
                    <th>1995</th>
                    <th>2000</th>
                    <th>2005</th>
                    <th>2010</th>
                    <th>2015</th>
                    <th>2020</th>
                </tr>
            </thead>
        </table>
    </div>
</div>

<br />
<div id=""info"" class=""row"">
    <div class=""col-md-12"">
        <div class=""panel-group"" role=""tablist"">
            <div class=""panel panel-info"">
                <div class=""panel-heading"" role=""tab"" id=""collapseListGroupHeading1"">
                    <h4 class=""panel-title"">
                        <a href=""#collapseListGroup1");
            WriteLiteral("\"");
            BeginWriteAttribute("class", " class=\"", 10720, "\"", 10728, 0);
            EndWriteAttribute();
            WriteLiteral(@" role=""button"" data-toggle=""collapse"" aria-expanded=""true"" aria-controls=""collapseListGroup1"">
                            <span class=""glyphicon glyphicon-info-sign"" aria-hidden=""true""></span> Notas
                        </a>
                    </h4>
                </div>
                <div class=""panel-collapse collapse in"" role=""tabpanel"" id=""collapseListGroup1"" aria-labelledby=""collapseListGroupHeading1"" aria-expanded=""true""");
            BeginWriteAttribute("style", " style=\"", 11167, "\"", 11175, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <ul id=""notes"" class=""list-group"">
                        <li class=""list-group-item""><p class=""text-info""><strong>Fuente: </strong>Elaborado por CONAVI, con información de los Censos de Población y Vivienda 1990-2000-2010-2015, conteos 1995-2005 y Encuesta Intercensal 2015 de INEGI</p></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Modal -->
");
            WriteLiteral(@"<div class=""modal"" id=""mdl"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
                <h4 class=""modal-title"" id=""lbl_titulo""></h4>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        <div id=""barChart2"" class=""chart2""></div>
                    </div>
                    <div class=""col-md-12"">
                        <table id=""table2"" class=""table table-striped table-hover"" style=""width: 100%"">
                            <thead>
                                <tr>
                                    <th>Municipio</th>
                                    <th>1990</th>
                                    <th>1995</th>");
            WriteLiteral(@"
                                    <th>2000</th>
                                    <th>2005</th>
                                    <th>2010</th>
                                    <th>2015</th>
                                    <th>2020</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Salir</button>
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