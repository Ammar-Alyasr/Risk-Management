using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Risk_Management_at_Airports
{
    public partial class Camera : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        OleDbDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            fillTable();
        }

        public void fillTable()
        {
            try
            {
                string sorgu = "SELECT * FROM CAMERA";
                da = new OleDbDataAdapter(sorgu, con);
                dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                gvKamera.DataSource = dt;
                gvKamera.DataBind();

                //Attribute to show the Plus Minus Button.
                gvKamera.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                gvKamera.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                gvKamera.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                gvKamera.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                gvKamera.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";

                //Adds THEAD and TBODY to GridView.
                gvKamera.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception e)
            {
                
            }
        }
        protected void gvKamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId.Text = gvKamera.SelectedRow.Cells[1].Text;
            txtAdi.Text = HttpUtility.HtmlDecode(gvKamera.SelectedRow.Cells[2].Text.ToString());
            txtAdres.Text = HttpUtility.HtmlDecode(gvKamera.SelectedRow.Cells[3].Text.ToString());
            txtAngle.Text = HttpUtility.HtmlDecode(gvKamera.SelectedRow.Cells[5].Text.ToString());
            txtAciklama.Text = HttpUtility.HtmlDecode(gvKamera.SelectedRow.Cells[4].Text.ToString());
            fillTable();
        }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            con.Open();
            if (txtId.Text == "")
            {
                OleDbCommand komut = new OleDbCommand("insert into CAMERA (NAME,LOCATION,EXPLANATION,VISUAL_ANGLE) values(NAME,LOCATION,EXPLANATION,VISUAL_ANGLE)", con);
                komut.Parameters.AddWithValue("NAME", txtAdi.Text); //parametre değerleri atanıyor.
                komut.Parameters.AddWithValue("LOCATION", txtAdres.Text);
                komut.Parameters.AddWithValue("EXPLANATION", txtAciklama.Text);
                komut.Parameters.AddWithValue("VISUAL_ANGLE", txtAngle.Text);
                komut.ExecuteNonQuery(); //komut nesnesi çalıştırılıyor.

            }
            else
            {
                OleDbCommand update = new OleDbCommand("UPDATE CAMERA SET NAME=@NAME,LOCATION=@LOCATION,EXPLANATION=@EXPLANATION,VISUAL_ANGLE=@VISUAL_ANGLE where ID=" + txtId.Text + "", con);
                update.Parameters.AddWithValue("@NAME", txtAdi.Text); //parametre değerleri atanıyor.
                update.Parameters.AddWithValue("@LOCATION", txtAdres.Text);
                update.Parameters.AddWithValue("@EXPLANATION", txtAciklama.Text);
                update.Parameters.AddWithValue("@VISUAL_ANGLE", txtAngle.Text);
                update.ExecuteNonQuery(); //komut nesnesi çalıştırılıyor.
            }
            con.Close();
            fillTable();
            temizle();
            Response.Write("<script>alert('Succesfully saved.')</script>");
        }
        protected void btnSil_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand komut = new OleDbCommand("delete from CAMERA where Id=@id", con);
            komut.Parameters.AddWithValue("id", txtId.Text);
            komut.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Data deleted succesfully.')</script>");
            temizle();
            fillTable();
        }

        protected void btnYeni_Click(object sender, EventArgs e)
        {
            Response.Redirect("Kamera.aspx");
        }
        protected void temizle()
        {
            txtId.Text = "";
            txtAdi.Text = "";
            txtAdres.Text = "";
            txtAngle.Text = "";
            txtAciklama.Text = "";
        }
    }
}
