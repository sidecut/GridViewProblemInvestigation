using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.DataAccess;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        private const string EDIT_WEIGHT_COMMAND_NAME = "edit-weight";
        private readonly IPeopleDataContext _peopleDataContext;

        public _Default() : this(new FakePeopleDataContext())
        {
        }

        public _Default(IPeopleDataContext peopleDataContext)
        {
            _peopleDataContext = peopleDataContext;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = _peopleDataContext.People;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Trace.Write(string.Format("GridView1_RowEditing: {0}", e.NewEditIndex));
            e.Cancel = true;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == EDIT_WEIGHT_COMMAND_NAME)
            {
                // Update this row with some new, predictable data
                int personId = Convert.ToInt32(e.CommandArgument);
                _peopleDataContext.IncrementPersonSalary(personId);
            }
        }
    }
}
