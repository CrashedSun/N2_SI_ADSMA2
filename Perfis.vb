Public Class Perfis
    Private Sub ToolStripTextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_busca.TextChanged
        Try
            sql = "select * from pacientes where nomePaciente like '%" & txt_busca.Text & "%'"
            rs = db.Execute(sql)
            With dgv_perfil
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(rs.Fields(1).Value, Nothing)
                    rs.MoveNext()
                Loop

            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar dados!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub Perfis_Load(sender As Object, e As EventArgs) Handles Me.Load
        carrega_perfis()
    End Sub

    Private Sub dgv_perfil_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_perfil.CellContentDoubleClick
        With dgv_perfil
            If .CurrentRow.Cells(1).Selected Then
                aux_nome_pac = .CurrentRow.Cells(0).Value
                PerfilPaciente.ShowDialog()
            End If
        End With
    End Sub
End Class