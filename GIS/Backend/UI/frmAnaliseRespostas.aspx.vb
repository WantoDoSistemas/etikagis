

Public Class frmAnaliseRespostas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("sessionUser") = "" Or Session("sessionUser") = Nothing Then
            Response.Redirect("frmLogin.aspx")
        End If

        If Not IsPostBack Then
            carrega_cmbEmpresa()
            carrega_cmbCompetencia()
            pnlMsg.Visible = False

            If Not Request.QueryString.Item("editar") Is Nothing Then
                If Request.QueryString("editar").ToString = "1" Then

                    pnlQuestionario.Visible = True

                    cmbStatus.Enabled = True
                    txtRetorno.Enabled = True

                    cmbEmpresa.SelectedValue = Request.QueryString("cd_empresa").ToString
                    carrega_cmbArea()
                    cmbArea.SelectedValue = Request.QueryString("cd_representante").ToString
                    carregaGridQuestao()

                    txtCabecalho.Text = Request.QueryString("dc_questao").ToString
                    txtRetorno.Text = Request.QueryString("dc_retorno").ToString

                    If Request.QueryString("xx_tipo").ToString = "I" Then
                        carrega_resposta(Request.QueryString("cd_questionario").ToString)
                        pnlGridItem.Visible = False
                        lblItem.Visible = False

                        If Request.QueryString("cd_status").ToString = 7 Or Request.QueryString("cd_status").ToString = 8 Then
                            cmbStatus.SelectedValue = Request.QueryString("cd_status").ToString
                        Else
                            cmbStatus.SelectedValue = 0
                        End If


                    Else
                        txtResposta.Visible = False
                        lblResposta.Visible = False
                        lblItem.Visible = True
                        gridItemQuestao.Visible = True
                        carrega_gridItemQuestao(Request.QueryString("cd_questionario").ToString)
                    End If

                    If Request.QueryString("cd_status").ToString = 4 Then
                        btnGravar.Enabled = False
                        btnGravar.ImageUrl = "../imagens/save_disabled.png"
                        btnCancelar.Enabled = False
                        btnCancelar.ImageUrl = "../imagens/no_disabled.png"
                    Else
                        btnGravar.Enabled = True
                        btnGravar.ImageUrl = "../imagens/save.ico"
                        btnCancelar.Enabled = True
                        btnCancelar.ImageUrl = "../imagens/no.ico"
                    End If
                    
                End If
            End If

        End If
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

    Private Sub carrega_gridItemQuestao(codQuestionario As Integer)
        Dim objRespostaBLL As New BLL.RespostaBLL
        Dim ds As DataSet
        Dim dt As DataTable
        Dim dv As DataView

        ds = objRespostaBLL.ListaItemResposta(codQuestionario)
        dv = ds.Tables(0).DefaultView
        dt = ds.Tables(0)
        gridItemQuestao.DataSource = dt

        gridItemQuestao.DataBind()
    End Sub

    Private Sub carrega_resposta(codQuestionario As Integer)
        Dim objRespostaBLL As New BLL.RespostaBLL
        Dim dt As DataTable

        dt = objRespostaBLL.RetornaResposta(codQuestionario).Tables(0)

        txtResposta.Text = dt.Rows(0)("Resposta").ToString
        Session("codResposta") = dt.Rows(0)("codResposta").ToString

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
        carrega_cmbArea()
        cmbArea.Enabled = True
    End Sub


    Private Sub carregaGridQuestao()
        Dim objAnaliseQuestaoBLL As New BLL.AnaliseQuestaoBLL
        Dim ds As DataSet
        Dim dt As DataTable
        Dim dv As DataView

        ds = objAnaliseQuestaoBLL.ListaAnaliseQuestao(cmbArea.SelectedValue, cmbCompetencia.SelectedValue)
        dv = ds.Tables(0).DefaultView
        dt = ds.Tables(0)

        If dt.Rows.Count > 0 Then
            divLegenda.Visible = True
        Else
            divLegenda.Visible = False
        End If

        gridQuestao.DataSource = dt
        gridQuestao.DataBind()
    End Sub

    Protected Sub cmbArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbArea.SelectedIndexChanged
        If cmbCompetencia.Text = "" Then
            lblMsg.Text = "Informe uma competência!"
            lblMsg.ForeColor = Drawing.Color.Red
            pnlMsg.Visible = True
            Exit Sub
        Else
            pnlMsg.Visible = False
        End If

        carregaGridQuestao()

        'gridQuestao.Focus()
    End Sub

    Private Sub gridQuestao_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridQuestao.RowDataBound
        Dim temp As String

        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Text = ""
            e.Row.Cells(1).Text = ""
            e.Row.Cells(2).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            temp = e.Row.Cells(6).Text
            e.Row.Cells(6).Text = "<div style='width:685px; white-space:pre-wrap;'>" & temp & "</div>"

            If e.Row.Cells(8).Text = 4 Then
                e.Row.Cells(0).Text = "<img src='../imagens/Flag-Red.png'>"
            End If

            If e.Row.Cells(8).Text = 6 Then
                e.Row.Cells(0).Text = "<img src='../imagens/Flag-Green.png'>"
            End If

            If e.Row.Cells(8).Text = 7 Then
                e.Row.Cells(0).Text = "<img src='../imagens/Flag-Yellow.png'>"
            End If

            If e.Row.Cells(8).Text = 8 Then
                e.Row.Cells(0).Text = "<img src='../imagens/Flag-Checkered.png'>"
            End If

            If e.Row.Cells(8).Text = 4 Then
                e.Row.Cells(1).Text = "<a href='frmAnaliseRespostas.aspx?editar=1&cd_questionario=" & e.Row.Cells(2).Text & "&cd_questao=" & e.Row.Cells(4).Text & "&nm_indicador=" & e.Row.Cells(5).Text & "&dc_questao=" & temp & "&xx_tipo=" & e.Row.Cells(7).Text & "&cd_status=" & e.Row.Cells(8).Text & "&dc_retorno=" & e.Row.Cells(9).Text & "&cd_empresa=" & e.Row.Cells(10).Text & "&cd_representante=" & e.Row.Cells(11).Text & "'><img src='../imagens/find.ico'></a>"
            Else
                e.Row.Cells(1).Text = "<a href='frmAnaliseRespostas.aspx?editar=1&cd_questionario=" & e.Row.Cells(2).Text & "&cd_questao=" & e.Row.Cells(4).Text & "&nm_indicador=" & e.Row.Cells(5).Text & "&dc_questao=" & temp & "&xx_tipo=" & e.Row.Cells(7).Text & "&cd_status=" & e.Row.Cells(8).Text & "&dc_retorno=" & e.Row.Cells(9).Text & "&cd_empresa=" & e.Row.Cells(10).Text & "&cd_representante=" & e.Row.Cells(11).Text & "'><img src='../imagens/edit.png'></a>"
            End If


            If e.Row.Cells(5).Text = "" Or e.Row.Cells(5).Text = "&nbsp;" Then
                e.Row.Cells(5).Text = "P-" & e.Row.Cells(4).Text
            End If

            e.Row.Cells(2).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
        End If
    End Sub

    Private Sub gridItemQuestao_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridItemQuestao.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Visible = False

        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Visible = False

        End If
    End Sub

    Private Sub limpaCampos()
        txtCabecalho.Text = ""
        txtResposta.Text = ""
        lblItem.Visible = False
        gridItemQuestao.Visible = False
    End Sub

    Protected Sub btnGravar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnGravar.Click
        Dim objAnaliseQuestao As New BLL.AnaliseQuestaoBLL
        Dim objQuestionario As New MODEL.Questionario
        Dim objQuestionarioBLL As New BLL.QuestionarioBLL
        Dim dt As DataTable
        Dim objRepresentante As New BLL.RepresentanteBLL

        If cmbStatus.SelectedValue = 0 Then
            lblMsg.Text = "Informe o status da analise!"
            lblMsg.ForeColor = Drawing.Color.Red
            pnlMsg.Visible = True
            cmbStatus.Focus()
            Exit Sub
        End If

        objAnaliseQuestao.AlteraAnaliseQuestao(Request.QueryString("cd_questionario").ToString, cmbStatus.SelectedValue, txtRetorno.Text)

        If cmbStatus.SelectedValue = 7 Then
            'Envia email representante            
            dt = objRepresentante.RetornaRepresentante(Request.QueryString("cd_representante").ToString, 0).Tables(0)
            If dt.Rows(0)("xx_recebe_email") = 1 Then
                objQuestionario.representante.dc_email = dt.Rows(0)("email").ToString
                objQuestionario.representante.no_representante = dt.Rows(0)("Nome").ToString
                objQuestionario.representante.dc_area = dt.Rows(0)("Area").ToString

                'objQuestionarioBLL.EnviaEmailAnaliseQuestao(objQuestionario)
            End If


            'Envia email ponto focal
            If dt.Rows.Count > 0 Then
                dt = objQuestionarioBLL.RetornaPontoFocal(cmbEmpresa.SelectedValue).Tables(0)
                objQuestionario.representante.dc_email = dt.Rows(0)("dc_email").ToString
                objQuestionario.representante.no_representante = dt.Rows(0)("no_representante").ToString
                objQuestionario.representante.dc_area = cmbArea.SelectedItem.ToString

                'objQuestionarioBLL.EnviaEmailAnaliseQuestao(objQuestionario)
            End If
            
        End If



        carregaGridQuestao()

        lblMsg.Text = "Análise gravada com sucesso!"
        lblMsg.ForeColor = Drawing.Color.LightGreen
        pnlMsg.Visible = True

        btnGravar.Enabled = False
        btnGravar.ImageUrl = "../imagens/save_disabled.png"

        btnCancelar.Enabled = False
        btnCancelar.ImageUrl = "../imagens/no_disabled.png"

        gridQuestao.Focus()
    End Sub

    'Protected Sub btnFinalizar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnFinalizar.Click
    '    Dim objAnaliseQuestao As New BLL.AnaliseQuestaoBLL
    '    Dim dt As DataTable
    '    Dim objQuestionario As New MODEL.Questionario
    '    Dim objQuestionarioBLL As New BLL.QuestionarioBLL
    '    Dim objRepresentante As New BLL.RepresentanteBLL
    '    Dim j As Integer = 0

    '    If gridQuestao.Rows.Count <= 0 Then
    '        Exit Sub
    '    End If

    '    For i = 0 To gridQuestao.Rows.Count - 1
    '        If gridQuestao.Rows(i).Cells(8).Text = 6 Then
    '            j += 1
    '        End If
    '    Next

    '    If gridQuestao.Rows.Count - 1 = j Then
    '        lblMsg.Text = "Nenhuma questão foi analisada!"
    '        lblMsg.ForeColor = Drawing.Color.Red
    '        pnlMsg.Visible = True

    '        Exit Sub
    '    End If

    '    For i = 0 To gridQuestao.Rows.Count - 1
    '        If gridQuestao.Rows(i).Cells(8).Text = 8 Then
    '            objAnaliseQuestao.AlteraAnaliseQuestao(gridQuestao.Rows(i).Cells(2).Text, 9, txtRetorno.Text)
    '        End If
    '    Next

    '    For i = 0 To gridQuestao.Rows.Count - 1
    '        If gridQuestao.Rows(i).Cells(8).Text = 7 Then

    '            dt = objRepresentante.RetornaRepresentante(gridQuestao.Rows(i).Cells(11).Text, 0).Tables(0)
    '            objQuestionario.representante.dc_email = dt.Rows(0)("email").ToString
    '            objQuestionario.representante.no_representante = dt.Rows(0)("Nome").ToString
    '            objQuestionario.representante.dc_area = dt.Rows(0)("Area").ToString

    '            If objQuestionarioBLL.EnviaEmailAnaliseQuestao(objQuestionario) Then

    '                'objQuestionarioBLL.AlteraQuestionario(objQuestionario.representante.cd_representante, 0, 4)

    '                lblMsg.Text = "Questionário finalizado com sucesso!"
    '                lblMsg.ForeColor = Drawing.Color.LightGreen
    '                pnlMsg.Visible = True
    '            Else
    '                lblMsg.Text = "Não foi possível finalizar o questionário. Favor verificar o email de cadastro do Representante."
    '                lblMsg.ForeColor = Drawing.Color.Red
    '                pnlMsg.Visible = True
    '            End If


    '        End If
    '    Next


    '    limpaCampos()
    '    pnlQuestionario.Visible = False
    '    carregaGridQuestao()
    'End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        limpaCampos()
        pnlQuestionario.Visible = False
        gridQuestao.DataSource = Nothing
        gridQuestao.DataBind()

        cmbArea.DataSource = Nothing
        cmbArea.Items.Clear()

        carrega_cmbEmpresa()

        divLegenda.Visible = False

        btnGravar.Enabled = False
        btnGravar.ImageUrl = "../imagens/save_disabled.png"

        btnCancelar.Enabled = False
        btnCancelar.ImageUrl = "../imagens/no_disabled.png"
    End Sub

    Protected Sub gridQuestao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridQuestao.SelectedIndexChanged

    End Sub

    Protected Sub gridItemQuestao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridItemQuestao.SelectedIndexChanged

    End Sub
End Class