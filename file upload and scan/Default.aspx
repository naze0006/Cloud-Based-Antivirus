<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-family: "Times New Roman", Times, serif;
            color: #0000FF;
            font-weight: bold;
        }
        .style2
        {
            font-size: medium;
            color: #FF0000;
        }
        .style3
        {
            font-size: medium;
            color: #FF0000;
            font-weight: bold;
        }
        .style4
        {
            font-size: large;
        }
        .style5
        {
            font-family: "Times New Roman", Times, serif;
            color: #FF0000;
            font-weight: bold;
        }
    </style>
</head>
<body style="z-index: 1; left: 33px; top: 77px; position: absolute; height: 26px; width: 1271px" 
    background="upload/12.jpg">
    <form id="form1" runat="server">
    <div>
    
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Check File" Width="84px" />
    
    </div>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False" 
            ForeColor="#CC0000"></asp:Label>
    </p>
    <asp:Panel ID="Panel1" runat="server" Height="311px">
        <span class="style1">
        <br />
        <br />
        <br />
        Our Project:<br class="style4" /> </span>
        <span class="style4"><span class="style5">Antivirus Mcafee As a Service</span></span><span 
            class="style1"><br />
        <br />
        <br />
        <br />
        Our Group members:</span><br />
        <span class="style3">Vahid Moraveji Hashemi</span><b><br class="style2" /> </b>
        <span class="style3">Ali Falsafi</span><b><br class="style2" /> </b>
        <span class="style3">Mohammadali Iravani</span><b><br class="style2" /> </b>
        <span class="style3">Shirin Nazemoroaya</span><b><br class="style2" /> </b>
        <span class="style3">Ghazaleh Rezayat</span></asp:Panel>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
