<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagPacientes.aspx.cs" Inherits="Clinica.PagPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
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
                        <th scope="row"><%#Eval("ID") %></th>
                        <td><%#Eval("DNI") %></td>
                        <td><%#Eval("Nombre") %></td>
                        <td><%#Eval("Apellido") %></td>
                        <td><%#Eval("Email") %></td>
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
