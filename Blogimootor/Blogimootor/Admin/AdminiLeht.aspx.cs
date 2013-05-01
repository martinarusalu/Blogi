using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace Blogimootor.Admin
{
    public partial class AdminiLeht : System.Web.UI.Page
    {
        XmlDataSource andmedXML = new XmlDataSource();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Server.MapPath(@"postitused.xml")) && !Page.IsPostBack)
            {
                loadListbox();
            }

        }
        private void loadListbox()
        {
            /*Täidab/värskendab postituste listboxi*/
            andmedXML.DataFile = Server.MapPath(@"postitused.xml");
            andmedXML.DataBind();
            ListBox1.DataSource = "";
            ListBox1.DataBind();
            ListBox1.Items.Clear();
            ListBox1.DataSource = andmedXML;
            ListBox1.DataTextField = "pealkiri";
            ListBox1.DataValueField = "id";
            ListBox1.DataBind();
        }

        protected void lisaBtn_Click(object sender, EventArgs e)
        {
            /*Kui pealkiri ja sisu olemas, tekitab uue postituse*/
            if (PealkiriTb.Text.Trim() == "" || TekstTb.Text.Trim() == "")
            {
                VigaLbl.Text = "Sisesta nii pealkiri kui ka sisu!";
            }
            else { writeXML(); }
            loadListbox();
        }

        private void writeXML()
        {
            /*kontrollib, kas andmebaas on olmas. Kui ei ole, siis tekitab selle*/
            if (!System.IO.File.Exists(Server.MapPath(@"postitused.xml")))
            {
                XmlWriter kirjutaXML = XmlWriter.Create(Server.MapPath(@"postitused.xml"));
                kirjutaXML.WriteStartDocument();
                kirjutaXML.WriteStartElement("postitused");

                kirjutaXML.WriteStartElement("postitus");
                kirjutaXML.WriteAttributeString("id", "1");
                kirjutaXML.WriteAttributeString("pealkiri", PealkiriTb.Text);
                kirjutaXML.WriteAttributeString("tekst", TekstTb.Text);
                kirjutaXML.WriteAttributeString("aeg", DateTime.Now.ToString("H:mm dd-MM-yyyy"));

                kirjutaXML.WriteEndElement();
                kirjutaXML.WriteEndDocument();
                kirjutaXML.Close();
            }
            else
            {
                /*Lisab andmebaasi uue postituse*/
                XmlTextReader lugeja = new XmlTextReader(Server.MapPath(@"postitused.xml"));
                XmlDocument dokument = new XmlDocument();
                dokument.Load(lugeja);
                lugeja.Close();
                XmlElement root = dokument.DocumentElement;
                XmlElement uusPostitus = dokument.CreateElement("postitus");
                int? max = null;
                foreach (XmlElement n in dokument.SelectNodes("/postitused/postitus"))
                {
                    int i = int.Parse(n.GetAttribute("id"));
                    if (max == null || i > max) { max = i; }
                }
                if (dokument.SelectNodes("/postitused/postitus") == null) { max = 0; }

                uusPostitus.SetAttribute("id", (max+1).ToString());
                uusPostitus.SetAttribute("pealkiri", PealkiriTb.Text);
                uusPostitus.SetAttribute("tekst", TekstTb.Text);
                uusPostitus.SetAttribute("aeg", DateTime.Now.ToString("H:mm dd-MM-yyyy"));

                root.InsertAfter(uusPostitus, root.LastChild);
                dokument.Save(Server.MapPath(@"postitused.xml"));
            }
        }

        protected void muudaBtn_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedItem != null)
            {
                if (PealkiriTb.Text.Trim() == "" || TekstTb.Text.Trim() == "")
                {
                    VigaLbl.Text = "Sisesta nii pealkiri kui ka sisu!";
                }
                else
                {
                    /*vahetab vanad postituse andmed uute vastu*/
                    XmlTextReader lugeja = new XmlTextReader(Server.MapPath(@"postitused.xml"));
                    XmlDocument dokument = new XmlDocument();
                    dokument.Load(lugeja);
                    lugeja.Close();
                    XmlNode vana;
                    XmlElement root = dokument.DocumentElement;
                    vana = root.SelectSingleNode("descendant::postitus[@id='" + ListBox1.SelectedItem.Value + "']");

                    XmlElement uusPostitus = dokument.CreateElement("postitus");
                    uusPostitus.SetAttribute("id", (ListBox1.SelectedValue));
                    uusPostitus.SetAttribute("pealkiri", PealkiriTb.Text);
                    uusPostitus.SetAttribute("tekst", TekstTb.Text);
                    uusPostitus.SetAttribute("aeg", DateTime.Now.ToString("H:mm dd-MM-yyyy"));

                    if (vana != null)
                    {
                        root.ReplaceChild(uusPostitus, vana);
                        dokument.Save(Server.MapPath(@"postitused.xml"));
                        loadListbox();
                    }
                }
            }
            else
            {
                VigaLbl.Text = "Vali postitus.";
            }
        }

        protected void kustutaBtn_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedItem != null)
            {
                XmlTextReader lugeja = new XmlTextReader(Server.MapPath(@"postitused.xml"));
                XmlDocument dokument = new XmlDocument();
                dokument.Load(lugeja);
                lugeja.Close();
                XmlNode vana;
                XmlElement root = dokument.DocumentElement;
                vana = root.SelectSingleNode("descendant::postitus[@id='" + ListBox1.SelectedItem.Value + "']");
                if (vana != null)
                {
                    /*kustutab postituse*/
                    root.RemoveChild(vana);
                    dokument.Save(Server.MapPath(@"postitused.xml"));
                    andmedXML.DataBind();
                    loadListbox();
                }
            }
            else
            {
                VigaLbl.Text = "Vali postitus";
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Täidab pealkirja ja sisu väljad valitud postituse andmetega*/
            XElement xelem = XElement.Load(Server.MapPath(@"postitused.xml"));

            foreach (var c in xelem.Elements("postitus"))
            {
                if (c.Attribute("id").Value == ListBox1.SelectedItem.Value)
                {
                    PealkiriTb.Text = c.Attribute("pealkiri").Value;
                    TekstTb.Text = c.Attribute("tekst").Value;
                }
            }
        }
    }
}