#pragma checksum "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92c47820b702d78a127046037861bb36b105d826"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NotificacaoLider_Index), @"mvc.1.0.view", @"/Views/NotificacaoLider/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/NotificacaoLider/Index.cshtml", typeof(AspNetCore.Views_NotificacaoLider_Index))]
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
#line 1 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\_ViewImports.cshtml"
using BridgestoneLibras;

#line default
#line hidden
#line 2 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\_ViewImports.cshtml"
using BridgestoneLibras.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92c47820b702d78a127046037861bb36b105d826", @"/Views/NotificacaoLider/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"192150bb95317d23cebc8fb46a5e75f7c3dacb90", @"/Views/_ViewImports.cshtml")]
    public class Views_NotificacaoLider_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BridgestoneLibras.Models.NotificacaoLiderModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("rl_operador"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "rl_operador", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(68, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(158, 72, true);
            WriteLiteral("\r\n<ul class=\"breadcrumb\">\r\n    <li>Lista de Notificações</li>\r\n</ul>\r\n\r\n");
            EndContext();
#line 12 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
            BeginContext(260, 195, true);
            WriteLiteral("    <div class=\"form-control-feedback\">\r\n        <div class=\"form-row\">\r\n            <div class=\"form-group col-md-4\">\r\n                <label><strong>Operador:</strong></label>\r\n                ");
            EndContext();
            BeginContext(455, 115, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "00bbf1069eb1416e8c32e985f2188bf7", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 18 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.ListaUsuarioOperador;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(570, 147, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <input class=\"btn btn-danger\" type=\"submit\" value=\"Pesquisa\" tyle=\"text-align:right\" />\r\n    </div>\r\n");
            EndContext();
#line 23 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
}

#line default
#line hidden
            BeginContext(720, 8, true);
            WriteLiteral("<br />\r\n");
            EndContext();
#line 25 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
 if (@TempData["Msg"] != null)
{

#line default
#line hidden
            BeginContext(763, 60, true);
            WriteLiteral("    <div class=\"alert alert-success\" role=\"alert\">\r\n        ");
            EndContext();
            BeginContext(824, 25, false);
#line 28 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
   Write(Html.Raw(TempData["Msg"]));

#line default
#line hidden
            EndContext();
            BeginContext(849, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 30 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
}

#line default
#line hidden
            BeginContext(866, 122, true);
            WriteLiteral("\r\n<table class=\"table table-striped  dt-responsive nowrap\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(989, 22, false);
#line 36 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
           Write(Html.DisplayName("Id"));

#line default
#line hidden
            EndContext();
            BeginContext(1011, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1067, 28, false);
#line 39 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
           Write(Html.DisplayName("Operador"));

#line default
#line hidden
            EndContext();
            BeginContext(1095, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1151, 29, false);
#line 42 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
           Write(Html.DisplayName("Descrição"));

#line default
#line hidden
            EndContext();
            BeginContext(1180, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1236, 41, false);
#line 45 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
           Write(Html.DisplayName("Data de Leitura Líder"));

#line default
#line hidden
            EndContext();
            BeginContext(1277, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1333, 20, false);
#line 48 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
           Write(Html.DisplayName(""));

#line default
#line hidden
            EndContext();
            BeginContext(1353, 63, true);
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 53 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1465, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1526, 49, false);
#line 57 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.id_notificacao));

#line default
#line hidden
            EndContext();
            BeginContext(1575, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1643, 61, false);
#line 60 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.UsuarioOperador.nm_usuario));

#line default
#line hidden
            EndContext();
            BeginContext(1704, 3, true);
            WriteLiteral("   ");
            EndContext();
            BeginContext(1729, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1797, 58, false);
#line 63 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.ds_operador_notificacao));

#line default
#line hidden
            EndContext();
            BeginContext(1855, 5, true);
            WriteLiteral("     ");
            EndContext();
            BeginContext(1910, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1978, 51, false);
#line 66 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.dt_lider_leitura));

#line default
#line hidden
            EndContext();
            BeginContext(2029, 15, true);
            WriteLiteral("               ");
            EndContext();
            BeginContext(2100, 47, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
            EndContext();
            BeginContext(3230, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 84 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(3285, 3909, true);
            WriteLiteral(@"    </tbody>
</table>

<!-- Modal -->
<div class=""modal fade"" id=""modalDadosNotificacao"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"" style=""margin-top: 80px;"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Descrição da Mensagem ao líder</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <label id=""lbldt_lider_leitura"" style=""display:none""></label>
                    <label style=""display:block"" id=""lblid_notificacao""></label>
                    <div class=""col-lg-6"">
                        <label>Departamento</label>
                        <input type=""text"" id=""lbldepartam");
            WriteLiteral(@"ento"" readonly=""true"" class=""form-control"">
                    </div>
                    <div class=""col-lg-6"">
                        <label>Máquina</label>
                        <input type=""text"" id=""lblnm_maquina"" readonly=""true"" class=""form-control"">
                    </div>
                    <div class=""col-lg-6"">
                        <label>Máquina Parte</label>
                        <input type=""text"" id=""lblds_maquina_parte"" readonly=""true"" class=""form-control"">
                    </div>
                    <div class=""col-lg-6"">
                        <label>Formulário</label>
                        <input type=""text"" id=""lblds_nome"" readonly=""true"" class=""form-control"">
                    </div>

                </div>
                <div class=""form-group"">
                    <label>Mensagem do Operador</label> <br />
                    <textarea class=""form-control"" name=""mensagemOperador"" readonly=""true"" id=""mensagemOperador"" cols=""90"" rows=""5""></textarea>");
            WriteLiteral(@"
                </div>

                <div class=""form-group"">
                    <label>Mensagem do Líder</label> <br />
                    <textarea name=""mensagemLider"" class=""form-control"" id=""mensagemLider"" cols=""90"" rows=""5""></textarea>
                </div>

            </div>
            <div class=""modal-footer"">
                <button type=""button"" id=""btnEnviarNotificacao"" class=""btn btn-danger"" onclick=""EnviaNotificacaoLider()"" data-dismiss=""modal"" style=""margin:auto; "">Enviar</button>
            </div>
        </div>
    </div>
</div>


<script>
    function AbrirNotificacao(id_notifica, nm_maquina, ds_maquina_parte, ds_nome, codigo_departamento, depto, desc_operador, ds_lider_notificacao, dt_lider_leitura) {
          $(""#modalDadosNotificacao"").modal('show');

          //POPULANDO OS CAMPOS DDA MODAL.
          $(""#lblid_notificacao"").val(id_notifica);
          $(""#lbldepartamento"").val(codigo_departamento + "" - "" + depto);
          $(""#lblnm_maquina"").val(nm_m");
            WriteLiteral(@"aquina);
          $(""#lblds_maquina_parte"").val(ds_maquina_parte);
          $(""#lblds_nome"").val(ds_nome);
          $(""#mensagemOperador"").val(desc_operador);
          $(""#mensagemLider"").val(ds_lider_notificacao);

          $('#lbldt_lider_leitura').val(dt_lider_leitura);

        //REGRA PARA HABILITAR/DESABILITAR A EDIÇÃO DO CAMPO DA MENSAGEM DO LIDER.
        if ($('#lbldt_lider_leitura').val() != null && $('#lbldt_lider_leitura').val() != '') {
            $(""#mensagemLider"").prop(""readonly"", ""true"");
            document.getElementById(""btnEnviarNotificacao"").disabled = true;
        } else {
            document.getElementById(""btnEnviarNotificacao"").disabled = false;
            $(""#mensagemLider"").removeAttr('readonly');
            // ATUALIZA A DATA DE LEITURA DO LIDER.
            var link = '");
            EndContext();
            BeginContext(7195, 58, false);
#line 162 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
                   Write(Url.Action("AtualizaDataLeituraLider", "NotificacaoLider"));

#line default
#line hidden
            EndContext();
            BeginContext(7253, 514, true);
            WriteLiteral(@"';
            var dado = { id_notificacao: id_notifica };

            $.ajax({
                  url: link,
                  data: JSON.stringify(dado),
                      type: 'POST',
                      traditional: true,
                      contentType: 'application/json',
                      success: function (data) {
                      }
            });
        }

    }

    function EnviaNotificacaoLider() {

        // Envia a notificação do lider
        var link = '");
            EndContext();
            BeginContext(7768, 55, false);
#line 181 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
               Write(Url.Action("EnviaNotificacaoLider", "NotificacaoLider"));

#line default
#line hidden
            EndContext();
            BeginContext(7823, 465, true);
            WriteLiteral(@"';
        var dado = {
            id_notificacao: $('#lblid_notificacao').val(),
            ds_lider_notificacao: $('#mensagemLider').val()
        };

          $.ajax({
              url: link,
              data: JSON.stringify(dado),
                  type: 'POST',
                  traditional: true,
                  contentType: 'application/json',
                  success: function (data) {
                      window.location.href = '");
            EndContext();
            BeginContext(8289, 39, false);
#line 194 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\NotificacaoLider\Index.cshtml"
                                         Write(Url.Action("Index", "NotificacaoLider"));

#line default
#line hidden
            EndContext();
            BeginContext(8328, 120, true);
            WriteLiteral("\';\r\n                  }\r\n          });\r\n\r\n          $(\"#modalDadosNotificacao\").modal(\'hide\');\r\n\r\n      }\r\n\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BridgestoneLibras.Models.NotificacaoLiderModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
