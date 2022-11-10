<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagRecepcionista.aspx.cs" Inherits="Clinica.PagRecepcionista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table table-striped table-bordered">
        <thead class="table-dark">
            <tr>
                <th scope="col">ID</th>
                <th scope="col">DNI</th>
                <th scope="col">Nombre</th>
                <th scope="col">Apellido</th>
                <th scope="col">Email</th>
                <th scope="col">Accion</th>
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
                            <a href="PagAltaRecepcionista.aspx?id=<%#Eval("ID") %>">Accion</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <a href="PagAltaRecepcionista.aspx" class="btn btn-primary">Agregar Recepcionista</a>

</asp:Content>
