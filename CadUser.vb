Imports System.ComponentModel
Imports System.Data.OleDb

Public Class CadUser
    Private Sub CadUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conecta_banco()
        carrega_usuarios()

        btn_editar.Visible = False

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If (txt_senha.UseSystemPasswordChar And txt_rsenha.UseSystemPasswordChar) = True Then
            txt_senha.UseSystemPasswordChar = False
            txt_rsenha.UseSystemPasswordChar = False
        Else
            txt_senha.UseSystemPasswordChar = True
            txt_rsenha.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub btn_salvar_Click(sender As Object, e As EventArgs) Handles btn_salvar.Click
        Try
            If txt_nome_user.Text = "" Or txt_senha.Text = "" Or txt_rsenha.Text = "" Or txt_user.Text = "" Then
                MsgBox("Preencha todos os campos!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            ElseIf txt_senha.Text <> txt_rsenha.Text Then
                MsgBox("Senhas Diferentes", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            ElseIf cmb_categoria.Text = "Categoria" Then
                MsgBox("Selecione uma categoria", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Else

                sql = "select * from usuarios where usuario = '" & txt_user.Text & "'"
                rs = db.Execute(sql)
                aux_status = "ATIVO"
                If rs.EOF = True Then
                    sql = "insert into usuarios (nomeUsuario, usuario, senha, categoria, email, bloqueio) values ('" & txt_nome_user.Text & "', '" & txt_user.Text & "', '" & txt_senha.Text & "', '" & cmb_categoria.Text & "', '" & txt_email.Text & "', '" & aux_status & "') "
                    db.Execute(sql)

                    MsgBox("Dados Gravados com Sucesso", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Aviso")
                    limpa_dados()
                    carrega_usuarios()
                Else
                    MsgBox("Este usuário ja existe!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção")
                    Exit Sub
                End If

            End If
        Catch ex As Exception

            MsgBox("Erro ao Gravar os dados!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção")
        End Try
    End Sub

    Private Sub dgv_adm_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_adm.CellDoubleClick
        With dgv_adm
            txt_nome_user.Text = .CurrentRow.Cells(0).Value
            txt_user.Text = .CurrentRow.Cells(1).Value
            sql = "Select * from usuarios where usuario = '" & txt_user.Text & "'"
            rs = db.Execute(sql)

            txt_email.Text = rs.Fields(2).Value
                cmb_categoria.Text = rs.Fields(3).Value
                txt_senha.Text = rs.Fields(5).Value
                txt_rsenha.Text = rs.Fields(5).Value

                txt_user.Enabled = False

                btn_salvar.Visible = False
                btn_editar.Visible = True



        End With

        With dgv_adm
            aux_status = .CurrentRow.Cells(2).Value
            aux_usu = .CurrentRow.Cells(1).Value

            Try
                If .CurrentRow.Cells(4).Selected = True Then
                    resp = MsgBox("Deseja apagar o usuario: '" & aux_usu & "'?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Atenção")
                    If resp = MsgBoxResult.Yes Then
                        sql = "delete from usuarios where usuario = '" & aux_usu & "'"
                        rs = db.Execute(sql)
                        carrega_usuarios()
                    End If
                End If

            Catch ex As Exception
                MsgBox("Erro ao apagar  os dados", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            End Try

            Try
                If .CurrentRow IsNot Nothing Then
                    If .CurrentRow.Cells(2).Selected = True Then
                        If .CurrentRow.Cells(2).Value = "ATIVO" Then
                            aux_status = "BLOQUEADO"
                            sql = "update usuarios set bloqueio = '" & aux_status & "' where usuario = '" & aux_usu & "'"
                            rs = db.Execute(sql)
                            MsgBox("Status alterado com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Aviso")
                            carrega_usuarios()
                        Else
                            aux_status = "ATIVO"
                            sql = "update usuarios set bloqueio = '" & aux_status & "' where usuario = '" & aux_usu & "'"
                            rs = db.Execute(sql)
                            MsgBox("Status alterado com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Aviso")
                            carrega_usuarios()

                        End If
                    End If

                End If
            Catch ex As Exception
                MsgBox("Erro ao atualizar o status", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            End Try

        End With
    End Sub

    Private Sub btn_editar_Click(sender As Object, e As EventArgs) Handles btn_editar.Click
        If txt_nome_user.Text = "" Or txt_senha.Text = "" Or txt_rsenha.Text = "" Or txt_email.Text = "" Or txt_user.Text = "" Then
            MsgBox("Preencha todos os campos!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
        Else
            Try

                sql = "update usuarios set nomeUsuario = '" & txt_nome_user.Text & "', email = '" & txt_email.Text & "', senha = '" & txt_senha.Text & "', categoria = '" & cmb_categoria.Text & "' where usuario = '" & txt_user.Text & "' "
                rs = db.Execute(sql)
                MsgBox("Dados Editados com Sucesso", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Aviso")
                carrega_usuarios()
                limpa_dados()
                btn_editar.Visible = False
                btn_salvar.Visible = True

            Catch ex As Exception

                MsgBox("Erro ao Editar os dados!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção")
            End Try
        End If
    End Sub

    Private Sub CadUser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Hide()
        Login.Show()
    End Sub

    Private Sub CadUser_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        limpa_dados()
    End Sub


End Class