<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagMedicos.aspx.cs" Inherits="Clinica.PagMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <table class="table table-striped table-bordered">
        <thead>
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Nombre</th>
                <th scope="col">Apellido</th>
                <th scope="col">Número Matricula</th>
                <th scope="col">Email</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%#Eval("ID") %></th>
                        <td><%#Eval("Nombre") %></td>
                        <td><%#Eval("Apellido") %></td>
                        <td><%#Eval("Matricula") %></td>
                        <td><%#Eval("Email") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <a class="btn btn-primary" href="PagAltaMedico.aspx">Alta Medico</a>
</asp:Content>
