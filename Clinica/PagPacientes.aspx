<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagPacientes.aspx.cs" Inherits="Clinica.PagPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .boton {
            background-color: #fff;
            border-color: #fff;
        }        
        .barra{
            display: flex;
            flex-direction: row;
        }
    </style>

    <div class="barra">
    <asp:TextBox CssClass="form-control me-1" placeholder="Buscar paciente por DNI, nombre o apellido" runat="server" ID="Filtro"></asp:TextBox>
    <asp:Button ID="btnBuscar" runat="server" Text="🔎" class="btn boton" onclick="btnBuscar_Click"/>
    </div>

    <h3 style="padding-top:20px; text-align: center;"><asp:Label ID="txtBusqueda" runat="server" /></h3>

    <table class="table table-striped table-bordered">
        <thead class="table-dark">
            <tr>
                <th scope="col" style="text-align: center">ID</th>
                <th scope="col" style="text-align: center">DNI</th>
                <th scope="col" style="text-align: center">Nombre</th>
                <th scope="col" style="text-align: center">Apellido</th>
                <th scope="col" style="text-align: center">Email</th>
                <th scope="col" style="text-align: center"></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <tr style="background-color: white">
                        <th scope="row" style="text-align: center"><%#Eval("ID") %></th>
                        <td style="text-align: center"><%#Eval("DNI") %></td>
                        <td style="text-align: center"><%#Eval("Nombre") %></td>
                        <td style="text-align: center"><%#Eval("Apellido") %></td>
                        <td style="text-align: center"><%#Eval("Email") %></td>
                        <td>
                            <a href="PagAltaPaciente.aspx?id=<%#Eval("ID") %>"><i class="fas fa-search-plus" style="color: black;"></i></a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <a href="PagAltaPaciente.aspx" class="btn btn-primary">Agregar paciente</a>

</asp:Content>
