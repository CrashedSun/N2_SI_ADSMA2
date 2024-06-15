Public Class NovoAgendamento
    Private Sub NovoAgendamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conecta_banco()


        If reagendar = True Then
            cmb_paciente.Text = aux_nome
            dtp_data.Text = aux_data
            cmb_horario.Text = aux_hora

            cmb_paciente.Enabled = False
        Else
            sql = "select * from pacientes"
            rs = db.Execute(sql)

            Do While rs.EOF = False
                With cmb_paciente
                    .Items.Add(rs.Fields(1).Value)
                    rs.MoveNext()
                End With
            Loop
        End If

        preencherHora()
        dtp_data.Value = data.ToString
        consultaData()
    End Sub

    Private Sub brn_conf_agenda_Click(sender As Object, e As EventArgs) Handles brn_conf_agenda.Click
        If reagendar = True Then
            sql = "update agenda set dataConsulta = '" & dtp_data.Value.Date & "', horario = '" & cmb_horario.Text & "' where (codPaciente = (SELECT codPaciente FROM pacientes WHERE nomePaciente = '" & aux_nome & "') and dataConsulta = '" & aux_data & "')"
            rs = db.Execute(sql)
            reagendar = False
            cmb_paciente.Enabled = True
            limpa_dados()
            carregar_dados()
            preencherHora()
            Exit Sub
        End If

        If cmb_paciente.Text = "" Or cmb_horario.Text = "" Then
            MsgBox("Preencha todos os campos", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
        ElseIf dtp_data.Value.Date < data Then
            MsgBox("Data inválida", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
        Else
            sql = "insert into agenda (codPaciente, dataConsulta, horario) select codPaciente, '" & dtp_data.Value.Date & "', '" & cmb_horario.Text & "' from pacientes where nomePaciente = '" & cmb_paciente.Text & "'"
            rs = db.Execute(sql)
            MsgBox("Consulta agendada com sucesso", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Aviso")
            carregar_dados()
            limpa_dados()
            dtp_data.Value = data.ToString
            consultaData()

        End If

    End Sub

    Private Sub NovoAgendamento_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        limpa_dados()
    End Sub

    Private Sub NovoAgendamento_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        limpa_dados()
    End Sub

    Private Sub dtp_data_ValueChanged(sender As Object, e As EventArgs) Handles dtp_data.ValueChanged
        preencherHora()
        consultaData()
    End Sub
End Class