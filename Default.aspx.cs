using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        string fullname = name.Value;
        string emailAddress = email.Value;
        string userPassword = password.Value;
        
        //Encrypt password
        UTF8Encoding UTF8Encoder = new UTF8Encoding();
        byte[] inputBytes = UTF8Encoder.GetBytes(userPassword);
        string encryptPassword = Convert.ToBase64String(inputBytes);
        ///////////////////

        string message = DatabaseUtil.InsertUserData(fullname, emailAddress, encryptPassword);
        name.Value = string.Empty;
        email.Value = string.Empty;
        lbAlert.Text = "<script type='text/javascript'>alert('" + message + "');window.location='home.aspx';</script>";
    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        string userEmail = loginEmail.Value;
        string userPassword = loginPassword.Value;
        string message = string.Empty;
        //Encrypt password
        UTF8Encoding UTF8Encoder = new UTF8Encoding();
        byte[] inputBytes = UTF8Encoder.GetBytes(userPassword);
        string encryptPassword = Convert.ToBase64String(inputBytes);
        ///////////////////

        UserParameters userInfo = DatabaseUtil.UserAuthentication(userEmail, encryptPassword);
        if (userInfo != null)
        {
            Session["userID"] = userInfo.UserID;
            Session["userInformation"] = userInfo;
            Response.Redirect("home.aspx");
        }
        else
        {
            message = "Invalid email or password";
            lbAlert.Text = "<script type='text/javascript'>alert('" + message + "');</script>";
        }
    }
}
