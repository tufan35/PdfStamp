<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pdfstamp.aspx.cs" Inherits="PdfStamp.pdfstamp1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script>    
            function printTrigger(elementId) {
            var getMyFrame = document.getElementById(elementId);
            getMyFrame.focus();
            getMyFrame.contentWindow.print();
        }
    </script>
   
    <style type="text/css">
        .auto-style1 {
            width: 23%;
        }
    </style>
   
</head>
<body style="height: 810px; width: 1107px">
    <form id="form1" runat="server">
           <div>

            <table style="width:100%">
                <tr>
                    <td style="width:25%">
                        <asp:FileUpload ID="fuUpload" runat="server" Width="90%" />
                    </td>
                    <td style="width:25%">
                        <asp:Button ID="btnUpload" Text="Yükle" runat="server"  Width="90%" OnClick="Upload"/>
                     </td>
                    <td class="auto-style1">
                        <asp:Button ID="btnView" runat="server" Text="Göster" OnClick="View" Width="90%" />
                    </td>
                    <td style="width:25%">
                        <asp:Button ID="btnDownload" runat="server" OnClick="download" Text="İndir" Width="90%" />
                    </td>
                </tr>
                <tr>
                     <td style="width:25%">
                        <input type="button" value="Print" onclick="printTrigger('frm_docs');"  />
                    </td>
                    <td style="width:25%">
                        <asp:Button ID="btnstamp" runat="server" OnClick="Btnstamp" Text="Damga Bas!" Width="90%" />
                    </td>
                    <td class="auto-style1">
                         <asp:ListBox ID="ListBox2" runat="server" Width="97px" SelectionMode ="Multiple"  >
                            <asp:ListItem Text="deneme1" Value="//stampimage//deneme1.jpg"/>
                            <asp:ListItem Text="deneme2" Value="//stampimage//deneme2.jpg"/>
                            <asp:ListItem Text="deneme3" Value="//stampimage//deneme3.jpg"/>
                            <asp:ListItem Text="deneme4" Value="//stampimage//deneme4.jpg"/>
                            <asp:ListItem Text="deneme5" Value="//stampimage//deneme5.jpg"/>
                            <asp:ListItem Text="deneme6" Value="//stampimage//deneme6.jpg"/>
                            <asp:ListItem Text="deneme7" Value="//stampimage//deneme7.jpg"/>
                        </asp:ListBox>

                    </td>

                  
                </tr>
                <tr>
                    <td style="width:100%" colspan="4">
                 <iframe runat="server" id="frm_docs" src="MDPdfKontrol.aspx" style="display:inline; border:solid 1px black; width:100%; height:800px;" > </iframe>
                    </td>
                </tr>       
            </table>
                <asp:Label ID="Label1" runat="server"></asp:Label>  
        </div>
    </form>
</body>
</html>
