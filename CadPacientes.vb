Public Class CadPacientes
    Private Sub btn_salvar_Click(sender As Object, e As EventArgs) Handles btn_salvar.Click
        If txt_cel.Text = "" Or txt_cont_emer.Text = "" Or dtp_nasc.Value.Date = data Or txt_email.Text = "" Or txt_nomep.Text = "" Then
            MsgBox("Preencha todos os campos", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
        Else
            If txt_nomep.Text.Length > 5 Then
                MsgBox("Use apenas as iniciais do seu paciente", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")

            Else
                If dtp_nasc.Value.Date >= data Then
                    MsgBox("Data invalida", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
                Else
                    sql = "select * from pacientes where nomePaciente = '" & txt_nomep.Text & "'"
                    rs = db.Execute(sql)
                    If rs.EOF = True Then
                        sql = "insert into pacientes (nomePaciente, dataNasc, telPaciente, numEmergencia, email) values ('" & txt_nomep.Text & "', '" & dtp_nasc.Text & "', '" & txt_cel.Text & "', '" & txt_cont_emer.Text & "', '" & txt_email.Text & "' )"
                        rs = db.Execute(sql)
                        MsgBox("Paciente cadastrado com sucesso", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atenção")
                        limpa_dados()
                    Else
                        MsgBox("Iniciais já cadastradas", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub CadPacientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conecta_banco()
    End Sub
End Class