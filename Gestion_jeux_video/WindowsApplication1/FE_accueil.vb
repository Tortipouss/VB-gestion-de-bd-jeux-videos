Imports MySql.Data.MySqlClient

Public Class FE_accueil
    Private MysqlConn As New MySqlConnection
    Public Log As New CL_LOG 

    Public Structure ST_donneeConnection
        Shared server As String = "localhost"
        Shared user As String = "root"
        Shared password As String = ""
        Shared database As String = "bibliotheque_jeux_video"
    End Structure

    Private Sub FE_accueil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Log.creerFichierText()
        Etablissement_connection()
        Couleur_label_de_connection()
        initCombBox()
    End Sub

    Public Sub remplirStruct(server, user, password, database)
        ST_donneeConnection.server = server
        ST_donneeConnection.user = user
        ST_donneeConnection.password = password
        ST_donneeConnection.database = database
    End Sub

    Public Sub fermeConn()
        If getConnexion.State = ConnectionState.Open Then
            getConnexion.Close()
        End If
    End Sub

    Private Sub bt_configConnection_Click(sender As Object, e As EventArgs) Handles bt_configConnection.Click
        FE_configConn.Show()
    End Sub

    Public Function getConnexion() As MySqlConnection
        Return MysqlConn
    End Function

    ''' <summary>
    ''' Fonction éxecutée à l'initialisation du programme
    ''' afin d'établir une connection avec les données 
    ''' par défaut.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Etablissement_connection()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
            "server=" & ST_donneeConnection.server & ";uid=" & ST_donneeConnection.user & ";password=" & ST_donneeConnection.password & ";database=" & ST_donneeConnection.database
        MysqlConn.Dispose()
        Try
            MysqlConn.Open()
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' Change la couleur du label en vert si la connection a réussi
    ''' ou la laisse en rouge si la connection a échoué.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Couleur_label_de_connection()
        lb_fond_etat_connexion.BackColor = Color.Red
        If (MysqlConn.State = ConnectionState.Open) Then
            lb_fond_etat_connexion.BackColor = Color.Green
            Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "connection à la base de donnée '" & ST_donneeConnection.database & "'")
        Else
            Log.ecritureFichierLog("[Echec]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "connection à la base de donnée '" & ST_donneeConnection.database & "'")
        End If
    End Sub

    'Remplace les valeurs contenues dans la structure de connection
    'par celles entrées par l'utilisateur
    Private Sub AttributionDesValeursDeConnections()

        remplirStruct(FE_configConn.cp_adresse.Text,
                      FE_configConn.cp_user.Text,
                      FE_configConn.cp_password.Text,
                      FE_configConn.cp_bd_name.Text)
    End Sub

    'Remplit la combobox avec le nom des tables de la BD
    Public Sub initCombBox()
        Dim Query As String
        Dim Reader As MySqlDataReader
        Dim command As MySqlCommand
        Query = "SHOW TABLES FROM " & ST_donneeConnection.database
        command = New MySqlCommand(Query, MysqlConn)
        Log.ecritureFichierLog("[Requête]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & Query.ToString)
        Try
            Reader = command.ExecuteReader
            While Reader.Read
                cb_tables.Items.Add(Reader.GetString(0))
            End While
            Reader.Close()
            Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "affichage de " & cb_tables.Items.Count & " tables dans le libellé")

        Catch
            MsgBox("La connection à la base de donnée à l'aide des données d'authentification par défaut a échoué. Vous avez la possibilité de changer ces dernières en appuyant sur le bouton '" & Me.bt_configConnection.Text.Substring(1) & "' dans la fenêtre suivante. ", vbExclamation, "Connection impossible")
            Log.ecritureFichierLog("[Echec]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "Echec de la connection à la base de donnée " & ST_donneeConnection.database & " lors de l'initialisation du programme")
        End Try

    End Sub

    'Actualise le DataGrid à chaque fois que l'on
    'selectionne une nouvelle table dans la combobox
    Private Sub cb_tables_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_tables.SelectedIndexChanged
        actualiserDataGrid()
        Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "affichage de la table '" & cb_tables.Text & "' dans le DataGridView")
    End Sub

    'Liste qui va contenir le type de chaques clés présentes
    'sur une table donnée ('PRI' pour une cle primaire ou 'MUL' pour une étrangère) 
    Private li_typeDeCle As New List(Of String)

    Private Sub bt_supprimer_Click(sender As Object, e As EventArgs) Handles bt_supprimer.Click

        'Le bouton supprimer ne fonctionne que si une table à déja été affichée dans le DataGridView
        If dg_donnee.Columns.Count <> 0 Then

            Dim table As New DataTable

            remplirListeTypeCle()

            'Envoi des requêtes de suppression à la BD
            Try
                ' Si il s'agit d'une table associative on specifie dans la condition de la reqûete les deux clés etrangères
                If isTableAssociative() = True Then
                    Dim adapter As New MySqlDataAdapter("DELETE FROM " & ST_donneeConnection.database & "." & cb_tables.Text & " WHERE " & dg_donnee.Columns(0).HeaderCell.Value.ToString & " = " & dg_donnee.CurrentRow.Cells(dg_donnee.Columns(0).HeaderCell.Value.ToString).Value.ToString & " AND " & dg_donnee.Columns(1).HeaderCell.Value.ToString & " = " & dg_donnee.CurrentRow.Cells(dg_donnee.Columns(1).HeaderCell.Value.ToString).Value.ToString, MysqlConn)
                    adapter.Fill(table)
                    Log.ecritureFichierLog("[Requête]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "DELETE FROM " & ST_donneeConnection.database & "." & cb_tables.Text & " WHERE " & dg_donnee.Columns(0).HeaderCell.Value.ToString & " = " & dg_donnee.CurrentRow.Cells(dg_donnee.Columns(0).HeaderCell.Value.ToString).Value.ToString & " AND " & dg_donnee.Columns(1).HeaderCell.Value.ToString & " = " & dg_donnee.CurrentRow.Cells(dg_donnee.Columns(1).HeaderCell.Value.ToString).Value.ToString)

                Else
                    ' Autrement on n'en specifie qu'une 
                    Dim adapter As New MySqlDataAdapter("DELETE FROM " & ST_donneeConnection.database & "." & cb_tables.Text & " WHERE " & dg_donnee.Columns(0).HeaderCell.Value.ToString & " = " & dg_donnee.CurrentRow.Cells(dg_donnee.Columns(0).HeaderCell.Value.ToString).Value.ToString, MysqlConn)
                    adapter.Fill(table)
                    Log.ecritureFichierLog("[Requête]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "DELETE FROM " & ST_donneeConnection.database & "." & cb_tables.Text & " WHERE " & dg_donnee.Columns(0).HeaderCell.Value.ToString & " = " & dg_donnee.CurrentRow.Cells(dg_donnee.Columns(0).HeaderCell.Value.ToString).Value.ToString & " AND " & dg_donnee.Columns(1).HeaderCell.Value.ToString & " = " & dg_donnee.CurrentRow.Cells(dg_donnee.Columns(1).HeaderCell.Value.ToString).Value.ToString)

                End If
                actualiserDataGrid()
                Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "suppression d'un élement dans la table '" & cb_tables.Text & "'")

            Catch 'Si l'envoi des reqûetes ont échouées on specifie pourquoi

                '-> Parceque la table est vide
                If dg_donnee.RowCount <= 1 Then
                    If isTableAssociative() = True Then
                        Log.ecritureFichierLog("[Requête]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "DELETE FROM " & ST_donneeConnection.database & "." & cb_tables.Text & " WHERE " & dg_donnee.Columns(0).HeaderCell.Value.ToString & " = " & dg_donnee.CurrentRow.Cells(dg_donnee.Columns(0).HeaderCell.Value.ToString).Value.ToString & " AND " & dg_donnee.Columns(1).HeaderCell.Value.ToString & " = " & dg_donnee.CurrentRow.Cells(dg_donnee.Columns(1).HeaderCell.Value.ToString).Value.ToString)
                    End If
                    MsgBox("La table ne contient aucun enregistrement", vbOKOnly + vbCritical, "Suppression impossible")
                    Log.ecritureFichierLog("[Echec]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "suppression dans la table: tentative de suppression dans une table vide")

                Else
                    '-> Parceque elle est liée à une table enfant
                    Log.ecritureFichierLog("[Echec]" & vbTab & "[" & Me.Name.ToString & "]" & "DELETE FROM " & ST_donneeConnection.database & "." & cb_tables.Text & " WHERE " & dg_donnee.Columns(0).HeaderCell.Value.ToString & " = " & dg_donnee.CurrentRow.Cells(dg_donnee.Columns(0).HeaderCell.Value.ToString).Value.ToString)
                    MsgBox("Vous ne pouvez pas supprimer un enregistrement qui est lié à une table enfant", vbOKOnly + vbCritical, "Suppression impossible")
                    Log.ecritureFichierLog("[Echec]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "suppression dans la table: l'enregistrement est lié à une table enfant")
                End If
            End Try
        Else

            'Si aucune table n'est sélectionnée
            MsgBox("Veuillez d'abord sélectionner une table", vbExclamation, "Aucune table selectionnée")
            Log.ecritureFichierLog("[Echec]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "suppression dans la table: aucune table sélectionnée")
        End If
    End Sub

    ''' <summary>
    ''' Actualise le datagridview en interogeant la BD
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub actualiserDataGrid()
        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT * FROM " & ST_donneeConnection.database & "." & cb_tables.Text, MysqlConn)
        adapter.Fill(table)
        dg_donnee.DataSource = table
        adapter.Dispose()

        'compte le nombre d'enregistrements dans la table
        Dim nbrEnregistrement = 0
        Dim Query As String
        Dim Reader As MySqlDataReader
        Dim command As MySqlCommand
        Query = "SELECT * FROM " & ST_donneeConnection.database & "." & cb_tables.Text
        command = New MySqlCommand(Query, MysqlConn)
        Reader = command.ExecuteReader
        While Reader.Read
            nbrEnregistrement += 1
        End While
        Reader.Close()

        Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "actualisation du DataGridView, affichage de " & nbrEnregistrement.ToString & " enregistements")
        Log.ecritureFichierLog("[Requête]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "SELECT * FROM " & ST_donneeConnection.database & "." & cb_tables.Text)
    End Sub

    Private Sub bt_ajouter_Click(sender As Object, e As EventArgs) Handles bt_ajouter.Click

        'Le bouton ajouter ne fonctionne que si une table à déja été affichée dans le DataGridView
        If dg_donnee.Columns.Count <> 0 Then
            FE_ajouter.Show()
        Else
            MsgBox("Veuillez d'abord selectionner une table", vbExclamation, "Aucune table selectionnée")
            Log.ecritureFichierLog("[Echec]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "ouverture de la fenêtre '" & WindowsApplication1.FE_ajouter.Name.ToString & "' : aucune table sélectionnée")
        End If

    End Sub

    Private Sub dg_donnee_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_donnee.CellContentDoubleClick
        FE_update.Show()
    End Sub

    ''' <summary>
    ''' Teste si la table est associative
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isTableAssociative() As Boolean
        remplirListeTypeCle()
        Try
            If li_typeDeCle(0).ToString = "PRI" And li_typeDeCle(1).ToString = "PRI" Then
                Return True
            End If
        Catch
            Return False
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Rempli une liste avec les types des clés dans la table 
    ''' ("PRI" pour une clé primaire ou "MUL" pour une clé étrangère).
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub remplirListeTypeCle()
        li_typeDeCle.Clear()
        Dim Query As String
        Dim Reader As MySqlDataReader
        Dim command As MySqlCommand

        Query = "show columns from " & Me.cb_tables.Text.ToString & " from " & FE_accueil.ST_donneeConnection.database.ToString
        command = New MySqlCommand(Query, Me.getConnexion)
        Reader = command.ExecuteReader

        'Pour chacune des clés de la table, ajoute à la liste une valeur 'PRI' si il s'agit d'une clé primaire 
        'ou 'MUL' si il s'agit d'une clé étrangère
        While Reader.Read
            li_typeDeCle.Add(Reader.GetString(3))
        End While
        Reader.Close()

    End Sub

    Private Sub bt_log_Click(sender As Object, e As EventArgs) Handles bt_log.Click

        'Ouvre le fichier des logs
        Log.afficherFichier()
    End Sub
End Class