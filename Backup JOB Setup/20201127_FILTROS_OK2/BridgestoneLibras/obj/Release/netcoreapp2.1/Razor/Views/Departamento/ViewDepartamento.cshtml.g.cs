#pragma checksum "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aa8d896c1997665b144dfe951017b38c6e82d846"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Departamento_ViewDepartamento), @"mvc.1.0.view", @"/Views/Departamento/ViewDepartamento.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Departamento/ViewDepartamento.cshtml", typeof(AspNetCore.Views_Departamento_ViewDepartamento))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa8d896c1997665b144dfe951017b38c6e82d846", @"/Views/Departamento/ViewDepartamento.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"192150bb95317d23cebc8fb46a5e75f7c3dacb90", @"/Views/_ViewImports.cshtml")]
    public class Views_Departamento_ViewDepartamento : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BridgestoneLibras.Models.DepartamentoModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CadastroDepartamento", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/editar.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("15"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("15"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(57, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
  
    ViewData["Title"] = "ViewDepartamento";

#line default
#line hidden
            BeginContext(111, 39, true);
            WriteLiteral("\r\n\r\n<ul class=\"breadcrumb\">\r\n    <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 150, "\"", 200, 1);
#line 9 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
WriteAttributeValue("", 157, Url.Action("Departamento", "Departamento"), 157, 43, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(201, 120, true);
            WriteLiteral(" class=\"cor-bridge\">Quadro de Departamento</a></li>\r\n    <li>&nbsp;/&nbsp;Lista de Departamento</li>\r\n</ul>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(321, 125, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fa8f8b365384d1aadb1b49de99c2c5a", async() => {
                BeginContext(381, 61, true);
                WriteLiteral("\r\n        <i class=\"glyphicon glyphicon-plus\"></i> Novo\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(446, 10, true);
            WriteLiteral("\r\n</p>\r\n\r\n");
            EndContext();
#line 19 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
 if (@TempData["Msg"] != null)
{

#line default
#line hidden
            BeginContext(491, 52, true);
            WriteLiteral("    <div class=\"alert alert-success\" role=\"alert\">\r\n");
            EndContext();
#line 22 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
         if (@TempData["Msg"] != null)
        {
            

#line default
#line hidden
            BeginContext(607, 15, false);
#line 24 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
       Write(TempData["Msg"]);

#line default
#line hidden
            EndContext();
#line 24 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
                            
        }

#line default
#line hidden
            BeginContext(635, 12, true);
            WriteLiteral("    </div>\r\n");
            EndContext();
#line 27 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
}

#line default
#line hidden
            BeginContext(650, 120, true);
            WriteLiteral("<table class=\"table table-striped  dt-responsive nowrap\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(771, 22, false);
#line 32 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
           Write(Html.DisplayName("Id"));

#line default
#line hidden
            EndContext();
            BeginContext(793, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(849, 26, false);
#line 35 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
           Write(Html.DisplayName("Código"));

#line default
#line hidden
            EndContext();
            BeginContext(875, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(931, 32, false);
#line 38 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
           Write(Html.DisplayName("Departamento"));

#line default
#line hidden
            EndContext();
            BeginContext(963, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1019, 20, false);
#line 41 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
           Write(Html.DisplayName(""));

#line default
#line hidden
            EndContext();
            BeginContext(1039, 63, true);
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 46 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1151, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1212, 43, false);
#line 50 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
               Write(Html.DisplayFor(modelItem => item.id_depto));

#line default
#line hidden
            EndContext();
            BeginContext(1255, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1323, 54, false);
#line 53 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
               Write(Html.DisplayFor(modelItem => item.codigo_departamento));

#line default
#line hidden
            EndContext();
            BeginContext(1377, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1445, 40, false);
#line 56 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
               Write(Html.DisplayFor(modelItem => item.depto));

#line default
#line hidden
            EndContext();
            BeginContext(1485, 69, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1554, "\"", 1666, 1);
#line 59 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
WriteAttributeValue("", 1561, Url.Action("CadastroDepartamento", "Departamento",new { id = item.id_depto, @class = "btn btn-primary"}), 1561, 105, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1667, 27, true);
            WriteLiteral(">\r\n                        ");
            EndContext();
            BeginContext(1694, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8b1f86aa3b5a46e98dcafe6b5624c22e", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1750, 70, true);
            WriteLiteral("\r\n                    </a>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 64 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\Departamento\ViewDepartamento.cshtml"
        }

#line default
#line hidden
            BeginContext(1831, 30, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BridgestoneLibras.Models.DepartamentoModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591