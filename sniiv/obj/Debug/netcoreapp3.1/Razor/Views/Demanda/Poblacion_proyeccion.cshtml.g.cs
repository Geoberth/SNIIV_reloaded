#pragma checksum "D:\Resplado sedatu\Azure5\sniiv\Views\Demanda\Poblacion_proyeccion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce20f17b4e14621e0d40ff65838959a74c9ef682"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Demanda_Poblacion_proyeccion), @"mvc.1.0.view", @"/Views/Demanda/Poblacion_proyeccion.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce20f17b4e14621e0d40ff65838959a74c9ef682", @"/Views/Demanda/Poblacion_proyeccion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec35af421ca7f3dc8a2f18a41a548d91d9184c1b", @"/Views/_ViewImports.cshtml")]
    public class Views_Demanda_Poblacion_proyeccion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "D:\Resplado sedatu\Azure5\sniiv\Views\Demanda\Poblacion_proyeccion.cshtml"
  
    ViewData["Title"] = "Proyecciones de población";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <!-- DataTables -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ce20f17b4e14621e0d40ff65838959a74c9ef6826824", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce20f17b4e14621e0d40ff65838959a74c9ef6828089", async() => {
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
                WriteLiteral("\r\n\r\n    <!-- ECharts -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ce20f17b4e14621e0d40ff65838959a74c9ef6829303", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce20f17b4e14621e0d40ff65838959a74c9ef68210568", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce20f17b4e14621e0d40ff65838959a74c9ef68211759", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce20f17b4e14621e0d40ff65838959a74c9ef68212946", async() => {
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
        //var columns = ['2011', '2012', '2013', '2014', '2015', '2016', '2017', '2018', '2019', '2020', '2021', '2022', '2023', '2024', '2025', '2026', '2027', '2028', '2029', '2030'];
        var columns = ['2016', '2017', '2018', '2019', '2020', '2021', '2022', '2023', '2024', '2025', '2026', '2027', '2028', '2029', '2030'];
        //var sum = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        var sum = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        //var percentage_change = [, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ");
                WriteLiteral(@"0, 0, 0, 0, 0, 0, 0, 0];
        var percentage_change = [, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

        $(function () {
            showPopulation();
        });

        function showPopulation() {
            $.getJSON(path + 'DemandaAPI/GetProyeccionEstatal', function (data) {
                showTable(data);
                showChart(data);
            });
        }

        function showTable(data) {
            var columns = [
                {
                    'data': 'estado',
                    'render': function (data, type, row) {
                        if (type === 'display') {
                            data = '<a id=""' + row.clave_estado + '"" href=""#"" data-toggle=""modal"" data-target=""#mdl"" onclick=""selectMunicipality(\'' + row.clave_estado + '\', \'' + data + '\');"">' + data + '</a>';
                        }
                        return data;
                    }
                },
                /*{ 'data': '2011', render: function (data, type, ro");
                WriteLiteral(@"w) { return addCommas(data); } },
                { 'data': '2012', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2013', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2014', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2015', render: function (data, type, row) { return addCommas(data); } },*/
                { 'data': '2016', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2017', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2018', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2019', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2020', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2021', render: function (data, type, row) { return ");
                WriteLiteral(@"addCommas(data); } },
                { 'data': '2022', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2023', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2024', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2025', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2026', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2027', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2028', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2029', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2030', render: function (data, type, row) { return addCommas(data); } }
            ];

            var table = $('#table').DataTable({
                data: data");
                WriteLiteral(@",
                columns: columns,
                destroy: true,
                scrollY: height_table,
                scrollCollapse: true,
                paging: false,
                info: false,
                buttons: ['excel'],
                scrollX: true,
                /*columnDefs: [
                    { width: 200, targets: 0 }
                ],*/
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

            //Pendiente: ajustar valores maximos para cada serie
            //var sum_max = Ma");
                WriteLiteral(@"th.max.apply(null, sum);

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
                            formatter: function (a) {
                                return a / 1000000; // echarts.format.addCommas(a);
                            }
  ");
                WriteLiteral(@"                      }
                    },
                    {
                        type: 'value',
                        name: 'porcentaje',
                        min: 0,
                        max: 1.5,
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

        function selectMunicipality(clave_estado, nombre_estado) {
            changeTitle(nombre_estado);
            $.getJSON(path + 'DemandaAPI/GetProyeccionMunicipal/'");
                WriteLiteral(@" + clave_estado, function (data) {
                showTable2(data);
                showChart2(data);
            });
        }

        function showTable2(data) {
            var columns = [
                { 'data': 'municipio' },
                /*{ 'data': '2011', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2012', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2013', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2014', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2015', render: function (data, type, row) { return addCommas(data); } },*/
                { 'data': '2016', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2017', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2018', render: function (data, type, row) ");
                WriteLiteral(@"{ return addCommas(data); } },
                { 'data': '2019', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2020', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2021', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2022', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2023', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2024', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2025', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2026', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2027', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2028', render: function (data, type, row) { return addCo");
                WriteLiteral(@"mmas(data); } },
                { 'data': '2029', render: function (data, type, row) { return addCommas(data); } },
                { 'data': '2030', render: function (data, type, row) { return addCommas(data); } }
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
            sum = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
            $.each(data, function (i, item) {
                $.each(columns, function (j, value) {
                    sum[j] += item[value];

              ");
                WriteLiteral(@"  });
            });
            for (var i = 0; i < (sum.length - 1); i++) {
                percentage_change[i + 1] = percentageChange(sum[i + 1], sum[i]);
            }

            //Pendiente: ajustar valores maximos para cada serie
            //var sum_max = Math.max.apply(null, sum);

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
                        type:");
                WriteLiteral(@" 'value',
                        name: 'habitantes (millones)',
                        axisLabel: {
                            formatter: function (a) {
                                return a / 1000000; // echarts.format.addCommas(a);
                            }
                        }
                    },
                    {
                        type: 'value',
                        name: 'porcentaje',
                        min: 0,
                        max: 1.5,
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
                       ");
                WriteLiteral(" data: percentage_change\r\n                    }\r\n                ]\r\n            }, true);\r\n        }\r\n    </script>\r\n");
            }
            );
            WriteLiteral(@"
<div class=""page-header"">
    <h2>Proyecciones de población</h2>
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
                    <!--<th>2011</th>
                    <th>2012</th>
                    <th>2013</th>
                    <th>2014</th>
                    <th>2015</th>-->
                    <th>2016</th>
                    <th>2017</th>
                    <th>2018</th>
                    <th>2019</th>
                    <th>2020</th>
                    <th>2021</th>
                    <th>2022</th>
                    <th>2023</th>
                    <th>2024</th>
                    <th>2025</th>
                    <th>2026</th>
                    <th>2027</th>
                    <th>2028</th>
 ");
            WriteLiteral(@"                   <th>2029</th>
                    <th>2030</th>
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
                        <a href=""#collapseListGroup1""");
            BeginWriteAttribute("class", " class=\"", 14516, "\"", 14524, 0);
            EndWriteAttribute();
            WriteLiteral(@" role=""button"" data-toggle=""collapse"" aria-expanded=""true"" aria-controls=""collapseListGroup1"">
                            <span class=""glyphicon glyphicon-info-sign"" aria-hidden=""true""></span> Notas
                        </a>
                    </h4>
                </div>
                <div class=""panel-collapse collapse in"" role=""tabpanel"" id=""collapseListGroup1"" aria-labelledby=""collapseListGroupHeading1"" aria-expanded=""true""");
            BeginWriteAttribute("style", " style=\"", 14968, "\"", 14976, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <ul id=""notes"" class=""list-group"">
                        <li class=""list-group-item""><p class=""text-info""><strong>Fuente: </strong>Elaborado por CONAVI a partir de las proyecciones de población de México y las entidades federativas 1990-2030 de CONAPO</p></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Modal -->
<div class=""modal"" id=""mdl"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
                <h4 class=""modal-title"" id=""lbl_titulo""></h4>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        <div id=""barChart2"" c");
            WriteLiteral(@"lass=""chart2""></div>
                    </div>
                    <div class=""col-md-12"">
                        <table id=""table2"" class=""table table-striped table-hover"" style=""width: 100%"">
                            <thead>
                                <tr>
                                    <th>Municipio</th>
                                    <!--<th>2011</th>
                                    <th>2012</th>
                                    <th>2013</th>
                                    <th>2014</th>
                                    <th>2015</th>-->
                                    <th>2016</th>
                                    <th>2017</th>
                                    <th>2018</th>
                                    <th>2019</th>
                                    <th>2020</th>
                                    <th>2021</th>
                                    <th>2022</th>
                                    <th>2023</th>
                       ");
            WriteLiteral(@"             <th>2024</th>
                                    <th>2025</th>
                                    <th>2026</th>
                                    <th>2027</th>
                                    <th>2028</th>
                                    <th>2029</th>
                                    <th>2030</th>
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
