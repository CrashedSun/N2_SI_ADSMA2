Public Class novaNota
    Private Sub novaNota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn_confirmar.Visible = True
        lbl_data.Text = aux_data
        If verNota = True Then
            txt_nota.Text = notas
            btn_confirmar.Visible = False
            verNota = False
        End If

    End Sub

    Private Sub btn_confirmar_Click(sender As Object, e As EventArgs) Handles btn_confirmar.Click
        sql = "select * from pacientes where nomePaciente = '" & aux_nome_pac & "' "
        rs = db.Execute(sql)
        aux_cod_pac = rs.Fields(0).Value

        sql = "select * from agenda where dataConsulta = '" & aux_data & "' "
        rs = db.Execute(sql)
        aux_cod_cons = rs.Fields(0).Value
        aux_cod_convert = Integer.Parse(aux_cod_cons)

        sql = "insert into notas (codConsulta, codPaciente, nota) values (" & aux_cod_convert & ", '" & aux_cod_pac & "', '" & txt_nota.Text & "')"
        rs = db.Execute(sql)
        MsgBox("Notas Adicionadas com sucesso", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Aviso")
        limpa_dados()
        Exit Sub
    End Sub
End Class