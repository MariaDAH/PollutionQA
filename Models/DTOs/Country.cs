namespace PollutionQA.Models.DTOs
{
    /// <summary>
    /// </summary>
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        //Property member indicating number of meassurement for the country
        public int Count { get; set; }
    
        public override bool Equals(object obj) {

            Country target = (Country)obj;

            return (this.Code == target.Code) &&
                   (this.Name == target.Name) &&
                   (this.Count == target.Count);
        }

        public override int GetHashCode() {

            return this.Code.GetHashCode();
        }

        public override string ToString() {

            string strCountry = "[ Code = " + this.Code + " | " +
                "Name = " + this.Name + " | " +
                "Count = " + this.Count + " ] " ;

            return strCountry;
        }
    }
}