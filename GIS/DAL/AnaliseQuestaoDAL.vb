Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class AnaliseQuestaoDAL
    Public Function ListaAnaliseQuestao(cd_representante As Integer, competencia As String) As DataSet
        Try
            Dim dal As New BDDAL(COMUM.strConexao, True)
            Dim param() As SqlParameter

            param = {dal.CriarParametro("@cd_representante", SqlDbType.VarChar, cd_representante), _
                     dal.CriarParametro("@competencia", SqlDbType.VarChar, competencia)}



            Return dal.GetDataSet("st_sgs_analise_questao_s", CommandType.StoredProcedure, param)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub AlteraAnaliseQuestao(cd_questionario As Integer, cd_status As Integer, dc_retorno As String)
        Try
            Dim dal As New BDDAL(COMUM.strConexao, True)
            Dim param() As SqlParameter

            param = {dal.CriarParametro("@cd_questionario", SqlDbType.VarChar, cd_questionario), _
                     dal.CriarParametro("@cd_status", SqlDbType.VarChar, cd_status), _
                     dal.CriarParametro("@dc_retorno", SqlDbType.VarChar, dc_retorno)}

            dal.GetDataSet("st_sgs_analise_questao_u", CommandType.StoredProcedure, param)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
