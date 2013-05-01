using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Web.Security;

namespace Blogimootor
{
    public partial class Pealeht : System.Web.UI.Page
    {
        XmlDataSource postitusedXML = new XmlDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Server.MapPath(@"admin\postitused.xml")) && !Page.IsPostBack)
            {
                /*Avab andmebaasi, lisab postitused datalisti*/
                XDocument algneXML = XDocument.Load(Server.MapPath(@"admin\postitused.xml"));
                XDocument andmed = new XDocument(new XElement("postitused", from x in algneXML.Descendants("postitus").Reverse() select x));
                andmed.Save(Server.MapPath(@"admin\postitused.xml"));
                postitusedXML.DataFile = Server.MapPath(@"admin\postitused.xml");
                postitusedXML.DataBind();
                DataList1.DataSource = postitusedXML;
                DataList1.DataBind();
            }
        }
    }
}