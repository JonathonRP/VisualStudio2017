using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows;

namespace WebDashboard
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( Request.QueryString["Iframe"] == "True" )
            {
                nav.Visible = false;
                Controls.Remove(nav);

                Controls.Clear();

                Controls.Add(MasterStart);

                Controls.Add(MainContent);
            }
        }
    }
}