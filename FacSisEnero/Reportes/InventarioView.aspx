﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventarioView.aspx.cs" Inherits="FacSisEnero.Reportes.InventarioView" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        html, body, form, #div1 {
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="InventarioReportViewer1"  runat="server" >
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
