﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mdavies9_Mission9.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;


namespace Mdavies9_Mission9.Infrastructure
{
    [HtmlTargetElement("div",Attributes = "page-buttons")]
    public class Pagination : TagHelper
    {
        // Dynamically creating links. 
        private IUrlHelperFactory uhf;
        

        public Pagination (IUrlHelperFactory temp)
        {
            uhf = temp;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        
        public ViewContext vc { get; set; }
        public PageInfo PageButtons { get; set; }
        public string PageAction { get; set; }
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");
            for (int i = 1; i <= PageButtons.TotalPages; i++ )
            {
                TagBuilder tb = new TagBuilder("a");

                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageButtons.CurrPage
                        ? PageClassSelected : PageClassNormal);

                }
                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb); 

            }
            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}
