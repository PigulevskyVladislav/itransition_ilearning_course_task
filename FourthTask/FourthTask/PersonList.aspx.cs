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
        private PersonContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.db = new PersonContext();
        }

        public IQueryable<Person> GetPersons()
        {
            this.db = new PersonContext();
            IQueryable<Person> query = this.db.Persons;
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
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void UnblockUser_Click(object sender, EventArgs e)
        {
            ChangeStatus(false);
        }

        protected void DeleteUser_Click(object sender, EventArgs e)
        {
            DeleteUserRows();
        }

        private void DeleteUserRows()
        {
            ForEachSelectedRow(row => DeleteUserRow(row));

        }

        private void ChangeStatus(bool Blocked)
        {
            ForEachSelectedRow(row => ChangeStatusRow(row, Blocked));
        }

        private void ForEachSelectedRow(Action<GridViewRow> action)
        {
            try
            {
                foreach (GridViewRow row in PersonGridView.Rows)
                {
                    bool selected = ((CheckBox)row.FindControl("SelectCheckbox")).Checked;
                    if (selected)
                    {
                        action(row);
                    }
                }
            }
            catch
            {
                //TODO: 
            }
        }

        private void DeleteUserRow(GridViewRow row)
        {
            int id = Convert.ToInt32(((Label)row.FindControl("PersonIDLabel")).Text);
            Person person = new Person() { PersonID = id };
            db.Persons.Attach(person);
            db.Persons.Remove(person);
            db.SaveChanges();
            PersonGridView.DataBind();
        }

        private void ChangeStatusRow(GridViewRow row, bool Blocked)
        {
            CheckBox checkBox = (CheckBox)row.FindControl("BlockedCheckbox");
            if (checkBox.Checked != Blocked)
            {
                int id = Convert.ToInt32(((Label)row.FindControl("PersonIDLabel")).Text);
                Person person = (from p in this.db.Persons where p.PersonID == id select p).FirstOrDefault();
                person.Blocked = Blocked;
                db.SaveChanges();
                PersonGridView.DataBind();
            }
        }
    }
}