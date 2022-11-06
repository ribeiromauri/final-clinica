<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagAltas.aspx.cs" Inherits="Clinica.PagAltas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-family:Georgia (serif); font-size: xx-large; text-align: center; font-weight:600">
        <p>ALTA MÉDICO</p>
    </div>
    <div class="mb-3">
        <input class="form-control" type="text" placeholder=".form-control-lg" aria-label=".form-control-lg example" id="">
    </div>
    <div class="mb-3">
        <input class="form-control" type="password" placeholder=".form-control-lg" aria-label=".form-control-lg example" id="">
    </div>
    <div class="mb-3">
        <input class="form-control" type="text" placeholder=".form-control-lg" aria-label=".form-control-lg example" id="">
    </div>
    <a class="btn btn-success">Agregar</a>
    <a class="btn btn-danger" href="PagMedicos.aspx">Volver</a>

</asp:Content>
