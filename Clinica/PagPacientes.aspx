<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagPacientes.aspx.cs" Inherits="Clinica.PagPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <table class="table table-striped table-bordered">
        <thead class="table-dark">
            <tr>
                <th scope="col">ID</th>
                <th scope="col">DNI</th>
                <th scope="col">Nombre</th>
                <th scope="col">Apellido</th>
                <th scope="col">Email</th>
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
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
