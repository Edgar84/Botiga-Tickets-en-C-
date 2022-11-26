using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projecte_1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["carret"] == null || Request.Cookies["carret"].Value == "") {
                PlaceOrder.CssClass += " disabled";
            }
        }
        protected void PlaceOrder_Click(object sender, EventArgs e)
        {
            String nom = NameInput.Value.Contains(" ") ? NameInput.Value.Replace(" ", "") : NameInput.Value;
            DateTime dateTime = DateTime.UtcNow;
            String path = Server.MapPath(".") + "/comandes/" + dateTime.Minute.ToString() + dateTime.Second.ToString() + dateTime.ToString("ddMMyyyy") + "_" + nom + ".txt";

            saveOrder(path);
        }
        protected void saveOrder(String path)
        {

            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(path);
                writeOrder(writer);
            }
            catch (IOException exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message); // Missatge per terminal en cas de fallar l'escriptura
            }
            finally
            {
                if (writer != null)
                    writer.Dispose(); // També es pot utilitzar .Close()
            }
        }
        protected void writeOrder(StreamWriter writer) {

            String newProductCart = Request.Cookies["carret"].Value;
            String[] filmsInCart = newProductCart.Split('-');
            DateTime dateTime = DateTime.UtcNow;
            int total = 0;

            writer.WriteLine(dateTime.ToString("dd/MM/yyyy"));
            writer.WriteLine(NameInput.Value);
            writer.WriteLine(DNIInput.Value);
            writer.WriteLine(PhoneInput.Value);

            for (int i = 0; i < filmsInCart.Length - 1; i++)
            {
                String[] texts = filmsInCart[i].Split(',');
                    
                writer.WriteLine("-----");
                writer.WriteLine("Pel·licula: " + texts[0]);
                writer.WriteLine("Descripció: " + texts[2]);
                writer.WriteLine("Preu: " + texts[1] + "€");
                writer.WriteLine("Quantitat:" + texts[3] + " - (" + (int.Parse(texts[1]) * int.Parse(texts[3])).ToString() + "€)");
                writer.WriteLine("-----");
                total += int.Parse(texts[1]) * int.Parse(texts[3]);
            }

            writer.WriteLine("******");
            writer.WriteLine("Total:");
            writer.WriteLine(total + "€");

            borrarCookies();
            clearForm();
            redirectToThanksPage();
        }
        protected void borrarCookies()
        {
            if (Request.Cookies["carret"] != null)
            {
                HttpCookie currentUserCookie = HttpContext.Current.Request.Cookies["carret"];
                HttpContext.Current.Response.Cookies.Remove("carret");
                currentUserCookie.Expires = DateTime.Now.AddDays(-10);
                currentUserCookie.Value = null;
                HttpContext.Current.Response.SetCookie(currentUserCookie);
            }
        }
        protected void clearForm() {
            NameInput.Value = "";
            DNIInput.Value = "";
            PhoneInput.Value = "";
        }
        protected void redirectToThanksPage() {
            //Thread.Sleep(1500);
            Response.Redirect("thanks.aspx");
        }
        protected void goToCart(object sender, EventArgs e)
        {
            Response.Redirect("shopping_cart.aspx");
        }
        protected void GoHome(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}