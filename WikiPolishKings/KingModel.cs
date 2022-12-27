

namespace WikiPolishKings
{
    public class KingModel
    {
        public KingModel(string Name, string BiginningOfTheReign, string EndOfTheReign)
        {
            this.Name = Name; 
            this.BeginningOfTheReign = BiginningOfTheReign;
            this.EndOfTheReign = EndOfTheReign;
        }
        public string Name { get; set; }
        public string BeginningOfTheReign { get; set; }
        public string EndOfTheReign { get; set; }

    }
}
