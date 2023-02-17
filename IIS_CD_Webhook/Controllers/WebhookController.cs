using Microsoft.AspNetCore.Mvc;
using IIS_CD_Webhook.Services;
using System.Diagnostics;

namespace IIS_CD_Webhook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebhookController : ControllerBase
    {
       
        private readonly ILogger<WebhookController> _logger;

        public WebhookController(ILogger<WebhookController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name ="/")]
        public IActionResult Get(string t="test")
        {
            var config = new Configuration();
            if (t != config.AccessToken) throw new Exception("�g�[�N�����s���ł��B");
            using (var con = new ComandProcessContext())
            { 
                GitProcess gitProc = new GitProcess(con);
                gitProc.ExcecGitCommands(config.WorkingDir,config.CloneURL);
                MSBuildProcess buildProc = new MSBuildProcess(con);
                buildProc.ExcecBuildCommand(config.WorkingDir, config.RootPath, config.ProjectFileName);
            }
            return Ok();
        }

        [Route("/error")]
        public IActionResult HandleError() =>
                         Problem();
    }
}