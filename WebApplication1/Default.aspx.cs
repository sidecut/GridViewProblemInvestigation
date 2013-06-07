using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Trace.Write(string.Format("GridView1_RowEditing: {0}", e.NewEditIndex));
        }

        protected void GridView1_DataBinding(object sender, EventArgs e)
        {
            Trace.Write("GridView1_DataBinding");
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ZipCode { get; set; }
    }

    public class PersonList
    {
        readonly List<Person> _people = new List<Person>(); 

        public PersonList()
        {
            _people.AddRange(GetData());
        }

        public IEnumerable<Person> GetPeople()
        {
            return _people;
        } 

        private IEnumerable<Person> GetData()
        {
            yield return new Person {FirstName = "Fred", LastName = "Flintstone", ZipCode = "10001"};
            yield return new Person {FirstName = "Wilma", LastName = "Flintstone", ZipCode = "10001"};
            yield return new Person {FirstName = "Barney", LastName = "Rubble", ZipCode = "10002"};
            yield return new Person {FirstName = "Betty", LastName = "Rubble", ZipCode = "10002"};
        }
    }
}
