<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shopping_cart.aspx.cs" Inherits="Projecte_1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Carret de compra</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.0/css/all.min.css" integrity="sha512-xh6O/CkQoPOWDdYTDqeRdPCVd1SpvCA9XXcUnZS2FmJNp1coAFzvtCN9BmamE+4aHK8yyUHUSCcJHgXloTyT2A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link href="/src/css/style.css" rel="stylesheet">
</head>
<body>
    <form id="form2" runat="server" class="product-grid">
        <div class="container">
            <header class="d-flex flex-nowrap justify-content-between py-3 mb-4 border-bottom">
                <asp:LinkButton ID="Home" runat="server" CssClass="d-flex align-items-center mb-md-0 me-auto text-decoration-none header-logo" OnClick="GoHome">
                    <img src="/src/img/logo5.png" class="d-block d-md-none img-xs" alt="Master Ticket">
                    <img src="/src/img/logo-lg.jpg" class="d-none d-md-block img-md" alt="Master Ticket">
                </asp:LinkButton>

              <ul class="nav nav-pills">
                <li class="nav-item"><a href="#" class="nav-link active bg-danger" aria-current="cart"><i class="fa-solid fa-cart-shopping"></i></a></li>
              </ul>
            </header>
        </div>
        <h1 class="text-center">Carret</h1>
        <section class="h-100 h-custom">
          <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
              <div class="col">
                <div class="card">
                  <div class="card-body p-4">
                    <div class="row">
                      <div class="col-12">
                        <div id="productCardContainer" runat="server">
                            
                         </div>
                        <!-- navigation -->
                          <asp:Label ID="consoleLog" runat="server" Text=""></asp:Label>
                        <div class="d-flex justify-content-between align-items-center mb-4 mt-5 flex-wrap card-body_totals">
                          <div class="mb-4 mb-md-0">
                              <asp:Label ID="totalItems" runat="server" Text="No tens cap producte al carret." CssClass="mb-0 d-block"></asp:Label>
                          </div>
                          <div>
                            <h5 class="mb-0"><span class="text-muted me-2">Total:</span> 
                                <asp:Label ID="totalPrice" runat="server" Text="0" CssClass="text-body euro"></asp:Label>
                            </h5>
                          </div>
                        </div>
                        <hr>
                        <div class="d-flex justify-content-between align-items-center flex-wrap card-body_navigation">
                            <h5 class="mb-4 mb-md-3 mt-3 order-2 order-md-1">
                                <a href="/home.aspx" class="text-body"><i class="fas fa-long-arrow-alt-left me-2"></i>Continuar comprant</a>
                            </h5>
                            <h5 class="mb-3 mt-3 order-1 order-md-2">
                                <asp:LinkButton ID="Checkout" runat="server" CssClass="btn btn-danger" OnClick="GoCheckout">
                                    <span class="me-2">Realitzar comanda</span>
                                    <i class="fas fa-long-arrow-alt-right"></i>
                                </asp:LinkButton>
                            </h5>
                        </div>
                        
                        

                      </div>
                     </div>
                   </div>
                </div>
              </div>
            </div>
          </div>
        </section>

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