<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientesReporteView.aspx.cs" Inherits="FacSisEnero.Reportes.clientesReporteView" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ClienteReportViewer1" runat="server"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
