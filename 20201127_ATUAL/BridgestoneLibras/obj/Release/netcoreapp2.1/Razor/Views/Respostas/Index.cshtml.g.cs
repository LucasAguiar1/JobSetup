#pragma checksum "C:\Projetos\JobSetup\20201127_ATUAL\BridgestoneLibras\Views\Respostas\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "774fc0f5110e5ebac3f2fb79e64351240c9fe6fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Respostas_Index), @"mvc.1.0.view", @"/Views/Respostas/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Respostas/Index.cshtml", typeof(AspNetCore.Views_Respostas_Index))]
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
#line 1 "C:\Projetos\JobSetup\20201127_ATUAL\BridgestoneLibras\Views\_ViewImports.cshtml"
using BridgestoneLibras;

#line default
#line hidden
#line 2 "C:\Projetos\JobSetup\20201127_ATUAL\BridgestoneLibras\Views\_ViewImports.cshtml"
using BridgestoneLibras.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"774fc0f5110e5ebac3f2fb79e64351240c9fe6fb", @"/Views/Respostas/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"192150bb95317d23cebc8fb46a5e75f7c3dacb90", @"/Views/_ViewImports.cshtml")]
    public class Views_Respostas_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 25, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(25, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e63539a4ff36446ead5d848a306e7f59", async() => {
                BeginContext(31, 41, true);
                WriteLiteral("\r\n    <title>Consulta Respostas</title>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(79, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(81, 4579, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6eeb7e7a24d04c6bad5525cfac574ae9", async() => {
                BeginContext(87, 4566, true);
                WriteLiteral(@"
    <ul class=""breadcrumb"" style=""color:red"">
        <li>Consulta Respostas</li>
    </ul>

    <div class=""container"">
        <div class=""row text-center"" style=""margin-top:20px;"">
            <div class=""col-lg-2"">
                <label>Departamento</label>
            </div>
            <div class=""col-lg-2"">
                <label>Maquina</label>
            </div>
            <div class=""col-lg-2"">
                <label>Parte Máquina</label>
            </div>
            <div class=""col-lg-2"">
                <label>Formulários</label>
            </div>
            <div class=""col-lg-2"">
                <label>Inicio</label>
            </div>
            <div class=""col-lg-2"">
                <label>Fim</label>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-lg-2"">
                <select id=""lstDepartamento"" onchange=""ComboMaquina();"" name=""departamento"" class=""form-control""></select>
            </div>
            <div class=");
                WriteLiteral(@"""col-lg-2"">
                <select id=""lstMaquina"" onchange=""ComboParteMaquina();"" name=""maquinas"" class=""form-control""></select>
            </div>
            <div class=""col-lg-2"">
                <select id=""lstParteMaquina"" onchange=""ComboFormulario();"" name=""parteMaquina"" class=""form-control""></select>
            </div>
            <div class=""col-lg-2"">
                <select id=""lstFormulario"" name=""recursoCentroCusto"" class=""form-control""></select>
            </div>
            <div class=""col-lg-2"">
                <input type='date' style=""font-size: 14px;"" maxlength=""8"" id=""dataInicio"" name='txtdatapicker' class='form-control' />
            </div>
            <div class=""col-lg-2"">
                <input type='date' style=""font-size: 14px;"" maxlength=""8"" id=""dataFim"" name='txtdatapicker' class='form-control' />
            </div>

        </div>
    </div>
    <div class=""row"" style=""margin-top:20px;"">
        <div class=""col-lg-4"">
        </div>
        <div class=""col-");
                WriteLiteral(@"lg-2"">
            <button type=""button"" id=""btnConsultar"" onclick=""Pesquisar();"" class=""btn btn-outline-danger btn-block ""><span style=""color: black;"" class=""glyphicon glyphicon-search""></span></button>
        </div>
        <div class=""col-lg-2"">
            <button type=""button"" onclick=""Limpar()"" class=""btn btn-outline-secondary  btn-block"">Limpar</button>
        </div>
        <div class=""col-lg-4"">
        </div>
    </div>
    <div class=""modal fade"" id=""modalmsn"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"" style=""margin-top: 136px;"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLabel"">Informação</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
          ");
                WriteLiteral(@"      </div>
                <div class=""modal-body"">
                    <div id=""idmsn""></div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"" style=""margin:auto; background-color: black;"">Ok</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal -->
    <div class=""modal fade"" id=""modalFilhos"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"" style=""margin-top: 136px;"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLabel"">Informação</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <d");
                WriteLiteral(@"iv class=""modal-body"">
                    <div id=""gridFilhos""></div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"" style=""margin:auto; background-color: black;"">Ok</button>
                </div>
            </div>
        </div>
    </div>

    <div class=""container-fluid"" style=""margin-top:20px;"">
        <div id=""conteudo""></div>
    </div>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4660, 15, true);
            WriteLiteral("\r\n\r\n\r\n</html>\r\n");
            EndContext();
            BeginContext(4828, 727, true);
            WriteLiteral(@"<style>
    .dtHorizontalExampleWrapper {
        max-width: 600px;
        margin: 0 auto;
    }

    #dtHorizontalExample th, td {
        white-space: nowrap;
    }

    table.dataTable thead .sorting:after,
    table.dataTable thead .sorting:before,
    table.dataTable thead .sorting_asc:after,
    table.dataTable thead .sorting_asc:before,
    table.dataTable thead .sorting_asc_disabled:after,
    table.dataTable thead .sorting_asc_disabled:before,
    table.dataTable thead .sorting_desc:after,
    table.dataTable thead .sorting_desc:before,
    table.dataTable thead .sorting_desc_disabled:after,
    table.dataTable thead .sorting_desc_disabled:before {
        bottom: .5em;
    }
</style>
");
            EndContext();
            BeginContext(5701, 14745, true);
            WriteLiteral(@"<script>

    var dadosCadastro = """";
    (function () {

        ConsultarDepartamento();
        ComboMaquina();
        //ConsultarStatusFormulario();
        TabelaVazia();
        //$(""#datepicker"").datepicker();

    })();

    //function MascaraData(data) {
    //    $(""#"" + data).mask(""99/99/9999"");
    //}
    function ConsultarDepartamento() {
        $.ajax({
            url: ""Departamento/Respostas"",
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                var obj = data;
                $(""#lstDepartamento"").html("""");
                if (obj.length == 0) {
                    $(""#lstDepartamento"").prop('disabled', true);
                } else {
                    $(""#lstDepartamento"").prop('disabled', false);
                    $.each(obj, function (i, index) {
                        $(""#lstDepartamento"").append(
                            $('<option></option>').val(index.value).html(index.text));
           ");
            WriteLiteral(@"         })
                    $(""#lstDepartamento"").prop('selectedIndex');
                }
            },
            error: function (data) {
                alert(""erro"");
                console.log(data);
            }
        });
    }

    function ComboMaquina() {
        $.ajax({
            url: ""Maquinas/Respostas?idDepartamento="" + $(""#lstDepartamento"").val(),
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                var obj = data;
                $(""#lstMaquina"").html("""");
                if (obj.length == 0) {
                    $(""#lstMaquina"").prop('disabled', true);
                } else {
                    $(""#lstMaquina"").prop('disabled', false);
                    $.each(obj, function (i, index) {
                        $(""#lstMaquina"").append(
                            $('<option></option>').val(index.value).html(index.text));
                    })
                    $(""#lstMaquina"").prop('selecte");
            WriteLiteral(@"dIndex');
                }
            },
            error: function (data) {
                alert(""erro"");
                console.log(data);
            }
        });
    }

    function ComboParteMaquina() {

        $.ajax({
            url: ""MaquinaParte/Respostas?idMaquina="" + $(""#lstMaquina"").val(),
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                var obj = data;
                $(""#lstParteMaquina"").html("""");
                if (obj.length == 0) {
                    $(""#lstParteMaquina"").prop('disabled', true);
                } else {
                    $(""#lstParteMaquina"").prop('disabled', false);
                    $.each(obj, function (i, index) {
                        $(""#lstParteMaquina"").append(
                            $('<option></option>').val(index.value).html(index.text));
                    })
                    $(""#lstParteMaquina"").prop('selectedIndex');
                }
            ");
            WriteLiteral(@"},
            error: function (data) {
                alert(""erro"");
                console.log(data);
            }
        });
    }

    function ComboFormulario() {
        $.ajax({
            url: ""Formularios/Respostas?idParteMaquina="" + $(""#lstParteMaquina"").val(),
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                var obj = data;
                $(""#lstFormulario"").html("""");
                if (obj.length == 0) {
                    $(""#lstFormulario"").prop('disabled', true);
                } else {
                    $(""#lstFormulario"").prop('disabled', false);
                    $.each(obj, function (i, index) {
                        $(""#lstFormulario"").append(
                            $('<option></option>').val(index.value).html(index.text));
                    })
                    $(""#lstFormulario"").prop('selectedIndex');
                }
            },
            error: function (data) {
     ");
            WriteLiteral(@"           alert(""erro"");
                console.log(data);
            }
        });
    }



    //function ConsultarStatusFormulario() {
    //    $.ajax({
    //        url: ""StatusFormularios/Respostas"",
    //        dataType: 'json',
    //        type: 'GET',
    //        success: function (data) {
    //            var obj = data;
    //            $(""#lstStatus"").html("""");
    //            if (obj.length == 0) {
    //                $(""#lstStatus"").prop('disabled', true);
    //            } else {
    //                $(""#lstStatus"").prop('disabled', false);
    //                $.each(obj, function (i, index) {
    //                    $(""#lstStatus"").append(
    //                        $('<option></option>').val(index.value).html(index.text));
    //                })
    //                $(""#lstStatus"").prop('selectedIndex');
    //            }
    //        },
    //        error: function (data) {
    //            alert(""erro"");
    //            consol");
            WriteLiteral(@"e.log(data);
    //        }
    //    });
    //}


    function Consultar() {

        if ($(""#lstMaquina"").val() == ""0"" && $(""#lstDepartamento"").val() == ""0"") {
            ModalAlert(""Por favor, os parâmetros para efetuar a consulta."");
            return false
        }
        return true;
    }

    function ModalAlert(msn) {
        $(""#modalmsn"").modal('show');
        var resposta = '';
        $(""#idmsn"").empty();
        resposta = ""<div class='alert alert-danger  text-center' role='alert'>"" + msn + ""</div>"";
        $(""#idmsn"").append(resposta);
    }

    function Limpar() {

        $(""#lstFormulario"").val(0);
        $(""#lstParteMaquina"").val(0);
        $(""#lstMaquina"").val(0);
        $(""#lstDepartamento"").val(0);
        $(""#dataInicio"").val('');
        $(""#dataFim"").val('');
        TabelaVazia();
    }

    function validarCampos() {
        dadosCadastro = """";
        if ($(""#lstDepartamento"").val() == ""0"") {
            ModalAlert(""Por favor, inform");
            WriteLiteral(@"e o código do departamento."");
            return false;
        }
        dadosCadastro = ""id_departamento"" + '"":""' + $(""#lstDepartamento"").val();

        if ($(""#lstMaquina"").val() == ""0"") {
            ModalAlert(""Por favor, informe a Máquina"");
            return false;
        }
        dadosCadastro += '"",""' + ""id_maquina"" + '"":""' + $(""#lstMaquina"").val();

        if ($(""#lstParteMaquina"").val() == ""0"") {
            ModalAlert(""Por favor, informe a parte Máquina."");
            return false;
        }
        dadosCadastro += '"",""' + ""id_parteMaquina"" + '"":""' + $(""#lstParteMaquina"").val();

        if ($(""#lstFormulario"").val() == ""0"") {
            ModalAlert(""Por favor, informe o Formulário."");
            return false;
        }
        dadosCadastro += '"",""' + ""id_formulario"" + '"":""' + $(""#lstFormulario"").val();

        if ($(""#dataInicio"").val() != """" && $(""#dataFim"").val() == """") {

            ModalAlert(""Por favor informar as duas datas para a pesquisa"");
          ");
            WriteLiteral(@"  return;
        }

        if ($(""#dataInicio"").val() == """" && $(""#dataFim"").val() != """") {

            ModalAlert(""Por favor informar as duas datas para a pesquisa"");
            return;
        }

        if ($(""#dataInicio"").val() != """" && $(""#dataFim"").val() != """") {


            dadosCadastro += '"",""' + ""dataInicio"" + '"":""' + $(""#dataInicio"").val();

            dadosCadastro += '"",""' + ""dataFim"" + '"":""' + $(""#dataFim"").val();
        }



        return true;
    }


    function Pesquisar() {
        if (Consultar()) {
            if (validarCampos()) {
                eval('var myData = {""' + dadosCadastro + '""}');

                $.ajax({
                    url: ""Consulta/Respostas"",
                    data: JSON.stringify(myData),
                    type: 'POST',
                    traditional: true,
                    contentType: 'application/json',
                    success: function (data) {
                        dadosCadastro = """";
             ");
            WriteLiteral(@"           if (data.length > 0) {
                            Grid(data);
                        }
                        else {
                            TabelaVazia();
                        }


                    }
                });
            }
        }
    }

    function TabelaVazia() {
        $(""#conteudo"").empty();
        html = "" <div style='overflow-x:auto;'>"";
        html += ""<table id='dtHorizontalExample' class='table table-striped table-bordered table-sm' cellspacing='0' width='100%'>"";
        html += ""<thead>"";
        html += ""<tr>"";
        html += ""<th colspan='12'></th>"";
        html += ""</tr>"";
        html += ""</thead>"";
        html += ""<tbody>"";

        html += ""<tr style='text-align:center;'>"";
        html += ""<td>Consulta Repostas</td>"";

        html += ""</tr>"";
        html += ""<tr style='text-align:center; color:red '>"";
        html += ""<td colspan='12'> Não existe nenhum registro cadastrado. </td>"";
        html += ""</tr>"";


   ");
            WriteLiteral(@"     html += ""</tbody>"";
        html += ""</table>"";
        html += ""</div >"";
        $(""#conteudo"").append(html);
    }

    function Grid(dados) {

        var cabecalho = 0;
        var linhas = dados.length;
        var cont = 0
        for (var i = 0; i < dados.length; i++) {

            if (cabecalho == 0) {
                cabecalho = dados[cont].length;

            } else {
                if (cabecalho != dados[cont].length) {

                    if (dados[cont].length > cabecalho) {
                        cabecalho = dados[cont].length
                    }
                }
            }
            cont++;
        }

        $(""#conteudo"").empty();
        html = "" <div style='overflow-x:auto;'>"";
        html += ""<table id='dtHorizontalExample' class='table table-striped table-bordered table-sm' cellspacing='0' width='100%'>"";

        for (var i = 0; i < linhas; i++) {

            html += ""<thead>"";
            html += ""<tr style='text-align:center;backgr");
            WriteLiteral(@"ound-color: #e9ecef;'>"";
            
            if (i == 0) {
                html += ""<th>Status</th>"";
                html += ""<th>Data</th>"";
                for (var c = 0; c < cabecalho; c++) {


                    if (dados[i].length <= c) {

                        html += ""<th></th>"";
                    } else {
                        html += ""<th>"" + dados[i][c].pergunta + ""</th>"";
                    }
                }
            }

            html += ""</tr>"";
            html += ""</thead>"";
            html += ""<tbody>"";

            //for (var j = 0; j < linhas; j++) {

                html += ""<tr style='text-align:center;'>"";

                for (var r = 0; r < dados[i].length; r++) {

                    if (r == 0) {
                        if (dados[i][r].statusFormulario == ""F"") {
                            html += ""<td><span class='glyphicon glyphicon-ok' style=color:green></span></td >"";
                        } else {
                            ");
            WriteLiteral(@"html += ""<td><span class='glyphicon glyphicon-hourglass' style=color:gray>></span></td >"";
                        }

                        html += ""<td>"" + dados[i][r].data + ""</td>"";
                    }

                    if (dados[i][r].id_tipoResposta == 1) {
                        html += ""<td>"" + dados[i][r].descMutiplaEscolha + ""</td>"";
                    } else if (dados[i][r].id_tipoResposta == 2) {
                        html += ""<td  data-toggle='tooltip' title='Respostas Filhas'><button value ='' type='button' class='btn btn - link' onclick='ConsultaFilho("" + dados[i][r].idPreenchimento + "","" + dados[i][r].idPai + "","" + dados[i][r].id_formulario + "")'><span class='	glyphicon glyphicon-search' style=color:red></span></button></td>"";
                    }
                    else {
                        html += ""<td>"" + dados[i][r].valor + ""</td>"";
                    }


                }
                if (cabecalho != dados[i].length) {
                    html += ""<");
            WriteLiteral(@"td></td>"";
                }

                html += ""</tr>"";
                html += ""</tbody>"";
            //}

        }
        html += ""</table>"";
        html += ""</div >"";
        $(""#conteudo"").append(html);

    }

    function ConsultaFilho(idPreenchimento, idPai, id_formulario) {



        $.ajax({
            url: ""Consulta_perguntaFilhoRelatorio/Respostas?idPreenchimento="" + idPreenchimento + ""&idPai="" + idPai + ""&id_formulario="" + id_formulario,
            dataType: 'json',
            type: 'GET',
            success: function (data) {

                if (data.length > 0) {
                    ModalFilho();
                    GrdiFilhos(data);
                }
            },
            error: function (data) {
                alert(""erro"");
                console.log(data);
            }
        });


    }

    //

    function GrdiFilhos(data) {
        var html = """";
        $(""#gridFilhos"").empty();

        html = "" <div style='overflow-");
            WriteLiteral(@"x:auto;'>"";
        html += ""<table id='dtHorizontalExample' class='table table-striped table-bordered table-sm' cellspacing='0' width='100%'>"";
        html += ""<thead>"";

        html += ""<tr style='text-align:center;background-color: #e9ecef;'>"";
        for (var r = 0; r < data.length; r++) {
            html += ""<th>"" + data[r].nomePergunta + ""</th>"";
        }

        html += ""</tr>"";
        html += ""</thead>"";
        html += ""<tbody>"";
        if (data.length > 0) {
            html += ""<tr style='text-align:center;'>"";
            for (var r = 0; r < data.length; r++) {

                if (data[r].id_tipoResposta == 1) {

                    if (data[r].valor != 0) {

                        html += ""<td>"" + data[r].descMutiplaEscolha + ""</td>"";
                    }
                } else {
                    html += ""<td>"" + data[r].valor + ""</td>"";
                }


            }
            html += ""</tr>"";
        }
        else {
            html += ""<tr sty");
            WriteLiteral(@"le='text-align:center; color:red '>"";
            html += ""<td colspan='12'> Não existe nenhum registro cadastrado. </td>"";
            html += ""</tr>"";
        }

        html += ""</tbody>"";
        html += ""</table>"";
        html += ""</div >"";
        $(""#gridFilhos"").append(html);

    }

    function ModalFilho() {
        $(""#modalFilhos"").modal('show');
    }






</script>

");
            EndContext();
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
