using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Assignment1
{
    public partial class Products : System.Web.UI.Page
    {
        private Dictionary<string, (string ImageUrl, decimal Price)> products = new Dictionary<string, (string, decimal)>
        {

             { "Laptop", ("~/images/laptop.jpg", 19999.99m) },

            { "Smartphone", ("~/images/smartphone.jpg", 2499.99m) },

            { "Tablet", ("~/images/tablet.jpg", 1299.99m) },

            { "Headphones", ("~/images/headphones.jpg", 199.99m) },

            { "Smartwatch", ("~/images/smartwatch.jpg", 799.99m) }

        };

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                ddlProducts.DataSource = products.Keys;

                ddlProducts.DataBind();

            }

        }

        protected void ddlProducts_1(object sender, EventArgs e)
        {

            string selectedProduct = ddlProducts.SelectedValue;

            if (products.TryGetValue(selectedProduct, out var productInfo))

            {

                imgProduct.ImageUrl = productInfo.ImageUrl;

            }

        }



        protected void btnGetPrice_Click(object sender, EventArgs e)

        {

            string selectedProduct = ddlProducts.SelectedValue;

            if (products.TryGetValue(selectedProduct, out var productInfo))

            {

                lblPrice.Text = $"Price: Rs.{productInfo.Price:F2}";

            }

        }

    }
}