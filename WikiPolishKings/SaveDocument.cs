using FastExcel;

namespace WikiPolishKings
{
    public class SaveDocument
    {
        private KingScraper kings;
        private IEnumerable<KingModel> tableOfKing { get; set; }

        private string projectDirectory;


        public SaveDocument()
        {
            kings = new KingScraper();
            tableOfKing = kings.GetKing();
            projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        }

        public void SaveAsTxt()
        {
            int i = 1;
            StreamWriter file = new StreamWriter($@"{projectDirectory}\Output\WikiPolishKings.txt"); 

            foreach (var king in tableOfKing)
            {
                file.WriteLine($"{i}. {king.Name} okres panowania od {king.BeginningOfTheReign} do {king.EndOfTheReign}.");
                i++;
            }

            file.Close();
        }
        public void SaveAsXlsx()
        {
            string excelPath= $@"{projectDirectory}\Output\Output.xlsx";
            if (File.Exists(excelPath))
            {
                File.Delete(excelPath);
            }

            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(
                new FileInfo($@"{projectDirectory}\template.xlsx"), 
                new FileInfo(excelPath)
                ))
            {
                var worksheet = new Worksheet();
                var rows = new List<Row>();
                var rowNumber = 2;

                List<Cell> heading = new List<Cell>()
                {
                    new Cell(1, "Imię władcy"),
                    new Cell(2, "Początek panowania"),
                    new Cell(3, "Koniec panowania"),
                };

                rows.Add(new Row(1, heading));

                foreach (var item in tableOfKing)
                {
                    List<Cell> cells = new List<Cell>()
                    {
                        new Cell(1, item.Name),
                        new Cell(2, item.BeginningOfTheReign),
                        new Cell(3, item.EndOfTheReign)
                    };

                    rows.Add(new Row(rowNumber, cells));
                    rowNumber++;
                }

                worksheet.Rows = rows;

                fastExcel.Write(worksheet, "sheet1");
            }
        }
    }
}
        
     
