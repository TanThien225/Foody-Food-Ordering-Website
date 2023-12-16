﻿using Foody.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foody.Admin
{
    public partial class Report : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["breadCrum"] = "Selling Report";
                if (Session["admin"] == null)
                {
                    Response.Redirect("../User/Login.aspx");
                }
            }
        }

        private void getReportDate(DateTime fromDate, DateTime toTime)
        {
            double grandTotal = 0;
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("SellingReport", con);
            cmd.Parameters.AddWithValue("@FromDate", fromDate);
            cmd.Parameters.AddWithValue("@ToDate", toTime);
            cmd.CommandType = CommandType.StoredProcedure;

            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    grandTotal += Convert.ToDouble(dr["TotalPrice"]);
                }
                lblTotal.Text = "Sold Cost: $" + grandTotal;
                lblTotal.CssClass = "badge badge-primary";
            }

            rSReport.DataSource = dt;
            rSReport.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);
            if (toDate > DateTime.Now)
            {
                Response.Write("<script>alert('ToDate cannot be greater than current date!');</script>");
            }
            else if (fromDate > toDate)
            {
                Response.Write("<script>alert('FromDate cannot be greater than ToDate!');</script>");
            }
            else
            {
                getReportDate(fromDate, toDate);
            }
        }
    }
}