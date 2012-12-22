<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Follow Me</title>
    <link type="text/css" rel="Stylesheet" href="styles/default.css" />
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <table class="default_main_table">
            <tr>
                <td align="left" valign="top">
                    <br />
                    <div class="default_welcome_div">
                        <br />
                        <p>
                            <b>&nbsp;&nbsp;Find out what&#8217;s happening, right now, with the people and &nbsp;&nbsp;organizations
                                you care about.</b></p>
                    </div>
                </td>
                <td>
                    <div class="default_login_div">
                        <h3 align="left">
                            <i>Login</i></h3>
                        <table>
                            <tr>
                                <td align="left">
                                    Email:
                                </td>
                                <td align="right">
                                    <input type="text" name="username or email" class="width_150" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <br class="line_height_0_5" />
                                    Password:
                                </td>
                                <td align="right">
                                    <br class="line_height_0_5" />
                                    <input type="password" class="width_150" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <br class="line_height_0_5" />
                                    <asp:Button ID="btnSignIn" Text="Sign in" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div class="default_signup_div">
                        <h3 align="left">
                            <i>New to FollowMe? Sign up</i></h3>
                        <table>
                            <tr>
                                <td align="left">
                                    <br class="line_height_0_5" />
                                    Full name:
                                </td>
                                <td align="right">
                                    <br class="line_height_0_5" />
                                    <input type="text" maxlength="20" class="width_150" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <br class="line_height_0_5" />
                                    Email:
                                </td>
                                <td align="right">
                                    <br class="line_height_0_5" />
                                    <input type="text" class="width_150" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <br class="line_height_0_5" />
                                    Password
                                </td>
                                <td align="right">
                                    <br class="line_height_0_5" />
                                    <input type="password" class="width_150" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <br class="line_height_0_5" />
                                    <asp:Button ID="btnSignUp" runat="server" Text="Sign up" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>
