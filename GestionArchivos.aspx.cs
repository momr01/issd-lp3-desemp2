using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Desemp2
{
    public partial class GestionArchivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sesion = this.Session["usuario"] != null ? this.Session["usuario"].ToString() : string.Empty;

            if (string.IsNullOrEmpty(sesion))
            {
                this.Response.Redirect("Registro.aspx");
            } else
            {
                this.Username.Text = sesion;
                CargarGridView(sesion);
            }

        }

        private void CargarGridView(string username)
        {
            string path = $"{Server.MapPath(".")}/{username}";
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                List<Archivo> fileList = new List<Archivo>();
                foreach (string file in files)
                {
                    var fileNew = new Archivo(Path.GetFileName(file), file);
                    fileList.Add(fileNew);
                }
                GridView1.DataSource = fileList;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = $"{Server.MapPath(".")}/{this.Session["usuario"]}";
                string result = string.Empty;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                foreach (HttpPostedFile archivo in FileUpload1.PostedFiles)
                {
                    if (archivo.ContentLength > 1000)
                    {
                        result += $"El archivo {archivo.FileName} supera los 100 bytes - ";
                    }
                    else
                    {
                        if (File.Exists($"{path}/{archivo.FileName}"))
                        {
                            result += $"El archivo {archivo.FileName} ya existe - ";
                        }
                        else
                        {
                            FileUpload1.SaveAs($"{path}/{archivo.FileName}");
                        }
                    }

                }
                Label1.Text = result;
                CargarGridView(this.Session["usuario"].ToString());
            } catch
            {
                this.Label1.Text = "Debe seleccionar un archivo.";
                this.Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Descargar")
            {
                GridViewRow registro = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
                string filePath = registro.Cells[2].Text;

                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.TransmitFile(filePath);
                Response.End();
            }
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Response.Cookies.Remove("password");
        
            this.Session.Remove("usuario");

            this.Response.Redirect("Registro.aspx");
        }
    }
}