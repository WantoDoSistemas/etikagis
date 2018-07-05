<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmResposta.aspx.vb" Inherits="Frontend.frmResposta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            width: 429px;
        }
        .style4
        {
            height: 21px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager> 
    <table border="0" cellpadding="0" cellspacing="0" width="800" height="100%">
				
				
				<tr>
					<td colspan="2">
                        <asp:Panel id="panelBotoes" runat="server">
						    <nav id="navToolBar">
							    <ul style="margin-left:45%;">
                                    <li><asp:ImageButton id="btnNovo" runat="server" ImageUrl="~/Imagens/add.ico" 
                                            style="margin-top:5px;" EnableTheming="True" ToolTip="Novo" /> </li>
								    <li><asp:ImageButton id="btnGravar" runat="server" 
                                            ImageUrl="~/Imagens/save_disabled.png" Enabled="False" ToolTip="Gravar" /></li>
								    <li><asp:ImageButton id="btnCancelar" runat="server" 
                                            ImageUrl="~/Imagens/no_disabled.png" Enabled="False" ToolTip="Cancelar" /></li>
								    <li><asp:ImageButton id="btnFinalizar" runat="server" 
                                            ImageUrl="~/Imagens/accept_disabled.png" Enabled="False" 
                                            ToolTip="Finalizar" /></li>		
								
							    </ul>
                                                                
						    </nav>
                        </asp:Panel>
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
                        <div ID="divPrazo" runat="server" style="margin-left:20%; margin-top:20px; margin-bottom:10px; text-align:center; font-size:medium; color:Red;">
                            <asp:Label ID="lblDataPrazo" runat="server" />
                        </div>
                    </td>
                </tr>

                <tr>
				    <td colspan="2">
                        <fieldset id="frameFiltro" runat="server" visible="false" class="frame">
							<legend style="color:#B0C4DE;">Filtro</legend>
							    <table>                                    
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
                        <fieldset id="frameQuestao" runat="server" visible="false" class="frame">	
							<legend style="color:#B0C4DE;">Questão</legend>
							    <table>
								    <tr>	
                                        <td>                                             
                                            <asp:Label ID="lblCodQuestionario" runat="server" Visible="False"></asp:Label>   
                                            <asp:Label ID="lblOrdem" runat="server" Font-Bold="True" />						    
                                                -
                                            <asp:Label ID="lblQuestao" runat="server" Font-Bold="True" />
                                        </td>
								    </tr>                                                                          			    	                                   
							    </table>                            								
							</fieldset>                            
					</td>
				</tr>

                <tr>
					<td colspan="2">
                        <fieldset id="frameResposta" runat="server" visible="false" class="frame">	
							<legend style="color:#B0C4DE;">Resposta</legend>
							    <table>                                    
                                    <tr>									    
                                        <td>                                            
                                            <asp:Label ID="lblCodigoResposta" runat="server" Visible="False"></asp:Label>
                                            <asp:UpdatePanel ID="pnlResposta" runat="server">
                                                <ContentTemplate >  
                                                    <asp:TextBox ID="txtResposta" runat="server" MaxLength="8000" Width="439px" 
                                                            Height="137px" TextMode="MultiLine" style="margin-left:15px;"></asp:TextBox>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID ="txtResposta" />
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
                        <fieldset id="frameRetorno" runat="server" visible="false" class="frame">	
							<legend style="color:#B0C4DE;">Retorno</legend>
							    <table>                                    
                                    <tr>									    
                                        <td>
                                            <asp:Label ID="lblRetorno" runat="server" Font-Bold="True" />
                                        </td>
								    </tr>			    	                                   
							    </table>                            								
						</fieldset>                            
					</td>
				</tr>

                <tr>
					<td colspan="2">    
                        <asp:UpdatePanel ID="pnlItemResposta" runat="server">
                            <ContentTemplate >                                                
                                <fieldset id="frameItemResposta" runat="server" visible="false" class="frame">	
							        <legend style="color:#B0C4DE;">Itens</legend>
							            <table>   
                                            <tr>									                                                    
                                                <td colspan="3">
                                                    <asp:Label ID="lblEditarItem" runat="server" Visible="False"></asp:Label>   
                                                    <asp:Panel ID="pnlGridItemResposta"  runat="server" ScrollBars="Auto"                                                 
                                                        style="margin-left:0px; margin-top:0px; max-height:300px; width:465px;">
                                                           <asp:GridView ID="gridItemResposta" runat="server" 
                                                                style="margin-top: 0px; margin-left:auto; margin-right:auto;" CellPadding="4" ForeColor="#333333" 
                                                                Font-Size="Small">
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Item">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblItemQuestao" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Resposta">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtItemResposta" runat="server" Width="250px"/>
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
                                                </td> 
                                                <td>                                 
                                                    <asp:ImageButton ID="btnGravaItem" runat="server" ImageUrl="~/Imagens/add.ico" 
                                                        ToolTip="Gravar Itens" />                                                                                                                                   
                                                </td>
                                            </tr>  
                                        </table>  
                                    </fieldset>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID ="gridItemResposta" />
                                </Triggers>
                            </asp:UpdatePanel>   
                        </td>                        
				    </tr>
                    <tr>
					    <td colspan="2">    
                            <asp:UpdatePanel ID="pnlItemRespondida" runat="server">
                                <ContentTemplate >                                                
                                    <fieldset id="frameItemRespondida" runat="server" visible="false" class="frame">	
							            <legend style="color:#B0C4DE;">Resposta</legend>
							                <table>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Panel ID="pnlGridItemRespondida"  runat="server" ScrollBars="Auto"                                                 
                                                            style="margin-left:0px; margin-top:0px; max-height:300px; max-width:465px;">
                                                                <asp:GridView ID="gridItemRespondida" runat="server" 
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
                                <asp:AsyncPostBackTrigger ControlID ="gridItemRespondida" />
                            </Triggers>
                       </asp:UpdatePanel>                          
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
                                                       
                            <asp:UpdatePanel ID="pnlQuestao" runat="server">
                            <ContentTemplate >
                                    
                                    <div id="divLegenda" runat="server" visible="false">
                                        <ul style="margin-left:4%;">
                                            <li style="display:inline; margin-right:10px;"><img src="../imagens/Flag-Red.png"><span>Aguardando Resposta</span></li>
                                            <li style="display:inline; margin-right:10px;"><img src="../imagens/Flag-Blue.png"><span>Gravado</span></li>                                            
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
