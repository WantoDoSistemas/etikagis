<%@ Page Title="GIS - Relatório Status Questionarios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmRelStatusQuestionarios.aspx.vb" Inherits="Backend.frmRelStatusQuestionarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>

    <table border="0" cellpadding="0" cellspacing="0" width="800" height="100%">
        <tr>
            <td colspan="2">
                <asp:Panel runat="server" ID="pnlMsg" Visible=False style="width: 64%; margin-left: 25%; margin-top: 10px; background-color:#FFFACD; height: 34px; border:1px solid #FFE4B5;" HorizontalAlign="Center">
                    <p style="margin-top:7px;"><asp:Label runat="server" ID="lblMsg" Font-Bold="True" Font-Size="Small" ForeColor="Black" /></p>
                </asp:panel>
            </td>
        </tr>
                
        <tr>
		    <td colspan="2">
                <fieldset class="frame" style="width:60%;" runat="server">	
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
                                        <td>Área</td>
                                        <td>                         
                                            <asp:UpdatePanel ID="pnlArea" runat="server">
                                                    <ContentTemplate >                     
                                                        <asp:DropDownList ID="cmbArea" AutoPostBack="true" runat="server" Width="269px" 
                                                            Height="22px" Enabled="false" >
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID ="cmbArea" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                        </td>
                                    </tr>

                                    <tr>
									    <td>Categoria</td> <td> 
                                        
                                        <asp:UpdatePanel ID="pnlAspecto" runat="server">
                                            <ContentTemplate >                                                   
                                                 <asp:DropDownList ID="cmbAspecto" runat="server" AutoPostBack="true" Width="269px">
                                                 </asp:DropDownList>                                                
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID ="cmbAspecto" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                            
                                        </td>
                                        
								    </tr> 

                                    <tr>
                                        <td>Indicadores</td>
                                        <td>                         
                                            <asp:UpdatePanel ID="pnlIndicador" runat="server">
                                                <ContentTemplate >                     
                                                    <asp:DropDownList ID="cmbIndicador" AutoPostBack="true" runat="server" Width="269px" 
                                                        Height="22px" Enabled="False">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID ="cmbIndicador" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Status</td>
                                        <td>                         
                                            <asp:UpdatePanel ID="pnlStatus" runat="server">
                                                <ContentTemplate >                     
                                                    <asp:DropDownList ID="cmbStatus" AutoPostBack="true" runat="server" Width="269px" 
                                                        Height="22px">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID ="cmbStatus" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Competência</td>
                                        <td>                         
                                            <asp:UpdatePanel ID="pnlCompetencia" runat="server">
                                                <ContentTemplate >                     
                                                    <asp:DropDownList ID="cmbCompetencia" AutoPostBack="true" runat="server" Width="269px" 
                                                        Height="22px">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID ="cmbCompetencia" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                        </fieldset>

                                <td><asp:ImageButton ID="btnExportar" runat="server" 
                                                ImageUrl="~/Imagens/excel.png" OnClick = "ExportToExcel" /></td>

            </td>            
        </tr>
        </table>

        <table  border="0" cellpadding="0" cellspacing="0" width="800" height="100%" runat="server">	                
				<tr>
					<td colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate >
                                    <div id="divLegenda" runat="server" visible="false">
                                        <ul style="margin-left:-4%;">
                                            <li style="display:inline; margin-right:10px;"><img src="../imagens/Flag-Red.png"><span>Aguardando Resposta</span></li>
                                            <li style="display:inline; margin-right:10px;"><img src="../imagens/Flag-Blue.png"><span>Gravada</span></li>
                                            <li style="display:inline; margin-right:10px;"><img src="../imagens/Flag-Green.png"><span>Respondido</span></li>
                                            <li style="display:inline; margin-right:10px;"><img src="../imagens/Flag-Yellow.png"><span>Devolvido</span></li>                                
                                            <li style="display:inline; margin-right:10px;"><img src="../imagens/Flag-Checkered.png"><span>Finalizado</span></li>
                                        </ul>
                                    </div>   
                                </ContentTemplate>     
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID ="cmbEmpresa" />
                                </Triggers>
                        </asp:UpdatePanel>                                              

                        <asp:Panel ID="Panel1"  runat="server" ScrollBars="Vertical"  
                            style="margin-left:10px; margin-top:20px; max-height:366px; max-width:900px;">   
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate >                                    
						            <asp:GridView ID="gridQuestao" runat="server" 
                                        style="margin-top: 0px; margin-left:auto; margin-right:auto;" CellPadding="4" ForeColor="#333333" 
                                        Font-Size="Small" Height="215px" >
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
                                    <asp:AsyncPostBackTrigger ControlID ="cmbEmpresa" />
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
