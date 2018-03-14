Public Module modGlobal
    Public strConexao As String

    Sub New()
        ConectaBanco()
    End Sub

    Public Sub ConectaBanco()
        'Prod
        strConexao = "Data Source=mssql04-farm68.kinghost.net;Initial Catalog=etikagis;Persist Security Info=True; User ID=etikagis;Password=suporte2018"

        'Dev
        'strConexao = "Data Source=NESC-EC0146529;Initial Catalog=etikaconsultoria;Persist Security Info=True; User ID=etikaconsultoria;Password=P@ssw0rdM0del0"


    End Sub
End Module
