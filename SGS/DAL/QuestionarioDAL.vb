﻿Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class QuestionarioDAL

    Sub InsereQuestionario(objQuestionario As MODEL.Questionario)
        Try
            Dim dal As New BDDAL(COMUM.strConexao, True)
            Dim param() As SqlParameter

            param = {dal.CriarParametro("@cd_questao", SqlDbType.Int, objQuestionario.questao.cd_questao), _
                     dal.CriarParametro("@cd_representante", SqlDbType.Int, objQuestionario.representante.cd_representante), _
                     dal.CriarParametro("@cd_status", SqlDbType.Int, objQuestionario.status.cd_status), _
                     dal.CriarParametro("@nm_ordem", SqlDbType.Int, objQuestionario.nm_ordem), _
                     dal.CriarParametro("@no_userid", SqlDbType.VarChar, objQuestionario.no_userid)}

            dal.ExecuteNonQuery("st_sgs_questionario_i", CommandType.StoredProcedure, param)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ExcluiQuestionario(idRepresentante As Integer)
        Try
            Dim dal As New BDDAL(COMUM.strConexao, True)
            Dim param() As SqlParameter

            param = {dal.CriarParametro("@cd_representante", SqlDbType.Int, idRepresentante)}

            dal.ExecuteNonQuery("st_sgs_questionario_d", CommandType.StoredProcedure, param)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ListaQuestionario(codEmpresa As Integer, codCategoria As Integer, codRepresentante As Integer) As DataSet
        Try
            Dim dal As New BDDAL(COMUM.strConexao, True)
            Dim param() As SqlParameter

            param = {dal.CriarParametro("@cd_empresa", SqlDbType.Int, codEmpresa), _
                     dal.CriarParametro("@cd_categoria", SqlDbType.Int, codCategoria), _
                     dal.CriarParametro("@cd_representante", SqlDbType.Int, codRepresentante)}

            Return dal.GetDataSet("st_sgs_questionario_s", CommandType.StoredProcedure, param)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RetornaStatusQuestionario() As DataSet
        Try
            Dim dal As New BDDAL(COMUM.strConexao, True)
            Dim param() As SqlParameter

            param = {dal.CriarParametro("@tipo", SqlDbType.VarChar, "Questão")}

            Return dal.GetDataSet("st_sgs_status_s", CommandType.StoredProcedure, param)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class