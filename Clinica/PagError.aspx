<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagError.aspx.cs" Inherits="Clinica.PagError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Ocurrió un error</h1>
    <asp:Label ID="lblMensajeError" runat="server" Text=" " Font-Size="X-Large"></asp:Label>
</asp:Content>
