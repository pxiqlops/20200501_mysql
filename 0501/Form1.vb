Imports MySql.Data.MySqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '初期表示の処理
        Selectdata()
    End Sub

    Private Sub ReLoad_Click(sender As Object, e As EventArgs) Handles ReLoad.Click
        '再読込ボタン処理
        Selectdata()
    End Sub

    Private Sub Selectdata()
        ' 1.接続文字列を作成する
        Dim Builder = New MySqlConnectionStringBuilder()
        ' データベースに接続するために必要な情報をBuilderに与える
        Builder.Server = "localhost"
        Builder.Port = 3306
        Builder.UserID = "root"
        Builder.Password = "Pxiq0319"
        Builder.Database = "springboot"
        Dim ConStr = Builder.ToString()

        ' 2.データベースに接続するためのコネクションを準備して、実際につなぐ
        Dim Con As New MySqlConnection
        Con.ConnectionString = ConStr
        Con.Open()

        ' 3.発行するSQL文を作成する
        Dim SqlStr = "SELECT * FROM customer"

        ' 4.データ取得のためのアダプタの設定
        Dim Adapter = New MySqlDataAdapter(SqlStr, Con)

        ' 5.データを取得
        Dim Ds As New DataSet
        Adapter.Fill(Ds)

        ' 6.DataGridViewに取得したデータを表示させる
        DataGridView1.DataSource = Ds.Tables(0)

        ' 7.データベースの切断
        Con.Close()
    End Sub


End Class
