<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagAltaTurno.aspx.cs" Inherits="Clinica.PagAltaTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-family: Georgia (serif); font-size: xx-large; text-align: center; font-weight: 600" class="mb-3">
        <p>TURNOS MÉDICOS</p>
    </div>
    <div style="display: flex; flex-direction: column; justify-content: center;" class="mb-3">
        <div class="mb-3">
            <label class="form-label">DNI Paciente</label>
            <asp:TextBox CssClass="form-control inputSize" ID="DNI" runat="server" required="required" TextMode="Number"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Especialidad</label>
            <div>
                <asp:DropDownList ID="ddlEspecialidades" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <div class="mb-3">
            <label class="form-label">Médico</label>
            <div>
                <asp:DropDownList ID="ddlMedicos" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="mb-3">
            <label class="form-label">Día</label>
            <div>
                <asp:DropDownList ID="ddlDias" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="mb-3">
            <label class="form-label">Horario</label>
            <div>
                <asp:DropDownList ID="ddlHorarios" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="mb-3">
            <label class="form-label">Observaciones</label>
            <asp:TextBox CssClass="form-control inputSize" ID="TextBox5" runat="server" required="required"></asp:TextBox>
        </div>
        <div class="mb-3" style="margin-top:30px">
            <asp:Button ID="btnAceptar" runat="server" Text="Agregar Turno" CssClass="btn btn-success" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" />
        </div>
    </div>
</asp:Content>
