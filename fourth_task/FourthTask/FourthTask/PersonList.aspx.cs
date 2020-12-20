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
    }
}