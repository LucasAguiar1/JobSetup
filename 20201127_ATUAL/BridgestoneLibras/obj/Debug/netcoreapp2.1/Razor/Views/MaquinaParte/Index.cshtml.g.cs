#pragma checksum "C:\ProjetosManufatura\JobSetup\20201127_ATUAL\BridgestoneLibras\Views\MaquinaParte\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d9f22a593f4c84e34cfc14917975a89c31ffabb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MaquinaParte_Index), @"mvc.1.0.view", @"/Views/MaquinaParte/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MaquinaParte/Index.cshtml", typeof(AspNetCore.Views_MaquinaParte_Index))]
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
#line 1 "C:\ProjetosManufatura\JobSetup\20201127_ATUAL\BridgestoneLibras\Views\_ViewImports.cshtml"
using BridgestoneLibras;

#line default
#line hidden
#line 2 "C:\ProjetosManufatura\JobSetup\20201127_ATUAL\BridgestoneLibras\Views\_ViewImports.cshtml"
using BridgestoneLibras.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d9f22a593f4c84e34cfc14917975a89c31ffabb", @"/Views/MaquinaParte/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"192150bb95317d23cebc8fb46a5e75f7c3dacb90", @"/Views/_ViewImports.cshtml")]
    public class Views_MaquinaParte_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onload", new global::Microsoft.AspNetCore.Html.HtmlString("loadNoBack();"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onpageshow", new global::Microsoft.AspNetCore.Html.HtmlString("if (event.persisted) loadNoBack();"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 173, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<script type=\"text/javascript\">\r\n    window.history.forward();\r\n    function loadNoBack() {\r\n        window.history.forward();\r\n    }\r\n</script>\r\n<html>\r\n");
            EndContext();
            BeginContext(173, 49, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb14cce4c4224f1db94dc996ccfdd6aa", async() => {
                BeginContext(179, 36, true);
                WriteLiteral("\r\n    <title>Parte Máquina</title>\r\n");
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
            BeginContext(222, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(224, 3409, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b24e6e94b5342e0988dc0bc822f7fae", async() => {
                BeginContext(301, 3325, true);
                WriteLiteral(@"
    <ul class=""breadcrumb"" style=""color:red"">
        <li>Parte Máquina</li>
    </ul>
    <div class=""container"">
        <div class=""row text-center"" style=""margin-top:20px;"">
            <div class=""col-lg-2"">
                <label>Departamento</label>
            </div>
            <div class=""col-lg-2 text-center"">
                <label>Máquina</label>
            </div>
            <div class=""col-lg-6 text-center"">
                <label>Parte Máquina</label>
            </div>
            <div class=""col-lg-2 text-center"">
                <label>Status</label>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-lg-2"">
                <select id=""lstDepartamento"" name=""departamento"" onchange=""ComboParteMaquina();"" class=""form-control""></select>
            </div>
            <div class=""col-lg-2"">
                <select id=""lstMaquina"" name=""maquina"" class=""form-control""></select>
            </div>
            <div class=""col-lg-6"">
  ");
                WriteLiteral(@"              <input type='text' maxlength=""20"" id=""idtxtParteMaquina"" name='idParteMaquina' class='form-control' />
            </div>
            <div class=""col-lg-2"">
                <select id=""lstStatus"" name=""recursoCentroCusto"" class=""form-control""></select>
            </div>
        </div>

        <div class=""row"" style=""margin-top:10px;"">

            <div class=""col-lg-3"">
                <button type=""button"" id=""btnCadastrar"" onclick=""Cadastrar()"" class=""btn btn-outline-danger btn-block"">Cadastrar</button>
            </div>
            <div class=""col-lg-3"">
                <button type=""button"" id=""btnAlterar"" onclick=""Alterar(0)"" class=""btn btn-outline-dark btn-block"">Alterar</button>
            </div>
            <div class=""col-lg-3"">
                <button type=""button"" id=""btnConsultar"" onclick=""Pesquisar()"" class=""btn btn-outline-secondary btn-block""><span style=""color: black;"" class=""glyphicon glyphicon-search""></span></button>
            </div>
            <div cl");
                WriteLiteral(@"ass=""col-lg-3"">
                <button type=""button"" onclick=""Limpar()"" class=""btn btn-outline-secondary btn-block"">Limpar</button>
            </div>

        </div>
    </div>

    <div class=""container"" style=""margin-top: 6px;"">
        <div id=""conteudo""></div>
    </div>

    <!-- Modal -->
    <div class=""modal fade"" id=""modalmsn"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"" style=""margin-top: 136px;"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLabel"">Informação</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div id=""idmsn""></div>
                </div>
           ");
                WriteLiteral("     <div class=\"modal-footer\">\r\n                    <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\" style=\"margin:auto; background-color: black;\">Ok</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3633, 18998, true);
            WriteLiteral(@"


</html>

<script>

    var dadosCadastro = """";
    var copyData = """";
    var id_ParteMaquina = 0;
    var idMaquina = 0;
    dadosRetorno = new Array();
    (function () {

        $(""#btnAlterar"").prop('disabled', true);
        ComboStatus();
        ComboDepartamento();
        ComboParteMaquinas();
        ConsultarGrid();
        $('[data-toggle=""tooltip""]').tooltip();


    })();


    function ConsultarGrid() {

        $.ajax({
            url: ""ConsultaGrid/MaquinaParte"",
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                copyData = data;
                CarregaGrid(data, 0)
            },
            error: function (data) {
                alert(""erro"");
                console.log(data);
            }
        });
    }

    function Pesquisar() {
        if (populaCampos()) {
            eval('var myData = {""' + dadosCadastro + '""}');

            $.ajax({
                url: ""Pesquisar/M");
            WriteLiteral(@"aquinaParte"",
                data: JSON.stringify(myData),
                type: 'POST',
                traditional: true,
                contentType: 'application/json',
                success: function (data) {
                    dadosCadastro = """";
                    CarregaGrid(data);

                    //ModalAlert(data.msn);
                }
            });
        }
        //if (!validarCamposPesquisa()) {
        //    return false;
        //}
        //var cont = 0;
        //dadosRetorno = new Array();

        //if ($(""#lstDepartamento"").val() != ""0"" && $(""#lstMaquina"").val() == ""0"" && $(""#idtxtParteMaquina"").val() == """") {
        //    for (var i = 0; i < copyData.length; i++) {
        //        if (copyData[i].id_departamento == $(""#lstDepartamento"").val()) {
        //            ObjetoConsulta(copyData, i, cont);
        //            cont++;
        //        }
        //    }
        //    if (dadosRetorno != null) {
        //        CarregaGrid(dadosR");
            WriteLiteral(@"etorno, 1);
        //        return;
        //    }
        //}

        //if ($(""#lstDepartamento"").val() != ""0"" && $(""#lstMaquina"").val() != ""0"" && $(""#idtxtParteMaquina"").val() == """") {
        //    for (var i = 0; i < copyData.length; i++) {
        //        if (copyData[i].id_departamento == $(""#lstDepartamento"").val() && copyData[i].id_maquina == $(""#lstMaquina"").val()) {
        //            ObjetoConsulta(copyData, i, cont);
        //            cont++;
        //        }
        //    }
        //    if (dadosRetorno != null) {
        //        CarregaGrid(dadosRetorno, 1);
        //        return;
        //    }
        //}


        //if ($(""#lstDepartamento"").val() != ""0"" && $(""#lstMaquina"").val() != ""0"" && $(""#idtxtParteMaquina"").val() != """") {
        //    for (var i = 0; i < copyData.length; i++) {
        //        if (copyData[i].id_departamento == $(""#lstDepartamento"").val() && copyData[i].id_maquina == $(""#lstMaquina"").val() && $(""#idtxtParteMaquina"").val().t");
            WriteLiteral(@"rim().trim().toUpperCase() == copyData[i].nome.trim().toUpperCase()) {
        //            ObjetoConsulta(copyData, i, cont);
        //            cont++;
        //        }
        //    }
        //    if (dadosRetorno != null) {
        //        CarregaGrid(dadosRetorno, 1);
        //        return;
        //    }
        //}
    }

    function populaCampos() {
        if ($(""#lstDepartamento"").val() == """") {
            ModalAlert(""Por favor, selecione o Departamento."");
            return false;
        }
        dadosCadastro = ""id_departamento"" + '"":""' + $(""#lstDepartamento"").val();

        if ($(""#lstMaquina"").val() != """") {
            dadosCadastro += '"",""' + ""id_maquina"" + '"":""' + $(""#lstMaquina"").val();
        }

        if ($(""#idtxtParteMaquina"").val() != """") {
            dadosCadastro += '"",""' + ""nome"" + '"":""' + $(""#idtxtParteMaquina"").val();
        }

        if ($(""#lstStatus"").val() != ""0"") {
            dadosCadastro += '"",""' + ""status"" + '"":""' + cara");
            WriteLiteral(@"cterSpecial($(""#lstStatus"").val());
        }

        return true;
    }
    function ObjetoConsulta(obj, i, cont) {

        b = new Object();
        b[""id""] = copyData[i].id;
        b[""nome""] = copyData[i].nome;
        b[""departamento""] = copyData[i].departamento;
        b[""id_departamento""] = copyData[i].id_departamento;
        b[""maquina""] = copyData[i].maquina;
        b[""id_maquina""] = copyData[i].id_maquina;
        b[""status""] = copyData[i].status;
        dadosRetorno[cont] = b;
    }


    function Alterar(Tipo) {

        if (Tipo == 0) {
            if (!validarCampos()) {
                return false;
            }
            dadosCadastro += '"",""' + ""id"" + '"":""' + id_ParteMaquina;
        }
        
        eval('var myData = {""' + dadosCadastro + '""}');
        
        $.ajax({
            url: ""Alterar/MaquinaParte"",
            data: JSON.stringify(myData),
            type: 'POST',
            traditional: true,
            contentType: 'application");
            WriteLiteral(@"/json',
            success: function (data) {
                dadosCadastro = """";
                ConsultarGrid()
                ModalAlert(data.msn);
            }
        });
    }

    function AtivoInativo(id) {

        dadosCadastro = """";
        for (var i = 0; i < copyData.length; i++) {
            if (copyData[i].id == id.value) {

                dadosCadastro = ""id_departamento"" + '"":""' + copyData[i].id_departamento;
                dadosCadastro += '"",""' + ""nome"" + '"":""' + copyData[i].nome;
                dadosCadastro += '"",""' + ""id_maquina"" + '"":""' + copyData[i].id_maquina;
                dadosCadastro += '"",""' + ""id"" + '"":""' + copyData[i].id;
                if (copyData[i].status == 1) {
                    dadosCadastro += '"",""' + ""status"" + '"":""' + 2
                } else {
                    dadosCadastro += '"",""' + ""status"" + '"":""' + 1
                }
            }
        }
        Alterar(1);
    }

    function CarregaGrid(dados, tipo) {

        ");
            WriteLiteral(@"$(""#conteudo"").empty();
        html = "" <div style='overflow-x:auto;'>"";
        html += ""<table id='dtHorizontalExample' class='table table-striped table-bordered table-sm' cellspacing='0' width='100%'>"";
        html += ""<thead>"";
        html += ""<tr style='text-align:center;background-color: #e9ecef;'>"";
        html += ""<th style='width: 1%;'><button type='button' class='btn btn -default btn - md' onclick='ConsultarGrid()' data-toggle='tooltip' title='Atualizar Consulta' style='color:red'><span style='' class='glyphicon glyphicon-refresh'></span></button><span></span></th>"";
        html += ""<th>Departamento</th>"";
        html += ""<th>Máquina</th>"";
        html += ""<th>Parte Máquina</th>"";
        html += ""<th>Status</th>"";
        html += ""<th>Editar</th>"";
        html += ""</tr>"";
        html += ""</thead>"";
        html += ""<tbody>"";
        if (dados.length > 0) {
            for (var r = 0; r < dados.length; r++) {
                html += ""<tr style='text-align:center;'>"";
      ");
            WriteLiteral(@"          html += ""<td></td>"";
                html += ""<td>"" + dados[r].departamento + ""</td>"";
                html += ""<td>"" + dados[r].maquina + ""</td>"";
                html += ""<td>"" + dados[r].nome + ""</td>"";
                if (dados[r].status == 1) {
                    html += ""<td  data-toggle='tooltip' title='Ativo' ><button type='button' style='margin-left:8px;' class='btn btn-white' value="" + dados[r].id + ""  id='btn_Alterar_"" + dados[r].id + ""  ' onclick='AtivoInativo(this)'><span  style='color: green;' class='glyphicon glyphicon-ok' ></button></td>"";
                } else {
                    html += ""<td  data-toggle='tooltip' title='Inativo' ><button type='button' style='margin-left:8px;' class='btn btn-white' value="" + dados[r].id + ""  id='btn_Alterar_"" + dados[r].id + ""  ' onclick='AtivoInativo(this)'><span  style='color: red;' class='glyphicon glyphicon-ok' ></button></td>"";
                }

                html += ""<td><button type='button' style='margin-left:8px;' class='b");
            WriteLiteral(@"tn btn-white' value="" + dados[r].id + ""  id='btn_Alterar_"" + dados[r].id + ""  ' onclick='Editar(this)'><span  style='color: black;' class='glyphicon glyphicon-pencil' ></button></td>"";
                html += ""</tr>"";
            }
        } //else if (dados != null) {

        //    if (tipo == 1) {
        //        if (dados != null) {
        //            html += ""<tr style='text-align:center;'>"";
        //            html += ""<td>"" + dados.departamento + ""</td>"";
        //            html += ""<td>"" + dados.maquina + ""</td>"";
        //            html += ""<td>"" + dados.nome + ""</td>"";
        //            if (dados.status == 1) {
        //                html += ""<td  data-toggle='tooltip' title='Ativo' ><button type='button' style='margin-left:8px;' class='btn btn-white' value="" + dados.id + ""  id='btn_Alterar_"" + dados.id + ""  ' onclick='AtivoInativo(this)'><span  style='color: green;' class='glyphicon glyphicon-ok' ></button></td>"";
        //            } else {
        //         ");
            WriteLiteral(@"       html += ""<td  data-toggle='tooltip' title='Inativo' ><button type='button' style='margin-left:8px;' class='btn btn-white' value="" + dados.id + ""  id='btn_Alterar_"" + dados.id + ""  ' onclick='AtivoInativo(this)'><span  style='color: red;' class='glyphicon glyphicon-ok' ></button></td>"";
        //            }

        //            html += ""<td><button type='button' style='margin-left:8px;' class='btn btn-white' value="" + dados.id + ""  id='btn_Alterar_"" + dados.id + ""  ' onclick='Editar(this)'><span  style='color: black;' class='glyphicon glyphicon-pencil' ></button></td>"";
        //            html += ""</tr>"";
        //            dados = null;
        //        }
        //        else {
        //            html += ""<tr style='text-align:center; color:red '>"";
        //            html += ""<td colspan='12'> Não existe nenhum registro cadastrado. </td>"";
        //            html += ""</tr>"";
        //        }
        //    }
        //    else {
        //        html += ""<tr sty");
            WriteLiteral(@"le='text-align:center; color:red '>"";
        //        html += ""<td colspan='12'> Não existe nenhum registro cadastrado. </td>"";
        //        html += ""</tr>"";
        //    }
        //}
        else {
            html += ""<tr style='text-align:center; color:red '>"";
            html += ""<td colspan='12'> Não existe nenhum registro cadastrado. </td>"";
            html += ""</tr>"";
        }

        html += ""</tbody>"";
        html += ""</table>"";
        html += ""</div >"";
        $(""#conteudo"").append(html);
    }

    

    function Editar(id) {

        for (var i = 0; i < copyData.length; i++) {
            if (copyData[i].id == id.value) {
                $(""#lstStatus"").val(copyData[i].status);
                $(""#lstDepartamento"").val(copyData[i].id_departamento);
                $(""#lstMaquina"").val(copyData[i].id_maquina);
                $(""#idtxtParteMaquina"").val(copyData[i].nome);

                $(""#lstDepartamento"").prop('disabled', true);
                $(""#");
            WriteLiteral(@"lstMaquina"").prop('disabled', true);

                $(""#btnAlterar"").prop('disabled', false);
                $(""#btnCadastrar"").prop('disabled', true);
                id_ParteMaquina = id.value;

            }
        }
    }

    function Cadastrar() {
        if (validarCampos()) {
            if (VerificaExiste()) {

                eval('var myData = {""' + dadosCadastro + '""}');

                $.ajax({
                    url: ""Cadastrar/Formulario"",
                    data: JSON.stringify(myData),
                    type: 'POST',
                    traditional: true,
                    contentType: 'application/json',
                    success: function (data) {
                        dadosCadastro = """";
                        ConsultarGrid();
                        ModalAlert(data.msn);
                    }
                });

            }
        }
    }

    function VerificaExiste() {

        for (var i = 0; i < copyData.length; i++) {

        ");
            WriteLiteral(@"    if ($(""#lstDepartamento"").val() == copyData[i].id_departamento && $(""#lstMaquina"").val() == copyData[i].id_maquina && $(""#idtxtParteMaquina"").val().toUpperCase() == copyData[i].nome.toUpperCase()) {
                ModalAlert(""Não é possível efetuar o cadastro, o registro já exste."");
                return false;
            }
        }
        return true;
    }





    function ComboStatus() {
        $.ajax({
            url: ""Status/MaquinaParte"",
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                var obj = data;
                $(""#lstStatus"").html("""");
                if (obj.length == 0) {
                    $(""#lstStatus"").prop('disabled', true);
                } else {
                    $(""#lstStatus"").prop('disabled', false);
                    $.each(obj, function (i, index) {
                        $(""#lstStatus"").append(
                            $('<option></option>').val(index.value).html(index.te");
            WriteLiteral(@"xt));
                    })
                    $(""#lstStatus"").prop('selectedIndex');
                }
            },
            error: function (data) {
                alert(""erro"");
                console.log(data);
            }
        });
    }
    function ComboDepartamento() {
        $.ajax({
            url: ""Departamento/MaquinaParte"",
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
                    })
                    $(""#lstDepartamento"").prop('select");
            WriteLiteral(@"edIndex');
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
            url: ""Maquinas/MaquinaParte?idDepartamento="" + $(""#lstDepartamento"").val(),
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
                    $(""#lstMaquina"").prop('selectedIndex');
                }
            },
            e");
            WriteLiteral(@"rror: function (data) {
                alert(""erro"");
                console.log(data);
            }
        });
    }


    function ComboParteMaquinas() {
        $.ajax({
            url: ""Maquinas/MaquinaParte"",
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
                    $(""#lstMaquina"").prop('selectedIndex');
                }
            },
            error: function (data) {
                alert(""erro"");
                console.log(data);
          ");
            WriteLiteral(@"  }
        });
    }
    //function ConsultarDepartamento() {

    //    $.ajax({
    //        url: ""Consulta/MaquinaParte"",
    //        dataType: 'json',
    //        type: 'GET',
    //        success: function (data) {
    //            copyData = data;
    //            CarregaGrid(data, 0);
    //        }
    //    });
    //}

    function validarCamposPesquisa() {
        if ($(""#lstDepartamento"").val() == ""0"" && $(""#lstMaquina"").val() == ""0"" && $(""#idtxtParteMaquina"").val() == """") {
            ModalAlert(""Por favor, informe um parametro para a consulta."");
            return false;
        }
        return true;
    }
    function validarCampos() {
        if ($(""#lstDepartamento"").val() == 0) {

            ModalAlert(""Por favor, selecione o departamento."");
            return false;
        }
        dadosCadastro = ""id_departamento"" + '"":""' + $(""#lstDepartamento"").val();

        if ($(""#lstMaquina"").val() == ""0"") {
            ModalAlert(""Por favor, selecione");
            WriteLiteral(@" a Máquina."");

            return false;
        }
        dadosCadastro += '"",""' + ""id_maquina"" + '"":""' + $(""#lstMaquina"").val();
        if ($(""#idtxtParteMaquina"").val() == """") {

            ModalAlert(""Por favor, informe o nome da Parte Máquina."");
            return false;
        }
        dadosCadastro += '"",""' + ""nome"" + '"":""' + caracterSpecial($(""#idtxtParteMaquina"").val());

        if ($(""#lstStatus"").val() == ""0"") {
            ModalAlert(""Por favor, selecione o status do departamento."");
            return false;
        }
        dadosCadastro += '"",""' + ""status"" + '"":""' + $(""#lstStatus"").val();
        return true;
    }

    function caracterSpecial(text) {

        return text.trim().replace(/&/g, ""&amp;"").replace(/>/g, ""&gt;"").replace(/</g, ""&lt;"").replace(/""/g, ""&quot;"");
    }

    function ModalAlert(msn) {
        $(""#modalmsn"").modal('show');
        var resposta = '';
        $(""#idmsn"").empty();
        resposta = ""<div class='alert alert-danger  text-ce");
            WriteLiteral(@"nter' role='alert'>"" + msn + ""</div>"";
        $(""#idmsn"").append(resposta);
    }

    function Limpar() {
        
        $(""#lstStatus"").val(0);
        $(""#lstDepartamento"").val(0);
        $(""#lstMaquina"").val(0);

        $(""#idtxtParteMaquina"").val("""");
        $(""#lstDepartamento"").prop('disabled', false);
        $(""#lstMaquina"").prop('disabled', false);
        $(""#btnCadastrar"").prop('disabled', false);
        $(""#btnAlterar"").prop('disabled', true);
        $(""#conteudo"").empty();
        ConsultarGrid();
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
