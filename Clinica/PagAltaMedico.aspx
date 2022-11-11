<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagAltaMedico.aspx.cs" Inherits="Clinica.PagAltas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-family: Georgia (serif); font-size: xx-large; text-align: center; font-weight: 600" class="mb-3">
        <p>ALTA MÉDICO</p>
    </div>
    <div style="display: flex; flex-direction: column; justify-content: center;" class="mb-3">
        <div class="mb-3">
            <label class="form-label">Nombre</label>
            <asp:TextBox CssClass="form-control inputSize" ID="nombreMedico" runat="server" required="required"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Apellido</label>
            <asp:TextBox CssClass="form-control inputSize" ID="apellidoMedico" runat="server" required="required"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">DNI</label>
            <asp:TextBox CssClass="form-control inputSize" ID="dniMedico" runat="server" required="required" TextMode="Number"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Matricula</label>
            <asp:TextBox CssClass="form-control inputSize" ID="matriculaMedico" runat="server" required="required" TextMode="Number"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Email</label>
            <asp:TextBox CssClass="form-control inputSize" ID="emailMedico" runat="server" type="email" required="required"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Contraseña</label>
            <asp:TextBox CssClass="form-control inputSize" ID="passMedico" runat="server" type="password" required="required"></asp:TextBox>
        </div>
        <h6>Seleccionar especialidad:</h6>
        <asp:CheckBoxList ID="chkEspecialidades" runat="server" RepeatColumns="3"></asp:CheckBoxList>

    </div>
    <div class="mb-3">
        <asp:Button ID="Agregar" runat="server" Text="Agregar" CssClass="btn btn-success" OnClick="Agregar_Click" />
        <a href="PagMedicos.aspx" class="btn btn-warning">Volver</a>
        <%if (BotonEliminar)
            {%>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btnEliminar_Click"/>
        <%} %>
        <%if (ConfirmarEliminacion)
            {%>
        <hr />
        <div class="mb-3">
            <asp:CheckBox ID="chkConfirmarEliminacionMed" runat="server" Text="Confirmar" />
            <asp:Button ID="btnConfirmarEliminacion" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" OnClick="btnConfirmarEliminacion_Click"/>
        </div>

        <% } %>
    </div>
    <h5 style="padding-top: 20px;">
        <asp:Label ID="Validaciones" CssClass="h5" runat="server" /></h5>
</asp:Content>
