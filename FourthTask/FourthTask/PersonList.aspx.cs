using FourthTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace FourthTask
{
    public partial class PersonList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IQueryable<Person> GetPersons()
        {
            var _db = new PersonContext();
            IQueryable<Person> query = _db.Persons;
            return query;
        }

        protected void ChckedChanged(object sender, EventArgs e)
        {
            CheckBox CheckColumn = (PersonGridView.HeaderRow.Cells[0].FindControl("SelectCheckboxAll") as CheckBox);

            foreach (GridViewRow row in PersonGridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox CheckRow = (row.Cells[0].FindControl("SelectCheckbox") as CheckBox);
                    CheckRow.Checked = CheckColumn.Checked;
                }
            }
        }
    }
}