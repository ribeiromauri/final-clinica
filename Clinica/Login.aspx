<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Clinica.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Bienvenido a Clinica</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.15.3/css/all.css" integrity="sha384-SZXxX4whJ79/gErwcOYf+zWLeJdY/qpuqC4cAa9rOGUstPomtqpuNWT9wdPEn2fk" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <style>
        .centrado {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="centrado">
            <div class="mb-3">
                <h4 style="text-align: center; padding-bottom: 15px;">Ingresar al sistema</h4>
                <label for="dniUsuario" class="form-label">DNI del usuario</label>
                <asp:TextBox runat="server" CssClass="form-control" type="number" required="required" ID="dniUsuario" />
            </div>

            <div class="mb-3">
                <label for="passUsuario" class="form-label">Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" type="password" required="required" ID="passUsuario" />
            </div>
            <asp:Button ID="btnLoguear" runat="server" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnLoguear_Click"/>
        </div>
    </form>
</body>
</html>
