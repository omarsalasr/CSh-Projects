#pragma checksum "C:\Users\omars\Google Drive\4.UIC Spring 2019\CS 341\SQL\Project 7\cta-web\Views\StationInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55dbd2017cd6dd3b82cc58454338df13d0cbb661"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(program.Pages.Views_StationInfo), @"mvc.1.0.razor-page", @"/Views/StationInfo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Views/StationInfo.cshtml", typeof(program.Pages.Views_StationInfo), null)]
namespace program.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\omars\Google Drive\4.UIC Spring 2019\CS 341\SQL\Project 7\cta-web\Views\_ViewImports.cshtml"
using program;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55dbd2017cd6dd3b82cc58454338df13d0cbb661", @"/Views/StationInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65a87352ab55936b7625448d2e9155e1658af919", @"/Views/_ViewImports.cshtml")]
    public class Views_StationInfo : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\omars\Google Drive\4.UIC Spring 2019\CS 341\SQL\Project 7\cta-web\Views\StationInfo.cshtml"
  
  ViewData["Title"] = "Station Information";

#line default
#line hidden
            BeginContext(80, 61, true);
            WriteLiteral("\n<h2>Station Information</h2>  \n\n<br />\nYour search string: \"");
            EndContext();
            BeginContext(142, 11, false);
#line 10 "C:\Users\omars\Google Drive\4.UIC Spring 2019\CS 341\SQL\Project 7\cta-web\Views\StationInfo.cshtml"
                Write(Model.Input);

#line default
#line hidden
            EndContext();
            BeginContext(153, 30, true);
            WriteLiteral("\"\n<br />\n# of stations found: ");
            EndContext();
            BeginContext(184, 23, false);
#line 12 "C:\Users\omars\Google Drive\4.UIC Spring 2019\CS 341\SQL\Project 7\cta-web\Views\StationInfo.cshtml"
                Write(Model.StationList.Count);

#line default
#line hidden
            EndContext();
            BeginContext(207, 15, true);
            WriteLiteral("\n<br />\n<br />\n");
            EndContext();
#line 15 "C:\Users\omars\Google Drive\4.UIC Spring 2019\CS 341\SQL\Project 7\cta-web\Views\StationInfo.cshtml"
  
   if (@Model.EX != null)
	 {

#line default
#line hidden
            BeginContext(255, 16, true);
            WriteLiteral("\t\t <h3>**ERROR: ");
            EndContext();
            BeginContext(272, 16, false);
#line 18 "C:\Users\omars\Google Drive\4.UIC Spring 2019\CS 341\SQL\Project 7\cta-web\Views\StationInfo.cshtml"
                 Write(Model.EX.Message);

#line default
#line hidden
            EndContext();
            BeginContext(288, 46, true);
            WriteLiteral("</h3>\n\t\t <br />\n\t\t <hr />\n\t\t <br />\n\t\t <br />\n");
            EndContext();
#line 23 "C:\Users\omars\Google Drive\4.UIC Spring 2019\CS 341\SQL\Project 7\cta-web\Views\StationInfo.cshtml"
	 }

#line default
#line hidden
            BeginContext(340, 292, true);
            WriteLiteral(@"
<table class=""table"">  
    <thead>  
        <tr>   
            <th>  
                ID
            </th>  
						<th>  
                Name
            </th>  
            <th>  
                Average Daily Ridership 
            </th>  
        </tr>  
    </thead>  
    <tbody>  
");
            EndContext();
#line 41 "C:\Users\omars\Google Drive\4.UIC Spring 2019\CS 341\SQL\Project 7\cta-web\Views\StationInfo.cshtml"
         foreach (var item in Model.StationList)  
        {  

#line default
#line hidden
            BeginContext(695, 52, true);
            WriteLiteral("            <tr>  \n                <td>  \n\t\t\t\t\t\t\t\t\t\t");
            EndContext();
            BeginContext(748, 14, false);
#line 45 "C:\Users\omars\Google Drive\4.UIC Spring 2019\CS 341\SQL\Project 7\cta-web\Views\StationInfo.cshtml"
                                   Write(item.StationID);

#line default
#line hidden
            EndContext();
            BeginContext(762, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(831, 16, false);
#line 48 "C:\Users\omars\Google Drive\4.UIC Spring 2019\CS 341\SQL\Project 7\cta-web\Views\StationInfo.cshtml"
               Write(item.StationName);

#line default
#line hidden
            EndContext();
            BeginContext(847, 59, true);
            WriteLiteral("\n                </td> \n\t\t\t\t\t\t\t\t<td>  \n                    ");
            EndContext();
            BeginContext(907, 22, false);
#line 51 "C:\Users\omars\Google Drive\4.UIC Spring 2019\CS 341\SQL\Project 7\cta-web\Views\StationInfo.cshtml"
               Write(item.AvgDailyRidership);

#line default
#line hidden
            EndContext();
            BeginContext(929, 44, true);
            WriteLiteral("\n                </td> \n            </tr>  \n");
            EndContext();
#line 54 "C:\Users\omars\Google Drive\4.UIC Spring 2019\CS 341\SQL\Project 7\cta-web\Views\StationInfo.cshtml"
        }  

#line default
#line hidden
            BeginContext(985, 26, true);
            WriteLiteral("    </tbody>  \n</table> \n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StationInfoModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<StationInfoModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<StationInfoModel>)PageContext?.ViewData;
        public StationInfoModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
