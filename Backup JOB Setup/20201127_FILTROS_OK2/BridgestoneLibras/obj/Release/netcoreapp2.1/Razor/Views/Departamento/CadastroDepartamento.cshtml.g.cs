#pragma checksum "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16e70e630c02177c8ffaed26aea98520080e2bc0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Departamento_CadastroDepartamento), @"mvc.1.0.view", @"/Views/Departamento/CadastroDepartamento.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Departamento/CadastroDepartamento.cshtml", typeof(AspNetCore.Views_Departamento_CadastroDepartamento))]
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
#line 1 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\_ViewImports.cshtml"
using BridgestoneLibras;

#line default
#line hidden
#line 2 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\_ViewImports.cshtml"
using BridgestoneLibras.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16e70e630c02177c8ffaed26aea98520080e2bc0", @"/Views/Departamento/CadastroDepartamento.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"192150bb95317d23cebc8fb46a5e75f7c3dacb90", @"/Views/_ViewImports.cshtml")]
    public class Views_Departamento_CadastroDepartamento : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BridgestoneLibras.Models.DepartamentoModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
  
    ViewData["Title"] = "Cadastro de Departamento";


#line default
#line hidden
            BeginContext(115, 37, true);
            WriteLiteral("\r\n<ul class=\"breadcrumb\">\r\n    <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 152, "\"", 206, 1);
#line 9 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
WriteAttributeValue("", 159, Url.Action("ViewDepartamento", "Departamento"), 159, 47, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(207, 111, true);
            WriteLiteral(" class=\"cor-bridge\">Lista de Departamento</a></li>\r\n    <li>&nbsp;/&nbsp;Cadastro de Departamento</li>\r\n</ul>\r\n");
            EndContext();
#line 12 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
 if (@TempData["Msg"] != null)
{

#line default
#line hidden
            BeginContext(353, 62, true);
            WriteLiteral("    <div class=\"alert alert-success\" role=\"alert\">\r\n\r\n        ");
            EndContext();
            BeginContext(416, 15, false);
#line 16 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
   Write(TempData["Msg"]);

#line default
#line hidden
            EndContext();
            BeginContext(431, 16, true);
            WriteLiteral("\r\n\r\n    </div>\r\n");
            EndContext();
#line 19 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
}

#line default
#line hidden
            BeginContext(450, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(453, 69, false);
#line 21 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
Write(Html.Hidden("RedirectTo", Url.Action("Departamento", "Departamento")));

#line default
#line hidden
            EndContext();
            BeginContext(522, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 23 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
 using (Html.BeginForm("CadastroDepartamento", "Departamento", FormMethod.Post))
{


#line default
#line hidden
            BeginContext(613, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(617, 1744, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73d2aca2e9cc4adcba5ca354e2476326", async() => {
                BeginContext(637, 72, true);
                WriteLiteral("\r\n        <div style=\"margin-top:10px;padding-bottom:4px\">\r\n            ");
                EndContext();
                BeginContext(710, 39, false);
#line 28 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
       Write(Html.HiddenFor(model => model.id_depto));

#line default
#line hidden
                EndContext();
                BeginContext(749, 101, true);
                WriteLiteral("\r\n            <div class=\"form-group\">\r\n                <label>Departamento</label>\r\n                ");
                EndContext();
                BeginContext(851, 148, false);
#line 31 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
           Write(Html.EditorFor(model => model.depto, new { htmlAttributes = new { @Id = "descDepartamento", @class = "form-control", @placeholder = "Descrição" } }));

#line default
#line hidden
                EndContext();
                BeginContext(999, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(1018, 83, false);
#line 32 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
           Write(Html.ValidationMessageFor(model => model.depto, "", new { @class = "text-danger" }));

#line default
#line hidden
                EndContext();
                BeginContext(1101, 128, true);
                WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label>Código Departamento</label>\r\n                ");
                EndContext();
                BeginContext(1230, 174, false);
#line 36 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
           Write(Html.EditorFor(model => model.codigo_departamento, new { htmlAttributes = new { @Id = "codigoDepartamento", @class = "form-control", @placeholder = "Código Departamento" } }));

#line default
#line hidden
                EndContext();
                BeginContext(1404, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(1423, 97, false);
#line 37 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
           Write(Html.ValidationMessageFor(model => model.codigo_departamento, "", new { @class = "text-danger" }));

#line default
#line hidden
                EndContext();
                BeginContext(1520, 165, true);
                WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                <label>Status</label>\r\n                <select name=\"id_status\" class=\"form-control\">\r\n");
                EndContext();
#line 43 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
                     foreach (var status in ViewBag.ListaStatus)
                    {
                        

#line default
#line hidden
#line 45 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
                         if (status.IdStatus == Model.id_status)
                        {

#line default
#line hidden
                BeginContext(1867, 28, true);
                WriteLiteral("                            ");
                EndContext();
                BeginContext(1895, 70, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a1f5c1585d984fd78bccd2566959a9be", async() => {
                    BeginContext(1938, 17, false);
#line 47 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
                                                                 Write(status.DescStatus);

#line default
#line hidden
                    EndContext();
                    BeginContext(1955, 1, true);
                    WriteLiteral(" ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 47 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
                               WriteLiteral(status.IdStatus);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1965, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 48 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"

                        }
                        else
                        {

#line default
#line hidden
                BeginContext(2053, 28, true);
                WriteLiteral("                            ");
                EndContext();
                BeginContext(2081, 61, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e52200b730e4208acb751065a7323e7", async() => {
                    BeginContext(2115, 17, false);
#line 52 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
                                                        Write(status.DescStatus);

#line default
#line hidden
                    EndContext();
                    BeginContext(2132, 1, true);
                    WriteLiteral(" ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 52 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
                               WriteLiteral(status.IdStatus);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2142, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 53 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"

                        }

#line default
#line hidden
#line 54 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"
                         
                    }

#line default
#line hidden
                BeginContext(2196, 158, true);
                WriteLiteral("                </select>\r\n            </div>\r\n        </div>\r\n\r\n        <button type=\"submit\" id=\"btnSalvar\" class=\"btn btn-danger\">Salvar</button>\r\n\r\n\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2361, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 64 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\CadastroDepartamento.cshtml"



}

#line default
#line hidden
            BeginContext(2372, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BridgestoneLibras.Models.DepartamentoModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
