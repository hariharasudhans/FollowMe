using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userInformation"] != null)
        {
            UserParameters userParams = (UserParameters)Session["userInformation"];
            lbUserName.Text = userParams.UserName;
            LoadUserSuggestions();
            LoadMessages();
        }
        else
        {
            Response.Redirect("default.aspx");
        }
    }

    private void LoadUserSuggestions()
    {
        long? userID = long.Parse(Session["userID"].ToString());
        List<user_registration> userDetails = DatabaseUtil.GetUserSuggestions(userID);
        foreach (user_registration usrDet in userDetails)
        {
            Label lbname = new Label();
            lbname.Text = usrDet.name;
            Label lbSpace = new Label();
            lbSpace.Text = "&nbsp;";
            Button btnFollow = new Button();
            btnFollow.ID = string.Format("{0}", usrDet.user_id.ToString());
            btnFollow.Text = DatabaseUtil.CheckUserFollowStatus(userID, usrDet.user_id);
            if (btnFollow.Text.Equals("Unfollow"))
            {
                btnFollow.Enabled = false;
            }
            btnFollow.Click += new EventHandler(btnFollow_Click);
            Label lbBreak1 = new Label();
            lbBreak1.Text = "<br />";
            Label lbBreak2 = new Label();
            lbBreak2.Text = "<br />";
            phUserSuggestions.Controls.Add(lbname);
            phUserSuggestions.Controls.Add(lbSpace);
            phUserSuggestions.Controls.Add(btnFollow);
            phUserSuggestions.Controls.Add(lbBreak1);
            phUserSuggestions.Controls.Add(lbBreak2);
        }
    }

    void btnFollow_Click(object sender, EventArgs e)
    {
        Button btnFollowUp = (Button)sender;
        btnFollowUp.Text = "Unfollow";
        btnFollowUp.Enabled = false;
        long? followerID = long.Parse(Session["userID"].ToString());
        long? followingID = long.Parse(btnFollowUp.ID);
        string status = DatabaseUtil.CheckUserFollowStatus(followerID, followingID);
        if (status.Equals("Follow"))
        {
            DatabaseUtil.InsertUserFollowUp(followerID, followingID);
        }
        Response.Redirect("home.aspx");
    }

    private void LoadMessages()
    {
        long? userID = long.Parse(Session["userID"].ToString());
        List<long?> userFollowingIDs = DatabaseUtil.GetUserFollowingIDs(userID);
        userFollowingIDs.Add(userID);
        List<user_message> indivMessages = new List<user_message>();
        List<List<user_message>> allMessages = new List<List<user_message>>();
        foreach (long ID in userFollowingIDs)
        {
            indivMessages = DatabaseUtil.GetUserMessages(ID);
            allMessages.Add(indivMessages);
        }
        if (!indivMessages.Count.Equals(0))
        {
            foreach (List<user_message> messages in allMessages)
            {
                foreach (user_message message in messages)
                {
                    Label lbName = new Label();
                    lbName.Font.Bold = true;
                    lbName.Text = message.user_registration.name + " - ";
                    Label lbMsg = new Label();
                    lbMsg.Text = message.message;
                    Label lbBreak1 = new Label();
                    lbBreak1.Text = "<br />";
                    Label lbBreak2 = new Label();
                    lbBreak2.Text = "<br />";
                    phMessages.Controls.Add(lbName);
                    phMessages.Controls.Add(lbMsg);
                    phMessages.Controls.Add(lbBreak1);
                    phMessages.Controls.Add(lbBreak2);
                }
            }
        }
        else
        {
            Label lbMsg = new Label();
            lbMsg.Text = "Sorry, you dont have any messages";
            phMessages.Controls.Add(lbMsg);
        }
    }

    protected void btnPost_Click(object sender, EventArgs e)
    {
        string message = tbMessage.Text;
        string result = string.Empty;
        long? userID = long.Parse(Session["userID"].ToString());
        result = DatabaseUtil.InsertUserPost(userID, message);
        tbMessage.Text = string.Empty;
        lbAlert.Text = "<script type='text/javascript'>alert('" + result + "');window.location='home.aspx';</script>";
    }
}
