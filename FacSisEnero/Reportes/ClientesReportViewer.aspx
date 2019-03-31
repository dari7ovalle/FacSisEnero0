<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientesReportViewer.aspx.cs" Inherits="FacSisEnero.Reportes.ClientesReportViewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        html,body,form,#div1{
            height: 100%;
        }
    </style>
</head>
<body>
   <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
        <div id="div1" class="container">
            <rsweb:ReportViewer ID="ListadoReportViewer" ProcessingMode="Remote" Height="100%" Width="100%" runat="server">
                <ServerReport ReportPath="" ReportServerUrl="" />
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
