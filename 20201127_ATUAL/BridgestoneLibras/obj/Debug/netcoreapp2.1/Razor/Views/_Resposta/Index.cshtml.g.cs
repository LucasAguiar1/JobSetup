#pragma checksum "C:\ProjetosManufatura\JobSetup\20201127_ATUAL\BridgestoneLibras\Views\_Resposta\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8c90fde84bcbbb311800664dadae274a299bc41"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views__Resposta_Index), @"mvc.1.0.view", @"/Views/_Resposta/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/_Resposta/Index.cshtml", typeof(AspNetCore.Views__Resposta_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8c90fde84bcbbb311800664dadae274a299bc41", @"/Views/_Resposta/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"192150bb95317d23cebc8fb46a5e75f7c3dacb90", @"/Views/_ViewImports.cshtml")]
    public class Views__Resposta_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            BeginContext(25, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "089675a5b31a41bb9c9a8c1197a63721", async() => {
                BeginContext(31, 46, true);
                WriteLiteral("\r\n    <title>Departamento sdafasfsfa</title>\r\n");
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
            BeginContext(84, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(86, 3115, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ee0ff2c90ab4b7589fcfa472171f874", async() => {
                BeginContext(92, 3102, true);
                WriteLiteral(@"
    <ul class=""breadcrumb"" style=""color:red"">
        <li>Departamentos</li>
    </ul>

    <div class=""container"">
        <div class=""row text-center"" style=""margin-top:20px;"">
            <div class=""col-lg-2"">
                <label>Código</label>
            </div>
            <div class=""col-lg-8 text-center"">
                <label>Departamento</label>
            </div>
            <div class=""col-lg-2 text-center"">
                <label>Status</label>
            </div>
        </div>
        <div class=""row"" >
            <div class=""col-lg-2"">
                <input type='text' maxlength=""4"" id=""idCodDepartamento"" onkeypress=""ValidaNumeros(this)"" name='txtCodDepartamento' class='form-control' />
            </div>
            <div class=""col-lg-8"">
                <input type='text' maxlength=""50"" id=""idDepartamento"" name='txtCodDepartamento' class='form-control' />
            </div>
            <div class=""col-lg-2"">
                <select id=""lstStatus"" name=""recursoC");
                WriteLiteral(@"entroCusto"" class=""form-control""></select>
            </div>
        </div>
        <div class=""row"" style=""margin-top:10px;"">

            <div class=""col-lg-3"">
                <button type=""button"" id=""btnCadastrar"" onclick=""Cadastrar()"" class=""btn btn-outline-danger btn-block "">Cadastrar</button>
            </div>
            <div class=""col-lg-3"">
                <button type=""button"" id=""btnAlterar"" onclick=""Alterar(0)"" class=""btn btn-outline-dark  btn-block "">Alterar</button>
            </div>
            <div class=""col-lg-3"">
                <button type=""button"" onclick=""Limpar()"" class=""btn btn-outline-secondary  btn-block"">Limpar</button>
            </div>
            <div class=""col-lg-3"">
                <button type=""button"" id=""btnConsultar"" onclick=""Pesquisar(1)"" class=""btn btn-outline-secondary btn-block ""><span style=""color: black;"" class=""glyphicon glyphicon-search""></span></button>
            </div>

        </div>
    </div>

    <div class=""container"" style=""ma");
                WriteLiteral(@"rgin-top: 6px;"">
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
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"" style=""margin:auto; background-color: black;"">Ok</button>
                </div>
            </div>");
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
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
            BeginContext(3201, 11809, true);
            WriteLiteral(@"


</html>

<script>
    var dadosCadastro = """";
    var copyData = """";
    var idDepartamento = 0;
    (function () {

        $(""#btnAlterar"").prop('disabled', true);

        ComboStatus();
        ConsultarDepartamento();
        $('[data-toggle=""tooltip""]').tooltip();


    })();

    function ComboStatus() {
        $.ajax({
            url: ""Status/Departamento"",
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
                            $('<option></option>').val(index.value).html(index.text));
                    })
                    $(""#lstStatus"").prop('selected");
            WriteLiteral(@"Index');
                }
            },
            error: function (data) {
                alert(""erro"");
                console.log(data);
            }
        });
    }



    function Cadastrar() {
        if (validarCampos()) {
            if (VerificaExiste()) {
                eval('var myData = {""' + dadosCadastro + '""}');

                $.ajax({
                    url: ""Cadastrar/Departamento"",
                    data: JSON.stringify(myData),
                    type: 'POST',
                    traditional: true,
                    contentType: 'application/json',
                    success: function (data) {
                        dadosCadastro = """";
                        ConsultarDepartamento()
                        ModalAlert(data.msn);
                        $(""#btnAlterar"").prop('disabled', true);
                    }
                });
            }
        }
    }

    function ConsultarDepartamento() {

        $.ajax({
            url:");
            WriteLiteral(@" ""Consulta/Departamento"",
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                copyData = data;
                CarregaGrid(data, 0);
            }
        });
    }

    function Alterar(Tipo) {

        if (Tipo == 0) {
            if (!validarCampos()) {
                return false;
            }
        }
        dadosCadastro += '"",""' + ""id"" + '"":""' + idDepartamento;

        eval('var myData = {""' + dadosCadastro + '""}');

        $.ajax({
            url: ""Alterar/Departamento"",
            data: JSON.stringify(myData),
            type: 'POST',
            traditional: true,
            contentType: 'application/json',
            success: function (data) {
                dadosCadastro = """";
                ConsultarDepartamento()
                ModalAlert(data.msn);
            }
        });
    }

    function AtivoInativo(id) {

        dadosCadastro = """"; 
        for (var i = 0; i < copyData.length; ");
            WriteLiteral(@"i++) {
            if (copyData[i].id == id.value) {

                dadosCadastro = ""codigo"" + '"":""' + copyData[i].codigo; 
                dadosCadastro += '"",""' + ""nome"" + '"":""' + copyData[i].nome;
                if (copyData[i].status == 1) {
                    dadosCadastro += '"",""' + ""status"" + '"":""' + 2
                } else {
                    dadosCadastro += '"",""' + ""status"" + '"":""' + 1
                }
            }
        }
        Alterar(1);
    }

    function Editar(id) {

        for (var i = 0; i < copyData.length; i++) {
            if (copyData[i].id == id.value) {
                $(""#lstStatus"").val(copyData[i].status);
                $(""#idCodDepartamento"").val(copyData[i].codigo);
                $(""#idDepartamento"").val(copyData[i].nome);
                $(""#idCodDepartamento"").prop('disabled', true);
                $(""#btnAlterar"").prop('disabled', false);
                $(""#btnCadastrar"").prop('disabled', true);
                idDepartamento = id.");
            WriteLiteral(@"value; 
                
            }
        }
    }

    function Pesquisar() {


        for (var i = 0; i < copyData.length; i++) {
            if (copyData[i].codigo == $(""#idCodDepartamento"").val().trim().toUpperCase() || copyData[i].nome.trim().toUpperCase() == $(""#idDepartamento"").val() || copyData[i].status == $(""#lstStatus"").val()) {
                dadosRetorno = [];
                dadosRetorno[""id""] = copyData[i].id;
                dadosRetorno[""codigo""] = copyData[i].codigo;
                dadosRetorno[""nome""] = copyData[i].nome;
                dadosRetorno[""status""] = copyData[i].status;
                CarregaGrid(dadosRetorno, 1);
            }
        }

    }

    function ParametrosPesquisa() {
        if ($(""#idCodDepartamento"").val() == """") {

            ModalAlert(""Por favor, informe o código do departamento para pesquisar."");
            return false;
        }
        dadosCadastro = ""codigo"" + '"":""' + $(""#idCodDepartamento"").val();

        if ($(""#");
            WriteLiteral(@"idDepartamento"").val() != """") {
            dadosCadastro += '"",""' + ""nome"" + '"":""' + $(""#idDepartamento"").val().trim().toUpperCase();
        }
        
        if ($(""#lstStatus"").val() != ""0"") {
            dadosCadastro += '"",""' + ""status"" + '"":""' + $(""#lstStatus"").val();    
        }
        
        return true;
    }

    function ValidaNumeros(x) {

        $(x).val($(x).val().replace(/[^0-9\.]/g, ''));
        if ((event.which != 46 || $(x).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    }

    function validarCampos() {
        if ($(""#idCodDepartamento"").val() == """") {

            ModalAlert(""Por favor, informe o código do departamento."");
            return false;
        }
        dadosCadastro = ""codigo"" + '"":""' + $(""#idCodDepartamento"").val();

        if ($(""#idDepartamento"").val() == """") {
            ModalAlert(""Por favor, informe o nome do departamento."");
            return false;
     ");
            WriteLiteral(@"   }
        dadosCadastro += '"",""' + ""nome"" + '"":""' + $(""#idDepartamento"").val().trim();

        if ($(""#lstStatus"").val() == ""0"") {
            ModalAlert(""Por favor, selecione o status do departamento."");
            return false;
        }
        dadosCadastro += '"",""' + ""status"" + '"":""' + $(""#lstStatus"").val();
        return true;
    }

    function VerificaExiste() {

        for (var i = 0; i < copyData.length; i++) {

            if ($(""#idCodDepartamento"").val() == copyData[i].codigo ) {

                ModalAlert(""Não é possível efetuar o cadastro, o registro já exste."");
                return false;
            }
        }
        return true;
    }

    function CarregaGrid(dados, tipo) {

        $(""#conteudo"").empty();
        html = "" <div style='overflow-x:auto;'>"";
        html += ""<table id='dtHorizontalExample' class='table table-striped table-bordered table-sm' cellspacing='0' width='100%'>"";
        html += ""<thead>"";
        html += ""<tr style='text-al");
            WriteLiteral(@"ign:center;background-color: #e9ecef;'>"";
        html += ""<th style='width: 1%;'><button type='button' class='btn btn -default btn - md' onclick='ConsultarDepartamento()' data-toggle='tooltip' title='Atualizar Consulta' style='color:red'><span style='' class='glyphicon glyphicon-refresh'></span></button><span></span></th>"";
        html += ""<th>Código</th>"";
        html += ""<th>Nome</th>"";
        html += ""<th>Status</th>"";
        html += ""<th>Editar</th>"";
        html += ""</tr>"";
        html += ""</thead>"";
        html += ""<tbody>"";
        if (dados.length > 0) {
            for (var r = 0; r < dados.length; r++) {
                html += ""<tr style='text-align:center;'>"";
                html += ""<td></td>"";
                html += ""<td>"" + dados[r].codigo + ""</td>"";
                html += ""<td>"" + dados[r].nome + ""</td>"";
                if (dados[r].status == 1) {
                    html += ""<td  data-toggle='tooltip' title='Ativo' ><button type='button' style='margin-left:8px;' cl");
            WriteLiteral(@"ass='btn btn-white' value="" + dados[r].id + ""  id='btn_Alterar_"" + dados[r].id + ""  ' onclick='AtivoInativo(this)'><span  style='color: green;' class='glyphicon glyphicon-ok' ></button></td>"";
                } else {
                    html += ""<td  data-toggle='tooltip' title='Inativo' ><button type='button' style='margin-left:8px;' class='btn btn-white' value="" + dados[r].id + ""  id='btn_Alterar_"" + dados[r].id + ""  ' onclick='AtivoInativo(this)'><span  style='color: red;' class='glyphicon glyphicon-ok' ></button></td>"";
                }

                html += ""<td><button type='button' style='margin-left:8px;' class='btn btn-white' value="" + dados[r].id + ""  id='btn_Alterar_"" + dados[r].id + ""  ' onclick='Editar(this)'><span  style='color: black;' class='glyphicon glyphicon-pencil' ></button></td>"";
                html += ""</tr>"";
            }
        } else if (dados != null) {

            if (tipo == 1) {
                if (dados != null) {
                    //$(""#btnCadastrar"").pr");
            WriteLiteral(@"op('disabled', true);
                    html += ""<tr style='text-align:center;'>"";
                    html += ""<td></td>"";
                    html += ""<td>"" + dados.codigo + ""</td>"";
                    html += ""<td>"" + dados.nome + ""</td>"";
                    if (dados.status == 1) {
                        html += ""<td  data-toggle='tooltip' title='Ativo' ><button type='button' style='margin-left:8px;' class='btn btn-white' value="" + dados.id + ""  id='btn_Alterar_"" + dados.id + ""  ' onclick='AtivoInativo(this)'><span  style='color: green;' class='glyphicon glyphicon-ok' ></button></td>"";
                    } else {
                        html += ""<td  data-toggle='tooltip' title='Inativo' ><button type='button' style='margin-left:8px;' class='btn btn-white' value="" + dados.id + ""  id='btn_Alterar_"" + dados.id + ""  ' onclick='AtivoInativo(this)'><span  style='color: red;' class='glyphicon glyphicon-ok' ></button></td>"";
                    }
                    html += ""<td><button type='but");
            WriteLiteral(@"ton' style='margin-left:8px;' class='btn btn-white' value="" + dados.id + ""  id='btn_Alterar_"" + dados.id + ""  ' onclick='Editar(this)'><span  style='color: black;' class='glyphicon glyphicon-pencil' ></button></td>"";
                    html += ""</tr>"";
                    dados = null;
                }

            } else {
                html += ""<tr style='text-align:center; color:red '>"";
                html += ""<td colspan='12'> Não existe nenhum registro cadastrado. </td>"";
                html += ""</tr>"";
            }
        }
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

    function Limpar() {
        $(""#lstStatus"").val(0);
        $(""#idCodDepartamento"").val("""");
        $(""#idDepartam");
            WriteLiteral(@"ento"").val("""");
        $(""#idCodDepartamento"").prop('disabled', false);
        $(""#btnAlterar"").prop('disabled', true);
        $(""#btnCadastrar"").prop('disabled', false);
        $(""#conteudo"").empty();
        ConsultarDepartamento();
    }

    function ModalAlert(msn) {
        $(""#modalmsn"").modal('show');
        var resposta = '';
        $(""#idmsn"").empty();
        resposta = ""<div class='alert alert-danger  text-center' role='alert'>"" + msn + ""</div>"";
        $(""#idmsn"").append(resposta);
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
