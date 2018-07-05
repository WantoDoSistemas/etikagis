<%@ Page Title="GIS - Analise de Resposta" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmAnaliseRespostas.aspx.vb" Inherits="Backend.frmAnaliseRespostas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
        .style3
        {
            width: 429px;
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
							<ul style="margin-left:45%; padding-left:50;">
                                <%--<li><asp:ImageButton id="btnNovo" runat="server" ImageUrl="~/Imagens/add.ico" 
                                        style="margin-top:5px;" EnableTheming="True" /> </li>--%>
								<li><asp:ImageButton id="btnGravar" runat="server" 
                                        ImageUrl="~/Imagens/save_disabled.png" Enabled="False" ToolTip="Gravar" /></li>
								<li><asp:ImageButton id="btnCancelar" runat="server" 
                                        ImageUrl="~/Imagens/no_disabled.png" Enabled="False" ToolTip="Cancelar" /></li>
                               <%-- <li><asp:ImageButton id="btnFinalizar" runat="server" 
                                        ImageUrl="~/Imagens/accept.png" /></li>	--%>							
								
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
							<legend style="color:#B0C4DE;">Filtro</legend>
							    <table>
                                    <tr>
                                        <td>Empresa*</td>
                                        <td>    
                                            <asp:UpdatePanel ID="pnlEmpresa" runat="server">
                                                <ContentTemplate >                     
                                                    <asp:DropDownList AutoPostBack="true" ID="cmbEmpresa" runat="server" Width="269px" Height="17px">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID ="cmbEmpresa" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>                                 

                                    <tr>
                                        <td>Competência*</td>
                                        <td>                         
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate >                     
                                                        <asp:DropDownList ID="cmbCompetencia" AutoPostBack="true" runat="server" Width="269px" 
                                                            Height="22px" Visible="true">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID ="cmbArea" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Área*</td>
                                        <td>                         
                                            <asp:UpdatePanel ID="pnlArea" runat="server">
                                                    <ContentTemplate >                     
                                                        <asp:DropDownList ID="cmbArea" AutoPostBack="true" runat="server" Width="269px" 
                                                            Height="22px">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID ="cmbArea" />
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
                        <fieldset id="pnlQuestionario" runat="server" visible="false" class="frame">	
							<legend style="color:#B0C4DE;">Questão</legend>
							    <table>		                                    

                                    <tr>
									    <td>Cabeçalho </td> <td style="margin-left: 40px">                                            
                                            <asp:TextBox ID="txtCabecalho" runat="server" MaxLength="8000" Width="402px" Height="93px" TextMode="MultiLine" Enabled="false"></asp:TextBox>                                                
                                        </td>
								    </tr>

                                    <tr>                                        
									    <td><asp:label runat="server" ID="lblResposta">Resposta</asp:label></td> 

                                        <td style="margin-left: 40px"> 
                                            <asp:Panel runat="server" ID="pnlResposta" Visible=true>                                           
                                                <asp:TextBox ID="txtResposta" runat="server" MaxLength="8000" Width="402px" Height="93px" TextMode="MultiLine" Enabled="false"></asp:TextBox>                                                
                                            </asp:Panel>
                                       </td>
                                        
								    </tr>

                                    <tr>
                                        <td><asp:Label runat="server" ID="lblItem" Visible="False">Item</asp:Label></td>

                                         <td style="margin-left: 40px"> 
                                            <asp:Panel ID="pnlGridItem"  runat="server" ScrollBars="Auto"                                                 
                                                    style="margin-left:0px; margin-top:0px; max-height:2    00px; max-width:465px;">
                                                    
                                                            <asp:GridView ID="gridItemQuestao" runat="server" 
                                                                style="margin-top: 0px; margin-left:0px; margin-right:0px;" 
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

                                    <tr>
									    <td>Status*</td> <td>                         
                                        <asp:DropDownList ID="cmbStatus" runat="server" Width="202px" Enabled="False">
                                            <asp:ListItem Value="0">&lt;Selecione&gt;</asp:ListItem>
                                            <asp:ListItem Value="8">Finalizado</asp:ListItem>
                                            <asp:ListItem Value="7">Devolvido</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
								    </tr>

                                    <tr>
									    <td>Retorno </td> <td style="margin-left: 40px">                                            
                                            <asp:TextBox ID="txtRetorno" runat="server" MaxLength="8000" Width="402px" 
                                                Height="93px" TextMode="MultiLine" Enabled="False"></asp:TextBox>                                                
                                        </td>
								    </tr>
							    </table>                            								
							</fieldset>                            
					</td>
				</tr>                

                
            </table>
			
            
            <table  border="0" cellpadding="0" cellspacing="0" width="800" height="100%">	
                <%--<tr>
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
                </tr>--%>

               
				<tr>
					<td colspan="2">
                        <asp:Panel ID="Panel1"  runat="server" ScrollBars="auto" Width="900px" 
                            style="margin-left:10px; margin-top:20px; max-height:366px;">
                                                       
                            <asp:UpdatePanel ID="pnlQuestao" runat="server">
                            <ContentTemplate >
                                    
                                    <div id="divLegenda" runat="server" visible="false">
                                        <ul style="margin-left:-4%;">
                                            <li style="display:inline; margin-right:10px;"><img src="../imagens/Flag-Red.png"><span>Aguardando Resposta</span></li>                                            
                                            <li style="display:inline; margin-right:10px;"><img src="../imagens/Flag-Green.png"><span>Respondido</span></li>
                                            <li style="display:inline; margin-right:10px;"><img src="../imagens/Flag-Yellow.png"><span>Devolvido</span></li>                                
                                            <li style="display:inline; margin-right:10px;"><img src="../imagens/Flag-Checkered.png"><span>Finalizado</span></li>
                                        </ul>
                                    </div>
                                

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
                                    <asp:AsyncPostBackTrigger ControlID ="cmbArea" />
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
