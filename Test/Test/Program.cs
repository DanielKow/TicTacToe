using LibGit2Sharp;

var repoUrl = "https://gitea.modelingevolution.com/ModelingEvolution/Tools.git";
var dirPath = "/home/danielk/testrepo/test";
var options = new CloneOptions()
{
    CredentialsProvider = (_, _, _) => new UsernamePasswordCredentials
    {
        Username = "daniel.kowalski@modelingevolution.com",
        Password = "D@nK0w18git",
    }
};

//var repo = Repository.Clone(repoUrl, dirPath, options);

var x = Directory.EnumerateFiles(dirPath, "*.csproj", SearchOption.AllDirectories);



Console.WriteLine(Path.DirectorySeparatorChar);