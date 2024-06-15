Imports System.ComponentModel

Public Class Home
    Private Sub btn_cadp_Click(sender As Object, e As EventArgs) Handles btn_cadp.Click
        CadPacientes.ShowDialog()
    End Sub

    Private Sub btn_agenda_Click(sender As Object, e As EventArgs) Handles btn_agenda.Click
        Agenda.ShowDialog()
    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        db.Close()
        Application.Exit()
    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_usuLogado.Text = lbl_usuLogado.Text & aux_usu
        If aux_categoria = "Secretário(a)" Then
            btn_perfil.Enabled = False
        End If
        conecta_banco()
        carregar_dados()
    End Sub

    Private Sub dgv_home_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_home.CellContentClick
        With dgv_home
            aux_nome = .CurrentRow.Cells(0).Value
            aux_data = .CurrentRow.Cells(1).Value
            aux_hora = .CurrentRow.Cells(2).Value
            reagendar = True
            NovoAgendamento.ShowDialog()

        End With
    End Sub

    Private Sub Home_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    End Sub

    Private Sub Home_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Hide()
        Login.Show()
    End Sub

    Private Sub btn_perfil_Click(sender As Object, e As EventArgs) Handles btn_perfil.Click
        Perfis.ShowDialog()
    End Sub
End Class