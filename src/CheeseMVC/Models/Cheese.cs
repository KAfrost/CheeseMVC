namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }


        public CheeseType Type { get; set; }
        public int Rating { get; set; }
        
        // its a convention to use the class name followed by Id
        public int CheeseId { get; set; }
        //is only used internally and increments eveytime a new id is created
        private static int nextId = 1;

        public Cheese(string name, string description) : this()
        {
            Name = name;
            Description = description;


        }

        // default constructor 
        public Cheese()
        {
            CheeseId = nextId;
            nextId++;

            // hardcode a type to the cheese
            // Type = CheeseType.Hard;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            return CheeseId == (obj as Cheese).CheeseId;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return CheeseId;
        }
    }
}
