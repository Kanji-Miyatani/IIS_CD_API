namespace IIS_CD_Webhook.Services
{
    public class GitProcess
    {
        readonly ComandProcessContext _context;
        public GitProcess(ComandProcessContext context) 
        {
            _context = context;
        }
        public void ExcecGitCommands(string workingDir,string remoteUrl)
        {
            GitInitIfNotGitWorkingDir(workingDir, remoteUrl);
            GitPull(workingDir);
        }
        private void GitInitIfNotGitWorkingDir(string workingDir,string remoteUrl)
        {
            if (!Directory.Exists($"{workingDir}\\.git"))
            {
                string[] Commads = new string[] 
                {
                    $"cd {workingDir}",
                    $"git clone {remoteUrl} ."
                };
                _context.DoCommands(Commads);
            }
        }

        private void GitPull(string workingDir)
        {
            string[] Commads = new string[]
            {
                $"cd {workingDir}",
                "git pull origin master"
            };
            _context.DoCommands(Commads);
        }
    }
}
