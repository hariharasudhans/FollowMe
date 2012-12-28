<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                                    <input id="name" runat="server" type="text" maxlength="20" class="width_150" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <br class="line_height_0_5" />
                                    Email:
                                </td>
                                <td align="right">
                                    <br class="line_height_0_5" />
                                    <input id="email" runat="server" type="text" class="width_150" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <br class="line_height_0_5" />
                                    Password
                                </td>
                                <td align="right">
                                    <br class="line_height_0_5" />
                                    <input type="password" class="width_150" id="password" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <br class="line_height_0_5" />
                                    <asp:Button ID="btnSignUp" runat="server" Text="Sign up" OnClientClick="return validate();"
                                        OnClick="btnSignUp_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <asp:Label ID="lbAlert" runat="server"></asp:Label>
    </center>
    </form>

    <script type="text/javascript">

        function validate() {
            var name = document.getElementById("<%=name.ClientID %>");
            var email = document.getElementById("<%=email.ClientID %>");
            var password = document.getElementById("<%=password.ClientID %>");
            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            if (!name.value.match(/\S/)) {
                alert("Please fill the name");
                return false;
            }
            else if (!email.value.match(/\S/)) {
                alert("Please fill the email");
                return false;
            }
            else if (!filter.test(email.value)) {
                alert("Please provide a valid email address");
                return false;
            }
            else if (!password.value.match(/\S/)) {
                alert("Please fill the password");
                return false;
            }
        }
    </script>

</body>
</html>
