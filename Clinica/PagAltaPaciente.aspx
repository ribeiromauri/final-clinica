<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagAltaPaciente.aspx.cs" Inherits="Clinica.PagAltaPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-family:Georgia (serif); font-size: xx-large; text-align: center; font-weight:600">
        <p>ALTA PACIENTE</p>
    </div>
    <div class="mb-3">
        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Ingresar Nombre" />
    </div>
    <div class="mb-3">
        <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" placeholder="Ingresar Apellido" />
    </div>
    <div class="mb-3">
        <asp:TextBox runat="server" ID="txtDNI" CssClass="form-control" placeholder="Ingresar DNI" />
    </div> 
    <div class="mb-3">
        <asp:TextBox runat="server" ID="txtDomicilio" CssClass="form-control" placeholder="Ingresar Domicilio" />
    </div>
    <div class="mb-3">
        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Ingresar Email" />
    </div>
    <div class="mb-3">
        <asp:TextBox runat="server" ID="txtFechaNacimiento" CssClass="form-control" placeholder="Ingresar Fecha Nacimiento" />
    </div>
    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" class="btn btn-success" OnClick="btnAceptar_Click"/>
    <a class="btn btn-danger" href="PagPacientes.aspx">Volver</a>
</asp:Content>
