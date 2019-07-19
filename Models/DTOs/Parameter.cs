namespace PollutionQA.Models.DTOs
{
    /// <summary>
    /// </summary>
    public class Parameter
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PreferredUnit { get; set; }
     
        public override bool Equals(object obj) {

            Parameter target = (Parameter)obj;

            return 
                   (this.Id == target.Id) &&
                   (this.Name == target.Name) &&
                   (this.Description == target.Description) &&
                   (this.PreferredUnit == target.PreferredUnit);
        }

        public override int GetHashCode(){
            return this.Name.GetHashCode();
        }

        public override string ToString() {

            string strCountry = "[ Id = " + this.Id + " | " +
                "Name = " + this.Name + " | " +
                "Preferred Unit = " + this.PreferredUnit + " | " +
                "Description = " + this.Description + " ] " ;

            return strCountry;
        }
    }
}