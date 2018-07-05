<%@ Page Title="GIS - Cadastro de Questão" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmQuestao.aspx.vb" Inherits="Backend.frmQuestaoIndicador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            width: 429px;
        }
        .style4
        {
            width: 112px;
        }
    </style>
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
                                        ImageUrl="~/Imagens/save_disabled.png" Enabled="False" ToolTip="Gravar" /></li>
								<li><asp:ImageButton id="btnCancelar" runat="server" 
                                        ImageUrl="~/Imagens/no_disabled.png" Enabled="False" ToolTip="Cancelar" /></li>
								<li><asp:Label ID="Label1" runat="server" Text="Filtro:" />
                                    <asp:DropDownList id="cmbFiltro" runat="server" Width="180px" >
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Código</asp:ListItem>
                                        <asp:ListItem>Questão</asp:ListItem>
                                        <asp:ListItem>Categoria</asp:ListItem>
                                        <asp:ListItem>Indicador</asp:ListItem>
                                        <asp:ListItem>Empresa</asp:ListItem>
                                        <asp:ListItem>Status</asp:ListItem>
                                        <asp:ListItem>Competência</asp:ListItem>
                                    </asp:DropDownList>
								    <asp:TextBox runat="server" id="txtFiltro" Width="171px" />                                	
									    <asp:ImageButton id="btnConsultar" runat="server" 
                                        ImageUrl="~/Imagens/find.ico" ToolTip="Consultar" />
								</li>					
								
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
                        </asp:panel>
                    </td>
                </tr>
				
				<tr>
					<td colspan="2">
                        <fieldset class="frame">	
							<legend style="color:#B0C4DE;">Dados</legend>
							    <table>
								    <tr>
									    <td>Código</td>
                                        <td>
                                            <asp:UpdatePanel ID="pnlCodigo" runat="server">
                                                <ContentTemplate >
                                                    <asp:TextBox ID="txtCodigo" runat="server" Enabled="False" Width="103px"></asp:TextBox>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID ="btnGravaItem" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
								    </tr>	
                                    
                                    <tr>
									    <td>Empresa*</td> <td>                         
                                        <asp:DropDownList ID="cmbEmpresa" runat="server" Width="404px">
                                        </asp:DropDownList>
                                        </td>
								    </tr>	    	

                                    <tr>
									    <td>Categoria*</td> <td> 
                                        
                                        <asp:UpdatePanel ID="pnlCategoria" runat="server">
                                            <ContentTemplate >                                                   
                                                 <asp:DropDownList ID="cmbCategoria" runat="server" AutoPostBack="true" Width="404px">
                                                 </asp:DropDownList>                                                
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID ="cmbCategoria" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                            
                                        </td>
								    </tr> 
                                    
                                    <tr>
									    <td>Tipo*</td> <td>                                         
                                                
                                                <asp:UpdatePanel ID="pnlTipoIndicador" runat="server" style="float:left;">
                                                    <ContentTemplate >    
                                                        <asp:RadioButton GroupName="tipo" ID="rdbIndicador" runat="server" Checked="True" 
                                                            Text="Indicador" AutoPostBack="True" /> &nbsp;&nbsp;&nbsp;&nbsp;
                                                            </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID ="rdbIndicador" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                        

                                                <asp:UpdatePanel ID="pnlTipoNovaQuestao" runat="server" style="float:none;">
                                                    <ContentTemplate > 
                                                        <asp:RadioButton GroupName="tipo" ID="rdbNovaQustao" runat="server" Text="Pergunta" 
                                                            AutoPostBack="True" />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID ="rdbNovaQustao" />
                                                    </Triggers>
                                                </asp:UpdatePanel>

                                            
                                        </td>
								    </tr>     
                                    
                                    <tr>
									    <td>
                                            <asp:UpdatePanel ID="pnlLableSub" runat="server">
                                                <ContentTemplate > 
                                                    <asp:Label ID="lblSubcategoria" runat="server">Subcategoria</asp:Label>
                                                    </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID ="rdbIndicador" />
                                                </Triggers>
                                            </asp:UpdatePanel>

                                        </td> 

                                        <td>                                         
                                            <asp:UpdatePanel ID="pnlSubcategoria" runat="server">
                                                <ContentTemplate >                                                   
                                                     <asp:DropDownList ID="cmbSubcatedoria" runat="server" AutoPostBack="true" 
                                                         Width="404px">
                                                     </asp:DropDownList>                                                
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID ="cmbSubcatedoria" />
                                                </Triggers>
                                            </asp:UpdatePanel>                                            
                                        </td>
								    </tr>     
                                    
                                    <tr>
									    <td>
                                            <asp:UpdatePanel ID="pnlLblAspecto" runat="server">
                                                <ContentTemplate >
                                                    <asp:Label ID="lblAspecto" runat="server">Aspecto*</asp:Label>
                                                </asp:DropDownList>                                                
                                                </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID ="rdbIndicador" />
                                                    </Triggers>
                                            </asp:UpdatePanel>
                                        </td> 

                                        <td>                                         
                                            <asp:UpdatePanel ID="pnlAspecto" runat="server">
                                                <ContentTemplate >                                                   
                                                     <asp:DropDownList ID="cmbAspecto" runat="server" AutoPostBack="true" 
                                                         Width="404px">
                                                     </asp:DropDownList>                                                
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID ="cmbAspecto" />
                                                </Triggers>
                                            </asp:UpdatePanel>                                            
                                        </td>
								    </tr>       
                                    
                                    <tr>
									    <td>
                                            <asp:UpdatePanel ID="pnlLblIndicador" runat="server">
                                                <ContentTemplate >
                                                    <asp:Label ID="lblIndicador" runat="server">Indicador*</asp:Label>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID ="rdbIndicador" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td> 
                                        
                                        <td>                                         
                                            <asp:UpdatePanel ID="pnlIndicador" runat="server">
                                                <ContentTemplate >                                                   
                                                     <asp:DropDownList ID="cmbIndicador" runat="server" AutoPostBack="true" 
                                                         Width="404px">
                                                     </asp:DropDownList>                                                
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID ="cmbIndicador" />
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
									    <td>Status*</td> <td>                         
                                        <asp:DropDownList ID="cmbStatus" runat="server" Width="202px">
                                        </asp:DropDownList>
                                        </td>
								    </tr>

                                    <tr>
									    <td>Questão* </td> <td style="margin-left: 40px">
                                            <asp:UpdatePanel ID="pnlQuestao" runat="server">
                                                <ContentTemplate >
                                                    <asp:TextBox ID="txtQuestao" runat="server" MaxLength="8000" Width="402px" 
                                                        Height="137px" TextMode="MultiLine"></asp:TextBox>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID ="rdbIndicador" />
                                                </Triggers>
                                            </asp:UpdatePanel>

                                        </td>
								    </tr>
							    </table>                            								
							</fieldset>                            
					</td>
				</tr>                

                <tr>
					<td colspan="2">
                        <asp:UpdatePanel ID="pnlItens" runat="server">
                            <ContentTemplate >
                            <fieldset id="frameItem" runat="server" visible="false" class="frame">	
							    <legend style="color:#B0C4DE;">Item Questão</legend>
							        <table>   
                                        <tr>
									        <td>Item</td> <td class="style4"> 
                                                <asp:Label ID="lblCodigoItem" runat="server" Visible="False"></asp:Label>
                                                <asp:TextBox ID="txtItem" runat="server" Width="404px"></asp:TextBox>
                                            </td>
                                            <td>
                                            
                                                <asp:ImageButton ID="btnGravaItem" runat="server"
                                                    ImageUrl="~/Imagens/save.ico" ToolTip="Gravar Item" />                                            
                                            </td>
								        </tr>

                                        <tr>
                                            <td colspan="3">
                                                <asp:Panel ID="pnlGridItem"  runat="server" ScrollBars="Auto"                                                 
                                                    style="margin-left:0px; margin-top:0px; max-height:2    00px; max-width:465px;">
                                                    
                                                            <asp:GridView ID="gridItemQuestao" runat="server" 
                                                                style="margin-top: 0px; margin-left:auto; margin-right:auto;" 
                                                                CellPadding="4" ForeColor="#333333" 
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
                                            </td> 
                                        </tr>

                                                                    
							        </table>                            								
							    </fieldset>     
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID ="rdbIndicador" />
                            </Triggers>
                       </asp:UpdatePanel>                        
					</td>
				</tr>
            </table>
			
            
            <table  border="0" cellpadding="0" cellspacing="0" width="800" height="100%">	
                <tr>
                    <td colspan="2">
                        <asp:Panel runat="server" ID="pnlExcluir" Visible="false" Height="44px">
                            <table width="99%" style="background-color:#FFDAB9; height: 41px; border:1px solid #CD3333; margin-left:10px;">
                                <tr>
                                    <td class="style3">
                                        <span style="margin-left:200px; font-size:medium; color:#CD3333;">Deseja excluir esse registro?</span>
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
                        <asp:Panel runat="server" ID="pnlExcluirItem" Visible="false" Height="44px">
                            <table width="99%" style="background-color:#FFDAB9; height: 41px; border:1px solid #CD3333; margin-left:10px;">
                                <tr>
                                    <td class="style3">
                                        <span style="margin-left:200px; font-size:medium; color:#CD3333;">Deseja excluir esse item?</span>
                                    </td> 
                                    <td>
                                        <asp:Button ID="btnSimItem" runat="server" Text="SIM" Width="76px" />
                                        <asp:Button ID="btnNaoItem" runat="server" Text="NÃO" Width="76px" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>

				<tr>
					<td colspan="2">
                        <asp:Panel ID="Panel1"  runat="server" ScrollBars="auto" Width="900px" 
                            style="margin-left:10px; margin-top:20px; max-height:366px;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate > 
						                <asp:GridView ID="gridQuestao" runat="server" 
                                            style="margin-top: 0px; margin-left:auto; margin-right:auto;" 
                                            CellPadding="4" ForeColor="#333333" 
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
                                      </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID ="btnGravaItem" />
                                            </Triggers>
                             </asp:UpdatePanel>
                        </asp:Panel>
					</td>
				</tr>

                <tr>
					<td valign="top" height="100%">
								
					</td>					
				</tr>				
			</table>
</asp:Content>
