namespace IIS_CD_Webhook.Services
{
    public class MSBuildProcess
    {
        readonly ComandProcessContext _context;
        public MSBuildProcess(ComandProcessContext context)
        {
            _context = context;
        }

        public void ExcecBuildCommand(string workingDir,string rootpath,string projectName="")
        {
            string buildPath = workingDir;
            string[] Commads = new string[]
               {
                    $"cd {buildPath}",
                    $"cd ",
                    $"dotnet publish ./{projectName} -o {rootpath}",
               };
            //プロジェクト名が空白でない場合ビルド対象を指定する。
            if (projectName != "")
            {
                Commads.Prepend($"dotnet publish -o {rootpath}");
            }
            else
            {
                Commads.Prepend($"dotnet publish ./{projectName} -o {rootpath}");
            }
            _context.DoCommands(Commads);
        }
    }
}
