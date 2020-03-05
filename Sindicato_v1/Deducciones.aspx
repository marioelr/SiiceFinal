<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Deducciones.aspx.cs" Inherits="Sindicato_v1.Deducciones" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Ingreso de deducciones</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/deducciones-style.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script type="text/javascript">
        function successalert() {
            swal({
                title: "Confirmación",
                text: "¡Se agregaron las deducciones correctamente!",
                icon: "success"
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" class="container" enctype="multipart/form-data" style="position: center;">
        <nav class="navbar navbar-default navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="/Home/Index">SIICE</a>
                </div>
            </div>
        </nav>

        <br />
        <br />
        <br />

        <ul class="breadcrumb">
            <li><a href="/Home/Index/">SIICE - Inicio</a></li>
            <li><a href="/Usuario/Administrador/">Administrativo</a></li>
            <li><a href="/Deducciones/BusquedaDeduccion/">Gestión Deducciones</a></li>
            <li>Ingreso de deducciones</li>
        </ul>

        <div>
            <h2>Ingreso de deducciones</h2>
        </div>

        <hr class="hr-custom" />

        <center>         
            <div style="height:auto; margin-left:110px; width:auto; position:center;">
                <asp:table runat="server" ID="titulo">               
                <asp:TableRow>
                    <asp:TableCell>                        
                        <h3>Información Deducciones</h3>
                    </asp:TableCell>
                </asp:TableRow>
             </asp:Table>

                <asp:Table runat="server" ID="acciones">
                    <asp:TableRow>
                               <asp:TableCell>
                                   <asp:GridView ID="GridView" runat="server" Width="590px"></asp:GridView>
                               </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                               <asp:TableCell>
                                   <asp:FileUpload ID="FileUpload" runat="server" />
                                   <br />
                               </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Button ID="btn_Cargar" runat="server" Text="Cargar información" Width="590px" Height="40px" OnClick="btn_Cargar_Click"/>
                                <br />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Button ID="btn_Confirmar" runat="server" Text="Confirmar cambios" Width="590px" Height="40px" OnClick="btn_Confirmar_Click"/>
                                <br />
                            </asp:TableCell>
                        </asp:TableRow>
                     </asp:Table> 
            </div> 
            
            <hr class="hr-custom"/>

            <div >
                <footer>
                    <p>2019 - SIICE V1.0</p>
                </footer>
            </div>
        </center>
    </form>
</body>
</html>
