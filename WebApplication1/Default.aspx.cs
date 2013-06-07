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

        protected override void DataBindChildren()
        {
            base.DataBindChildren();

            if (!IsPostBack)
            {
                var people = GetData();
                GridView1.DataSource = people;
                GridView1.DataBind();
            }
        }

        private static IEnumerable<Person> GetData()
        {
            yield return new Person {FirstName = "Fred", LastName = "Flintstone", ZipCode = "10001"};
            yield return new Person {FirstName = "Wilma", LastName = "Flintstone", ZipCode = "10001"};
            yield return new Person {FirstName = "Barney", LastName = "Rubble", ZipCode = "10002"};
            yield return new Person {FirstName = "Betty", LastName = "Rubble", ZipCode = "10002"};
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Trace.Write(string.Format("GridView1_RowEditing: {0}", e.NewEditIndex));
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ZipCode { get; set; }
    }
}
