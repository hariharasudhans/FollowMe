using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatabaseUtil
/// </summary>
public class DatabaseUtil
{
	public DatabaseUtil()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string InsertUserData(string fullname, string emailAddress, string encryptPassword)
    {
        string message = string.Empty;
        user_registration userReg = new user_registration();
        userReg.name = fullname;
        userReg.email = emailAddress;
        userReg.password = encryptPassword;
        try
        {
            DatabaseConnect.DataContext.user_registrations.InsertOnSubmit(userReg);
            DatabaseConnect.DataContext.SubmitChanges();
            message = string.Format("{0}, Thanks for sign up with us", fullname);
        }
        catch (Exception ex)
        {
            message = string.Format("{0}, server is busy. Please try again later", fullname);
        }
        return message;
    }

    public static UserParameters UserAuthentication(string email, string password)
    {
        UserParameters userParams = new UserParameters();
        try
        {
            var query = (from usr in DatabaseConnect.DataContext.user_registrations where usr.email == email && usr.password == password select usr).FirstOrDefault();
            if (query != null)
            {
                userParams.UserEmail = query.email;
                userParams.UserName = query.name;
                userParams.UserID = query.user_id;
            }
            else
            {
                userParams = null;
            }
        }
        catch (Exception ex)
        {
            userParams = null;
        }
        return userParams;
    }

    public static string InsertUserPost(long? userID, string userMessage)
    {
        string message = string.Empty;
        user_message userMsg = new user_message();
        userMsg.user_id = userID;
        userMsg.message = userMessage;
        try
        {
            DatabaseConnect.DataContext.user_messages.InsertOnSubmit(userMsg);
            DatabaseConnect.DataContext.SubmitChanges();
            message = string.Format("Your message posted successfully");
        }
        catch (Exception ex)
        {
            message = string.Format("{Server is busy. Please try again later");
        }
        return message;
    }

    public static List<user_registration> GetUserSuggestions(long? userID)
    {
        var query = (from usr in DatabaseConnect.DataContext.user_registrations where usr.user_id != userID select usr).ToList();
        return query;
    }

    public static void InsertUserFollowUp(long? followerID, long? followingID)
    {
        user_followup userFollow = new user_followup();
        userFollow.follower_user_id = followerID;
        userFollow.following_user_id = followingID;
        try
        {
            DatabaseConnect.DataContext.user_followups.InsertOnSubmit(userFollow);
            DatabaseConnect.DataContext.SubmitChanges();
        }
        catch (Exception ex)
        {
        }
    }

    public static string CheckUserFollowStatus(long? followerID, long? followingID)
    {
        string buttonText = string.Empty;
        var followingIDs = (from userFollow in DatabaseConnect.DataContext.user_followups where userFollow.follower_user_id == followerID select userFollow.following_user_id).ToList();
        if (followingIDs != null)
        {
            if (followingIDs.Contains(followingID))
            {
                buttonText = "Unfollow";
            }
            else
            {
                buttonText = "Follow";
            }
        }
        else
        {
            buttonText = "Follow";
        }
        return buttonText;
    }

    public static List<long?> GetUserFollowingIDs(long? followerID)
    {
        string buttonText = string.Empty;
        var followingIDs = (from userFollow in DatabaseConnect.DataContext.user_followups where userFollow.follower_user_id == followerID select userFollow.following_user_id).ToList();
        return followingIDs;
    }

    public static List<user_message> GetUserMessages(long? userID)
    {
        var messages = (from userMsg in DatabaseConnect.DataContext.user_messages where userMsg.user_id == userID select userMsg).ToList();
        return messages;
    }
}
