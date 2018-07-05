<%@ Page Title="GIS - Questionário" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmQuestionario.aspx.vb" Inherits="Backend.frmQuestionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
        .style3
        {
            width: 429px;
        }
        .style4
        {
            height: 50px;
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
							<ul style="margin-left:50%; padding-left:50;">
                                <li><asp:ImageButton id="btnNovo" runat="server" ImageUrl="~/Imagens/add.ico" 
                                        style="margin-top:5px; height: 24px;" EnableTheming="True" 
                                        ToolTip="Novo" /> </li>
								<li><asp:ImageButton id="btnGravar" runat="server" 
                                        ImageUrl="~/Imagens/save_disabled.png" Enabled="False" ToolTip="Gravar" /></li>
								<li><asp:ImageButton id="btnCancelar" runat="server" 
                                        ImageUrl="~/Imagens/no_disabled.png" Enabled="False" ToolTip="Cancelar" /></li>
                                <li><asp:ImageButton id="btnFinalizar" runat="server" 
                                        ImageUrl="~/Imagens/accept_disabled.png" Enabled="False" 
                                        ToolTip="Finalizar" /></li>		
							</ul>
						</nav>
					</td>					
				</tr>

                <tr>
                    <td colspan="2">
                        <asp:Panel runat="server" ID="pnlMsg" Visible=False 
                            style="width: 64%; margin-left: 25%; margin-top: 10px; background-color:#FFFACD; height: 34px; border:1px solid #FFE4B5;" 
                            HorizontalAlign="Center">
                            <p style="margin-top:7px;">
                                <asp:Label runat="server" ID="lblMsg" Font-Bold="True" 
                                    Font-Size="Small" ForeColor="Black" /></p>
                        </asp:Panel>
                    </td>
                </tr>
				
				<tr>
					<td colspan="2">
                        <fieldset class="frame" style="width:68%;">	
							<legend style="color:#B0C4DE;">Filtro</legend>
							    <table>
                                    <tr>
									    <td>Empresa*</td> <td>   
                                        <asp:UpdatePanel ID="pnlEmpresa" runat="server">
                                            <ContentTemplate >                        
                                                <asp:DropDownList ID="cmbEmpresa" AutoPostBack="true" runat="server" Width="476px" Height="19px">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID ="cmbEmpresa" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        </td>
								    </tr> 
                                    
                                    <tr>
									    <td>Competência*</td> <td>                         
                                        <asp:DropDownList ID="cmbCompetencia" runat="server" Width="202px">
                                        </asp:DropDownList>
                                        </td>
								    </tr>    

                                    <tr>
									    <td>Categoria</td> <td>        
                                        <asp:UpdatePanel ID="pnlCategoria" runat="server">
                                            <ContentTemplate >                     
                                                <asp:DropDownList ID="cmbCategoria" AutoPostBack="true" runat="server" Width="476px" Height="19px">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID ="cmbCategoria" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        </td>
								    </tr>
                                                                        						                                    
							    </table>                            								
							</fieldset>
                            <fieldset class="frame" style="width:68%;">	
							    <legend style="color:#B0C4DE;">Campos</legend>
                                    <table>
                                        <tr>
									        <td>Área*</td> <td>     
                                                <asp:UpdatePanel ID="pnlArea" runat="server">
                                                    <ContentTemplate >                     
                                                        <asp:DropDownList ID="cmbArea" AutoPostBack="true" runat="server" Width="269px" Height="22px">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID ="cmbArea" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
								        </tr>  	

                                        <tr>
									        <td></td> <td>     
                                                <asp:UpdatePanel ID="plnRepresentante" runat="server">
                                                    <ContentTemplate >                     
                                                        <asp:Label AutoPostBack="true" runat="server" ID="lblRepresentante" Font-Bold="true">
                                                        </asp:Label>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID ="cmbArea" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
								        </tr>

                                        <tr>
									        <td>Prazo</td> <td>     
                                                <asp:UpdatePanel ID="pnlPrazo" runat="server">
                                                    <ContentTemplate >                     
                                                        
                                                        <asp:TextBox ID="txtPrazo" AutoPostBack="true" runat="server" 
                                                            onkeypress="MascaraData(ctl00$MainContent$txtPrazo)" MaxLength="10"></asp:TextBox>
                                                        
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID ="txtPrazo" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
								        </tr>
                                    

                                    </table>
                            </fieldset>                           
					</td>
				</tr>

            </table>
			
            
            <table  border="0" cellpadding="0" cellspacing="0" width="800" height="100%">	  
            
                <tr>
                    <td colspan="2">
                        <asp:Panel runat="server" ID="pnlFinalizar" Visible="false" Height="44px">
                            <table width="99%" style="background-color:#FFDAB9; height: 41px; border:1px solid #CD3333; margin-left:10px;">
                                <tr>
                                    <td class="style3">
                                        <span style="margin-left:200px; font-size:medium; color:#CD3333;">Deseja finalizar o questionário?</span>
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
                        <asp:Panel runat="server" ID="pnlExcluirQuestionario" Visible="false" Height="44px">
                            <table width="99%" style="background-color:#FFDAB9; height: 41px; border:1px solid #CD3333; margin-left:10px;">
                                <tr>
                                    <td class="style3">
                                        <span style="margin-left:200px; font-size:medium; color:#CD3333;">Deseja excluir o questionario?</span>
                                    </td> 
                                    <td>
                                        <asp:Button ID="btnSimQuestionario" runat="server" Text="SIM" Width="76px" />
                                        <asp:Button ID="btnNaoQuestionario" runat="server" Text="NÃO" Width="76px" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>

                <tr>
					<td colspan="2" class="style4">
                        <asp:UpdatePanel ID="pnlQuestionario" runat="server">
                            <ContentTemplate >
                            <asp:Panel ID="Panel2"  runat="server" ScrollBars="Horizontal" style="margin-left:auto; margin-right:auto; margin-top:20px; max-height:224px;" Width="900px">
						        <asp:GridView ID="gridQuestionario" runat="server" 
                                    style="margin-top: 0px; margin-left:auto; margin-right:auto;" CellPadding="4" ForeColor="#333333" 
                                    Font-Size="Small">
                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#7C6F57" />
                                    <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" 
                                        Height="30px" Wrap="False" />
                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#E3EAEB" Wrap="False" />
                                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                                </asp:GridView> 
                            </asp:Panel>
                            </ContentTemplate>     
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID ="gridQuestao" />
                            </Triggers>
                        </asp:UpdatePanel>                                
					</td>
				</tr>
                          
				<tr>
					<td colspan="2" class="style4">
                        <asp:UpdatePanel ID="pnlQuestoes" runat="server">
                            <ContentTemplate >
                            <asp:Panel ID="Panel1"  runat="server" ScrollBars="Horizontal" style="margin-left:auto; margin-right:auto; margin-top:20px; max-height:224px;" Width="900px">
						        <asp:GridView ID="gridQuestao" runat="server" 
                                    style="margin-top: 0px; margin-left:auto; margin-right:auto;" CellPadding="4" ForeColor="#333333" 
                                    Font-Size="Small">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkQuestao" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ordem">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtOrdem" runat="server" Width="35px"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#7C6F57" />
                                    <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" 
                                        Height="30px" Wrap="False" />
                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#E3EAEB" Wrap="False" />
                                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                                </asp:GridView> 
                            </asp:Panel>
                            </ContentTemplate>     
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID ="gridQuestao" />
                            </Triggers>
                        </asp:UpdatePanel>                                
					</td>
				</tr>                
                
                <tr>
					<td valign="top" height="100%">
						
					</td>					
				</tr>			
			</table>
</asp:Content>
