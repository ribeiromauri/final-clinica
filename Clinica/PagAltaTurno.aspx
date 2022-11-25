<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagAltaTurno.aspx.cs" Inherits="Clinica.PagAltaTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .boton {
            background-color: #fff;
            border-color: #fff;
        }

        .validaciones {
            display: inline-flex;
        }
    </style>
    <div style="font-family: Georgia (serif); font-size: xx-large; text-align: center; font-weight: 600" class="mb-3">
        <p>TURNOS MÉDICOS</p>
    </div>
    <div style="display: flex; flex-direction: column; justify-content: center;" class="mb-3">
        <div style="display: inline-flex;">
            <label class="form-label">DNI Paciente</label>
            <asp:TextBox CssClass="form-control inputSize" ID="DNI" runat="server" required="required" TextMode="Number"></asp:TextBox>
            <asp:Button CssClass="btn boton" ID="buscarPacinte" runat="server" Text="🔎" OnClick="buscarPaciente_Click" />
        </div>
        <div class="mb-3">
            <h5 style="text-align: center;">
                <asp:Label ID="txtValidar" CssClass="h5" runat="server" Visible="false" /></h5>
            <a href="PagAltaPaciente.aspx">
                <h5 style="text-align: center;">
                    <asp:Label ID="txtAlta" runat="server" Visible="false" /></h5>
            </a>
        </div>
        <div class="validaciones">
            <asp:RadioButtonList runat="server" ID="paciente" Visible="false"></asp:RadioButtonList>
            <asp:Button runat="server" ID="seleccionar" Visible="false" Text="✔" CssClass="btn boton" />
            <asp:Button runat="server" ID="cancelar" Visible="false" Text="✖" CssClass="btn boton" OnClick="cancelar_Click" />
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
                <asp:DropDownList ID="ddlMedicos" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMedicos_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <%if (ValidarDias)
            { %>
        <div class="mb-3">
            <table class="table-striped table-bordered">
                <thead>
                    <tr>
                        <th scope="col" style="text-align: center">Dias Laborales</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="repDias">
                        <ItemTemplate>
                            <tr>
                                <td scope="row" style="text-align: center"><%#Eval("Dia") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <%} %>
        <div class="mb-3">
            <asp:Calendar ID="calDias" runat="server" OnSelectionChanged="calDias_SelectionChanged"></asp:Calendar>
            <asp:Label ID="lblValidarDia" runat="server" Text=" "></asp:Label>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblTest" runat="server" Text=" "></asp:Label>
        </div>
        <div class="mb-3">
            <label class="form-label">Fecha Turno</label>
            <div>
                <asp:TextBox ID="txtFecha" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <div class="mb-3">
            <label class="form-label">Horario Turno</label>
            <div>
                <asp:DropDownList ID="ddlHorarios" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="mb-3">
            <label class="form-label">Observaciones</label>
            <asp:TextBox CssClass="form-control inputSize" ID="TextBox5" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3" style="margin-top: 30px">
            <asp:Button ID="btnAceptar" runat="server" Text="Agregar Turno" CssClass="btn btn-success" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" />
        </div>
    </div>
</asp:Content>
