#pragma checksum "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90973c552972cf7acf178b8a801dd63e2847b601"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Maquina_Create), @"mvc.1.0.view", @"/Views/Maquina/Create.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Maquina/Create.cshtml", typeof(AspNetCore.Views_Maquina_Create))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90973c552972cf7acf178b8a801dd63e2847b601", @"/Views/Maquina/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"192150bb95317d23cebc8fb46a5e75f7c3dacb90", @"/Views/_ViewImports.cshtml")]
    public class Views_Maquina_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BridgestoneLibras.Models.MaquinaModel>
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
            BeginContext(46, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
  
    ViewData["Title"] = "Cadastro de Máquina";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(150, 37, true);
            WriteLiteral("\r\n<ul class=\"breadcrumb\">\r\n    <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 187, "\"", 225, 1);
#line 9 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
WriteAttributeValue("", 194, Url.Action("Index", "Maquina"), 194, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(226, 104, true);
            WriteLiteral(" class=\"cor-bridge\">Lista de Máquinas</a></li>\r\n    <li>&nbsp;/&nbsp;Cadastro de Máquina</li>\r\n</ul>\r\n\r\n");
            EndContext();
#line 13 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
 if (@TempData["Msg"] != null)
{

#line default
#line hidden
            BeginContext(365, 62, true);
            WriteLiteral("    <div class=\"alert alert-success\" role=\"alert\">\r\n\r\n        ");
            EndContext();
            BeginContext(428, 25, false);
#line 17 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
   Write(Html.Raw(TempData["Msg"]));

#line default
#line hidden
            EndContext();
            BeginContext(453, 16, true);
            WriteLiteral("\r\n\r\n    </div>\r\n");
            EndContext();
#line 20 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
}

#line default
#line hidden
            BeginContext(472, 58, true);
            WriteLiteral("\r\n<div style=\"margin-top:10px;padding-bottom:4px\">\r\n\r\n    ");
            EndContext();
            BeginContext(530, 1924, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c45c22176e9041d29ffcb49b15f2b7fd", async() => {
                BeginContext(550, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(561, 41, false);
#line 25 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
   Write(Html.HiddenFor(model => model.id_maquina));

#line default
#line hidden
                EndContext();
                BeginContext(602, 92, true);
                WriteLiteral("\r\n        <div class=\"form-group\">\r\n            <label>Nome da Máquina</label>\r\n            ");
                EndContext();
                BeginContext(695, 152, false);
#line 28 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
       Write(Html.EditorFor(model => model.nm_maquina, new { htmlAttributes = new { @Id = "nmMaquina", @class = "form-control", @placeholder = "Nome da Máquina" } }));

#line default
#line hidden
                EndContext();
                BeginContext(847, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(862, 88, false);
#line 29 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
       Write(Html.ValidationMessageFor(model => model.nm_maquina, "", new { @class = "text-danger" }));

#line default
#line hidden
                EndContext();
                BeginContext(950, 149, true);
                WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <label>Status</label>\r\n            <select name=\"id_status\" class=\"form-control\">\r\n");
                EndContext();
#line 35 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                 foreach (var status in ViewBag.ListaStatus)
                {
                    

#line default
#line hidden
#line 37 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                     if (status.IdStatus == Model.id_status)
                    {

#line default
#line hidden
                BeginContext(1265, 24, true);
                WriteLiteral("                        ");
                EndContext();
                BeginContext(1289, 70, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3d1d3b1580554dd1a578ede2dd75f7fd", async() => {
                    BeginContext(1332, 17, false);
#line 39 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                                                             Write(status.DescStatus);

#line default
#line hidden
                    EndContext();
                    BeginContext(1349, 1, true);
                    WriteLiteral(" ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 39 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
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
                BeginContext(1359, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 40 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                    }
                    else
                    {

#line default
#line hidden
                BeginContext(1433, 24, true);
                WriteLiteral("                        ");
                EndContext();
                BeginContext(1457, 62, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "05a208b11f594df4a059b340210b4684", async() => {
                    BeginContext(1490, 1, true);
                    WriteLiteral(" ");
                    EndContext();
                    BeginContext(1492, 17, false);
#line 43 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                                                     Write(status.DescStatus);

#line default
#line hidden
                    EndContext();
                    BeginContext(1509, 1, true);
                    WriteLiteral(" ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 43 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
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
                BeginContext(1519, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 44 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                    }

#line default
#line hidden
#line 44 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                     
                }

#line default
#line hidden
                BeginContext(1563, 182, true);
                WriteLiteral("            </select>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <label>Departamento</label>\r\n            <select name=\"id_departamento\" class=\"form-control\">\r\n");
                EndContext();
#line 52 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                 foreach (var departamentos in ViewBag.ListaDepartamento)
                {
                    

#line default
#line hidden
#line 54 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                     if (departamentos.id_depto == Model.id_departamento)
                    {

#line default
#line hidden
                BeginContext(1937, 16, true);
                WriteLiteral("                ");
                EndContext();
                BeginContext(1953, 116, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb95412c868b46fe97822e186225861b", async() => {
                    BeginContext(2003, 33, false);
#line 56 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                                                            Write(departamentos.codigo_departamento);

#line default
#line hidden
                    EndContext();
                    BeginContext(2036, 3, true);
                    WriteLiteral(" - ");
                    EndContext();
                    BeginContext(2040, 19, false);
#line 56 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                                                                                                 Write(departamentos.depto);

#line default
#line hidden
                    EndContext();
                    BeginContext(2059, 1, true);
                    WriteLiteral(" ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 56 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                   WriteLiteral(departamentos.id_depto);

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
                BeginContext(2069, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 57 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                    }
                    else
                    {

#line default
#line hidden
                BeginContext(2143, 24, true);
                WriteLiteral("                        ");
                EndContext();
                BeginContext(2167, 108, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6699f6fa9d3645ecbb973b1b2ca08f1c", async() => {
                    BeginContext(2207, 1, true);
                    WriteLiteral(" ");
                    EndContext();
                    BeginContext(2209, 33, false);
#line 60 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                                                            Write(departamentos.codigo_departamento);

#line default
#line hidden
                    EndContext();
                    BeginContext(2242, 3, true);
                    WriteLiteral(" - ");
                    EndContext();
                    BeginContext(2246, 19, false);
#line 60 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                                                                                                 Write(departamentos.depto);

#line default
#line hidden
                    EndContext();
                    BeginContext(2265, 1, true);
                    WriteLiteral(" ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 60 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                           WriteLiteral(departamentos.id_depto);

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
                BeginContext(2275, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 61 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                    }

#line default
#line hidden
#line 61 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Maquina\Create.cshtml"
                     
                }

#line default
#line hidden
                BeginContext(2319, 128, true);
                WriteLiteral("            </select>\r\n        </div>\r\n        <button type=\"submit\" id=\"btnSalvar\" class=\"btn btn-danger\">Salvar</button>\r\n    ");
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
            BeginContext(2454, 14, true);
            WriteLiteral("\r\n\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(2539, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BridgestoneLibras.Models.MaquinaModel> Html { get; private set; }
    }
}
#pragma warning restore 1591