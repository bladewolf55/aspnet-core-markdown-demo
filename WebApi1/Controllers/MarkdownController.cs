using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Markdig.Renderers;
using Markdig;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkdownController : ControllerBase
    {
        public ActionResult<string> Post([FromForm] string markdown)
        {
            string html = "";
            
            if (!String.IsNullOrWhiteSpace(markdown))
            {
                var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
                html = Markdown.ToHtml(markdown, pipeline);
            }
            return html;
        }

    }
}
