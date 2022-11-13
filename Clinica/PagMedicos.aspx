<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagMedicos.aspx.cs" Inherits="Clinica.PagMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table table-striped table-bordered">
        <thead class="table-dark">
            <tr>
                <th scope="col" style="text-align: center">ID</th>
                <th scope="col" style="text-align: center">Nombre</th>
                <th scope="col" style="text-align: center">Apellido</th>
                <th scope="col" style="text-align: center">Número Matricula</th>
                <th scope="col" style="text-align: center">Email</th>
                <th scope="col" style="text-align: center"></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <tr>
                        <th scope="row" style="text-align: center"><%#Eval("ID") %></th>
                        <td style="text-align: center"><%#Eval("Nombre") %></td>
                        <td style="text-align: center"><%#Eval("Apellido") %></td>
                        <td style="text-align: center"><%#Eval("Matricula") %></td>
                        <td style="text-align: center"><%#Eval("Email") %></td>
                        <td>
                            <a href="PagAltaMedico.aspx?id=<%#Eval("ID") %>"><i class="fas fa-search-plus" style="color: black;"></i></a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <a class="btn btn-primary" href="PagAltaMedico.aspx">Agregar médico</a>
</asp:Content>
