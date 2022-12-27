
namespace WikiPolishKings
{
    class Program
    {
        static public void Main(string[] args)
        {
            SaveDocument saveDocument = new SaveDocument();
            saveDocument.SaveAsTxt();
            saveDocument.SaveAsXlsx();
        }
    }
}