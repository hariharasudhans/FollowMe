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
            message = string.Format("{0} signed up successfully", fullname);
        }
        catch (Exception ex)
        {
            message = string.Format("{0}, server is busy. Please try again later", fullname);
        }
        return message;
    }
}
