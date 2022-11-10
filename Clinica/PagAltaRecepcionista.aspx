<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagAltaRecepcionista.aspx.cs" Inherits="Clinica.PagAltaRecepcionista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-family: Georgia (serif); font-size: xx-large; text-align: center; font-weight: 600" class="mb-3">
        <p>ALTA RECEPCIONISTA</p>
    </div>
    <div style="display: flex; flex-direction: column; justify-content: center;" class="mb-3">
        <div class="mb-3">
            <label class="form-label">Nombre</label>
            <asp:TextBox CssClass="form-control inputSize" ID="nombreRecepcionista" runat="server" required="required"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Apellido</label>
            <asp:TextBox CssClass="form-control inputSize" ID="apellidoRecepcionista" runat="server" required="required"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">DNI</label>
            <asp:TextBox CssClass="form-control inputSize" ID="dniRecepcionista" runat="server" required="required" TextMode="Number"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Email</label>
            <asp:TextBox CssClass="form-control inputSize" ID="emailRecepcionista" runat="server" type="email" required="required"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Contraseña</label>
            <asp:TextBox CssClass="form-control inputSize" ID="passRecepcionista" runat="server" type="password" required="required"></asp:TextBox>
        </div>
    </div>
    <div class="mb-3">
        <asp:Button ID="Agregar" runat="server" Text="Agregar" CssClass="btn btn-success" OnClick="Agregar_Click" />
        <a href="PagRecepcionista.aspx" class="btn btn-warning">Volver</a>
        <%if (BotonEliminar)
            {%>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btnEliminar_Click" />
        <%} %>
        <%if (ConfirmarEliminacion)
            {%>
        <hr />
        <div class="mb-3">
            <asp:CheckBox ID="chkConfirmarEliminacionRecep" runat="server" Text="Confirmar" />
            <asp:Button ID="btnConfirmarEliminacion" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" OnClick="btnConfirmarEliminacion_Click"/>
        </div>

        <% } %>
    </div>
    <h5 style="padding-top: 20px;">
        <asp:Label ID="Validaciones" CssClass="h5" runat="server" /></h5>
</asp:Content>
