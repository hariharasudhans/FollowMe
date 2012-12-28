<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" rel="Stylesheet" href="styles/home.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <table class="home-main-table">
                <tr>
                    <td align="left" valign="top">
                        <table>
                            <tr>
                                <td align="left">
                                    <h3>
                                        Welcome,
                                        <asp:Label ID="lbUserName" runat="server"></asp:Label>(<a href="Default.aspx">log out</a>)</h3>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:TextBox ID="tbMessage" Text="Please type your message here" onmousedown="this.value='';"
                                        onblur="if(this.value == ''){this.value='Please type your message here';}" runat="server"
                                        TextMode="MultiLine" Height="100px" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button ID="btnPost" Text="Post" runat="server" OnClick="btnPost_Click" OnClientClick="return msgvalidate();" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>
                                        User Suggestions</h3>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:PlaceHolder ID="phUserSuggestions" runat="server"></asp:PlaceHolder>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <h3 class="align-left">
                            User Messages</h3>
                        <asp:PlaceHolder ID="phMessages" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
            </table>
            <asp:Label ID="lbAlert" runat="server"></asp:Label>
        </center>
    </div>
    </form>

    <script type="text/javascript">

        function msgvalidate() {
            var msg = document.getElementById("<%=tbMessage.ClientID %>");
            if (!msg.value.match(/\S/)) {
                alert("Please type your message here");
                return false;
            }
        }

    </script>

</body>
</html>
