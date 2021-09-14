using System.Text;

namespace NameSorter.Models
{
    public class Person
    {
      
        public string LastName { get; set; }
        public string GivenName1 { get; set; }
        public string GivenName2 { get; set; }
        public string GivenName3 { get; set; }

        public StringBuilder ToStringBuilder()
        {
            StringBuilder result = new StringBuilder();
            result.Append(GivenName1 + " " + (GivenName2 != null ? GivenName2 + " " : "") + (GivenName3 != null ? GivenName3 + " " : "") + LastName);
            return result;
        }
    }
}
