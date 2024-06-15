Public Class PerfilPaciente

    Private Sub PerfilPaciente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conecta_banco()

        txt_nome.Text = aux_nome_pac
        sql = "select * from pacientes where nomePaciente = '" & txt_nome.Text & "'"
        rs = db.Execute(sql)
        txt_celular.Text = rs.Fields(3).Value
        txt_contEmerg.Text = rs.Fields(4).Value
        txt_datanasc.Text = rs.Fields(2).Value
        txt_email.Text = rs.Fields(5).Value

        txt_nome.Enabled = False
        txt_celular.Enabled = False
        txt_contEmerg.Enabled = False
        txt_datanasc.Enabled = False
        txt_email.Enabled = False

        carrega_consultas()
    End Sub

    Private Sub dgv_consultas_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_consultas.CellContentDoubleClick
        With dgv_consultas
            If .CurrentRow.Cells(2).Selected Then
                aux_data = .CurrentRow.Cells(0).Value

                sql = "select * from agenda where dataConsulta = '" & aux_data & "' "
                rs = db.Execute(sql)
                aux_cod_cons = rs.Fields(0).Value
                aux_cod_convert = Integer.Parse(aux_cod_cons)
                sql = "select * from notas where codConsulta = " & aux_cod_convert & ""
                rs = db.Execute(sql)
                If rs.EOF = True Then
                    aux_data = .CurrentRow.Cells(0).Value
                    novaNota.ShowDialog()
                Else
                    MsgBox("Ja exitem notas realizadas sobre esta consulta", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
                    Exit Sub
                End If
            End If

            If .CurrentRow.Cells(1).Selected Then

                    aux_data = .CurrentRow.Cells(0).Value
                    sql = "select * from agenda where dataConsulta = '" & aux_data & "' "
                    rs = db.Execute(sql)
                    aux_cod_cons = rs.Fields(0).Value
                    aux_cod_convert = Integer.Parse(aux_cod_cons)
                    sql = "select * from notas where codConsulta = " & aux_cod_convert & ""
                    rs = db.Execute(sql)

                    If rs.EOF = False Then
                        notas = rs.Fields(2).Value
                        verNota = True
                        novaNota.ShowDialog()
                    Else
                        MsgBox("Não há notas nesta consulta", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
                        Exit Sub
                    End If

                End If


        End With
    End Sub

End Class