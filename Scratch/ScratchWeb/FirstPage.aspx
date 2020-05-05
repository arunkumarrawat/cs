<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstPage.aspx.cs" Inherits="ScratchWeb.FirstPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 111px;
        }
    </style>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function Submit1_onclick() {

        }

// ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    First Page of Asp.Net<br />

        <asp:Label ID="lblName" runat="server" ViewStateMode="Enabled"></asp:Label>
    
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    name:</td>
                <td>
                    <input id="Text1" type="text" /></td>
            </tr>
            <tr>
                <td class="style1">
                    Address:</td>
                <td>
                    <input id="Text2" type="text" /></td>
            </tr>
            <tr>
                <td class="style1">
                    Phone:</td>
                <td>
                    <input id="Text3" type="text" /></td>
            </tr>
        </table>
    
    </div>
    </form>
    <p>
        <input id="Submit1" type="submit" value="submit" onclick="return Submit1_onclick()" /></p>
</body>
</html>
