#pragma checksum "E:\Azure\sniiv\Views\Demanda\Potencial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "723e8795f7a07ad822916ef32c0129ac78447994"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Demanda_Potencial), @"mvc.1.0.view", @"/Views/Demanda/Potencial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"723e8795f7a07ad822916ef32c0129ac78447994", @"/Views/Demanda/Potencial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"caf6fc7e17390637ee7a4d1b16d5f6a3a119c2e3", @"/Views/_ViewImports.cshtml")]
    public class Views_Demanda_Potencial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "E:\Azure\sniiv\Views\Demanda\Potencial.cshtml"
  

    ViewData["Title"] = "Demanda Potencial";
    List<SelectListItem> anios = (List<SelectListItem>)ViewBag.anios;
    List<SelectListItem> meses = (List<SelectListItem>)ViewBag.meses;

#line default
#line hidden
#nullable disable
            DefineSection("Scripts", async() => {
                WriteLiteral("\n");
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "723e8795f7a07ad822916ef32c0129ac784479946775", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "723e8795f7a07ad822916ef32c0129ac784479948038", async() => {
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
                WriteLiteral("\n\n");
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "723e8795f7a07ad822916ef32c0129ac784479949259", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "723e8795f7a07ad822916ef32c0129ac7844799410522", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "723e8795f7a07ad822916ef32c0129ac7844799411709", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "723e8795f7a07ad822916ef32c0129ac7844799412894", async() => {
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
       
        $(function () {
            $('[id$=ddl_anio]').change(async function () {
                anio = $('#ddl_anio').val();
                mes = await mostrarMes();
                createHousingPotencial(anio, mes);
            });
            $('[id$=ddl_mes]').change(async function () {
                anio = $('#ddl_anio').val();
                mes = $('#ddl_mes').val();
                createHousingPotencial(anio, mes);
            });
            createHousingPotencial();
        });

        async function mostrarMes() {
            anio = $('#ddl_anio').val();
            var data = await $.getJSON(path + 'CatalogoAPI/GetMesPotencial/' + anio, function (json) {
                $('#ddl_mes').empty();
                $.each(json, function (key, obj) {
                    $('#ddl_mes').append($('<option></option>').attr('value', obj.id).text(obj.descripcion));
                });
            });
            return data[0].id;
        }

        function s");
                WriteLiteral(@"howModal(clave_estado, nombre_estado) {
            changeTitle(nombre_estado);
            createHousingPotencial2(clave_estado);
            $('#mdl').modal();
        }

        function createHousingPotencial(anio_v, mes_v) {
            var anio = (anio_v != undefined) ? anio_v : $('[id$=ddl_anio]').val();
            var mes = (mes_v != undefined) ? mes_v : $('[id$=ddl_mes]').val();
            $.getJSON(path + 'DemandaAPI/GetDemandaPotencial/' + anio + '/' + mes, function (data) {
                var array = data
                    .map(x => x.resultado)
                    .map(y => 
                    (y.length == 6 ?
                        { estado: y[0].estado, col1: y[0].total, col2: y[1].total, col3: y[2].total, col4: y[3].total, col5: y[4].total, col6: y[5].total, id_estado: y[0].id_estado } :
                        { estado: y[0].estado, col1: y[0].total, col2: y[1].total, col3: y[2].total, col4: y[3].total, col5: y[4].total, col6: y[5].total, col7: y[6].total, id_estado: y[0].id_estado }

");
                WriteLiteral(@"                    ));
                var headings = data.map(x => x.resultado)[0].map(y => y.descripcion);
                var columns = [
                    {
                        title: 'Estado', data: 'estado', 'render': function (data, type, row) {
                            if (type === 'display') {
                                data = '<a id=""' + row.id_estado + '""  href=""#""  onclick=""showModal(\'' + row.id_estado + '\', \'' + data + '\');"">' + data + '</a>';
                            } return data;
                        }
                    },
                    { title: headings[0], data: 'col1', render: function (data, type, row) { return addCommas(data); } },
                    { title: headings[1], data: 'col2', render: function (data, type, row) { return addCommas(data); } },
                    { title: headings[2], data: 'col3', render: function (data, type, row) { return addCommas(data); } },
                    { title: headings[3], data: 'col4', render: function (data, type, ");
                WriteLiteral(@"row) { return addCommas(data); } },
                    { title: headings[4], data: 'col5', render: function (data, type, row) { return addCommas(data); } },
                    { title: headings[5], data: 'col6', render: function (data, type, row) { return addCommas(data); } },

                ];

                var table = '';
                var footer = '';
                if (data[0].resultado.length > 6) {
                    table = '#table2';
                    footer = '<tfoot>< tr ><th>Total</th><th></th><th></th><th></th><th></th><th></th><th></th><th></th></tr ></tfoot >';
                    $('#table1-div').hide();
                    $('#table2-div').show();
                    columns.push({ title: headings[6], data: 'col7', render: function (data, type, row) { return addCommas(data); } });
                }
                else {
                    table = '#table1';
                    footer = '<tfoot>< tr ><th>Total</th><th></th><th></th><th></th><th></th><th></th><th></th></tr ></tfoo");
                WriteLiteral(@"t >';
                    $('#table2-div').hide();
                    $('#table1-div').show();
                }

                $(table).append(footer);
                var dataMap = data.map(x => ({ id: x.id_estado, name: x.estado, value: x.total }));
                var clave_estado = '00';
                changeTitle();
                showMap(dataMap, data, clave_estado,'#map');
                showTable(array, columns, table);

            });
        }
        function showTable(data, columns, table) {
            var table = $(table).DataTable({
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
                    //console.log(columns);
          ");
                WriteLiteral(@"          // Remove the formatting to get integer data for summation
                    var intVal = function (i) {
                        return typeof i === 'string' ? i.replace(/[\$,]/g, '') * 1 : typeof i === 'number' ? i : 0;
                    };
                    // Total over all pages
                    total1 = api.column(1).data().reduce(function (a, b) { return intVal(a) + intVal(b); }, 0);
                    total2 = api.column(2).data().reduce(function (a, b) { return intVal(a) + intVal(b); }, 0);
                    total3 = api.column(3).data().reduce(function (a, b) { return intVal(a) + intVal(b); }, 0);
                    total4 = api.column(4).data().reduce(function (a, b) { return intVal(a) + intVal(b); }, 0);
                    total5 = api.column(5).data().reduce(function (a, b) { return intVal(a) + intVal(b); }, 0);
                    total6 = api.column(6).data().reduce(function (a, b) { return intVal(a) + intVal(b); }, 0);
                    // Update footer
               ");
                WriteLiteral(@"     $(api.column(1).footer()).html(addCommas(total1));
                    $(api.column(2).footer()).html(addCommas(total2));
                    $(api.column(3).footer()).html(addCommas(total3));
                    $(api.column(4).footer()).html(addCommas(total4));
                    $(api.column(5).footer()).html(addCommas(total5));
                    $(api.column(6).footer()).html(addCommas(total6));
                    if (Object.keys(data[0]).length > 8) {
                        total7 = api.column(7).data().reduce(function (a, b) { return intVal(a) + intVal(b); }, 0);
                        $(api.column(7).footer()).html(addCommas(total7));
                    }
                }
            });
            table.buttons().container().appendTo($('.col-sm-6:eq(0)', table.table().container()));
        }
        function showMap(dataMap, data, clave_estado,id_map) {
            for (var i = 0; i < dataMap.length; i++) {
                if (dataMap[i].id == clave_estado) {
                    dataMap");
                WriteLiteral(@"[i].selected = true;
                }
            }
            var nacional = data
            var anio = $('[id$=ddl_anio]').val();
            var min = Math.min.apply(null, dataMap.map(x => x.value));
            var max = Math.max.apply(null, dataMap.map(x => x.value));
            $.get('../js/maps/' + clave_estado + '.json', function (mxJson) {
                echarts.registerMap('mx', mxJson);
                var map = echarts.init($(id_map)[0]);
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
                ");
                WriteLiteral(@"    series: [{
                        name: clave_nacional,
                        type: 'map',
                        map: 'mx',
                        aspectScale: 1.0,
                        label: {
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
                    
                    var clave_estado = params.data.id;
                    var nombre_estado = params.data.name;
                    if (clave_estado.length <= 2) {
                        changeTitle(nombre_estado);
                        createHousingPotencial2(clave_estado);
                        $('#mdl').modal();
         ");
                WriteLiteral(@"           }
                    
                });
                //Responsive
                $(window).on('resize', function () {
                    map.resize();
                });
            });
        }
        function createHousingPotencial2(clave_estado) {
            var anio = $('#ddl_anio').val();
            var mes = $('#ddl_mes').val();
            $.getJSON(path + 'DemandaAPI/GetDemandaPotencialMunicipal/' + anio + '/' + mes + '/' +clave_estado, function (data) {
                var array = data
                    .map(x => x.resultado)
                    .map(y => 
                        (y.length <= 6 ?
                        { estado: y[0].estado, col1: (y[0] != undefined) ? y[0].total : 0, col2: (y[1] != undefined) ? y[1].total : 0, col3: (y[2] != undefined) ? y[2].total : 0, col4: (y[3] != undefined) ? y[3].total : 0, col5: (y[4] != undefined) ? y[4].total : 0, col6: (y[5] != undefined) ? y[5].total : 0, id_estado: y[0].id_estado} :
                        { estado: y[0].estado");
                WriteLiteral(@", col1: (y[0] != undefined) ? y[0].total : 0, col2: (y[1] != undefined) ? y[1].total : 0, col3: (y[2] != undefined) ? y[2].total : 0, col4: (y[3] != undefined) ? y[3].total : 0, col5: (y[4] != undefined) ? y[4].total : 0, col6: (y[5] != undefined) ? y[5].total : 0, col7: (y[6] != undefined) ? y[6].total : 0, id_estado: y[0].id_estado }
                    ));
                var cols_num = 0;
                var cols_max = 0;
                cols = data.map(x => x.resultado);
                cols.forEach((element, index) => { cols_max = (element.length > cols_num) ? index : cols_max; cols_num = (element.length > cols_num) ? element.length : cols_num; });
                var headings = data.map(x => x.resultado)[cols_max].map(y => y.descripcion);
                var columns = [
                    {
                        title: 'Municipio', data: 'estado', render: function (data, type, row) {
                            return data;
                        }
                    },
                    { title");
                WriteLiteral(@": headings[0], data: 'col1', render: function (data, type, row) { return addCommas(data); } },
                    { title: headings[1], data: 'col2', render: function (data, type, row) { return addCommas(data); } },
                    { title: headings[2], data: 'col3', render: function (data, type, row) { return addCommas(data); } },
                    { title: headings[3], data: 'col4', render: function (data, type, row) { return addCommas(data); } },
                    { title: headings[4], data: 'col5', render: function (data, type, row) { return addCommas(data); } },
                    { title: headings[5], data: 'col6', render: function (data, type, row) { return addCommas(data); } },

                ];

                var table = '';
                var footer = '';
                if (data[0].resultado.length > 6) {
                    table = '#table4';
                    footer = '<tfoot>< tr ><th>Total</th><th></th><th></th><th></th><th></th><th></th><th></th><th></th></tr ></tfoot >';
    ");
                WriteLiteral(@"                $('#table3-div').hide();
                    $('#table4-div').show();
                    columns.push({ title: headings[6], data: 'col7', render: function (data, type, row) { return addCommas(data); } });
                }
                else {
                    table = '#table3';
                    footer = '<tfoot>< tr ><th>Total</th><th></th><th></th><th></th><th></th><th></th><th></th></tr ></tfoot >';
                    $('#table4-div').hide();
                    $('#table3-div').show();
                }

                $(table).append(footer);
                var dataMap = data.map(x => ({ id: x.id_estado, name: x.estado, value: x.total }));
                changeTitle();
                showMap(dataMap, data, clave_estado,'#map2');
                showTable(array, columns, table);

            });
        }




    </script>
");
            }
            );
            WriteLiteral("\n<div class=\"page-header\">\n    <h2>Demanda potencial INFONAVIT<small> Número de derechohabientes</small></h2>\n</div>\n\n<div id=\"div-form\" class=\"form-inline\">\n    <div class=\"form-group\">\n        <label>Año:</label>\n        ");
#nullable restore
#line 279 "E:\Azure\sniiv\Views\Demanda\Potencial.cshtml"
   Write(Html.DropDownList("ddl_anio", anios, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n    <div class=\"form-group\">\n        <label>Mes:</label>\n        ");
#nullable restore
#line 283 "E:\Azure\sniiv\Views\Demanda\Potencial.cshtml"
   Write(Html.DropDownList("ddl_mes", meses, new { @class = "form-control" }));

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
    </div>
    <div class=""col-md-7"">
        <div id=""table1-div"">
            <table id=""table1"" class=""table table-striped table-hover"" style=""width:100%"">
            </table>

        </div>
        <div id=""table2-div"">
            <table id=""table2"" class=""table table-striped table-hover"" style=""width:100%"">
            </table>
        </div>

    </div>
</div>


<div id=""mdl"" class=""modal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
                <h4 class=""modal-title"" id=""lbl_titulo"">Modal title</h4>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-md-6"">
     ");
            WriteLiteral(@"                   <div id=""map2""></div>
                    </div>
                    
                </div>
                <div class=""row"">
                    <div class=""col-md-12"">
                        <div id=""table3-div"">
                            <table id=""table3"" class=""table table-striped table-hover"" style=""width:100%"">
                            </table>

                        </div>
                        <div id=""table4-div"">
                            <table id=""table4"" class=""table table-striped table-hover"" style=""width:100%"">
                            </table>
                        </div>

                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Salir</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
");
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
