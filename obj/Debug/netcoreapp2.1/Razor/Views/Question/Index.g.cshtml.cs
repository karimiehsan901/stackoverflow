#pragma checksum "E:\karshenasi\term5\c3\Views\Question\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67a6f4dd8ed11941059012ac4c8cd3790b0c1dc2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Question_Index), @"mvc.1.0.view", @"/Views/Question/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Question/Index.cshtml", typeof(AspNetCore.Views_Question_Index))]
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
#line 1 "E:\karshenasi\term5\c3\Views\_ViewImports.cshtml"
using stackoverflow;

#line default
#line hidden
#line 2 "E:\karshenasi\term5\c3\Views\_ViewImports.cshtml"
using stackoverflow.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67a6f4dd8ed11941059012ac4c8cd3790b0c1dc2", @"/Views/Question/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a34379b5d58e557c947657d396ff9df9bf882e26", @"/Views/_ViewImports.cshtml")]
    public class Views_Question_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "E:\karshenasi\term5\c3\Views\Question\Index.cshtml"
  
    Layout = "";

#line default
#line hidden
            BeginContext(25, 8, true);
            WriteLiteral("<html>\r\n");
            EndContext();
            BeginContext(33, 293, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "306c9a8fb1fe4a79b27371588ec6f0e4", async() => {
                BeginContext(39, 280, true);
                WriteLiteral(@"
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css""/>
    <link rel=""stylesheet"" href=""/css/site.css""/>
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css""/>
");
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
            BeginContext(326, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(328, 4200, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "03ce8d54374045ad952dd007a1390bfa", async() => {
                BeginContext(334, 4187, true);
                WriteLiteral(@"
<nav class=""navbar navbar-inverse"">
    <div class=""container-fluid"">
        <div class=""navbar-header"">
            <a class=""navbar-brand"" href=""/"">Stack Overflow</a>
        </div>
        <ul class=""nav navbar-nav"">
            <li class=""active""><a href=""/"">Home</a></li>
            <li><a href=""#"">Ask Question</a></li>
        </ul>
        <div class=""navbar-form navbar-left"" action=""/action_page.php"">
            <div class=""input-group"">
                <input type=""text"" class=""form-control"" placeholder=""Search"">
            </div>
        </div>
        <ul class=""nav navbar-nav navbar-right"">
            <li><a href=""/SignUp/""><span class=""glyphicon glyphicon-user""></span> Sign Up</a></li>
            <li><a href=""/Login/""><span class=""glyphicon glyphicon-log-in""></span> Login</a></li>
        </ul>
    </div>
</nav>
<div class=""col-lg-1""></div>
<div class=""col-lg-10"">
    <h1>How do I operate on a DataFrame with a Series for every column</h1><hr/>
    <div class=""col-lg-");
                WriteLiteral(@"2 center-align"">
        <span class=""fa fa-chevron-up fa-3x""></span>
        <br/>
        <div class=""col-lg-12 question-likes"">10</div>
        <br/>
        <span class=""fa fa-chevron-down fa-3x""></span>
    </div>
    <div class=""col-lg-10"">
        <div class=""col-lg-12"">
            down vote
            favorite
            6
            Objective and Motivation
            I've seen this kind of question several times over and have seen many other questions that involve some element of this. Most recently, I had to spend a bit of time explaining this concept in comments while looking for an appropriate canonical Q&A. I did not find one and so I thought I'd write one.

            This question usually arises with respect to a specific operation but equally applies to most arithmetic operations.

            How do I subtract a Series from every column in a DataFrame?
            How do I add a Series from every column in a DataFrame?
            How do I multiply a Series from ever");
                WriteLiteral(@"y column in a DataFrame?
            How do I divide a Series from every column in a DataFrame?
            The Question
            Given a Series s and DataFrame df. How do I operate on each column of df with s?

            df = pd.DataFrame(
            [[1, 2, 3], [4, 5, 6]],
            index=[0, 1],
            columns=['a', 'b', 'c']
            )

            s = pd.Series([3, 14], index=[0, 1])
            When I attempt to add them, I get all np.nan

            df + s

            a b c 0 1
            0 NaN NaN NaN NaN NaN
            1 NaN NaN NaN NaN NaN
            What I thought I should get is

            a b c
            0 4 5 6
            1 18 19 20
            <br/>
            <br/>
            <span class=""tag"">python</span>
            <span class=""tag"">pandas</span>
            <br/>
            <br/>
            <hr/>
            <div class=""comment"">possible be duplicated</div>
        </div>
    </div>
    <div class=""col-lg-12""><br/>
        <");
                WriteLiteral(@"h3>1 Answer</h3>
        <br/>
        <hr/></div>
    <div class=""col-lg-2 center-align"">
        <span class=""fa fa-chevron-up fa-3x""></span>
        <br/>
        <div class=""col-lg-12 question-likes"">-1</div>
        <br/>
        <span class=""fa fa-chevron-down fa-3x""></span>
    </div>
    <div class=""col-lg-10"">
        <div class=""col-lg-12"">
            The controller-runtime client library does not yet support subresources other than /status, so you would have to use client-go as shown in the other question.
            <br/>
            <br/>
            <hr/>
            <div class=""comment"">possible be duplicated</div>
        </div>
    </div>
    <div class=""col-lg-12"">
        <hr/>
        <h3>Your Answer</h3>
        <textarea class=""form-control"" rows=""10""></textarea>
        <button class=""form-control"">Submit</button>
    </div>
</div>
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js""></script>
<script src=""https://maxcdn.bootstrapcd");
                WriteLiteral("n.com/bootstrap/3.3.7/js/bootstrap.min.js\"></script>\r\n<script src=\"/js/site.js\"></script>\r\n");
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
            BeginContext(4528, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
