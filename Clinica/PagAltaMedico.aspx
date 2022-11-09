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
            <asp:TextBox CssClass="form-control inputSize" ID="nombreMedico" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Apellido</label>
            <asp:TextBox CssClass="form-control inputSize" ID="apellidoMedico" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">DNI</label>
            <asp:TextBox CssClass="form-control inputSize" ID="dniMedico" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Matricula</label>
            <asp:TextBox CssClass="form-control inputSize" ID="matriculaMedico" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Email</label>
            <asp:TextBox CssClass="form-control inputSize" ID="emailMedico" runat="server" type="email"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Contraseña</label>
            <asp:TextBox CssClass="form-control inputSize" ID="passMedico" runat="server" type="password"></asp:TextBox>
        </div>
        <h6>Seleccionar especialidad:</h6>
        <asp:CheckBoxList ID="chkEspecialidades" runat="server" RepeatColumns="3"></asp:CheckBoxList>

    </div>
    <div class="mb-3">
        <asp:Button ID="Agregar" runat="server" Text="Agregar" CssClass="btn btn-success" OnClick="Agregar_Click" />
        <a href="PagMedicos.aspx" class="btn btn-warning">Volver</a>
    </div>
</asp:Content>
