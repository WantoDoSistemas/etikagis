<%@ Page Title="GIS - Relatório Final" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RelatorioQuestionario.aspx.vb" Inherits="Backend.RelatorioQuestionario" %>
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
                <fieldset class="frame" style="width:60%;">	
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
                                        <td>&nbsp;</td>
                                        <td>                         
                                            <asp:UpdatePanel ID="pnlArea" runat="server">
                                                    <ContentTemplate >                     
                                                        <asp:DropDownList ID="cmbArea" AutoPostBack="true" runat="server" Width="269px" 
                                                            Height="22px" Visible="False">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID ="cmbArea" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                        </td>
                                    </tr>                                    

                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnConsultar" runat="server" Text="Gerar relatório" />
                                        </td>
                                    </tr>
                                </table>
                        </fieldset>
            </td>
        </tr>
        </table>

    <asp:Literal ID="litRelatorio" runat="server" />
</asp:Content>
