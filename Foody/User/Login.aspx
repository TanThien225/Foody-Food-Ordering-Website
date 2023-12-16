<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Foody.User.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                var lblMsgElement = document.getElementById("<%=lblMsg.ClientID%>");
                if (lblMsgElement) {
                    lblMsgElement.style.display = "none";
                }
            }, seconds * 1000);
        };
    </script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="book_section layout_padding">
        <div class="container">
            <div class="heading_container">
                <div class="align-self-end">
                    <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                </div>
                <asp:Label ID="lblHeaderMsg" runat="server" Text="<h2>Login</h2>"></asp:Label>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form_container">
                        <img id="userLogin" src="../Images/login.jpg" alt="" class="img-thumbnail" />
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form_container">
                        <asp:Panel ID="LoginPanel" runat="server" DefaultButton="btnLogin">
                            <%-- Username --%>
                            <div>
                                <asp:RequiredFieldValidator ID="rfcUsername" runat="server" ErrorMessage="Username is required"
                                    ControlToValidate="txtUsername" ForeColor="Red" Display="Dynamic"
                                    SetFocusOnError="true" Font-Size="Small">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"
                                    placeholder="Enter Username" ToolTip="Username">
                                </asp:TextBox>
                            </div>

                            <%-- Password --%>
                            <div>
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password is required"
                                    ControlToValidate="txtPassword" ForeColor="Red" Display="Dynamic"
                                    SetFocusOnError="true" Font-Size="Small">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"
                                    placeholder="Enter Password" ToolTip="Password" TextMode="Password">
                                </asp:TextBox>
                            </div>

                            <%-- Btn Login --%>
                            <div class="btn_box">
                                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn pl-4 pr-4"
                                    Style="width: 200px; outline: none; color: #DAA06D; padding: 1em; padding-left: 3em; padding-right: 3em; border: 2px dashed #DAA06D; border-radius: 15px; background-color: #EADDCA; box-shadow: 0 0 0 4px #EADDCA, 2px 2px 4px 2px rgba(0, 0, 0, 0.5); transition: .1s ease-in-out, .4s color;"
                                    OnClick="btnLogin_Click" />

                                <script type="text/javascript">
                                    var btnStyled = document.getElementById('<%= btnLogin.ClientID %>');

                                    btnStyled.addEventListener('mousedown', function () {
                                        btnStyled.style.transform = 'translateX(0.1em) translateY(0.1em)';
                                        btnStyled.style.boxShadow = '0 0 0 4px #EADDCA, 1.5px 1.5px 2.5px 1.5px rgba(0, 0, 0, 0.5)';
                                    });

                                    btnStyled.addEventListener('mouseup', function () {
                                        btnStyled.style.transform = 'none';
                                        btnStyled.style.boxShadow = '0 0 0 4px #EADDCA, 2px 2px 4px 2px rgba(0, 0, 0, 0.5)';
                                    });

                                    console.log(btnStyled);
                                    btnStyled.addEventListener('keydown', function (event) {
                                        console.log('keydown event');
                                        if (event.key === 'Enter') {
                                            event.preventDefault();
                                            console.log('mousedown event');
                                            // Find the button by ID and trigger a click
                                            if (btnLogin) {
                                                btnLogin.onclick();
                                            }
                                        }
                                    });

                                </script>
                                <span class="pl-3">Don't have an account?
                                <a href='Registration.aspx' class='badge badge-lg' style='text-decoration: underline; color: #DAA06D;'>Sign up now</a>
                                </span>
                                <%--<asp:Label ID="lblAlreadyUser" runat="server" CssClass="pl-3 text-black-100"
                                Text="Already register? <a href='Login.aspx' class='badge badge-lg' style='text-decoration: underline; Color: Black;'>Login here</a>">
                            </asp:Label>--%>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>

        </div>
    </section>

</asp:Content>
