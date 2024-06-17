using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Desemp2
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sesion = this.Session["usuario"] != null ? this.Session["usuario"].ToString() : string.Empty;

            if (!string.IsNullOrEmpty(sesion))
            {
                this.Response.Redirect("GestionArchivos.aspx");
            }
            

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int edad;
            edad = int.Parse(this.Edad.Text);
            if(edad <= 15)
                args.IsValid = false;
            else 
                args.IsValid = true;
        }

        protected void BtnRegistro_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
              

                bool cookieCreada = CrearCookie(this.Password.Text);
                bool sesionCreada = CrearSesion(this.Username.Text);

                if(cookieCreada && sesionCreada)
                {
                    this.ResRegistro.Text = "Registro exitoso!";
                    this.Response.Redirect("GestionArchivos.aspx");
                } else
                {
                    if(cookieCreada)
                    {
                        this.Response.Cookies.Remove("password");
                    }

                    if (sesionCreada)
                    {
                        this.Session.Remove("usuario");
                    }
                }


            }
        }

        private bool CrearCookie(string pass)
        {
            try
            {
                HttpCookie cookiePass = new HttpCookie("password", pass);
                cookiePass.Expires = new DateTime(2024, 12, 25);
                this.Response.Cookies.Add(cookiePass);
                return true;
            } catch
            {
                return false;
            }


        }

        private bool CrearSesion(string username)
        { 
            try
            {
                this.Session["usuario"] = username;
                return true;
            } catch { return false; }
            
           
        }
    }
}