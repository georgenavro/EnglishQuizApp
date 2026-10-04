namespace English_QA.Globals
{
    public class Variables
    {
        public static string connectionString { get; } = "Data Source = " + DatabasePath;
        public static string DatabasePath { get; } =
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "EnglishQA/EnglishQADB.db";
        public static string DatabaseDirectory { get; } =
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "EnglishQA";

    }
}
