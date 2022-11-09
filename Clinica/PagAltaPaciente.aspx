<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagAltaPaciente.aspx.cs" Inherits="Clinica.PagAltaPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-family: Georgia (serif); font-size: xx-large; text-align: center; font-weight: 600">
        <p>FORMULARIO PACIENTE</p>
    </div>
    <div class="mb-3">
        <label class="form-label">Nombre</label>
        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Ingresar Nombre" />
    </div>
    <div class="mb-3">
        <label class="form-label">Apellido</label>
        <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" placeholder="Ingresar Apellido" />
    </div>
    <div class="mb-3">
        <label class="form-label">DNI</label>
        <asp:TextBox runat="server" ID="txtDNI" CssClass="form-control" placeholder="Ingresar DNI" />
    </div>
    <div class="mb-3">
        <label class="form-label">Domicilio</label>
        <asp:TextBox runat="server" ID="txtDomicilio" CssClass="form-control" placeholder="Ingresar Domicilio" />
    </div>
    <div class="mb-3">
        <label class="form-label">Email</label>
        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Ingresar Email" />
    </div>
    <div class="mb-3">
        <label class="form-label">Fecha Nacimiento</label>
        <asp:TextBox runat="server" ID="txtFechaNacimiento" CssClass="form-control" placeholder="Ingresar Fecha Nacimiento" />
    </div>
    <div class="row">
        <div class="mb-3">
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" class="btn btn-success" OnClick="btnAceptar_Click" />
            <a class="btn btn-warning" href="PagPacientes.aspx">Volver</a>
            <%if (BotonEliminar)
                {%>
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btnEliminar_Click" />
            <%} %>
            <%if (ConfirmarEliminacion)
                {%>
            <hr />
            <div class="mb-3">
                <asp:CheckBox ID="chkConfirmarEliminacion" runat="server" Text="Confirmar" />
                <asp:Button ID="btnConfirmarEliminacion" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" OnClick="btnConfirmarEliminacion_Click" />
            </div>

            <% } %>
        </div>
</asp:Content>
