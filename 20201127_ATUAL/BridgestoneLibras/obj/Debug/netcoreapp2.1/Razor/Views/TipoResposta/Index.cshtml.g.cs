#pragma checksum "C:\ProjetosManufatura\JobSetup\20201127_ATUAL\BridgestoneLibras\Views\TipoResposta\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e98272373fcebfedeba9d380817071ed94557c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TipoResposta_Index), @"mvc.1.0.view", @"/Views/TipoResposta/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/TipoResposta/Index.cshtml", typeof(AspNetCore.Views_TipoResposta_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e98272373fcebfedeba9d380817071ed94557c0", @"/Views/TipoResposta/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"192150bb95317d23cebc8fb46a5e75f7c3dacb90", @"/Views/_ViewImports.cshtml")]
    public class Views_TipoResposta_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            BeginContext(0, 29, true);
            WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(29, 48, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "15bf1214bcf843f5866947cd13d66185", async() => {
                BeginContext(35, 35, true);
                WriteLiteral("\r\n    <title>Alternativas</title>\r\n");
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
            BeginContext(77, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(79, 2867, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b4c167360a914603bbfb15b87d864252", async() => {
                BeginContext(85, 2854, true);
                WriteLiteral(@"
    <ul class=""breadcrumb"" style=""color:red"">
        <li>Alternativas</li>
    </ul>

    <div class=""container"">
        <div class=""row text-center"" style=""margin-top:20px;"">
            <div class=""col-lg-2"">
                <label>Tipo de Alternativa</label>
            </div>
            <div class=""col-lg-8 text-center"">
                <label>Descrição</label>
            </div>
            <div class=""col-lg-2 text-center"">
                <label>Status</label>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-lg-2"">
                <select id=""lstTipoResposta"" name=""departamento"" class=""form-control""></select>
            </div>
            <div class=""col-lg-8"">
                <input type='text' maxlength=""20"" id=""iddescricao"" name='txtdescricao' class='form-control' />
            </div>
            <div class=""col-lg-2"">
                <select id=""lstStatus"" name=""recursoCentroCusto"" class=""form-control""></select>
            </di");
                WriteLiteral(@"v>
        </div>
        <div class=""row"" style=""margin-top:10px;"">
            <div class=""col-lg-4"" >
                <button type=""button"" id=""btnCadastrar "" onclick=""Cadastrar();"" class=""btn btn-outline-danger btn-block"">Cadastrar</button>
            </div>
            <div class=""col-lg-4"" >
                <button type=""button"" id=""btnConsultar"" onclick=""Pesquisar();"" class=""btn btn-outline-secondary btn-block""><span style=""color: black;"" class=""glyphicon glyphicon-search""></span></button>
            </div>
            <div class=""col-lg-4"" >
                <button type=""button"" onclick=""Limpar()"" class=""btn btn-outline-secondary btn-block"">Limpar</button>
            </div>
        </div>
    </div>
   
    <div class=""container"" style="" margin-top:17px;"">
        <div id=""conteudo""></div>
    </div>

    <!-- Modal -->
    <div class=""modal fade"" id=""modalmsn"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"" style=""margin-top: 136px;"">
       ");
                WriteLiteral(@" <div class=""modal-dialog"" role=""document"">
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
            </div>
        </div>
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
            BeginContext(2946, 11544, true);
            WriteLiteral(@"


</html>

<script>
    var copyData = """";
    var dadosCadastro = """";
    var idTipoRegistro = 0; 
    var idMaquina = 0;
    dadosRetorno = new Array();

    (function () {
        TipoResposta();
        ComboStatus();
        ConsultarGrid();
        $('[data-toggle=""tooltip""]').tooltip();


    })();


    function validarCampos() {
        if ($(""#lstTipoResposta"").val() == ""0"") {

            ModalAlert(""Por favor, selecione o tipo de Alternativa."");
            return false;
        }
        if ($(""#iddescricao"").val() == """") {

            ModalAlert(""Por favor, informe a Descrição."");
            return false;
        }

        if ($(""#lstStatus"").val() == ""0"") {
            ModalAlert(""Por favor, selecione o status do Tipo de Alternativa."");
            return false;
        }
        return true;
    }



    function ModalAlert(msn) {
        $(""#modalmsn"").modal('show');
        var resposta = '';
        $(""#idmsn"").empty();
        resposta = """);
            WriteLiteral(@"<div class='alert alert-danger  text-center' role='alert'>"" + msn + ""</div>"";
        $(""#idmsn"").append(resposta);
    }

    function TipoResposta() {
        $.ajax({
            url: ""TiposRespostas/TipoRespsota"",
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                var obj = data;
                $(""#lstTipoResposta"").html("""");
                if (obj.length == 0) {
                    $(""#lstTipoResposta"").prop('disabled', true);
                } else {
                    $(""#lstTipoResposta"").prop('disabled', false);
                    $.each(obj, function (i, index) {
                        $(""#lstTipoResposta"").append(
                            $('<option></option>').val(index.value).html(index.text));
                    })
                    $(""#lstTipoResposta"").prop('selectedIndex');
                }
            },
            error: function (data) {
                alert(""erro"");
                console.lo");
            WriteLiteral(@"g(data);
            }
        });


    }

    function ComboStatus() {
        $.ajax({
            url: ""Status/TipoResposta"",
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
                    $(""#lstStatus"").prop('selectedIndex');
                }
            },
            error: function (data) {
                alert(""erro"");
                console.log(data);
            }
        });
    }

    function ConsultarGrid() {

        $.ajax({
            url:");
            WriteLiteral(@" ""ConsultaGrid/TipoResposta"",
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                copyData = data;
                CarregaGrid(data)
            },
            error: function (data) {
                alert(""erro"");
                console.log(data);
            }
        });
    }


    function Pesquisar() {
        if (!validarPesquisa()) {
            return false;
        }

        var cont =0 ; 
        dadosRetorno = new Array();

        if ( $(""#lstTipoResposta"").val() != ""0"" && $(""#iddescricao"").val() == """") {
            for (var i = 0; i < copyData.length; i++) {
                ObjetoConsulta(copyData, i, cont);
                cont++;
            }
            if (dadosRetorno != null) {
                CarregaGrid(dadosRetorno);
                return;
            }
        }

        if ( $(""#lstTipoResposta"").val() == ""0"" && $(""#iddescricao"").val()  != """" ) {
            for (var i = 0; i < copyData.");
            WriteLiteral(@"length; i++) {
                if (copyData[i].nome.trim().toUpperCase() == $(""#iddescricao"").val().trim().toUpperCase()) {
                    ObjetoConsulta(copyData, i, cont);
                    cont++;
                }
            }
            if (dadosRetorno != null) {
                CarregaGrid(dadosRetorno);
                return;
            }
        }


        if ($(""#lstTipoResposta"").val() != ""0"" && $(""#iddescricao"").val() != """") {
            for (var i = 0; i < copyData.length; i++) {
                if (copyData[i].nome.trim().toUpperCase() == $(""#iddescricao"").val().trim().toUpperCase() && copyData[i].id_TipoResposta == $(""#lstTipoResposta"").val()) {
                    ObjetoConsulta(copyData, i, cont);
                    cont++;
                }
            }
            if (dadosRetorno != null) {
                CarregaGrid(dadosRetorno);
                return;
            }
        }
    }


    function ObjetoConsulta(obj, i, cont) {
        b = new");
            WriteLiteral(@" Object();
        b[""id""] = copyData[i].id;
        b[""nome""] = copyData[i].nome;
        b[""id_TipoResposta""] = copyData[i].id_TipoResposta;
        b[""status""] = copyData[i].status;
        dadosRetorno[cont] = b;
    }


    function Cadastrar() {
        if (validarCampos()) {
            if (VerificaExiste()) {
                eval('var myData = {""' + dadosCadastro + '""}');

                $.ajax({
                    url: ""Cadastrar/TipoResposta"",
                    data: JSON.stringify(myData),
                    type: 'POST',
                    traditional: true,
                    contentType: 'application/json',
                    success: function (data) {
                        dadosCadastro = """";
                        ConsultarGrid()
                        ModalAlert(data.msn);
                    }
                });
            }
        }
    }



    function validarPesquisa() {
        if ($(""#lstTipoResposta"").val() == 0 && $(""#iddescricao"").val(");
            WriteLiteral(@") == """" && $(""#lstStatus"").val() == ""0"") {

            ModalAlert(""Por favor, informe algum parametro para consutla."");
            return false;
        }
        return true;
    }

    function validarCampos() {
        if ($(""#lstTipoResposta"").val() == 0) {

            ModalAlert(""Por favor, selecione o Tipo de Alternativa."");
            return false;
        }
        dadosCadastro = ""id_tipoResposta"" + '"":""' + $(""#lstTipoResposta"").val();

        if ($(""#iddescricao"").val() == """") {
            ModalAlert(""Por favor, informe a Descrição."");
            return false;
        }
        dadosCadastro += '"",""' + ""nome"" + '"":""' + caracterSpecial($(""#iddescricao"").val());

        if ($(""#lstStatus"").val() == ""0"") {
            ModalAlert(""Por favor, selecione o status do Tipo de Alternativa."");
            return false;
        }
        dadosCadastro += '"",""' + ""status"" + '"":""' + $(""#lstStatus"").val();
        return true;
    }

    function caracterSpecial(text) {

   ");
            WriteLiteral(@"     return text.trim().replace(/&/g, ""&amp;"").replace(/>/g, ""&gt;"").replace(/</g, ""&lt;"").replace(/""/g, ""&quot;"");
    }

    function VerificaExiste() {

        for (var i = 0; i < copyData.length; i++) {

            if ($(""#iddescricao"").val().trim().toUpperCase() == copyData[i].nome.trim().toUpperCase() && $(""#lstTipoResposta"").val() == copyData[i].id_TipoResposta) {

                ModalAlert(""Não é possível efetuar o cadastro, o registro já exste."");
                return false;
            }
        }
        return true;
    }

    function Alterar(Tipo) {

        if (Tipo == 0) {
            if (!validarCampos()) {
                return false;
            }
        }
        dadosCadastro += '"",""' + ""id"" + '"":""' + idTipoRegistro;
        
        eval('var myData = {""' + dadosCadastro + '""}');

        $.ajax({
            url: ""Alterar/TipoResposta"",
            data: JSON.stringify(myData),
            type: 'POST',
            traditional: true,
            co");
            WriteLiteral(@"ntentType: 'application/json',
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

                dadosCadastro = ""codigo"" + '"":""' + copyData[i].codigo;
                dadosCadastro += '"",""' + ""nome"" + '"":""' + copyData[i].nome;
                dadosCadastro += '"",""' + ""id_tipoResposta"" + '"":""' + copyData[i].id_TipoResposta;
                if (copyData[i].status == 1) {
                    dadosCadastro += '"",""' + ""status"" + '"":""' + 2
                } else {
                    dadosCadastro += '"",""' + ""status"" + '"":""' + 1
                }
            }
        }
        Alterar(1);
    }

    function CarregaGrid(dados) {

        $(""#conteudo"").empty();
        html = "" <div style='overflow-x");
            WriteLiteral(@":auto;'>"";
        html += ""<table id='dtHorizontalExample' class='table table-striped table-bordered table-sm' cellspacing='0' width='100%'>"";
        html += ""<thead>"";
        html += ""<tr style='text-align:center;background-color: #e9ecef;'>"";
        html += ""<th style='width: 1%;'><button type='button' class='btn btn -default btn - md' onclick='ConsultarGrid()' data-toggle='tooltip' title='Atualizar Consulta' style='color:red'><span style='' class='glyphicon glyphicon-refresh'></span></button><span></span></th>"";
        html += ""<th>Descrição</th>"";
        html += ""<th>Status</th>"";
        html += ""</tr>"";
        html += ""</thead>"";
        html += ""<tbody>"";
        if (dados.length > 0) {
            for (var r = 0; r < dados.length; r++) {
                html += ""<tr style='text-align:center;'>"";
                html += ""<td></td>"";
                html += ""<td>"" + dados[r].nome + ""</td>"";
                if (dados[r].status == 1) {
                    html += ""<td  data-toggle='");
            WriteLiteral(@"tooltip' title='Ativo' ><button type='button' style='margin-left:8px;' class='btn btn-white' value="" + dados[r].id + ""  id='btn_Alterar_"" + dados[r].id + ""  ' onclick='AtivoInativo(this)'><span  style='color: green;' class='glyphicon glyphicon-ok' ></button></td>"";
                } else {
                    html += ""<td  data-toggle='tooltip' title='Inativo' ><button type='button' style='margin-left:8px;' class='btn btn-white' value="" + dados[r].id + ""  id='btn_Alterar_"" + dados[r].id + ""  ' onclick='AtivoInativo(this)'><span  style='color: red;' class='glyphicon glyphicon-ok' ></button></td>"";
                }
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
 ");
            WriteLiteral(@"   }

    function Limpar() {
        $(""#lstStatus"").val(0);
        $(""#lstTipoResposta"").val(0);
        $(""#iddescricao"").val("""");
        $(""#lstTipoResposta"").prop('disabled', false);
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
