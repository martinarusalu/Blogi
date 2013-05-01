using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Xml;
using System.Xml.Linq;

namespace Blogimootor
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            /*Avab andmebaasi. Kontrollib, kas sisestatud kasutajanimele vastab xml-is olev parool*/
            XElement x = XElement.Load(Server.MapPath(@"Admin\kasutajad.xml"));

            foreach (var c in x.Elements(Login1.UserName))
            {
                if (c.Attribute("parool").Value == Login1.Password)
                {
                    string name = c.Attribute("nimi").Value;
                    FormsAuthentication.RedirectFromLoginPage(name, Login1.RememberMeSet);
                }
            }
        }
    }
}