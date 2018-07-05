<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.vb" Inherits="Frontend._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        #divConteudo
        {
            width: 540px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <center><h2>
        Bem Vindo!
        
    </h2></center>

    <div ID="divConteudo" runat="server" style="margin-left:auto; margin-right:auto; margin-top:50px; margin-bottom:50px; text-align:justify; font-size:medium;">
        <asp:Label ID="lblConteudo" runat="server"> 
        
        </asp:Label>          

    </div>
        
    <div ID="divPrazo" runat="server" style="margin-left:auto; margin-right:auto; margin-top:50px; margin-bottom:50px; text-align:center; font-size:medium; color:Red;">
        <asp:Label ID="lblDataPrazo" runat="server" />
    </div>

    <p style="text-align:center;">
        
        <asp:LinkButton ID="lnkResposta" runat="server" PostBackUrl="~/UI/frmResposta.aspx"><img src="../Imagens/botao-responder.png"></asp:LinkButton>
    </p>
</asp:Content>
