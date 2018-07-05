Public Class frmQuestionario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("sessionUser") = "" Or Session("sessionUser") = Nothing Then
            Response.Redirect("frmLogin.aspx")
        End If

        If btnNovo.Enabled = True Then
            desabilitaCampos()
        End If

        If Not IsPostBack Then
            carrega_cmbEmpresa()
            carrega_cmbCompetencia()

            If Not Request.QueryString.Item("excluir") Is Nothing Then
                If Request.QueryString("excluir").ToString = "1" Then

                    'desabilitaCampos()

                    cmbEmpresa.SelectedValue = Request.QueryString("codEmpresa").ToString
                    carrega_cmbCategoria()
                    cmbCategoria.SelectedValue = Request.QueryString("codCategoria").ToString
                    carrega_cmbArea()
                    cmbArea.SelectedValue = Request.QueryString("codArea").ToString

                    pnlMsg.Visible = False

                    pnlExcluirQuestionario.Visible = True
                    pnlExcluirQuestionario.Focus()

                    carregaGridQuestao()
                    carregaGridQuestionario()
                End If
            End If
        End If
    End Sub

    Private Sub carregaGridQuestao()
        Dim objQuestionarioBLL As New BLL.QuestionarioBLL
        Dim ds As DataSet
        Dim dt As DataTable
        Dim dv As DataView

        ds = objQuestionarioBLL.ListaQuestionario(cmbEmpresa.SelectedValue, _
                                                  IIf(cmbCategoria.SelectedValue = "", 0, cmbCategoria.SelectedValue), _
                                                  IIf(cmbArea.SelectedValue = "", 0, cmbArea.SelectedValue), _
                                                  cmbCompetencia.SelectedValue)
        dv = ds.Tables(0).DefaultView
        dt = ds.Tables(0)
        gridQuestao.DataSource = dt

        gridQuestao.DataBind()
    End Sub

    Private Sub gridQuestao_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridQuestao.RowDataBound

        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(2).Visible = False
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(3).Text = "" Or e.Row.Cells(3).Text = "&nbsp;" Then
                e.Row.Cells(3).Text = "P-" & e.Row.Cells(2).Text
            End If

            e.Row.Cells(2).Visible = False
        End If

    End Sub

    Private Sub carregaGridQuestionario()
        Dim objQuestionarioBLL As New BLL.QuestionarioBLL
        Dim parametros() As String = {"cd_perfil", "cd_usuario", "cd_empresa", "cd_representante", "dt_competencia"}
        Dim ds As DataSet
        Dim dt As DataTable
        Dim dv As DataView

        parametros(0) = 2
        parametros(1) = 0
        parametros(2) = cmbEmpresa.SelectedValue
        parametros(3) = cmbArea.SelectedValue
        parametros(4) = cmbCompetencia.SelectedValue

        ds = objQuestionarioBLL.RetornaQuestionarioRepresentante(parametros)
        dv = ds.Tables(0).DefaultView
        dt = ds.Tables(0)
        gridQuestionario.DataSource = dt

        gridQuestionario.DataBind()
    End Sub

    Private Sub gridQuestionario_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridQuestionario.RowDataBound
        'Dim cb As CheckBox
        'Dim tx As TextBox

        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Text = ""
            e.Row.Cells(1).Visible = False
            e.Row.Cells(2).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(10).Visible = False
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Cells(0).Text = "<a href='frmQuestionario.aspx?excluir=1&codQuestionario=" & e.Row.Cells(2).Text & "&codStatus=" & e.Row.Cells(7).Text & "&codEmpresa=" & cmbEmpresa.SelectedValue & "&codCategoria=" & cmbCategoria.SelectedValue & "&codArea=" & cmbArea.SelectedValue & "'><img src='../imagens/delete.png'></a>"

            e.Row.Cells(1).Visible = False
            e.Row.Cells(2).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(10).Visible = False
        End If

    End Sub

    Private Sub carrega_cmbEmpresa()
        Dim objEmpresaBLL As New BLL.EmpresaBLL
        Dim lista As New ListItem

        cmbEmpresa.DataTextField = "Razão Social"
        cmbEmpresa.DataValueField = "Código"
        cmbEmpresa.DataSource = objEmpresaBLL.ListaEmpresa.Tables(0)
        cmbEmpresa.DataBind()

        lista.Text = "<Selecione>"
        lista.Value = 0
        cmbEmpresa.Items.Insert(0, lista)
    End Sub

    Private Sub carrega_cmbCompetencia()
        Dim StartDate, EndDate As Date

        StartDate = New Date(2014, 12, 31)
        EndDate = New Date(2050, 12, 31)

        While StartDate <= EndDate
            cmbCompetencia.Items.Add(StartDate.Year.ToString())
            StartDate = StartDate.AddYears(1)
        End While
    End Sub

    Private Sub carrega_cmbCategoria()
        Dim objCategoriaBLL As New BLL.CategoriaBLL
        Dim lista As New ListItem


        cmbCategoria.DataTextField = "Descrição"
        cmbCategoria.DataValueField = "Código"
        cmbCategoria.DataSource = objCategoriaBLL.ListaCategoria.Tables(0)
        cmbCategoria.DataBind()

        lista.Text = "<Selecione>"
        lista.Value = 0
        cmbCategoria.Items.Insert(0, lista)
    End Sub

    Private Sub carrega_cmbArea()
        Dim objRepresentanteBLL As New BLL.RepresentanteBLL
        Dim lista As New ListItem

        cmbArea.DataTextField = "Area"
        cmbArea.DataValueField = "Cod. Representante"
        cmbArea.DataSource = objRepresentanteBLL.ListaArea(cmbEmpresa.SelectedValue).Tables(0)
        cmbArea.DataBind()

        lista.Text = "<Selecione>"
        lista.Value = 0
        cmbArea.Items.Insert(0, lista)
    End Sub

    Protected Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        carrega_cmbCategoria()
        carrega_cmbArea()

        carregaGridQuestao()
    End Sub

    Protected Sub cmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoria.SelectedIndexChanged
        carregaGridQuestao()
    End Sub

    Protected Sub cmbArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbArea.SelectedIndexChanged
        Dim objRepresentanteBLL As New BLL.RepresentanteBLL
        Dim dt As DataTable

        dt = objRepresentanteBLL.RetornaRepresentante(cmbArea.SelectedValue).Tables(0)
        lblRepresentante.Text = dt.Rows(0)("Nome").ToString
        txtPrazo.Text = dt.Rows(0)("Prazo").ToString

        carregaGridQuestao()
        carregaGridQuestionario()
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As System.EventArgs) Handles btnGravar.Click
        Dim cb As CheckBox
        Dim tx As TextBox
        Dim objQuestionarioBLL As New BLL.QuestionarioBLL
        Dim objQuestionario As New MODEL.Questionario

        If cmbEmpresa.SelectedItem.Text = "" Or cmbEmpresa.SelectedItem.Text = "<Selecione>" Or _
           cmbArea.SelectedItem.Text = "" Or cmbArea.SelectedItem.Text = "<Selecione>" Then

            lblMsg.Text = "Os campos com * são de preenchimento obrigatório!"
            lblMsg.ForeColor = Drawing.Color.Red
            pnlMsg.Visible = True
            Exit Sub
        Else
            pnlMsg.Visible = False
        End If

        'objQuestionarioBLL.ExcluiQuestionario(cmbArea.SelectedValue, cmbCategoria.SelectedValue)

        For i As Integer = 0 To gridQuestao.Rows.Count - 1

            cb = gridQuestao.Rows(i).Cells(0).FindControl("chkQuestao")

            tx = gridQuestao.Rows(i).Cells(0).FindControl("txtOrdem")

            For j As Integer = 0 To gridQuestionario.Rows.Count - 1
                If tx.Text <= gridQuestionario.Rows(j).Cells(3).Text Then
                    lblMsg.Text = "A ordem não pode ser repetida nem menor que a atual!"
                    lblMsg.ForeColor = Drawing.Color.Red
                    pnlMsg.Visible = True
                    Exit Sub
                End If
            Next

            If cb.Checked Then
                With objQuestionario
                    .questao.cd_questao = gridQuestao.Rows(i).Cells(2).Text
                    .representante.cd_representante = cmbArea.SelectedValue
                    .status.cd_status = 1
                    .nm_ordem = tx.Text
                    .no_userid = Session("sessionUser")
                    .dt_competencia = cmbCompetencia.SelectedValue
                End With

                objQuestionarioBLL.InsereQuestionario(objQuestionario)
            End If
        Next

        If txtPrazo.Text = "" Then
            objQuestionarioBLL.AlteraPrazo(cmbArea.SelectedValue)
        Else
            objQuestionarioBLL.AlteraPrazo(cmbArea.SelectedValue, CDate(txtPrazo.Text))
        End If

        lblMsg.Text = "Questionario criado com sucesso!"
        lblMsg.ForeColor = Drawing.Color.LightGreen
        pnlMsg.Visible = True

        carregaGridQuestao()
        carregaGridQuestionario()
        'btnCancelar_Click(sender, e)

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

        btnFinalizar.Enabled = True
        btnFinalizar.ImageUrl = "../imagens/accept.png"

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

        btnFinalizar.Enabled = True
        btnFinalizar.ImageUrl = "../imagens/accept_disabled.png"
    End Sub

    Private Sub limpaCampos()
        lblRepresentante.Text = ""
        carrega_cmbEmpresa()
        carrega_cmbCompetencia()
        carrega_cmbCategoria()
        carrega_cmbArea()
        txtPrazo.Text = ""
        carregaGridQuestao()
    End Sub

    Private Sub habilitaCampos()
        cmbEmpresa.Enabled = True
        cmbCategoria.Enabled = True
        cmbCompetencia.Enabled = True
        cmbArea.Enabled = True
        txtPrazo.Enabled = True
        gridQuestao.Enabled = True
    End Sub

    Private Sub desabilitaCampos()
        cmbEmpresa.Enabled = False
        cmbCategoria.Enabled = False
        cmbCompetencia.Enabled = False
        cmbArea.Enabled = False
        txtPrazo.Enabled = False
        gridQuestao.Enabled = False
    End Sub

    Protected Sub btnNaoQuestionario_Click(sender As Object, e As EventArgs) Handles btnNaoQuestionario.Click
        pnlExcluirQuestionario.Visible = False
        gridQuestao.Focus()
    End Sub

    Protected Sub btnSimQuestionario_Click(sender As Object, e As EventArgs) Handles btnSimQuestionario.Click
        Dim objQuestionarioBLL As New BLL.QuestionarioBLL

        If CInt(Request.QueryString("codStatus").ToString) > 2 Then
            lblMsg.Text = "Este questionario não pode ser excluído!"
            lblMsg.ForeColor = Drawing.Color.Red
            pnlMsg.Visible = True
        Else
            objQuestionarioBLL.ExcluiQuestionario(Request.QueryString("codQuestionario").ToString)
        End If

        carregaGridQuestao()
        carregaGridQuestionario()
        pnlExcluirQuestionario.Visible = False
        gridQuestao.Focus()
    End Sub

    Protected Sub btnFinalizar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnFinalizar.Click
        Dim i As Integer
        Dim cont As Integer = 0
        Dim cb As CheckBox
        Dim dt As DataTable
        Dim objQuestionarioBLL As New BLL.QuestionarioBLL

        If gridQuestionario.Rows.Count <= 0 Then
            lblMsg.Text = "Não existe questionário para essa área!"
            lblMsg.ForeColor = Drawing.Color.Red
            pnlMsg.Visible = True
            Exit Sub
        Else
            pnlMsg.Visible = False
        End If

        'Verifico ponto focal
        dt = objQuestionarioBLL.RetornaPontoFocal(cmbEmpresa.SelectedValue).Tables(0)
        If dt.Rows.Count <= 0 Then
            lblMsg.Text = "Não existe um ponto focal para essa empresa!"
            lblMsg.ForeColor = Drawing.Color.Red
            pnlMsg.Visible = True
            Exit Sub
        Else
            pnlMsg.Visible = False

            pnlFinalizar.Visible = True
        End If

    End Sub

    Protected Sub btnNao_Click(sender As Object, e As EventArgs) Handles btnNao.Click
        pnlMsg.Visible = False
        pnlFinalizar.Visible = False
    End Sub

    Protected Sub btnSim_Click(sender As Object, e As EventArgs) Handles btnSim.Click
        Dim dt As DataTable
        Dim objQuestionario As New MODEL.Questionario
        Dim objQuestionarioBLL As New BLL.QuestionarioBLL

        dt = objQuestionarioBLL.RetornaPontoFocal(cmbEmpresa.SelectedValue).Tables(0)
        objQuestionario.representante.dc_email = dt.Rows(0)("dc_email").ToString
        objQuestionario.representante.no_representante = dt.Rows(0)("no_representante").ToString
        objQuestionario.representante.dc_area = cmbArea.SelectedItem.ToString

        'If objQuestionarioBLL.EnviaEmailQuestionadioLiberado(objQuestionario) Then

        objQuestionarioBLL.AlteraQuestionario(0, 4, cmbCompetencia.SelectedValue, cmbArea.SelectedValue)

        lblMsg.Text = "Questionário finalizado com sucesso!"
        lblMsg.ForeColor = Drawing.Color.LightGreen
        pnlMsg.Visible = True

        pnlFinalizar.Visible = False
        'Else
        '    lblMsg.Text = "Não foi possível finalizar o questionário. Favor verificar o email de cadastro do Ponto Focal."
        '    lblMsg.ForeColor = Drawing.Color.Red
        '    pnlMsg.Visible = True

        '    pnlFinalizar.Visible = False
        'End If

        limpaCampos()
        desabilitaCampos()
    End Sub

End Class