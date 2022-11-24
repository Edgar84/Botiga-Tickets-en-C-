<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="Projecte_1.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Formulari de compra</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.0/css/all.min.css" integrity="sha512-xh6O/CkQoPOWDdYTDqeRdPCVd1SpvCA9XXcUnZS2FmJNp1coAFzvtCN9BmamE+4aHK8yyUHUSCcJHgXloTyT2A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link href="/src/css/style.css" rel="stylesheet">
</head>
<body class="checkout-body">
    <form id="form3" runat="server" class="product-grid">
        <div class="container">
            <header class="d-flex flex-nowrap justify-content-between py-3 mb-4 border-bottom">
                <asp:LinkButton ID="Home" runat="server" CssClass="d-flex align-items-center mb-md-0 me-auto text-decoration-none header-logo" OnClick="GoHome">
                    <img src="/src/img/logo5.png" class="d-block d-md-none img-xs" alt="Master Ticket">
                    <img src="/src/img/logo-lg.jpg" class="d-none d-md-block img-md" alt="Master Ticket">
                </asp:LinkButton>

              <ul class="nav nav-pills">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="nav-link active bg-danger" OnClick="goToCart">
                    <i class="fa-solid fa-cart-shopping"></i>
                </asp:LinkButton>
              </ul>
            </header>
        </div>
        <div class="container">
            <h1 class="text-center mb-4">Finalitzar comanda</h1>
        </div>
        <div class="d-flex justify-content-center align-items-center mt-0 mt-md-5 checkout-box">
            <div class="card pt-4 pb-4">
                <h3 class="mb-4">Dades personals</h3>
                <div class="mb-4">
                    <asp:Label ID="Name" runat="server" Text="NOM" CssClass="text-muted d-block text-center"></asp:Label>
                    <input id="NameInput" runat="server"  type="text" class="form-control" required="required"/>
                </div>
                <div class="mb-4">
                    <asp:Label ID="DNI" runat="server" Text="DNI" CssClass="text-muted d-block text-center"></asp:Label>
                    <input id="DNIInput" runat="server" type="text" class="form-control" title="DNIInput" pattern="[0-9]{8}[A-Za-z]{1}" minlength="9" maxlength="9" required="required"/>
                </div>
                <div class="mb-4">
                    <asp:Label ID="Phone" runat="server" Text="TELÈFON" CssClass="text-muted d-block text-center"></asp:Label>
                    <input id="PhoneInput" runat="server" type="tel" class="form-control" title="PhoneInput" pattern="[0-9]{9}" minlength="9" maxlength="9" required="required"/>
                </div>
                <asp:Button ID="PlaceOrder" runat="server" Text="Realitzar comanda" CssClass="btn btn-danger" OnClick="PlaceOrder_Click"/>
            </div>
        </div>
    </form>
    
    <div class="container container-footer">
        <footer class="my-4">
        <p class="text-center text-muted">© Edgar Capafons |  Projecte 1 - 2DAM</p>
        </footer>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <script src="/src/js/functions.js"></script>
</body>
</html>

