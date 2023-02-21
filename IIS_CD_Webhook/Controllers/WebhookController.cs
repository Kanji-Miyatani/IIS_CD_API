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
            try
            {
                var config = new Configuration();
                if (t != config.AccessToken) throw new Exception("トークンが不正です。");
                using (var con = new ComandProcessContext())
                { 
                    GitProcess gitProc = new GitProcess(con);
                    gitProc.ExcecGitCommands(config.WorkingDir,config.CloneURL);
                    _logger.LogTrace("Git Cmmands Excected");
                    MSBuildProcess buildProc = new MSBuildProcess(con);
                    _logger.LogTrace("Git Cmmands Excected");
                    buildProc.ExcecBuildCommand(config.WorkingDir, config.RootPath, config.ProjectFileName);
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e,"Error");
                throw;
            }
            return Ok();
        }

        [Route("/error")]
        public IActionResult HandleError() =>
                         Problem();
    }
}