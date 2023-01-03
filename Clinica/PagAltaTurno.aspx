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

        .contenedor {
            display: flex;
            flex-direction: column;
            justify-content: center;
            max-width: 500px;
            margin-left: 30%;
        }        

        .titulo{
            text-align: center;
        }

        .enLinea{
            display: flex;
            flex-direction: row;
            flex-wrap: nowrap;
        }

        .espacio{
            margin-top: 8px;
        }

        tr th{
            border-style: none;
            list-style: none;
        }
    </style>    
    <div class="contenedor">
        <h3 class="titulo">ASIGNAR TURNO</h3>      
    <label class="form-label">DNI Paciente</label>
        <div class="enLinea">
            <asp:TextBox ID="txtDNI" runat="server" required="required" TextMode="Number" CssClass="form-control inputSize"></asp:TextBox>
            <asp:Button ID="buscarPacinte" runat="server" Text="🔎" OnClick="buscarPaciente_Click"/>
        </div>
        
            <h5><asp:Label ID="txtValidar" runat="server" Visible="false"/></h5>
            <a href="PagAltaPaciente.aspx"><h5><asp:Label ID="txtAlta" runat="server" Visible="false" /></h5></a>
        
        <div class="validaciones">
            <asp:RadioButtonList runat="server" ID="paciente" Visible="false"></asp:RadioButtonList>
            <asp:Button runat="server" ID="seleccionar" Visible="false" Text="✔" CssClass="btn boton" />
            <asp:Button runat="server" ID="cancelar" Visible="false" Text="✖" CssClass="btn boton" OnClick="cancelar_Click" />
        </div>
        
       <label class="form-label">Especialidad</label>
       <div>
           <asp:DropDownList ID="ddlEspecialidades" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged" CssClass="form-control inputSize"></asp:DropDownList>
       </div>
        
       <label class="form-label">Médico</label>
       <div>
          <asp:DropDownList ID="ddlMedicos" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMedicos_SelectedIndexChanged" CssClass="form-control inputSize"></asp:DropDownList>
       </div>
        
        <%if (ValidarDias)
            { %>
        
            <table class="table-striped table-bordered">
                <thead>
                    <tr>
                        <th scope="col" class="espacio">Dias Laborales</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="repDias">
                        <ItemTemplate>
                            <tr>
                                <td scope="row"  style="text-align: center;"><%#Eval("Dia") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        
        <%} %>
        
        <label class="form-label">Elegir día</label>
        <asp:Calendar ID="calDias" runat="server" OnSelectionChanged="calDias_SelectionChanged"></asp:Calendar>
        <asp:Label ID="lblValidarDia" runat="server" Text=" "></asp:Label>
        <asp:Label ID="lblTest" runat="server" Text=" "></asp:Label>
        
        <label class="form-label">Fecha Turno</label>
        <div>
          <asp:TextBox ID="txtFecha" runat="server" ReadOnly="true" CssClass="form-control inputSize"></asp:TextBox>
        </div>
        
        <label class="form-label">Horario Turno</label>
        <div class="dropdown">
           <asp:DropDownList ID="ddlHorarios" runat="server" CssClass="form-control inputSize"></asp:DropDownList>
        </div>
        
        <label>Observaciones</label>
        <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control inputSize"></asp:TextBox>
       
        <asp:Button ID="btnAceptar" runat="server" Text="Agregar Turno" CssClass="btn btn-success espacio" OnClick="btnAceptar_Click"/>
        <a href="PagTurnos.aspx" class="btn btn-danger espacio">Cancelar</a>      
    </div>
</asp:Content>
