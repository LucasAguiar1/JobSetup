#pragma checksum "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\Home\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23bee84f5b5fec45d76ec86298992dbcfe1a7ab3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Login), @"mvc.1.0.view", @"/Views/Home/Login.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Login.cshtml", typeof(AspNetCore.Views_Home_Login))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23bee84f5b5fec45d76ec86298992dbcfe1a7ab3", @"/Views/Home/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"192150bb95317d23cebc8fb46a5e75f7c3dacb90", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BridgestoneLibras.Models.LoginModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\Home\Login.cshtml"
  
    ViewBag.Title = "Login";

#line default
#line hidden
#line 6 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\Home\Login.cshtml"
 using (Html.BeginForm("Login", "Home", FormMethod.Post))
{
    //cria a tag do formulário
    

#line default
#line hidden
            BeginContext(182, 23, false);
#line 9 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\Home\Login.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
#line 9 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\Home\Login.cshtml"
                             // previne o ataque CSRF
    

#line default
#line hidden
            BeginContext(237, 28, false);
#line 10 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\Home\Login.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
            EndContext();
            BeginContext(269, 111, true);
            WriteLiteral("    <center>\r\n        <table style=\"align-content: center; margin-top: 60px; width: 300px\">\r\n            <tr>\r\n");
            EndContext();
            BeginContext(490, 67, true);
            WriteLiteral("            </tr>\r\n            <tr><td><label class=\"text-warning\">");
            EndContext();
            BeginContext(558, 15, false);
#line 17 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\Home\Login.cshtml"
                                           Write(ViewBag.Message);

#line default
#line hidden
            EndContext();
            BeginContext(573, 58, true);
            WriteLiteral("</label></td></tr>\r\n            <tr>\r\n                <td>");
            EndContext();
            BeginContext(632, 169, false);
#line 19 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\Home\Login.cshtml"
               Write(Html.TextBoxFor(a => a.Usuario, new { id = "Usuario", @class = "form-control", @required = "true", autofocus = "true", @placeholder = "Usuário", @autocomplete = "off" }));

#line default
#line hidden
            EndContext();
            BeginContext(801, 64, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
            EndContext();
            BeginContext(866, 150, false);
#line 22 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\Home\Login.cshtml"
               Write(Html.PasswordFor(a => a.Senha, new { @class = "form-control", @required = "true", autofocus = "true", @placeholder = "Senha", @autocomplete = "off" }));

#line default
#line hidden
            EndContext();
            BeginContext(1016, 312, true);
            WriteLiteral(@"</td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <input type=""submit"" class=""btn btn-lg btn-primary btn-block"" value=""Entrar"" />
                </td>
            </tr>
        </table>
    </center>
");
            EndContext();
#line 34 "C:\Projetos\Backup JOB Setup\20201127_FILTROS_OK2\BridgestoneLibras\Views\Home\Login.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BridgestoneLibras.Models.LoginModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
