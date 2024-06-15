Public Class Agenda
    Private Sub btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        NovoAgendamento.ShowDialog()
    End Sub

    Private Sub btn_sair_Click(sender As Object, e As EventArgs) Handles btn_sair.Click
        Me.Close()
    End Sub

    Private Sub Agenda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conecta_banco()
    End Sub


    Private Sub dgv_agenda_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_agenda.CellContentDoubleClick
        With dgv_agenda

            If .CurrentRow.Cells(3).Selected Then
                resp = MsgBox("Deseja cancelar este agendamento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Atenção")
                If resp = MsgBoxResult.Yes Then
                    aux_data = .CurrentRow.Cells(1).Value
                    aux_hora = .CurrentRow.Cells(2).Value

                    sql = "delete from agenda where dataConsulta = '" & aux_data & "' and horario = '" & aux_hora & "'"
                    rs = db.Execute(sql)
                    carregar_dados()
                End If
            Else
                aux_nome = .CurrentRow.Cells(0).Value
                aux_data = .CurrentRow.Cells(1).Value
                aux_hora = .CurrentRow.Cells(2).Value
                reagendar = True
                NovoAgendamento.ShowDialog()
            End If
        End With
    End Sub
End Class