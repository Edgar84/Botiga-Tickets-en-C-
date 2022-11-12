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

        <section class="h-100 h-custom">
          <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
              <div class="col">
                <div class="card">
                  <div class="card-body p-4">
                    <div class="row">
                      <div class="col-12">
                        <!-- Card -->
                        <div class="card mb-3"> 
                          <div class="card-body">
                            <div class="row justify-content-between">
                              <div class="col-12 col-md-8 d-flex flex-row align-items-center mb-3 mb-md-0 flex-md-nowrap flex-wrap">
                                <div class="card-body_img mb-3 mb-md-0">
                                  <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-shopping-carts/img1.webp"
                                    class="img-fluid rounded-3" alt="Shopping item" style="width: 65px;">
                                </div>
                                <div class="ms-3">
                                  <h5 class="card-body_title">Iphone 11 pro</h5>
                                  <p class="small mb-0 card-body_decription">En un lugar de la mancha de cuyo nombre no quiero acordarme...</p>
                                </div>
                              </div>
                              <div class="col-12 col-md-4 d-flex flex-row align-items-center card-body_details">
                                <div>
                                  <select class="form-select form-select-sm">
                                    <option value=""></option>
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3" selected="selected">3</option>
                                    <option value="4">4</option>
                                    <option value="5">5</option>
                                    <option value="6">6</option>
                                    <option value="7">7</option>
                                    <option value="8">8</option>
                                    <option value="9">9</option>
                                    <option value="10">10</option>
                                </select>
                                </div>
                                <div class="text-center">
                                  <h5 class="mb-0">$900</h5>
                                </div>
                                <a href="#!" style="color: #cecece;"><i class="fas fa-trash-alt"></i></a>
                              </div>
                            </div>
                          </div>
                        </div>
                        <!-- End Card -->
                        <!-- Card -->
                        <div class="card mb-3"> 
                          <div class="card-body">
                            <div class="row justify-content-between">
                              <div class="col-12 col-md-8 d-flex flex-row align-items-center mb-3 mb-md-0 flex-md-nowrap flex-wrap">
                                <div class="card-body_img mb-3 mb-md-0">
                                  <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-shopping-carts/img1.webp"
                                    class="img-fluid rounded-3" alt="Shopping item" style="width: 65px;">
                                </div>
                                <div class="ms-3">
                                  <h5 class="card-body_title">Iphone 11 pro</h5>
                                  <p class="small mb-0 card-body_decription">En un lugar de la mancha de cuyo nombre no quiero acordarme...</p>
                                </div>
                              </div>
                              <div class="col-12 col-md-4 d-flex flex-row align-items-center card-body_details">
                                <div>
                                  <select class="form-select form-select-sm">
                                    <option value=""></option>
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3" selected="selected">3</option>
                                    <option value="4">4</option>
                                    <option value="5">5</option>
                                    <option value="6">6</option>
                                    <option value="7">7</option>
                                    <option value="8">8</option>
                                    <option value="9">9</option>
                                    <option value="10">10</option>
                                </select>
                                </div>
                                <div class="text-center">
                                  <h5 class="mb-0">$900</h5>
                                </div>
                                <a href="#!" style="color: #cecece;"><i class="fas fa-trash-alt"></i></a>
                              </div>
                            </div>
                          </div>
                        </div>
                        <!-- End Card -->
                          <!-- Card -->
                        <div class="card mb-3"> 
                          <div class="card-body">
                            <div class="row justify-content-between">
                              <div class="col-12 col-md-8 d-flex flex-row align-items-center mb-3 mb-md-0 flex-md-nowrap flex-wrap">
                                <div class="card-body_img mb-3 mb-md-0">
                                  <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-shopping-carts/img1.webp"
                                    class="img-fluid rounded-3" alt="Shopping item" style="width: 65px;">
                                </div>
                                <div class="ms-3">
                                  <h5 class="card-body_title">Iphone 11 pro</h5>
                                  <p class="small mb-0 card-body_decription">En un lugar de la mancha de cuyo nombre no quiero acordarme...</p>
                                </div>
                              </div>
                              <div class="col-12 col-md-4 d-flex flex-row align-items-center card-body_details">
                                <div>
                                  <select class="form-select form-select-sm">
                                    <option value=""></option>
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3" selected="selected">3</option>
                                    <option value="4">4</option>
                                    <option value="5">5</option>
                                    <option value="6">6</option>
                                    <option value="7">7</option>
                                    <option value="8">8</option>
                                    <option value="9">9</option>
                                    <option value="10">10</option>
                                </select>
                                </div>
                                <div class="text-center">
                                  <h5 class="mb-0">$900</h5>
                                </div>
                                <a href="#!" style="color: #cecece;"><i class="fas fa-trash-alt"></i></a>
                              </div>
                            </div>
                          </div>
                        </div>
                        <!-- End Card -->
                          <!-- Card -->
                        <div class="card mb-3"> 
                          <div class="card-body">
                            <div class="row justify-content-between">
                              <div class="col-12 col-md-8 d-flex flex-row align-items-center mb-3 mb-md-0 flex-md-nowrap flex-wrap">
                                <div class="card-body_img mb-3 mb-md-0">
                                  <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-shopping-carts/img1.webp"
                                    class="img-fluid rounded-3" alt="Shopping item" style="width: 65px;">
                                </div>
                                <div class="ms-3">
                                  <h5 class="card-body_title">Iphone 11 pro</h5>
                                  <p class="small mb-0 card-body_decription">En un lugar de la mancha de cuyo nombre no quiero acordarme...</p>
                                </div>
                              </div>
                              <div class="col-12 col-md-4 d-flex flex-row align-items-center card-body_details">
                                <div>
                                  <select class="form-select form-select-sm">
                                    <option value=""></option>
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3" selected="selected">3</option>
                                    <option value="4">4</option>
                                    <option value="5">5</option>
                                    <option value="6">6</option>
                                    <option value="7">7</option>
                                    <option value="8">8</option>
                                    <option value="9">9</option>
                                    <option value="10">10</option>
                                </select>
                                </div>
                                <div class="text-center">
                                  <h5 class="mb-0">$900</h5>
                                </div>
                                <a href="#!" style="color: #cecece;"><i class="fas fa-trash-alt"></i></a>
                              </div>
                            </div>
                          </div>
                        </div>
                        <!-- End Card -->

                        <!-- navigation -->

                        <div class="d-flex justify-content-between align-items-center mb-4 mt-5 flex-wrap card-body_totals">
                          <div class="mb-4 mb-md-0">
                            <p class="mb-0">You have 4 items in your cart</p>
                          </div>
                          <div>
                            <h5 class="mb-0"><span class="text-muted me-2">Total:</span> 
                                <asp:Label ID="totalPrice" runat="server" Text="250€" CssClass="text-body"></asp:Label>
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
</body>
</html>
