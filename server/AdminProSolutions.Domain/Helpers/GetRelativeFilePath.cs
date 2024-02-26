namespace AdminProSolutions.Domain.Helpers
{
    public class GetRelativeFilePath
    {
        public static string ReadFile(string name)
        {
            DirectoryInfo di = new DirectoryInfo("../");
            string filePath = $"{di.FullName}AdminProSolutions.Domain{Path.DirectorySeparatorChar}Seeds{Path.DirectorySeparatorChar}{name}.json";             
            return File.ReadAllText(filePath);
        }
    }
}
