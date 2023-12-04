using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interview_Practice.AjaxPrograms
{
    public partial class LiveTimer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToLongDateString();

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text=DateTime.Now.ToString();
        }
    }
}