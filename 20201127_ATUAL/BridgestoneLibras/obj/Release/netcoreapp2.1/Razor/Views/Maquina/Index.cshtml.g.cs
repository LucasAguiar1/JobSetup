#pragma checksum "C:\ProjetosManufatura\JobSetup\20201127_ATUAL\BridgestoneLibras\Views\Maquina\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ace9f4033911a2afa407f6a8bbc50884187c6f9a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Maquina_Index), @"mvc.1.0.view", @"/Views/Maquina/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Maquina/Index.cshtml", typeof(AspNetCore.Views_Maquina_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ace9f4033911a2afa407f6a8bbc50884187c6f9a", @"/Views/Maquina/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"192150bb95317d23cebc8fb46a5e75f7c3dacb90", @"/Views/_ViewImports.cshtml")]
    public class Views_Maquina_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            BeginContext(0, 171, true);
            WriteLiteral("<!DOCTYPE html>\r\n<script type=\"text/javascript\">\r\n    window.history.forward();\r\n    function loadNoBack() {\r\n        window.history.forward();\r\n    }\r\n</script>\r\n<html>\r\n");
            EndContext();
            BeginContext(171, 44, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6fd91623d31456ebf44e5ad6139ac2d", async() => {
                BeginContext(177, 31, true);
                WriteLiteral("\r\n    <title>Máquinas</title>\r\n");
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
            BeginContext(215, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(217, 6277, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2778f192991f40fbbbc233855e795bef", async() => {
                BeginContext(294, 4635, true);
                WriteLiteral(@"
    <ul class=""breadcrumb"" style=""color:red"">
        <li>Máquinas</li>
    </ul>

    <div class=""container"">
        <div class=""row text-center"" style=""margin-top:20px;"">
            <div class=""col-lg-2"">
                <label>Departamento</label>
            </div>
            <div class=""col-lg-3 text-center"">
                <label>Máquina</label>
            </div>
            <div class=""col-lg-2 text-center"">
                <label>Código PCS</label>
            </div>
            <div class=""col-lg-2 text-center"">
                <label>Descrição PCS</label>
            </div>
            <div class=""col-lg-1 text-center"">
                <label>C. TESS</label>
            </div>
            <div class=""col-lg-2 text-center"">
                <label>Status</label>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-lg-2"">
                <select id=""lstDepartamento"" name=""departamento"" class=""form-control""></select>
            </div");
                WriteLiteral(@">
            <div class=""col-lg-3"">
                <input type='text' maxlength=""50"" id=""idNomeMaquina"" name='txtNomeMaquina' class='form-control' />
            </div>
            <div class=""col-lg-2"">
                <button type=""button"" id=""btnCodigoPCS"" onclick=""ConsultaPCS()"" class=""btn btn-outline-secondary  btn-block ""> <span class=""glyphicon glyphicon-search""></span> </button>
            </div>
            <div class=""col-lg-2"">
                <input type='text' maxlength=""50"" id=""idDescricaoPCS"" name='txtDescricaoPCS' class='form-control' />
            </div>
            <div class=""col-lg-1"">
                <input type='text' maxlength=""50"" id=""idCodigoTess"" name='txtCodigoTess' class='form-control' />
            </div>

            <div class=""col-lg-2"">
                <select id=""lstStatus"" name=""recursoCentroCusto"" class=""form-control""></select>
            </div>
        </div>
        <div class=""row"" style=""margin-top:10px"">

            <div class=""col-lg-3"">
  ");
                WriteLiteral(@"              <button type=""button"" id=""btnCadastrar"" onclick=""Cadastrar();"" class=""btn btn-outline-danger btn-block "">Cadastrar</button>
            </div>
            <div class=""col-lg-3"">
                <button type=""button"" id=""btnAlterar"" onclick=""Alterar(0)"" class=""btn btn-outline-dark  btn-block "">Alterar</button>
            </div>
            <div class=""col-lg-3"">
                <button type=""button"" onclick=""Limpar()"" class=""btn btn-outline-secondary btn-block "">Limpar</button>
            </div>
            <div class=""col-lg-3"">
                <button type=""button"" id=""btnConsultar"" onclick=""Pesquisar();"" class=""btn btn-outline-secondary btn-block ""><span style=""color: black;"" class=""glyphicon glyphicon-search""></span></button>
            </div>
        </div>
    </div>


    <div class=""container"" style=""margin-top: 6px;"">
        <div id=""conteudo""></div>
    </div>

    <!-- Modal -->
    <div class=""modal fade"" id=""modalmsn"" tabindex=""-1"" role=""dialog"" aria-labelledb");
                WriteLiteral(@"y=""exampleModalLabel"" aria-hidden=""true"" style=""margin-top: 136px;"">
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
            </div>
        </div>
    </div>

    <!-- Modal -->
    <div class=""modal fade"" id=""modalPCS"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""");
                WriteLiteral(@"true"" style=""margin-top: 136px;"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"" style=""width: 120%;"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLabel"">Máquinas PCS</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
");
                EndContext();
                BeginContext(5968, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(6021, 114, true);
                WriteLiteral("                    <div id=\"gridPCS\"></div>\r\n                </div>\r\n                <div class=\"modal-footer\">\r\n");
                EndContext();
                BeginContext(6296, 191, true);
                WriteLiteral("                    <button type=\"button\" class=\"btn btn-outline-dark btn-block\" data-dismiss=\"modal\">Fechar</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
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
            BeginContext(6494, 23138, true);
            WriteLiteral(@"


</html>

<script>
    var copyData = """";
    var dadosCadastro = """";
    var idMaquina = 0;
    var copyPCS = """"; 
    var i_Pk_Maquina = 0;
    var vc_Descripcion = """"; 
    dadosRetorno = new Array();

    (function () {

        $(""#btnAlterar"").prop('disabled', true);
        ConsultarDepartamento();
        ComboStatus();
        ConsultarGrid();
        $('[data-toggle=""tooltip""]').tooltip();


    })();


    function validarCamposPesquisa() {
        if ($(""#lstDepartamento"").val() == ""0"" && $(""#idNomeMaquina"").val() == """") {
            ModalAlert(""Por favor, informe um parametro para a consulta."");
            return false;
        }
        return true;
    }

    function ConsultaPCS() {
        copyPCS = """";
        if ($(""#idDescricaoPCS"").val() == """") {
            ModalAlert(""Por favor, informar a descrição do PCS"");
            return
        }

        $.ajax({
            url: ""MaquinaPCS/Maquina?pcs="" + $(""#idDescricaoPCS"").val(),
            d");
            WriteLiteral(@"ataType: 'json',
            type: 'GET',
            success: function (data) {
                //CarregaGrid(data, 0)
                if (data.length > 0) {
                    MontaHtmlPCS(data);
                    copyPCS = data; 
                    ModalPCS();
                    
                } else {
                    ModalAlert(""Não existe nenhum registro."");

                }
            },
            error: function (data) {
                alert(""erro"");
                console.log(data);
            }
        });
    }

    function MontaHtmlPCS(dados) {
        i_Pk_Maquina = 0;
        vc_Descripcion = """";
        $(""#gridPCS"").empty();;
        html = "" <div style='overflow-x:auto'>"";
        html += ""<table id='dtHorizontalExample' class='table table-striped table-bordered table-sm' cellspacing='0' width='100%'>"";
        html += ""<thead>"";
        html += ""<tr style='text-align:center;background-color: #e9ecef;'>"";
        html += ""<th>Código</th>"";
    ");
            WriteLiteral(@"    html += ""<th>Descrição</th>"";
        html += ""<th>Selecionar</th>"";
        //html += ""<th>Remover</th>"";
        html += ""</tr>"";
        html += ""</thead>"";
        html += ""<tbody>"";
        if (dados.length > 0) {
            for (var r = 0; r < dados.length; r++) {
                html += ""<tr style='text-align:center;'>"";
                html += ""<td>"" + dados[r].i_Pk_Maquina + ""</td>"";
                html += ""<td>"" + dados[r].vc_Descripcion + ""</td>"";
                html += ""<td  data-toggle='tooltip' title='Selecionado' ><button type='button' style='margin-left:8px;' class='btn btn-white' onclick=addCodigoPCS("" + dados[r].i_Pk_Maquina  +"") ><span  style='color: gray;' class='glyphicon glyphicon-plus' ></button></td>"";
                //html += ""<td  data-toggle='tooltip' title='Exluir'><button  type='button' class='btn btn - link'><span class='	glyphicon glyphicon-trash' onclick=ExlucirPcs("" + dados[r].i_Pk_Maquina +"") style=color:red></span></button></td>"";
                html +=");
            WriteLiteral(@" ""</tr>"";
            }
        }
        else {
            html += ""<tr style='text-align:center; color:red '>"";
            html += ""<td colspan='3'> Não existe nenhum registro cadastrado. </td>"";
            html += ""</tr>"";
        }

        html += ""</tbody>"";
        html += ""</table>"";
        html += ""</div >"";
        $(""#gridPCS"").append(html);
    }
    function ModalPCS() {
        $(""#modalPCS"").modal('show');
    }


    function ModalAlert(msn) {
        $(""#modalmsn"").modal('show');
        var resposta = '';
        $(""#idmsn"").empty();
        resposta = ""<div class='alert alert-danger  text-center' role='alert'>"" + msn + ""</div>"";
        $(""#idmsn"").append(resposta);
    }


    

    //function ConsultarMaquinaspcs() {
    //    $.ajax({
    //        url: ""Maquinas/Maquina?idDepartamento="" + $(""#lstDepartamentoPCS"").val(),
    //        dataType: 'json',
    //        type: 'GET',
    //        success: function (data) {
    //            var obj = d");
            WriteLiteral(@"ata;
    //            $(""#lstMaquinasPCS"").html("""");
    //            if (obj.length == 0) {
    //                $(""#lstMaquinasPCS"").prop('disabled', true);
    //            } else {
    //                $(""#lstMaquinasPCS"").prop('disabled', false);
    //                $.each(obj, function (i, index) {
    //                    $(""#lstMaquinasPCS"").append(
    //                        $('<option></option>').val(index.value).html(index.text));
    //                })
    //                $(""#lstMaquinasPCS"").prop('selectedIndex');
    //            }
    //        },
    //        error: function (data) {
    //            alert(""erro"");
    //            console.log(data);
    //        }
    //    });
    //}


    //function ConsultarDepartamentopcs() {
    //    $.ajax({
    //        url: ""Departamento/Maquina"",
    //        dataType: 'json',
    //        type: 'GET',
    //        success: function (data) {
    //            var obj = data;
    //            $(""#");
            WriteLiteral(@"lstDepartamentoPCS"").html("""");
    //            if (obj.length == 0) {
    //                $(""#lstDepartamentoPCS"").prop('disabled', true);
    //            } else {
    //                $(""#lstDepartamentoPCS"").prop('disabled', false);
    //                $.each(obj, function (i, index) {
    //                    $(""#lstDepartamentoPCS"").append(
    //                        $('<option></option>').val(index.value).html(index.text));
    //                })
    //                $(""#lstDepartamentoPCS"").prop('selectedIndex');
    //            }
    //        },
    //        error: function (data) {
    //            alert(""erro"");
    //            console.log(data);
    //        }
    //    });
    //}

    function ConsultarDepartamento() {
        $.ajax({
            url: ""Departamento/Maquina"",
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                var obj = data;
                $(""#lstDepartamento"").html("""");
");
            WriteLiteral(@"                if (obj.length == 0) {
                    $(""#lstDepartamento"").prop('disabled', true);
                } else {
                    $(""#lstDepartamento"").prop('disabled', false);
                    $.each(obj, function (i, index) {
                        $(""#lstDepartamento"").append(
                            $('<option></option>').val(index.value).html(index.text));
                    })
                    $(""#lstDepartamento"").prop('selectedIndex');
                }
            },
            error: function (data) {
                alert(""erro"");
                console.log(data);
            }
        });
    }

    function ComboStatus() {
        $.ajax({
            url: ""Status/Maquina"",
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                var obj = data;
                $(""#lstStatus"").html("""");
                if (obj.length == 0) {
                    $(""#lstStatus"").prop('disabled', true);");
            WriteLiteral(@"
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
            url: ""ConsultaGrid/Maquina"",
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
        if (populaCampos()) {");
            WriteLiteral(@"
            eval('var myData = {""' + dadosCadastro + '""}');

            $.ajax({
                url: ""Pesquisar/Departamento"",
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

        //var cont = 0;
        //dadosRetorno = new Array();

        //if ($(""#lstDepartamento"").val() != ""0"" && $(""#idNomeMaquina"").val() == """") {
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

        //if ($(""#lstDepartamento"").val() == ""0"" && $(""#idNomeMaquina"").val() != """") {
        //    for (var i = 0; i < copyData.length; i++) {
        //        if (copyData[i].nome.trim().toUpperCase() == $(""#idNomeMaquina"").val().trim().toUpperCase()) {
        //            ObjetoConsulta(copyData, i, cont);
        //            cont++;
        //        }
        //    }
        //    if (dadosRetorno != null) {
        //        CarregaGrid(dadosRetorno, 1);
        //        return;
        //    }
        //}

        //if ($(""#lstDepartamento"").val() != ""0"" && $(""#idNomeMaquina"").val() != """") {
        //    for (var i = 0; i < copyData.length; i++) {
        //        if (copyData[i].nome.trim().toUpperCase() == $(""#idNomeMaquina"").val().trim().toUpperCase() && copyData[i].id_departamento == $(""#lstDepartamento"").val()) {
        //            ObjetoConsulta(copyData, i, cont);
        //            cont++;
 ");
            WriteLiteral(@"       //        }
        //    }
        //    if (dadosRetorno != null) {
        //        CarregaGrid(dadosRetorno, 1);
        //        return;
        //    }
        //}
    }

    function populaCampos() {
        if ($(""#lstDepartamento"").val() == ""0"") {
            ModalAlert(""Por favor, informe o Departamento."");
            return false;
        }
        dadosCadastro = ""id_departamento"" + '"":""' + $(""#lstDepartamento"").val();

        if ($(""#idNomeMaquina"").val() != """") {
            dadosCadastro += '"",""' + ""nome"" + '"":""' + $(""#idNomeMaquina"").val();
        }
        if ($(""#idDescricaoPCS"").val() != """") {
            dadosCadastro += '"",""' + ""vc_Descripcion"" + '"":""' + $(""#idDescricaoPCS"").val();
        }
        if ($(""#lstStatus"").val() != ""0"") {
            dadosCadastro += '"",""' + ""status"" + '"":""' + caracterSpecial($(""#lstStatus"").val());
        }

        return true;
    }

    function ObjetoConsulta(obj, i, cont) {

        b = new Object();
        ");
            WriteLiteral(@"b[""id""] = obj[i].id;
        b[""nome""] = obj[i].nome;
        b[""departamento""] = obj[i].departamento;
        b[""id_departamento""] = obj[i].id_departamento;
        b[""codigo""] = obj[i].codigo;
        b[""status""] = obj[i].status;
        b[""codigoTess""] = obj[i].codigoTess;
        b[""i_Pk_Maquina""] = obj[i].i_Pk_Maquina;
        b[""vc_Descripcion""] = obj[i].vc_Descripcion;

        dadosRetorno[cont] = b;
    }

    function Editar(id) {

        for (var i = 0; i < copyData.length; i++) {
            if (copyData[i].id == id.value) {
                $(""#lstStatus"").val(copyData[i].status);
                $(""#lstDepartamento"").val(copyData[i].id_departamento);
                $(""#idNomeMaquina"").val(copyData[i].nome);
                $(""#lstDepartamento"").prop('disabled', true);
                $(""#btnAlterar"").prop('disabled', false);
                $(""#btnCadastrar"").prop('disabled', true);
                $(""#idCodigoTess"").val(copyData[i].codigoTess);
                i_Pk_Maqu");
            WriteLiteral(@"ina = copyData[i].i_Pk_Maquina;
                vc_Descripcion = copyData[i].vc_Descripcion

                idMaquina = id.value;
            }
        }
    }


    function addCodigoPCS(id) {
        i_Pk_Maquina = 0;
        vc_Descripcion = """";
        for (var i = 0; i < copyPCS.length; i++) {
            if (copyPCS[i].i_Pk_Maquina == id) {
                i_Pk_Maquina =   copyPCS[i].i_Pk_Maquina;
                vc_Descripcion = copyPCS[i].vc_Descripcion;
                $(""#modalPCS"").modal('hide');
                break;
            }
        }
    }

    function ExlucirPcs(id) {
        i_Pk_Maquina = 0;
        vc_Descripcion = """";
        $(""#modalPCS"").modal('hide');
    }

    function Cadastrar() {
        if (validarCampos()) {
            if (VerificaExiste()) {
                populaObjPCS();
                eval('var myData = {""' + dadosCadastro + '""}');
                

                $.ajax({
                    url: ""Cadastrar/Maquina"",
          ");
            WriteLiteral(@"          data: JSON.stringify(myData),
                    type: 'POST',
                    traditional: true,
                    contentType: 'application/json',
                    success: function (data) {
                        dadosCadastro = """";
                        ConsultarGrid()
                        ModalAlert(data.msn);
                        copyPCS = """";
                        copyData = """";
                        //i_Pk_Maquina =0;
                        //vc_Descripcion = """" ;
                    }
                });
            }
        }
    }

    function populaObjPCS() {

        if (i_Pk_Maquina == """") {
            dadosCadastro += '"",""' + ""i_Pk_Maquina"" + '"":""' + 0;
        } else{
            dadosCadastro += '"",""' + ""i_Pk_Maquina"" + '"":""' + i_Pk_Maquina;
        }
        
        dadosCadastro += '"",""' + ""vc_Descripcion"" + '"":""' + vc_Descripcion;
    }

    function validarCampos() {
        if ($(""#lstDepartamento"").val() == 0) {

    ");
            WriteLiteral(@"        ModalAlert(""Por favor, selecione o departamento."");
            return false;
        }
        dadosCadastro = ""id_departamento"" + '"":""' + $(""#lstDepartamento"").val();

        if ($(""#idNomeMaquina"").val() == """") {
            ModalAlert(""Por favor, informe o nome da Máqina."");
            return false;
        }
        dadosCadastro += '"",""' + ""nome"" + '"":""' + caracterSpecial($(""#idNomeMaquina"").val());



        if ($(""#lstStatus"").val() == ""0"") {
            ModalAlert(""Por favor, selecione o status do departamento."");
            return false;
        }
        dadosCadastro += '"",""' + ""status"" + '"":""' + $(""#lstStatus"").val();

        dadosCadastro += '"",""' + ""codigoTess"" + '"":""' + caracterSpecial($(""#idCodigoTess"").val());
        return true;
    }

    function caracterSpecial(text) {

        return text.trim().replace(/&/g, ""&amp;"").replace(/>/g, ""&gt;"").replace(/</g, ""&lt;"").replace(/""/g, ""&quot;"");
    }

    function VerificaExiste() {

        for (var i");
            WriteLiteral(@" = 0; i < copyData.length; i++) {

            if ($(""#idNomeMaquina"").val().trim().toUpperCase() == copyData[i].nome.trim().toUpperCase() && $(""#lstDepartamento"").val() == copyData[i].id_departamento) {

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
            dadosCadastro += '"",""' + ""id"" + '"":""' + idMaquina;
            populaObjPCS();
        }

        
        eval('var myData = {""' + dadosCadastro + '""}');

        $.ajax({
            url: ""Alterar/Maquina"",
            data: JSON.stringify(myData),
            type: 'POST',
            traditional: true,
            contentType: 'application/json',
            success: function (data) {
                dadosCadastro = """";
                ConsultarGrid()
");
            WriteLiteral(@"                ModalAlert(data.msn);
                copyPCS = """";
                copyData = """";
                $(""#btnAlterar"").prop('disabled', true);
                //i_Pk_Maquina = 0;
                //vc_Descripcion = """";
            }
        });
    }

    function AtivoInativo(id) {

        dadosCadastro = """";
        for (var i = 0; i < copyData.length; i++) {
            if (copyData[i].id == id.value) {

                dadosCadastro = ""codigo"" + '"":""' + copyData[i].codigo;
                dadosCadastro += '"",""' + ""nome"" + '"":""' + copyData[i].nome;
                dadosCadastro += '"",""' + ""id_departamento"" + '"":""' + copyData[i].id_departamento;
                dadosCadastro += '"",""' + ""id"" + '"":""' + copyData[i].id;
                if (copyData[i].i_Pk_Maquina == """") {
                    dadosCadastro += '"",""' + ""i_Pk_Maquina"" + '"":""' + 0;
                } else {
                    dadosCadastro += '"",""' + ""i_Pk_Maquina"" + '"":""' + copyData[i].i_Pk_Maquina;
           ");
            WriteLiteral(@"     }
                
                dadosCadastro += '"",""' + ""vc_Descripcion"" + '"":""' + copyData[i].vc_Descripcion;
                dadosCadastro += '"",""' + ""codigoTess"" + '"":""' + copyData[i].codigoTess;

                if (copyData[i].status == 1) {
                    dadosCadastro += '"",""' + ""status"" + '"":""' + 2
                } else {
                    dadosCadastro += '"",""' + ""status"" + '"":""' + 1
                }
            }
        }
        Alterar(1);
    }

    function ExcluirPcsGRID(id) {
        dadosCadastro = """";
        var i_Pk_Maquina = 0;
        var vc_Descripcion = """";
        for (var i = 0; i < copyData.length; i++) {
            if (copyData[i].id == id) {

                dadosCadastro = ""codigo"" + '"":""' + copyData[i].codigo;
                dadosCadastro += '"",""' + ""nome"" + '"":""' + copyData[i].nome;
                dadosCadastro += '"",""' + ""id_departamento"" + '"":""' + copyData[i].id_departamento;
                dadosCadastro += '"",""' + ""id"" + '"":""' ");
            WriteLiteral(@"+ copyData[i].id;
                dadosCadastro += '"",""' + ""i_Pk_Maquina"" + '"":""' + i_Pk_Maquina;
                dadosCadastro += '"",""' + ""vc_Descripcion"" + '"":""' + vc_Descripcion;
                dadosCadastro += '"",""' + ""codigoTess"" + '"":""' + copyData[i].codigoTess;

                if (copyData[i].status == 1) {
                    dadosCadastro += '"",""' + ""status"" + '"":""' + 2
                } else {
                    dadosCadastro += '"",""' + ""status"" + '"":""' + 1
                }
            }
        }
        
        copyPCS = """";
        Alterar(1);
        
    }

    function CarregaGrid(dados, tipo) {

        $(""#conteudo"").empty();;
        html = "" <div style='overflow-x:auto'>"";
        html += ""<table id='dtHorizontalExample' class='table table-striped table-bordered table-sm' cellspacing='0' width='100%'>"";
        html += ""<thead>"";
        html += ""<tr style='text-align:center;background-color: #e9ecef;'>"";
        html += ""<th style='width: 1%;'><button type='b");
            WriteLiteral(@"utton' class='btn btn -default btn - md' onclick='ConsultarGrid()' data-toggle='tooltip' title='Atualizar Consulta' style='color:red'><span style='' class='glyphicon glyphicon-refresh'></span></button><span></span></th>"";
        html += ""<th>Departamento</th>"";
        html += ""<th>Máquina</th>"";
        html += ""<th>Código PCS</th>"";
        html += ""<th>Descrição PCS</th>"";
        html += ""<th>Código TESS</th>"";
        html += ""<th>Excluir PCS</th>"";
        html += ""<th>Status</th>"";
        html += ""<th>Editar</th>"";
        html += ""</tr>"";
        html += ""</thead>"";
        html += ""<tbody>"";
        if (dados.length > 0) {
            for (var r = 0; r < dados.length; r++) {
                html += ""<tr style='text-align:center;'>"";
                html += ""<td></td>"";
                html += ""<td>"" + dados[r].codigo + ""-"" + dados[r].departamento + ""</td>"";
                html += ""<td>"" + dados[r].nome + ""</td>"";
                if (dados[r].i_Pk_Maquina == 0) {
                ");
            WriteLiteral(@"    dados[r].i_Pk_Maquina = """";
                }
                html += ""<td>"" + dados[r].i_Pk_Maquina + ""</td>"";
                html += ""<td>"" + dados[r].vc_Descripcion + ""</td>"";
                html += ""<td>"" + dados[r].codigoTess + ""</td>"";
                if (dados[r].i_Pk_Maquina != """") {
                    html += ""<td  data-toggle='tooltip' title='Exluir'><button  type='button' class='btn btn - link'><span class='	glyphicon glyphicon-trash' onclick=ExcluirPcsGRID("" + dados[r].id + "") style=color:red></span></button></td>"";
                } else {
                    html += ""<td></td>"";
                }
                
                if (dados[r].status == 1) {
                    html += ""<td  data-toggle='tooltip' title='Ativo' ><button type='button' style='margin-left:8px;' class='btn btn-white' value="" + dados[r].id + ""  id='btn_Alterar_"" + dados[r].id + ""  ' onclick='AtivoInativo(this)'><span  style='color: green;' class='glyphicon glyphicon-ok' ></button></td>"";
            ");
            WriteLiteral(@"    } else {
                    html += ""<td  data-toggle='tooltip' title='Inativo' ><button type='button' style='margin-left:8px;' class='btn btn-white' value="" + dados[r].id + ""  id='btn_Alterar_"" + dados[r].id + ""  ' onclick='AtivoInativo(this)'><span  style='color: red;' class='glyphicon glyphicon-ok' ></button></td>"";
                }

                

                html += ""<td><button type='button' style='margin-left:8px;' class='btn btn-white' value="" + dados[r].id + ""  id='btn_Alterar_"" + dados[r].id + ""  ' onclick='Editar(this)'><span  style='color: black;' class='glyphicon glyphicon-pencil' ></button></td>"";
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
        $(""#conteudo"").app");
            WriteLiteral(@"end(html);
    }

    function Limpar() {
        $(""#lstStatus"").val(0);
        $(""#lstDepartamento"").val(0);
        $(""#idNomeMaquina"").val("""");
        $(""#idDescricaoPCS"").val("""");
        $(""#idCodigoTess"").val("""");
        $(""#lstDepartamento"").prop('disabled', false);
        $(""#btnAlterar"").prop('disabled', true);
        $(""#btnCadastrar"").prop('disabled', false);
        $(""#conteudo"").empty();
        $(""#gridPCS"").empty();
        copyPCS = """";
        copyData = """";
        i_Pk_Maquina = 0;
        vc_Descripcion = """";
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
