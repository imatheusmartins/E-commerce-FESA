#pragma checksum "Z:\2024\E-commerce-FESA\EcommerceLicenca\EcommerceLicenca\Views\Fornecedor\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5765f993e0c54c1a9904bae2065510f68e5e17da1b2e90a8350157c79ce0c754"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Fornecedor_Index), @"mvc.1.0.view", @"/Views/Fornecedor/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "Z:\2024\E-commerce-FESA\EcommerceLicenca\EcommerceLicenca\Views\_ViewImports.cshtml"
using EcommerceLicenca;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "Z:\2024\E-commerce-FESA\EcommerceLicenca\EcommerceLicenca\Views\_ViewImports.cshtml"
using EcommerceLicenca.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"5765f993e0c54c1a9904bae2065510f68e5e17da1b2e90a8350157c79ce0c754", @"/Views/Fornecedor/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"130893a23e00e6fb7e32857639a9bc1df9a25a6d39583e794b0ecdc30c44988f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Fornecedor_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<FornecedorViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<a href=""/fornecedor/Create"" class=""btn btn-success"">Novo fornecedor</a>
<br />
<br />
<table class=""table table-striped table-responsive"">
    <tr>
        <th>Ações</th>
        <th>Id</th>
        <th>Nome</th>
        <th>CNPJ</th>
        <th>Email</th>
    </tr>

");
#nullable restore
#line 15 "Z:\2024\E-commerce-FESA\EcommerceLicenca\EcommerceLicenca\Views\Fornecedor\Index.cshtml"
     foreach (var fornecedor in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 415, "\"", 456, 2);
            WriteAttributeValue("", 422, "/fornecedor/edit?id=", 422, 20, true);
#nullable restore
#line 19 "Z:\2024\E-commerce-FESA\EcommerceLicenca\EcommerceLicenca\Views\Fornecedor\Index.cshtml"
WriteAttributeValue("", 442, fornecedor.Id, 442, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">✍🏻</a>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 485, "\"", 535, 3);
            WriteAttributeValue("", 492, "javascript:apagarFornecedor(", 492, 28, true);
#nullable restore
#line 20 "Z:\2024\E-commerce-FESA\EcommerceLicenca\EcommerceLicenca\Views\Fornecedor\Index.cshtml"
WriteAttributeValue("", 520, fornecedor.Id, 520, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 534, ")", 534, 1, true);
            EndWriteAttribute();
            WriteLiteral(">💣</a>\r\n            </td>\r\n            <td>");
#nullable restore
#line 22 "Z:\2024\E-commerce-FESA\EcommerceLicenca\EcommerceLicenca\Views\Fornecedor\Index.cshtml"
           Write(fornecedor.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 23 "Z:\2024\E-commerce-FESA\EcommerceLicenca\EcommerceLicenca\Views\Fornecedor\Index.cshtml"
           Write(fornecedor.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 24 "Z:\2024\E-commerce-FESA\EcommerceLicenca\EcommerceLicenca\Views\Fornecedor\Index.cshtml"
           Write(fornecedor.Cnpj);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 25 "Z:\2024\E-commerce-FESA\EcommerceLicenca\EcommerceLicenca\Views\Fornecedor\Index.cshtml"
           Write(fornecedor.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 27 "Z:\2024\E-commerce-FESA\EcommerceLicenca\EcommerceLicenca\Views\Fornecedor\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<FornecedorViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
