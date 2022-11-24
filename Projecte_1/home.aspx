<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Projecte_1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Master Ticket</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.0/css/all.min.css" integrity="sha512-xh6O/CkQoPOWDdYTDqeRdPCVd1SpvCA9XXcUnZS2FmJNp1coAFzvtCN9BmamE+4aHK8yyUHUSCcJHgXloTyT2A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link href="/src/css/style.css" rel="stylesheet">
</head>
<body>
    <form id="form2" runat="server" class="product-grid">
        <div class="container">
            <header class="d-flex flex-nowrap justify-content-between py-3 mb-4 border-bottom">
              <asp:HyperLink ID="Home" runat="server" CssClass="d-flex align-items-center mb-md-0 me-auto text-decoration-none header-logo" OnClick="goHome">
                <img src="/src/img/logo5.png" class="d-block d-md-none img-xs" alt="Master Ticket">
                <img src="/src/img/logo-lg.jpg" class="d-none d-md-block img-md" alt="Master Ticket">
              </asp:HyperLink>

              <ul class="nav nav-pills">
                <li class="nav-item">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="nav-link active bg-danger" OnClick="goToCart">
                        <i class="fa-solid fa-cart-shopping"></i>
                    </asp:LinkButton>
                </li>
              </ul>
            </header>
        </div>
        <section class="container product-grid">
           <div class="p-0 mt-5 mb-5">
               <div id="productContainer" runat="server" class="row row-cols-1 row-cols-lg-4 row-cols-md-2 g-4">
                    
               </div>
            </div>
            <asp:Label ID="consolelog" runat="server" Text="" CssClass="alert alert-danger d-none"></asp:Label>
        </section>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="borrarCookies" CssClass="cookie" title="Borrar cookies"/>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </form>
    <div class="container container-footer">
        <footer class="my-4">
        <p class="text-center text-muted">© Edgar Capafons |  Projecte 1 - 2DAM</p>
        </footer>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
</body>
</html>

