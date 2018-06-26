Public Class frmRepresentante
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("sessionUser") = "" Or Session("sessionUser") = Nothing Then
            Response.Redirect("frmLogin.aspx")
        End If

        desabilitaCampos()

        If Not IsPostBack Then
            carregaGridRepresentante()
            carrega_cmbEmpresa()
            carrega_cmbPerfil()
            carrega_cmbStatus()

            If Not Request.QueryString.Item("editar") Is Nothing Then
                If Request.QueryString("editar").ToString = "1" Then

                    txtCodigo.Text = Request.QueryString("codigo").ToString
                    txtNome.Text = Request.QueryString("nome").ToString
                    cmbEmpresa.SelectedValue = Request.QueryString("codempresa").ToString
                    cmbPerfil.SelectedValue = Request.QueryString("codperfil").ToString
                    txtCargo.Text = Request.QueryString("cargo").ToString
                    txtArea.Text = Request.QueryString("area").ToString
                    txtTelefone.Text = Request.QueryString("telefone").ToString
                    txtUsuario.Text = Request.QueryString("usuario").ToString                    
                    txtEmail.Text = Request.QueryString("email").ToString
                    cmbStatus.SelectedValue = Request.QueryString("codstatus").ToString
                    cmbRecebeEmail.SelectedValue = Request.QueryString("recebe_email").ToString

                    habilitaCampos()

                    btnGravar.Enabled = True
                    btnGravar.ImageUrl = "../imagens/save.ico"

                    btnCancelar.Enabled = True
                    btnCancelar.ImageUrl = "../imagens/no.ico"

                    cmbFiltro.Enabled = False
                    txtFiltro.Enabled = False

                    btnConsultar.Enabled = False
                    btnConsultar.ImageUrl = "../imagens/find_disabled.png"

                    pnlMsg.Visible = False
                End If
            End If

            If Not Request.QueryString.Item("excluir") Is Nothing Then
                If Request.QueryString("excluir").ToString = "1" Then
                    txtCodigo.Text = Request.QueryString("codigo").ToString
                    txtNome.Text = Request.QueryString("nome").ToString
                    cmbEmpresa.SelectedValue = Request.QueryString("codempresa").ToString
                    cmbPerfil.SelectedValue = Request.QueryString("codperfil").ToString
                    txtCargo.Text = Request.QueryString("cargo").ToString
                    txtArea.Text = Request.QueryString("area").ToString
                    txtTelefone.Text = Request.QueryString("telefone").ToString
                    txtUsuario.Text = Request.QueryString("usuario").ToString
                    txtEmail.Text = Request.QueryString("email").ToString
                    cmbStatus.SelectedValue = Request.QueryString("codstatus").ToString
                    cmbRecebeEmail.SelectedValue = Request.QueryString("recebe_email").ToString

                    desabilitaCampos()

                    btnNovo.Enabled = False
                    btnNovo.ImageUrl = "../imagens/add_disabled.png"

                    btnGravar.Enabled = False
                    btnGravar.ImageUrl = "../imagens/save_disabled.png"

                    btnCancelar.Enabled = False
                    btnCancelar.ImageUrl = "../imagens/no_disabled.png"

                    cmbFiltro.Enabled = False
                    txtFiltro.Enabled = False

                    btnConsultar.Enabled = False
                    btnConsultar.ImageUrl = "../imagens/find_disabled.png"

                    pnlMsg.Visible = False

                    pnlExcluir.Visible = True
                    pnlExcluir.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub carregaGridRepresentante()
        Dim objRepresentanteBLL As New BLL.RepresentanteBLL
        Dim ds As DataSet
        Dim dt As DataTable
        Dim dv As DataView

        ds = objRepresentanteBLL.ListaRepresentante()
        dv = ds.Tables(0).DefaultView
        dt = ds.Tables(0)
        gridRepresentante.DataSource = dt

        If cmbFiltro.Text = "Código" Then
            dv.RowFilter = "Código = '" & txtFiltro.Text & "'"
        End If

        If cmbFiltro.Text = "Nome" Then
            dv.RowFilter = "[Nome] like '%" & txtFiltro.Text & "%'"
        End If

        If cmbFiltro.Text = "Empresa" Then
            dv.RowFilter = "[Empresa] = '" & txtFiltro.Text & "'"
        End If

        If cmbFiltro.Text = "Perfil" Then
            dv.RowFilter = "[Perfil] = '" & txtFiltro.Text & "'"
        End If

        If cmbFiltro.Text = "Status" Then
            dv.RowFilter = "[Status] like '%" & txtFiltro.Text & "%'"
        End If

        gridRepresentante.DataBind()
    End Sub

    Private Sub carrega_cmbStatus()
        Dim objRepresentanteBLL As New BLL.RepresentanteBLL

        cmbStatus.DataTextField = "dc_status"
        cmbStatus.DataValueField = "cd_status"
        cmbStatus.DataSource = objRepresentanteBLL.RetornaStatusRepresentante.Tables(0)
        cmbStatus.DataBind()
    End Sub

    Private Sub carrega_cmbEmpresa()
        Dim objEmpresaBLL As New BLL.EmpresaBLL

        cmbEmpresa.DataTextField = "Nome Fantasia"
        cmbEmpresa.DataValueField = "Código"
        cmbEmpresa.DataSource = objEmpresaBLL.ListaEmpresa().Tables(0)
        cmbEmpresa.DataBind()

        cmbEmpresa.Items.Add(New ListItem("<Selecione>", 0))
        cmbEmpresa.SelectedValue = 0
    End Sub

    Private Sub carrega_cmbPerfil()
        Dim objPerfilRepresentanteBLL As New BLL.PerfilRepresentanteBLL

        cmbPerfil.DataTextField = "Perfil"
        cmbPerfil.DataValueField = "Código"
        cmbPerfil.DataSource = objPerfilRepresentanteBLL.ListaPerfilRepresentante().Tables(0)
        cmbPerfil.DataBind()

        cmbPerfil.Items.Add(New ListItem("<Selecione>", 0))
        cmbPerfil.SelectedValue = 0
    End Sub

    Private Sub gridRepresentante_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridRepresentante.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Text = ""
            e.Row.Cells(1).Text = ""
            e.Row.Cells(5).Visible = False
            e.Row.Cells(7).Visible = False            
            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = False
            e.Row.Cells(17).Visible = False
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Text = "<a href='frmRepresentante.aspx?editar=1&codigo=" & e.Row.Cells(2).Text & "&nome=" & e.Row.Cells(3).Text & "&empresa=" & e.Row.Cells(4).Text & "&codempresa=" & e.Row.Cells(5).Text & "&perfil=" & e.Row.Cells(6).Text & "&codperfil=" & e.Row.Cells(7).Text & "&cargo=" & e.Row.Cells(8).Text & "&area=" & e.Row.Cells(9).Text & "&telefone=" & e.Row.Cells(10).Text & "&usuario=" & e.Row.Cells(11).Text & "&email=" & e.Row.Cells(13).Text & "&status=" & e.Row.Cells(14).Text & "&codstatus=" & e.Row.Cells(15).Text & "&recebe_email=" & e.Row.Cells(17).Text & "'><img src='../imagens/edit.png'></a>"
            e.Row.Cells(1).Text = "<a href='frmRepresentante.aspx?excluir=1&codigo=" & e.Row.Cells(2).Text & "&nome=" & e.Row.Cells(3).Text & "&empresa=" & e.Row.Cells(4).Text & "&codempresa=" & e.Row.Cells(5).Text & "&perfil=" & e.Row.Cells(6).Text & "&codperfil=" & e.Row.Cells(7).Text & "&cargo=" & e.Row.Cells(8).Text & "&area=" & e.Row.Cells(9).Text & "&telefone=" & e.Row.Cells(10).Text & "&usuario=" & e.Row.Cells(11).Text & "&email=" & e.Row.Cells(13).Text & "&status=" & e.Row.Cells(14).Text & "&codstatus=" & e.Row.Cells(15).Text & "&recebe_email=" & e.Row.Cells(17).Text & "'><img src='../imagens/delete.png'></a>"
            e.Row.Cells(5).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = False
            e.Row.Cells(17).Visible = False
        End If
    End Sub

    Protected Sub btnNovo_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnNovo.Click
        limpaCampos()
        habilitaCampos()

        btnNovo.Enabled = False
        btnNovo.ImageUrl = "../imagens/add_disabled.png"

        btnGravar.Enabled = True
        btnGravar.ImageUrl = "../imagens/save.ico"

        btnCancelar.Enabled = True
        btnCancelar.ImageUrl = "../imagens/no.ico"

        cmbFiltro.Enabled = False
        txtFiltro.Enabled = False

        btnConsultar.Enabled = False
        btnConsultar.ImageUrl = "../imagens/find_disabled.png"

        pnlMsg.Visible = False
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        limpaCampos()
        desabilitaCampos()

        btnNovo.Enabled = True
        btnNovo.ImageUrl = "../imagens/add.ico"

        btnGravar.Enabled = False
        btnGravar.ImageUrl = "../imagens/save_disabled.png"

        btnCancelar.Enabled = False
        btnCancelar.ImageUrl = "../imagens/no_disabled.png"

        cmbFiltro.Enabled = True
        txtFiltro.Enabled = True

        btnConsultar.Enabled = True
        btnConsultar.ImageUrl = "../imagens/find.ico"
    End Sub

    Protected Sub btnSim_Click(sender As Object, e As EventArgs) Handles btnSim.Click
        Dim objRepresentanteBLL As New BLL.RepresentanteBLL

        objRepresentanteBLL.ExcluiRepresentante(CInt(Request.QueryString("codigo").ToString))
        carregaGridRepresentante()
        DataBind()
        pnlExcluir.Visible = False

        limpaCampos()
        desabilitaCampos()

        btnNovo.Enabled = True
        btnNovo.ImageUrl = "../imagens/add.ico"

        btnGravar.Enabled = False
        btnGravar.ImageUrl = "../imagens/save_disabled.png"

        btnCancelar.Enabled = False
        btnCancelar.ImageUrl = "../imagens/no_disabled.png"

        cmbFiltro.Enabled = True
        txtFiltro.Enabled = True

        btnConsultar.Enabled = True
        btnConsultar.ImageUrl = "../imagens/find.ico"
    End Sub

    Protected Sub btnNao_Click(sender As Object, e As EventArgs) Handles btnNao.Click
        pnlExcluir.Visible = False
        limpaCampos()
        desabilitaCampos()

        btnNovo.Enabled = True
        btnNovo.ImageUrl = "../imagens/add.ico"

        btnGravar.Enabled = False
        btnGravar.ImageUrl = "../imagens/save_disabled.png"

        btnCancelar.Enabled = False
        btnCancelar.ImageUrl = "../imagens/no_disabled.png"

        cmbFiltro.Enabled = True
        txtFiltro.Enabled = True

        btnConsultar.Enabled = True
        btnConsultar.ImageUrl = "../imagens/find.ico"
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnConsultar.Click
        carregaGridRepresentante()
        gridRepresentante.Focus()
    End Sub

    Protected Sub btnGravar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnGravar.Click
        Dim objRepresentante As New MODEL.Representante
        Dim objRepresentanteBLL As New BLL.RepresentanteBLL

        If txtNome.Text = "" Or cmbEmpresa.SelectedItem.Text = "" Or cmbEmpresa.SelectedItem.Text = "<Selecione>" Or cmbPerfil.SelectedItem.Text = "" Or cmbPerfil.SelectedItem.Text = "<Selecione>" Or cmbStatus.SelectedItem.Text = "" Or cmbStatus.SelectedItem.Text = "<Selecione>" Or txtUsuario.Text = "" Or txtSenha.Text = "" Then
            lblMsg.Text = "Os campos com * são de preenchimento obrigatório!"
            lblMsg.ForeColor = Drawing.Color.Red
            pnlMsg.Visible = True
            habilitaCampos()
            Exit Sub
        Else
            pnlMsg.Visible = False
        End If

        With objRepresentante
            If txtCodigo.Text <> "" Then
                .cd_representante = txtCodigo.Text
            End If
            .no_representante = txtNome.Text
            .empresa = New MODEL.Empresa
            .empresa.cd_empresa = cmbEmpresa.SelectedValue
            .perfil = New MODEL.PerfilRepresentante
            .perfil.cd_perfil_representante = cmbPerfil.SelectedValue
            .no_representante = txtNome.Text
            .dc_usuario = txtUsuario.Text
            .dc_senha = txtSenha.Text
            .dc_cargo = txtCargo.Text
            .dc_area = txtArea.Text
            .nm_telefone = txtTelefone.Text
            .dc_email = txtEmail.Text
            .cd_status = cmbStatus.SelectedValue
            .recebe_email = cmbRecebeEmail.SelectedValue
        End With

        If btnNovo.Enabled = False Or txtCodigo.Text = "" Then
            objRepresentanteBLL.InsereRepresentante(objRepresentante)
            carregaGridRepresentante()
            btnCancelar_Click(sender, e)

            lblMsg.Text = "Representante cadastrado com sucesso!"
            lblMsg.ForeColor = Drawing.Color.LightGreen
            pnlMsg.Visible = True
        Else
            objRepresentanteBLL.AlteraRepresentante(objRepresentante)
            carregaGridRepresentante()

            btnCancelar_Click(sender, e)

            lblMsg.Text = "Representante alterado com sucesso!"
            lblMsg.ForeColor = Drawing.Color.LightGreen
            pnlMsg.Visible = True
        End If

    End Sub

    Private Sub limpaCampos()
        txtCodigo.Text = ""
        txtCargo.Text = ""
        txtArea.Text = ""
        txtNome.Text = ""
        txtEmail.Text = ""
        txtTelefone.Text = ""
        txtUsuario.Text = ""
        txtSenha.Text = ""

        carrega_cmbEmpresa()
        carrega_cmbPerfil()
        carrega_cmbStatus()
        pnlMsg.Visible = False
    End Sub

    Private Sub habilitaCampos()
        txtCargo.Enabled = True
        txtArea.Enabled = True
        txtNome.Enabled = True
        txtEmail.Enabled = True
        txtTelefone.Enabled = True
        txtUsuario.Enabled = True
        txtSenha.Enabled = True

        cmbEmpresa.Enabled = True
        cmbPerfil.Enabled = True
        cmbStatus.Enabled = True
        cmbRecebeEmail.Enabled = True
    End Sub

    Private Sub desabilitaCampos()
        txtCargo.Enabled = False
        txtArea.Enabled = False
        txtNome.Enabled = False
        txtEmail.Enabled = False
        txtTelefone.Enabled = False
        txtUsuario.Enabled = False
        txtSenha.Enabled = False

        cmbEmpresa.Enabled = False
        cmbPerfil.Enabled = False
        cmbStatus.Enabled = False
        cmbRecebeEmail.Enabled = False
    End Sub

    Protected Sub gridRepresentante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridRepresentante.SelectedIndexChanged

    End Sub
End Class