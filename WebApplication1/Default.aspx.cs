using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var people = GetData();
            GridView1.DataSource = people;
            GridView1.DataBind();
        }

        private IEnumerable<Person> GetData()
        {
            yield return new Person {FirstName = "Fred", LastName = "Flintstone", ZipCode = "10001"};
            yield return new Person {FirstName = "Wilma", LastName = "Flintstone", ZipCode = "10001"};
            yield return new Person {FirstName = "Barney", LastName = "Rubble", ZipCode = "10002"};
            yield return new Person {FirstName = "Betty", LastName = "Rubble", ZipCode = "10002"};
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ZipCode { get; set; }
    }
}
