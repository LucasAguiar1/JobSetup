#pragma checksum "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "faa9055e7dd66344cb7e9a3ee525a619202cfe66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MaquinaParte_MaquinaParte), @"mvc.1.0.view", @"/Views/MaquinaParte/MaquinaParte.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MaquinaParte/MaquinaParte.cshtml", typeof(AspNetCore.Views_MaquinaParte_MaquinaParte))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"faa9055e7dd66344cb7e9a3ee525a619202cfe66", @"/Views/MaquinaParte/MaquinaParte.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"192150bb95317d23cebc8fb46a5e75f7c3dacb90", @"/Views/_ViewImports.cshtml")]
    public class Views_MaquinaParte_MaquinaParte : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BridgestoneLibras.Models.MaquinaParteModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml"
  
    ViewData["Title"] = "Quadro de Parte das Máquinas";
    Layout = "~/Views/Shared/_Layout.cshtml";
    int cont = 0;

#line default
#line hidden
            BeginContext(187, 37, true);
            WriteLiteral("\r\n<ul class=\"breadcrumb\">\r\n    <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 224, "\"", 274, 1);
#line 9 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml"
WriteAttributeValue("", 231, Url.Action("Departamento", "Departamento"), 231, 43, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(275, 78, true);
            WriteLiteral(" class=\"cor-bridge\">Quadro de Departamento &nbsp;/&nbsp; </a></li>\r\n    <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 353, "\"", 398, 1);
#line 10 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml"
WriteAttributeValue("", 360, Url.Action("Maquina", "Departamento"), 360, 38, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(399, 109, true);
            WriteLiteral(" class=\"cor-bridge\">Quadro de Máquina </a></li>\r\n    <li>&nbsp;/&nbsp;Quadro de Parte Máquina</li>\r\n</ul>\r\n\r\n");
            EndContext();
#line 14 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml"
 using (Html.BeginForm("MaquinaParte", "MaquinaParte", FormMethod.Post))
{

#line default
#line hidden
            BeginContext(585, 46, true);
            WriteLiteral("<div class=\"container table table-bordered\">\r\n");
            EndContext();
#line 17 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml"
      
        int quantidade = Model.Count / 3;
    

#line default
#line hidden
            BeginContext(689, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 21 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml"
     if (Model.Count > 0)
    {

#line default
#line hidden
            BeginContext(725, 125, true);
            WriteLiteral("        <div>\r\n            <h1 style=\"text-align:center\">Clique na parte da máquina que deseja acessar</h1>\r\n        </div>\r\n");
            EndContext();
#line 26 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(874, 116, true);
            WriteLiteral("        <div>\r\n            <h1 style=\"text-align:center\">Não foi encontrado parte da máquina.</h1>\r\n        </div>\r\n");
            EndContext();
#line 32 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml"
    }

#line default
#line hidden
            BeginContext(997, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 34 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml"
     for (int j = 0; j <= quantidade; j++)
    {

#line default
#line hidden
            BeginContext(1050, 28, true);
            WriteLiteral("        <div class=\"row \">\r\n");
            EndContext();
#line 37 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml"
             for (int i = 0; i < 4; i++)
            {
                if (cont <= Model.Count - 1)
                {

#line default
#line hidden
            BeginContext(1200, 314, true);
            WriteLiteral(@"                    <div class=""col-lg-3 text-center"" style=""margin-top:21px;"">
                        <button type=""button""
                                onclick=""selecionarSpec(this)""
                                style=""width: 100%;  height:155px; padding: 14px 20px;font-size:22px;border-radius: 10px;""");
            EndContext();
            BeginWriteAttribute("id", "\r\n                                id=\"", 1514, "\"", 1611, 1);
#line 45 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml"
WriteAttributeValue("", 1552, Html.DisplayFor(modelItem => Model[cont].id_maquina_parte), 1552, 59, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1612, 91, true);
            WriteLiteral("\r\n                                class=\"btn btn-danger\">\r\n                                ");
            EndContext();
            BeginContext(1704, 58, false);
#line 47 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml"
                           Write(Html.DisplayFor(modelItem => Model[cont].ds_maquina_parte));

#line default
#line hidden
            EndContext();
            BeginContext(1762, 65, true);
            WriteLiteral("\r\n                        </button>\r\n                    </div>\r\n");
            EndContext();
#line 50 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml"
                    cont++;
                }
            }

#line default
#line hidden
            BeginContext(1890, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 55 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml"
    }

#line default
#line hidden
            BeginContext(1915, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
            BeginContext(1925, 96, true);
            WriteLiteral("    <script>\r\n        function selecionarSpec(id) {\r\n            return window.location.href = \'");
            EndContext();
            BeginContext(2022, 38, false);
#line 60 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml"
                                      Write(Url.Action("Formulario", "Formulario"));

#line default
#line hidden
            EndContext();
            BeginContext(2060, 54, true);
            WriteLiteral("?idMaquinaParte=\' + id.id;\r\n        }\r\n    </script>\r\n");
            EndContext();
#line 63 "C:\Users\deusvinicius\Desktop\20201127_FILTROS_OK\BridgestoneLibras\Views\MaquinaParte\MaquinaParte.cshtml"
}

#line default
#line hidden
            BeginContext(2117, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BridgestoneLibras.Models.MaquinaParteModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591