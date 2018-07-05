<%@ Page Title="GIS - Cadastro Empresa" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="frmEmpresa.aspx.vb" Inherits="Backend.frmEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
            
    <style type="text/css">
        .style3
        {
            width: 429px;
        }
    </style>
     <script language="JavaScript" type="text/javascript" src="../Scripts/MascaraValidacao.js"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="0" width="800" height="100%">
        <tr>
            <td colspan="2">
                <nav id="navToolBar">
							<ul>
                                <li><asp:ImageButton id="btnNovo" runat="server" ImageUrl="~/Imagens/add.ico" 
                                        style="margin-top:5px;" EnableTheming="True" ToolTip="Novo" /> </li>
								<li><asp:ImageButton id="btnGravar" runat="server" 
                                        ImageUrl="~/Imagens/save_disabled.png" Enabled="False" 
                                        style="height: 24px" ToolTip="Gravar" /></li>
								<li><asp:ImageButton id="btnCancelar" runat="server" 
                                        ImageUrl="~/Imagens/no_disabled.png" Enabled="False" ToolTip="Cancelar" /></li>
								<li><asp:Label ID="Label1" runat="server" Text="Filtro:" />
                                <asp:DropDownList id="cmbFiltro" runat="server" Width="180px" >
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Código</asp:ListItem>
                                    <asp:ListItem>Razão social</asp:ListItem>
                                    <asp:ListItem>Nome fantasia</asp:ListItem>
                                    <asp:ListItem>CNPJ</asp:ListItem>
                                    <asp:ListItem>Nome cobrança</asp:ListItem>
                                    <asp:ListItem>Departamento</asp:ListItem>
                                 </asp:DropDownList>
                                 <asp:TextBox runat="server" id="txtFiltro" Width="171px" />  
                                 <asp:ImageButton id="btnConsultar" runat="server" ImageUrl="~/Imagens/find.ico" 
                                        ToolTip="Consultar" />
								</li>					
								
							</ul>
						</nav>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel runat="server" ID="pnlMsg" Visible="False" Style="width: 64%; margin-left: 25%;
                    margin-top: 10px; background-color: #FFFACD; height: 34px; border: 1px solid #FFE4B5;"
                    HorizontalAlign="Center">
                    <p style="margin-top: 7px;">
                        <asp:Label runat="server" ID="lblMsg" Font-Bold="True" Font-Size="Small" ForeColor="Black" /></p>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <fieldset class="frame">
                    <legend style="color: #B0C4DE;">Dados</legend>
                    <table>
                        <tr>
                            <td>
                                Código
                            </td>
                            <td>
                                <asp:TextBox ID="txtCodigo" runat="server" Enabled="False" Width="103px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Razão social*
                            </td>
                            <td style="margin-left: 40px">
                                <asp:TextBox ID="txtRazaoSocial" runat="server" MaxLength="200" Width="386px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nome fantasia
                            </td>
                            <td>
                                <asp:TextBox ID="txtNomeFantasia" runat="server" MaxLength="200" Width="386px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                CNPJ*
                            </td>
                            <td>
                                <asp:TextBox ID="txtCNPJ" runat="server" MaxLength="18" Width="202px" onkeyPress="MascaraCNPJ(ctl00$MainContent$txtCNPJ);" onblur="ValidarCNPJ(ctl00$MainContent$txtCNPJ);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                IE
                            </td>
                            <td>
                                <asp:TextBox ID="txtIE" runat="server" Width="202px" MaxLength="12"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                IM
                            </td>
                            <td>
                                <asp:TextBox ID="txtIM" runat="server" Width="202px" MaxLength="11"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Status*
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbStatus" runat="server" Width="202px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset class="frame">
                    <legend style="color: #B0C4DE;">Dados Cobrança</legend>
                    <table id="tabEnderecoCobranca">
                        <tr>
                            <td>
                                Nome
                            </td>
                            <td>
                                <asp:TextBox ID="txtNome" runat="server" MaxLength="100" Width="383px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Departamento
                            </td>
                            <td>
                                <asp:TextBox ID="txtDepartamento" runat="server" MaxLength="50" Width="383px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                CEP
                            </td>
                            <td>
                                <asp:TextBox ID="txtCEP" runat="server" MaxLength="10" Width="179px" 
                                    onkeypress="MascaraCep(ctl00$MainContent$txtCEP);"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Endereço
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndereco" runat="server" MaxLength="200" Width="383px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Cidade
                            </td>
                            <td>
                                <asp:TextBox ID="txtCidade" runat="server" MaxLength="100" Width="383px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                UF
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="txtUF" runat="server" MaxLength="2" Width="57px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Telefone
                            </td>
                            <td>
                                <asp:TextBox ID="txtTelefone" runat="server" MaxLength="20" Width="179px" onkeypress="MascaraTelefone(ctl00$MainContent$txtTelefone);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Email
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" Width="386px" MaxLength="200"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="800" height="100%">
        <tr>
            <td colspan="2">
                <asp:Panel runat="server" ID="pnlExcluir" Visible="false" Height="44px">
                    <table width="99%" style="background-color: #FFDAB9; height: 41px; border: 1px solid #CD3333;
                        margin-left: 10px;">
                        <tr>
                            <td class="style3">
                                <span style="margin-left: 200px; font-size: medium; color: #CD3333;">Deseja excluir
                                    esse registro?</span>
                            </td>
                            <td>
                                <asp:Button ID="btnSim" runat="server" Text="SIM" Width="76px" />
                                <asp:Button ID="btnNao" runat="server" Text="NÃO" Width="76px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal" Style="margin-left: 10px;
                    margin-top: 20px; max-height: 224px; max-width: 900px;">
                    <asp:GridView ID="gridEmpresa" runat="server" Style="margin-top: 0px; margin-left: 0px;"
                        CellPadding="4" ForeColor="#333333" Font-Size="Small">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" Height="30px"
                            Wrap="False" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" Wrap="False" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td valign="top" height="100%">
                &nbsp;
            </td>
        </tr>
    </table>
                    </table>
</asp:Content>
