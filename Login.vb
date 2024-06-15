Imports System.ComponentModel

Public Class Login
    Private Sub chk_vsenha_CheckedChanged(sender As Object, e As EventArgs) Handles chk_vsenha.CheckedChanged
        If txt_senha.UseSystemPasswordChar = True Then
            txt_senha.UseSystemPasswordChar = False
        Else
            txt_senha.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub btn_entrar_Click(sender As Object, e As EventArgs) Handles btn_entrar.Click
        ' Try

        If txt_usuario.Text = "" Or txt_senha.Text = "" Then
                MsgBox("Preecha todos os campos!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
            ElseIf (txt_usuario.Text = "admin" And txt_senha.Text = "admin") Then
                limpa_dados()
                Hide()
                CadUser.Show()

            Else
                sql = "select * from usuarios where usuario = '" & txt_usuario.Text & "' and senha = '" & txt_senha.Text & "'"
                rs = db.Execute(sql)

                If rs.EOF = True Then
                    MsgBox("Usuario invalido!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção")
                    Exit Sub
                Else
                    If rs.Fields(4).Value = "ATIVO" Then
                        aux_categoria = rs.Fields(3).Value
                        aux_usu = rs.Fields(1).Value
                        limpa_dados()
                        Hide()
                        Home.Show()

                    Else
                        MsgBox("Seu acesso foi bloqueado, contate o administrador.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                        limpa_dados()
                        db.Close()
                    End If

                End If

            End If
            ' Catch ex As Exception
        '    MsgBox("Erro ao efetuar login", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
        ' End Try

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        conecta_banco()
    End Sub

    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub
End Class
