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
        <asp:CheckBoxList ID="chkEspecialidades" runat="server" RepeatColumns="6"></asp:CheckBoxList>
        <hr />
        <h6>Seleccionar día y horario de trabajo:</h6>
        <asp:CheckBoxList ID="chkDiasTrabajo" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
        <div class="mb-3">
            <h6>Horario Entrada:</h6>
            <asp:TextBox ID="txtHorarioEntrada" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <div class="mb-3">
            <h6>Horario Salida:</h6>
            <asp:TextBox ID="txtHorarioSalida" runat="server" TextMode="Number"></asp:TextBox>
        </div>

        <!--Otra opcion-->

         <table class="table table-striped table-bordered">
        <thead class="table-dark">
            <tr>
                <th scope="col" style="text-align: center">Dia</th>
                <th scope="col" style="text-align: center">Hora entrada</th>
                <th scope="col" style="text-align: center">Hora salida</th>
                <th scope="col" style="text-align: center">Día libre</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <tr>
                        <th scope="row" style="text-align: center"></th>
                        <td style="text-align: center">
                            <asp:DropDownList ID="horaEntrada" runat="server"></asp:DropDownList>
                        </td>
                        <td style="text-align: center">
                            <asp:DropDownList ID="horaSalida" runat="server"></asp:DropDownList>
                        </td>
                        <td style="text-align: center">
                            <asp:CheckBox runat="server" ID="diaLibre" />
                        </td>
                                                
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    </div>
    <div class="mb-3">
        <asp:Button ID="Agregar" runat="server" Text="Agregar" CssClass="btn btn-success" OnClick="Agregar_Click" />
        <a href="PagMedicos.aspx" class="btn btn-warning">Volver</a>
        <%if (BotonEliminar)
            {%>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btnEliminar_Click" />
        <%} %>
        <%if (ConfirmarEliminacion)
            {%>
        <hr />
        <div class="mb-3">
            <asp:CheckBox ID="chkConfirmarEliminacionMed" runat="server" Text="Confirmar" />
            <asp:Button ID="btnConfirmarEliminacion" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" OnClick="btnConfirmarEliminacion_Click" />
        </div>

        <% } %>
    </div>
    <h5 style="padding-top: 20px;">
        <asp:Label ID="Validaciones" CssClass="h5" runat="server" /></h5>
</asp:Content>
