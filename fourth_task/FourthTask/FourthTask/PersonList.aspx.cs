using FourthTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Data.Entity;

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

        protected void BlockUser_Click(object sender, EventArgs e)
        {
            ChangeStatus(true);
        }

        protected void UnblockUser_Click(object sender, EventArgs e)
        {
            ChangeStatus(false);
        }

        protected void DeleteUser_Click(object sender, EventArgs e)
        {

        }

        private void ChangeStatus(bool Blocked)
        {
            try
            {
                var _db = new PersonContext();
                foreach (GridViewRow row in PersonGridView.Rows)
                {
                    bool selected = ((CheckBox)row.FindControl("SelectCheckbox")).Checked;
                    if (selected)
                    {
                        ChangeStatusRow(row, Blocked, _db);
                    }
                }
            } catch
            {

            }
        }

        private void ChangeStatusRow(GridViewRow row, bool Blocked, PersonContext _db)
        {
            CheckBox checkBox = (CheckBox)row.FindControl("BlockedCheckbox");
            if (checkBox.Checked != Blocked)
            {
                int id = Convert.ToInt32(((Label)row.FindControl("PersonIDLabel")).Text);
                Person person = (from p in _db.Persons where p.PersonID == id select p).FirstOrDefault();
                person.Blocked = Blocked;
                _db.SaveChanges();
                checkBox.Checked = Blocked;
            }
        }
    }
}