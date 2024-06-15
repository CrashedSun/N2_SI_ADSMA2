Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Module Modulo
    Public db As New ADODB.Connection
    Public rs As New ADODB.Recordset
    Public sql As String
    Public dir_banco = Application.StartupPath & "\Banco\database.mdb"
    Public cont As Integer
    Public resp As String
    Public aux_categoria, aux_usu, aux_status, aux_nome, aux_data, aux_hora, aux_nome_pac, aux_cod_pac, aux_cod_cons As String
    Public reagendar = False
    Public data As String = DateTime.Today.ToString("dd/MM/yyyy")
    Public dataFormatada, dataFormatadaSQL As String
    Public hora As Integer = 13
    Public horarioOcupado As String
    Public notas As String
    Public verNota = False
    Public aux_cod_convert As Integer

    Sub conecta_banco()
        Try

            db = CreateObject("ADODB.Connection")
            db.Open("Provider=Microsoft.JET.OLEDB.4.0;Data Source=" & dir_banco)

        Catch ex As Exception
            MsgBox("Erro de Conexão", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Sub carregar_dados()
        With Home.dgv_home
            Try
                sql = "select agenda.*, pacientes.nomePaciente from agenda inner join pacientes on agenda.codPaciente = pacientes.codPaciente where (agenda.dataConsulta >= '" & data & "') order by agenda.dataConsulta, agenda.horario asc"
                rs = db.Execute(sql)

                cont = 1
                .Rows.Clear()
                Do While rs.EOF = False And cont <= 10
                    .Rows.Add(rs.Fields("nomePaciente").Value, rs.Fields(2).Value, rs.Fields(3).Value)
                    cont = cont + 1
                    rs.MoveNext()
                Loop

            Catch ex As Exception
                MsgBox("Erro ao carregar dados!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
            End Try
        End With


        With Agenda.dgv_agenda
            Try
                sql = "select agenda.*, pacientes.nomePaciente from agenda inner join pacientes on agenda.codPaciente = pacientes.codPaciente where agenda.dataConsulta >= '" & data & "' order by agenda.dataConsulta, agenda.horario desc"
                rs = db.Execute(sql)

                cont = 1
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(rs.Fields("nomePaciente").Value, rs.Fields(2).Value, rs.Fields(3).Value)
                    cont = cont + 1
                    rs.MoveNext()
                Loop

            Catch ex As Exception
                MsgBox("Erro ao carregar dados!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
            End Try
        End With




    End Sub
    Sub carrega_usuarios()

        With CadUser.dgv_adm
            Try
                sql = "select * from usuarios order by usuario asc"
                rs = db.Execute(sql)

                cont = 1
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(rs.Fields(1).Value, rs.Fields(0).Value, rs.Fields(4).Value, rs.Fields(3).Value, Nothing)
                    rs.MoveNext()
                Loop

            Catch ex As Exception
                MsgBox("Erro ao carregar dados!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
            End Try
        End With
    End Sub
    Sub carrega_perfis()
        With Perfis.dgv_perfil
            Try
                sql = "select * from pacientes order by nomePaciente asc"
                rs = db.Execute(sql)

                cont = 1
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(rs.Fields(1).Value, Nothing)
                    rs.MoveNext()
                Loop

            Catch ex As Exception
                MsgBox("Erro ao carregar dados!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
            End Try
        End With

    End Sub
    Sub carrega_consultas()
        With PerfilPaciente.dgv_consultas

            Try
                sql = "select * from agenda where codPaciente = (select codPaciente from pacientes where nomePaciente = '" & PerfilPaciente.txt_nome.Text & "') order by dataConsulta desc"
                rs = db.Execute(sql)

                cont = 1
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(rs.Fields(2).Value, Nothing)
                    rs.MoveNext()
                Loop

            Catch ex As Exception
                MsgBox("Erro ao carregar dados!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
            End Try
        End With
    End Sub


    Sub limpa_dados()
        With Login
            .txt_usuario.Text = ""
            .txt_senha.Text = ""
            .chk_vsenha.Checked = False
        End With

        With CadUser
            .txt_nome_user.Text = ""
            .txt_user.Text = ""
            .txt_email.Text = ""
            .txt_senha.Text = ""
            .txt_rsenha.Text = ""
            .cmb_categoria.Text = "Categoria"
            .txt_user.Enabled = True
            .btn_editar.Visible = False
            .btn_salvar.Visible = True
            .CheckBox1.Checked = False
        End With

        With CadPacientes
            .txt_cel.Text = ""
            .txt_cont_emer.Text = ""
            .dtp_nasc.Text = data
            .txt_email.Text = ""
            .txt_nomep.Text = ""

        End With

        With NovoAgendamento
            .cmb_paciente.Text = ""
            .cmb_horario.Text = ""
            .dtp_data.Value = data
            .cmb_paciente.Enabled = True
        End With

        With novaNota
            .txt_nota.Text = ""
            .lbl_data.Text = ""
            .Close()
        End With

    End Sub
    Sub preencherHora()
        NovoAgendamento.cmb_horario.Items.Clear()

        For hora = 13 To 20
            NovoAgendamento.cmb_horario.Items.Add(hora.ToString() + ":00")
        Next
    End Sub

    Sub consultaData()
        sql = "select  horario from agenda where dataConsulta = '" & NovoAgendamento.dtp_data.Value.Date & "' "
        rs = db.Execute(sql)

        If rs.EOF = False Then
            Do While rs.EOF = False
                horarioOcupado = rs.Fields("horario").Value.ToString
                If NovoAgendamento.cmb_horario.Items.Contains(horarioOcupado) Then
                    NovoAgendamento.cmb_horario.Items.Remove(horarioOcupado)
                End If
                rs.MoveNext()
            Loop
        End If
    End Sub
End Module

