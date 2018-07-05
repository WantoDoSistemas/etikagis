Public Class frmResposta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("sessionUser") = "" Or Session("sessionUser") = Nothing Then
            Response.Redirect("frmLogin.aspx")
        End If

        carrega_prazo()
   
        If Not IsPostBack Then

            carregagridQuestao()

            If Session("codPerfil") = 2 Then
                frameFiltro.Visible = True
                carrega_cmbArea()
                panelBotoes.Visible = False
                btnGravaItem.Visible = False
            End If

            If Not Request.QueryString.Item("editar") Is Nothing Then
                If Request.QueryString("editar").ToString = "1" Then

                    habilitaEdicao()

                    lblCodQuestionario.Text = Request.QueryString("codQuestionario").ToString

                    lblOrdem.Text = Request.QueryString("ordem").ToString
                    lblQuestao.Text = Request.QueryString("questao").ToString

                    If Trim(Request.QueryString("retorno").ToString) <> " " Then
                        frameRetorno.Visible = True
                        lblRetorno.Text = Request.QueryString("retorno").ToString
                    Else
                        frameRetorno.Visible = False
                    End If

                    If Request.QueryString("tipo").ToString.Equals("I") Then
                        frameResposta.Visible = True
                        frameItemResposta.Visible = False
                        frameItemRespondida.Visible = False

                        If Request.QueryString("codStatus").ToString <> 4 Then
                            carrega_resposta(Request.QueryString("codQuestionario").ToString)
                        End If

                    ElseIf Request.QueryString("tipo").ToString.Equals("Q") Then
                        frameResposta.Visible = False
                        frameItemResposta.Visible = True
                        frameItemRespondida.Visible = True

                        If Session("codPerfil") = 2 Then
                            pnlItemResposta.Visible = False
                        Else
                            If Request.QueryString("codStatus").ToString <> 6 And Request.QueryString("codStatus").ToString <> 8 Then
                                carrega_gridItemResposta(Request.QueryString("codQuestionario").ToString)
                            Else
                                pnlItemResposta.Visible = False
                            End If
                        End If

                        carrega_gridItemRespondida(lblCodQuestionario.Text)
                    End If
                End If
            End If


            If Not Request.QueryString.Item("pesquisar") Is Nothing Then
                If Request.QueryString("pesquisar").ToString = "1" Then

                    habilitaPesquisa()

                    If Request.QueryString("codarea").ToString <> 0 Then
                        cmbArea.SelectedValue = Request.QueryString("codarea").ToString
                    End If

                    carregagridQuestao()

                    lblCodQuestionario.Text = Request.QueryString("codQuestionario").ToString

                    lblOrdem.Text = Request.QueryString("ordem").ToString
                    lblQuestao.Text = Request.QueryString("questao").ToString

                    If Trim(Request.QueryString("retorno").ToString) <> " " Then
                        frameRetorno.Visible = True
                        lblRetorno.Text = Request.QueryString("retorno").ToString
                    Else
                        frameRetorno.Visible = False
                    End If

                    If Request.QueryString("tipo").ToString.Equals("I") Then
                        frameResposta.Visible = True
                        frameItemResposta.Visible = False
                        frameItemRespondida.Visible = False

                        carrega_resposta(Request.QueryString("codQuestionario").ToString)

                    ElseIf Request.QueryString("tipo").ToString.Equals("Q") Then
                        frameResposta.Visible = False
                        frameItemResposta.Visible = True
                        frameItemRespondida.Visible = True

                        If Session("codPerfil") = 2 Then
                            pnlItemResposta.Visible = False
                        Else
                            If Request.QueryString("codStatus").ToString <> 6 And Request.QueryString("codStatus").ToString <> 8 Then
                                carrega_gridItemResposta(Request.QueryString("codQuestionario").ToString)
                            Else
                                pnlItemResposta.Visible = False
                            End If
                        End If

                        carrega_gridItemRespondida(lblCodQuestionario.Text)
                    End If
                End If
            End If

            If Not Request.QueryString.Item("excluir") Is Nothing Then
                If Request.QueryString("excluir").ToString = "1" Then

                    lblCodQuestionario.Text = Request.QueryString("codQuestionario").ToString

                    lblOrdem.Text = Request.QueryString("ordem").ToString
                    lblQuestao.Text = Request.QueryString("questao").ToString

                    If Trim(Request.QueryString("retorno").ToString) <> " " Then
                        frameRetorno.Visible = True
                        lblRetorno.Text = Request.QueryString("retorno").ToString
                    Else
                        frameRetorno.Visible = False
                    End If

                    If Not Request.QueryString.Item("coditem") Is Nothing Then
                        pnlMsg.Visible = False

                        pnlExcluirItem.Visible = True
                        pnlExcluirItem.Focus()

                        frameQuestao.Visible = True
                        frameItemResposta.Visible = True
                        frameItemRespondida.Visible = True

                        If Session("codPerfil") = 2 Then
                            pnlItemResposta.Visible = False
                        Else
                            If Request.QueryString("codStatus").ToString <> 6 And Request.QueryString("codStatus").ToString <> 8 Then
                                carrega_gridItemResposta(Request.QueryString("codQuestionario").ToString)
                            Else
                                pnlItemResposta.Visible = False
                            End If
                        End If

                        carrega_gridItemRespondida(lblCodQuestionario.Text)
                        Exit Sub
                    End If
                End If
            End If

            If Not Request.QueryString.Item("editarItem") Is Nothing Then
                lblEditarItem.Text = "1"

                lblCodQuestionario.Text = Request.QueryString("codQuestionario").ToString

                lblOrdem.Text = Request.QueryString("ordem").ToString
                lblQuestao.Text = Request.QueryString("questao").ToString

                If Session("codPerfil") = 2 Then
                    pnlItemResposta.Visible = False
                Else
                    If Request.QueryString("codStatus").ToString <> 6 And Request.QueryString("codStatus").ToString <> 8 Then
                        carrega_gridItemResposta(Request.QueryString("codQuestionario").ToString)
                    Else
                        pnlItemResposta.Visible = False
                    End If
                End If

                carrega_gridItemRespondida(Request.QueryString("codQuestionario").ToString)

                frameItemResposta.Visible = True
                frameItemRespondida.Visible = True
                frameQuestao.Visible = True

            End If

        End If
    End Sub

    Private Sub carrega_prazo()
        Dim objRepresentanteBLL As New BLL.RepresentanteBLL
        Dim dt As DataTable

        dt = objRepresentanteBLL.RetornaRepresentante(Session("codRepresentante")).Tables(0)

        If dt.Rows(0)("Prazo").ToString <> "" Then
            lblDataPrazo.Text = "Você tem até " & dt.Rows(0)("Prazo").ToString & " para responder"
        Else
            lblDataPrazo.Text = ""
        End If


        If lblDataPrazo.Text = "" Then
            lblDataPrazo.Visible = False
        Else
            lblDataPrazo.Visible = True
        End If
    End Sub

    Private Sub carrega_gridItemResposta(codQuestionario As Integer)
        Dim objQuestaoBLL As New BLL.QuestaoBLL
        Dim objRespostaBLL As New BLL.RespostaBLL
        Dim ds As DataSet
        Dim dt As DataTable


        If lblEditarItem.Text = "1" Then
            ds = objRespostaBLL.EditaListaItem(codQuestionario, Request.QueryString("grupo").ToString)
        Else
            ds = objQuestaoBLL.ListaItemQuestao(0, codQuestionario)
        End If

        dt = ds.Tables(0)
        gridItemResposta.DataSource = dt
        gridItemResposta.DataBind()
    End Sub

    Private Sub gridItemResposta_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridItemResposta.RowDataBound
        Dim lb As Label
        Dim temp As String
        Dim tx As TextBox

        If e.Row.RowType = DataControlRowType.Header Then
            'If Not Request.QueryString.Item("editarItem") Is Nothing Then
            If lblEditarItem.Text = "1" Then
                e.Row.Cells(2).Visible = False
                e.Row.Cells(3).Visible = False
                e.Row.Cells(4).Visible = False
                e.Row.Cells(5).Visible = False
            Else
                e.Row.Cells(2).Visible = False
                e.Row.Cells(3).Visible = False
            End If

        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            'If Not Request.QueryString.Item("editarItem") Is Nothing Then
            If lblEditarItem.Text = "1" Then
                e.Row.Cells(2).Visible = False
                e.Row.Cells(3).Visible = False
                e.Row.Cells(4).Visible = False
                e.Row.Cells(5).Visible = False

                tx = e.Row.Cells(1).FindControl("txtItemResposta")
                tx.Text = e.Row.Cells(4).Text
            Else
                e.Row.Cells(2).Visible = False
                e.Row.Cells(3).Visible = False
            End If

            temp = e.Row.Cells(3).Text
            lb = e.Row.Cells(0).FindControl("lblItemQuestao")
            lb.Text = "<div style='width:150px; white-space:pre-wrap;'>" & temp & "</div>"
        End If

    End Sub

    Private Sub carrega_gridItemRespondida(codQuestionario As Integer)
        Dim objRespostaBLL As New BLL.RespostaBLL
        Dim ds As DataSet
        Dim dt As DataTable

        ds = objRespostaBLL.ListaItemRespondido(codQuestionario)
        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            gridItemRespondida.DataSource = dt
            gridItemRespondida.DataBind()
        End If
    End Sub

    Private Sub gridItemRespondida_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridItemRespondida.RowDataBound


        If e.Row.RowType = DataControlRowType.Header Then

            If Session("codPerfil") = 2 Then
                e.Row.Cells(0).Visible = False
            Else                            
                If Request.QueryString("codStatus").ToString <> 6 And Request.QueryString("codStatus").ToString <> 8 Then
                    e.Row.Cells(0).Text = ""
                Else
                    e.Row.Cells(0).Visible = False
                End If
            End If

            e.Row.Cells(1).Visible = False
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then

            If Session("codPerfil") = 2 Then
                e.Row.Cells(0).Visible = False
            Else
                If Request.QueryString("codStatus").ToString <> 6 And Request.QueryString("codStatus").ToString <> 8 Then
                    e.Row.Cells(0).Text = "<a href='frmResposta.aspx?editarItem=1&grupo=" & e.Row.Cells(1).Text & "&codQuestionario=" & Request.QueryString("codQuestionario").ToString & "&questao=" & Request.QueryString("questao").ToString & "&ordem=" & Request.QueryString("ordem").ToString & "&codStatus=" & Request.QueryString("codStatus").ToString & "'><img src='../imagens/edit.png'></a>"
                Else
                    e.Row.Cells(0).Visible = False                    
                End If
            End If

            e.Row.Cells(1).Visible = False

        End If

    End Sub

    Private Sub carregagridQuestao()
        Dim objQuestionarioBLL As New BLL.QuestionarioBLL
        Dim parametros() As String = {"cd_perfil", "cd_usuario", "cd_empresa", "cd_representante", "dt_competencia"}
        Dim ds As DataSet
        Dim dt As DataTable
        Dim dtCompetencia As DataTable

        parametros(0) = Session("codPerfil")
        parametros(1) = Session("codUsuario")
        parametros(2) = Session("codEmpresa")
        If cmbArea.SelectedValue <> "" And cmbArea.SelectedValue <> "-1" Then
            parametros(3) = cmbArea.SelectedValue
        Else
            parametros(3) = 0
        End If

        dtCompetencia = objQuestionarioBLL.RetornaUltimaCompetencia(parametros(3)).Tables(0)

        If dtCompetencia.Rows.Count > 0 Then
            parametros(4) = dtCompetencia.Rows(0)("dt_competencia")
        End If

        ds = objQuestionarioBLL.RetornaQuestionarioRepresentante(parametros)
        dt = ds.Tables(0)

        If dt.Rows.Count > 0 Then
            divLegenda.Visible = True
        Else
            divLegenda.Visible = False
        End If

        gridQuestao.DataSource = dt

        gridQuestao.DataBind()
    End Sub

    Private Sub gridQuestao_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridQuestao.RowDataBound
        Dim temp As String

        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Text = ""
            e.Row.Cells(1).Text = ""
            e.Row.Cells(2).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False

            If Session("codPerfil") = 2 Then
                e.Row.Cells(10).Visible = False
            End If
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then

            If Session("codPerfil") = 1 Then
                temp = e.Row.Cells(5).Text

                e.Row.Cells(5).Text = "<div style='width:410px; white-space:pre-wrap;'>" & temp & "</div>"

                Select Case e.Row.Cells(7).Text
                    Case 4 'Aguardando Resposta 
                        e.Row.Cells(0).Text = "<img src='../imagens/Flag-Red.png'>"
                        e.Row.Cells(1).Text = "<a href='frmResposta.aspx?editar=1&codQuestionario=" & e.Row.Cells(2).Text & "&ordem=" & e.Row.Cells(3).Text & "&codQuestao=" & e.Row.Cells(4).Text & "&questao=" & temp & "&tipo=" & e.Row.Cells(6).Text & "&codStatus=" & e.Row.Cells(7).Text & "&retorno=" & e.Row.Cells(8).Text & "&codarea=" & 0 & "'><img src='../imagens/edit.png'></a>"
                    Case 5 'Gravado
                        e.Row.Cells(0).Text = "<img src='../imagens/Flag-Blue.png'>"
                        e.Row.Cells(1).Text = "<a href='frmResposta.aspx?editar=1&codQuestionario=" & e.Row.Cells(2).Text & "&ordem=" & e.Row.Cells(3).Text & "&codQuestao=" & e.Row.Cells(4).Text & "&questao=" & temp & "&tipo=" & e.Row.Cells(6).Text & "&codStatus=" & e.Row.Cells(7).Text & "&retorno=" & e.Row.Cells(8).Text & "&codarea=" & 0 & "'><img src='../imagens/edit.png'></a>"
                    Case 6 'Respondido
                        e.Row.Cells(0).Text = "<img src='../imagens/Flag-Green.png'>"
                        e.Row.Cells(1).Text = "<a href='frmResposta.aspx?pesquisar=1&codQuestionario=" & e.Row.Cells(2).Text & "&ordem=" & e.Row.Cells(3).Text & "&codQuestao=" & e.Row.Cells(4).Text & "&questao=" & temp & "&tipo=" & e.Row.Cells(6).Text & "&codStatus=" & e.Row.Cells(7).Text & "&retorno=" & e.Row.Cells(8).Text & "&codarea=" & 0 & "'><img src='../imagens/find.ico'></a>"
                    Case 7 'Devolvido
                        e.Row.Cells(0).Text = "<img src='../imagens/Flag-Yellow.png'>"
                        e.Row.Cells(1).Text = "<a href='frmResposta.aspx?editar=1&codQuestionario=" & e.Row.Cells(2).Text & "&ordem=" & e.Row.Cells(3).Text & "&codQuestao=" & e.Row.Cells(4).Text & "&questao=" & temp & "&tipo=" & e.Row.Cells(6).Text & "&codStatus=" & e.Row.Cells(7).Text & "&retorno=" & e.Row.Cells(8).Text & "&codarea=" & 0 & "'><img src='../imagens/edit.png'></a>"
                    Case 8 'Finalizado
                        e.Row.Cells(0).Text = "<img src='../imagens/Flag-Checkered.png'>"
                        e.Row.Cells(1).Text = "<a href='frmResposta.aspx?pesquisar=1&codQuestionario=" & e.Row.Cells(2).Text & "&ordem=" & e.Row.Cells(3).Text & "&codQuestao=" & e.Row.Cells(4).Text & "&questao=" & temp & "&tipo=" & e.Row.Cells(6).Text & "&codStatus=" & e.Row.Cells(7).Text & "&retorno=" & e.Row.Cells(8).Text & e.Row.Cells(8).Text & "&codarea=" & 0 & "'><img src='../imagens/find.ico'></a>"
                End Select
            Else
                e.Row.Cells(10).Visible = False

                temp = e.Row.Cells(5).Text

                e.Row.Cells(5).Text = "<div style='width:510px; white-space:pre-wrap;'>" & temp & "</div>"

                Select Case e.Row.Cells(7).Text
                    Case 4 'Aguardando Resposta 
                        e.Row.Cells(0).Text = "<img src='../imagens/Flag-Red.png'>"
                    Case 5 'Gravado
                        e.Row.Cells(0).Text = "<img src='../imagens/Flag-Blue.png'>"
                    Case 6 'Respondido
                        e.Row.Cells(0).Text = "<img src='../imagens/Flag-Green.png'>"
                    Case 7 'Devolvido
                        e.Row.Cells(0).Text = "<img src='../imagens/Flag-Yellow.png'>"
                    Case 8 'Finalizado
                        e.Row.Cells(0).Text = "<img src='../imagens/Flag-Checkered.png'>"
                End Select

                e.Row.Cells(1).Text = "<a href='frmResposta.aspx?pesquisar=1&codQuestionario=" & e.Row.Cells(2).Text & "&ordem=" & e.Row.Cells(3).Text & "&codQuestao=" & e.Row.Cells(4).Text & "&questao=" & temp & "&tipo=" & e.Row.Cells(6).Text & "&codStatus=" & e.Row.Cells(7).Text & "&retorno=" & e.Row.Cells(8).Text & "&area=" & e.Row.Cells(9).Text & "&codarea=" & e.Row.Cells(10).Text & "'><img src='../imagens/find.ico'></a>"
            End If

            e.Row.Cells(2).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
        End If
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As System.EventArgs) Handles btnGravar.Click
        Dim objRespostaBLL As New BLL.RespostaBLL
        Dim objQuestionarioBLL As New BLL.QuestionarioBLL
        Dim objResposta As New MODEL.Resposta
        Dim respondido As Boolean
        Dim cdRepresentante As Integer
        Dim dtCompetencia As DataTable
        Dim competencia As String

        If txtResposta.Visible = True And txtResposta.Text = "" Then

            lblMsg.Text = "Os campos com * são de preenchimento obrigatório!"
            lblMsg.ForeColor = Drawing.Color.Red
            pnlMsg.Visible = True
            Exit Sub
        Else
            pnlMsg.Visible = False
        End If


        If cmbArea.SelectedValue <> "" And cmbArea.SelectedValue <> "-1" Then
            cdRepresentante = cmbArea.SelectedValue
        Else
            cdRepresentante = 0
        End If

        dtCompetencia = objQuestionarioBLL.RetornaUltimaCompetencia(cdRepresentante).Tables(0)
        competencia = dtCompetencia.Rows(0)("dt_competencia")

        If txtResposta.Visible = True Then
            With objResposta
                If lblCodigoResposta.Text <> "" Then
                    .cd_resposta = lblCodigoResposta.Text
                End If

                .dc_resposta = txtResposta.Text
                .questionario.cd_questionario = Request.QueryString("codQuestionario").ToString
                .no_userid = Session("sessionUser")
            End With

            If Request.QueryString("codStatus").ToString = 4 Then
                If objRespostaBLL.InsereResposta(objResposta) Then
                    objQuestionarioBLL.AlteraQuestionario(Request.QueryString("codQuestionario").ToString, 5, competencia)

                    lblMsg.Text = "Resposta cadastrada com sucesso!"
                    lblMsg.ForeColor = Drawing.Color.LightGreen
                    pnlMsg.Visible = True
                    btnCancelar_Click(sender, e)
                End If
            ElseIf Request.QueryString("codStatus").ToString = 5 Or Request.QueryString("codStatus").ToString = 7 Then
                If objRespostaBLL.AlteraResposta(objResposta) Then
                    objQuestionarioBLL.AlteraQuestionario(Request.QueryString("codQuestionario").ToString, 5, competencia)
                    lblMsg.Text = "Resposta alterada com sucesso!"
                    lblMsg.ForeColor = Drawing.Color.LightGreen
                    pnlMsg.Visible = True
                    btnCancelar_Click(sender, e)
                End If
            End If
        Else
            If gridItemResposta.Rows.Count > 0 Then
                objQuestionarioBLL.AlteraQuestionario(Request.QueryString("codQuestionario").ToString, 5, competencia)

                lblMsg.Text = "Resposta cadastrada com sucesso!"
                lblMsg.ForeColor = Drawing.Color.LightGreen
                pnlMsg.Visible = True
                btnCancelar_Click(sender, e)
            Else
                lblMsg.Text = "O questionário deve ser todo respondido!"
                lblMsg.ForeColor = Drawing.Color.Red
                pnlMsg.Visible = True
            End If
        End If

        For i = 0 To gridQuestao.Rows.Count - 1
            If gridQuestao.Rows(i).Cells(7).Text = 4 Or gridQuestao.Rows(i).Cells(7).Text = 7 Then
                respondido = False
                Exit For
            Else
                respondido = True
            End If
        Next

        If respondido Then
            pnlMsg.Visible = False

            pnlFinalizar.Visible = True
        End If

    End Sub

    Protected Sub btnGravaItem_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnGravaItem.Click
        Dim objItemResposta As New MODEL.ItemResposta
        Dim objRespostaBLL As New BLL.RespostaBLL
        Dim objQuestionarioBLL As New BLL.QuestionarioBLL
        Dim tx As TextBox
        Dim codGrupoItem As Integer

        If lblEditarItem.Text = "1" Then
            codGrupoItem = Request.QueryString("grupo").ToString
        Else
            If gridItemRespondida.Rows.Count > 0 Then
                codGrupoItem = CInt(gridItemRespondida.Rows(gridItemRespondida.Rows.Count - 1).Cells(1).Text) + 1
            Else
                codGrupoItem = 1
            End If
        End If

        For i = 0 To gridItemResposta.Rows.Count - 1

            tx = gridItemResposta.Rows(i).Cells(0).FindControl("txtItemResposta")

            With objItemResposta
                If lblEditarItem.Text = "1" Then
                    If gridItemResposta.Rows(i).Cells(5).Text <> "" Then
                        .cd_item_resposta = gridItemResposta.Rows(i).Cells(5).Text
                    End If
                End If

                .cd_grupo_item_resposta = codGrupoItem
                .itemQuestao.cd_item_questao = gridItemResposta.Rows(i).Cells(2).Text
                .dc_resposta_item = tx.Text
                .no_userid = Session("sessionUser")
                .questionario.cd_questionario = Request.QueryString("codQuestionario").ToString
            End With

            If lblEditarItem.Text = "1" Then
                If objRespostaBLL.AlteraItemResposta(objItemResposta) Then
                    tx.Text = ""
                    lblEditarItem.Text = ""
                    If i = gridItemResposta.Rows.Count - 1 Then
                        lblMsg.Text = "Item de Resposta alterado com sucesso!"
                        lblMsg.ForeColor = Drawing.Color.LightGreen
                        pnlMsg.Visible = True
                        carrega_gridItemRespondida(Request.QueryString("codQuestionario").ToString)
                    End If
                End If
            Else
                If objRespostaBLL.InsereItemResposta(objItemResposta) Then
                    tx.Text = ""
                    If i = gridItemResposta.Rows.Count - 1 Then
                        lblMsg.Text = "Item de Resposta cadastrado com sucesso!"
                        lblMsg.ForeColor = Drawing.Color.LightGreen
                        pnlMsg.Visible = True
                        carrega_gridItemRespondida(Request.QueryString("codQuestionario").ToString)
                    End If
                End If
            End If
        Next

    End Sub

    Protected Sub btnNaoItem_Click(sender As Object, e As EventArgs) Handles btnNaoItem.Click
        pnlExcluirItem.Visible = False
        gridItemResposta.Focus()
    End Sub

    Protected Sub btnSimItem_Click(sender As Object, e As EventArgs) Handles btnSimItem.Click
        Dim objItemRespostaBLL As New BLL.RespostaBLL

        carrega_gridItemResposta(lblCodQuestionario.Text)
        pnlExcluirItem.Visible = False
        gridItemResposta.Focus()
    End Sub

    Protected Sub btnFinalizar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnFinalizar.Click
        If gridQuestao.Rows.Count <= 0 Then
            Exit Sub
        End If

        pnlMsg.Visible = False
        pnlFinalizar.Visible = True

    End Sub

    Protected Sub btnNao_Click(sender As Object, e As EventArgs) Handles btnNao.Click
        pnlMsg.Visible = False
        pnlFinalizar.Visible = False
    End Sub

    Protected Sub btnSim_Click(sender As Object, e As EventArgs) Handles btnSim.Click
        Dim objQuestionario As New MODEL.Questionario
        Dim objQuestionarioBLL As New BLL.QuestionarioBLL
        Dim cdRepresentante As Integer
        Dim dtCompetencia As DataTable
        Dim competencia As String

        cdRepresentante = Session("codRepresentante")

        dtCompetencia = objQuestionarioBLL.RetornaUltimaCompetencia(cdRepresentante).Tables(0)
        competencia = dtCompetencia.Rows(0)("dt_competencia")

        pnlFinalizar.Visible = False

        objQuestionario.representante.cd_representante = Session("codRepresentante")
        objQuestionario.representante.dc_email = Session("email")
        objQuestionario.representante.no_representante = Session("nome")
        objQuestionario.representante.dc_area = Session("area")

        'If objQuestionarioBLL.EnviaEmailQuestionarioRespondido(objQuestionario) Then

        For i = 0 To gridQuestao.Rows.Count - 1
            If gridQuestao.Rows(i).Cells(7).Text = 5 Then
                objQuestionarioBLL.AlteraQuestionario(gridQuestao.Rows(i).Cells(2).Text, 6, competencia)
            End If
        Next

        lblMsg.Text = "Questionário finalizado com sucesso!"
        lblMsg.ForeColor = Drawing.Color.LightGreen
        pnlMsg.Visible = True
        'Else
        'lblMsg.Text = "Não foi possível finalizar o questionário."
        'lblMsg.ForeColor = Drawing.Color.Red
        'pnlMsg.Visible = True
        'End If

        limpaCampos()
    End Sub

    Protected Sub btnNovo_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnNovo.Click
        limpaCampos()

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
        lblQuestao.Text = ""
        txtResposta.Text = ""
        lblRetorno.Text = ""

        frameQuestao.Visible = False
        frameRetorno.Visible = False
        frameResposta.Visible = False
        frameItemResposta.Visible = False
        frameItemRespondida.Visible = False
        carregagridQuestao()
    End Sub

    Private Sub habilitaEdicao()
        limpaCampos()
        frameQuestao.Visible = True

        txtResposta.Enabled = True

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

    Private Sub habilitaPesquisa()
        limpaCampos()
        frameQuestao.Visible = True

        txtResposta.Enabled = False

        btnNovo.Enabled = False
        btnNovo.ImageUrl = "../imagens/add_disabled.png"

        btnCancelar.Enabled = True
        btnCancelar.ImageUrl = "../imagens/no.ico"

        pnlMsg.Visible = False
    End Sub

    Private Sub carrega_resposta(codQuestionario As Integer)
        Dim objRespostaBLL As New BLL.RespostaBLL
        Dim dt As DataTable

        dt = objRespostaBLL.RetornaResposta(codQuestionario).Tables(0)

        If dt.Rows.Count > 0 Then
            txtResposta.Text = dt.Rows(0)("Resposta").ToString
            lblCodigoResposta.Text = dt.Rows(0)("codResposta").ToString
        End If

    End Sub

    Private Sub carrega_cmbArea()
        Dim objRepresentanteBLL As New BLL.RepresentanteBLL
        Dim lista As New ListItem

        cmbArea.DataTextField = "Area"
        cmbArea.DataValueField = "Cod. Representante"
        cmbArea.DataSource = objRepresentanteBLL.ListaArea(Session("codEmpresa")).Tables(0)
        cmbArea.DataBind()

        lista.Text = "<Selecione>"
        lista.Value = -1
        cmbArea.Items.Insert(0, lista)
        'lista.Text = "Todos"
        'lista.Value = 999999
        'cmbArea.Items.Insert(1, lista)

    End Sub

    Protected Sub cmbArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbArea.SelectedIndexChanged
        carregagridQuestao()
    End Sub

    Protected Sub gridItemRespondida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridItemRespondida.SelectedIndexChanged

    End Sub
End Class