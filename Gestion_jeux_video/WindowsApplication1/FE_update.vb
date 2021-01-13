Imports MySql.Data.MySqlClient
Public Class FE_update
    Private Sub FE_update_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FE_accueil.Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "ouverture de la fenêtre")
        remplirListeTypeDonneeCellules()
        genererLabelsTextbox()
        remplirTxtBox()
    End Sub

    Private Sub bt_annuler_Click(sender As Object, e As EventArgs) Handles bt_annuler.Click
        Me.Close()
        FE_accueil.Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "fermeture de la fenêtre")
    End Sub

    ''' <summary>
    ''' Genere la requête finale
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function genererReq()
        FE_ajouter.isVide = False
        Dim constructReq As String = ""
        Dim reqFinale As String = ""
        Dim index As Integer = 1

        If FE_accueil.isTableAssociative Then
            index = 0
        End If

        For i As Integer = index To idEnTete - 1

            ' Teste si la cellule selectionnée est de type string
            If listeTypeDonneeCellules(i).Substring(0, listeTypeDonneeCellules(i).IndexOf("(")) = "varchar" Then

                'Mets la saisie entre parenthèses
                constructReq = """" + Me.Controls("TBX_" & (i).ToString).Text + """"
            ElseIf Me.Controls("TBX_" & (i).ToString).Text.ToString = "" Then 'Teste si la cellule est vide
                constructReq = """"""
            Else
                constructReq = Me.Controls("TBX_" & (i).ToString).Text
            End If

            reqFinale += FE_accueil.dg_donnee.Columns(i).HeaderCell.Value.ToString & " = " & constructReq

            'Ajoute une virgule à la fin si on ne traite pas le dernier champs
            If i <> idEnTete - 1 Then
                reqFinale += ","
            End If
        Next

        Return reqFinale
    End Function

    Private Sub bt_valider_Click(sender As Object, e As EventArgs) Handles bt_valider.Click

        'Fait un UPDATE dans la base de donnée en prenant comme valeur la saisie de l'utilisateur dans le DataGrid
        Dim READER As MySqlDataReader
        Dim query As String = "UPDATE " & FE_accueil.ST_donneeConnection.database & "." & FE_accueil.cb_tables.Text & " SET " & genererReq() & " WHERE " & FE_accueil.dg_donnee.Columns(0).HeaderCell.Value.ToString & " = " & FE_accueil.dg_donnee.CurrentRow.Cells(FE_accueil.dg_donnee.Columns(0).HeaderCell.Value.ToString).Value.ToString
        Try
            Dim cmd As New MySqlCommand(query, FE_accueil.getConnexion)
            READER = cmd.ExecuteReader
            READER.Close()
            FE_accueil.actualiserDataGrid()
            Me.Close()
            FE_accueil.Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "mis à jour dans la table")
            FE_accueil.Log.ecritureFichierLog("[Requête]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & query.ToString)

        Catch
            If FE_ajouter.isVide = True Then
                MsgBox("Certains champs obligatoires n'ont pas été remplis !", vbCritical, "Modification impossible")
                FE_accueil.Log.ecritureFichierLog("[Echec]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "mis à jour d'un enregistrement dans la table: un champ obligatoire n'a pas été rempli")
            Else

                'Les types de données des saisies dans les champs remplis par l'utilisateur ne correspondent pas a ceux de la BD
                'ou alors une contrainte de clé étrangère n'a pas été respectée
                MsgBox("Contrainte non respectée OU au moins une de vos saisies a un type de donnée qui ne correspond pas à ceux de la base de donnée", vbCritical, "Modification impossible")
                FE_accueil.Log.ecritureFichierLog("[Echec]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "mis à jour d'un enregistrement dans la table: contrainte non respectée ou mauvais type de donnée saisie dans un champs")

            End If

            FE_accueil.Log.ecritureFichierLog("[Requête]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & query.ToString)

        End Try
    End Sub

    Dim numPositionLabelTxtbox As Integer = 1
    Public listeTypeDonneeCellules As New List(Of String)
    Public idEnTete As Integer = 0

    ''' <summary>
    ''' Crée une TextBox, et lui donne une position sur la fenetre
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub creerTxtBox()
        Dim txt As New System.Windows.Forms.TextBox()
        Me.Controls.Add(txt)
        txt.Top = numPositionLabelTxtbox * 40
        txt.Left = 200
        numPositionLabelTxtbox += 1
        txt.Name = "TBX_" & idEnTete.ToString()
    End Sub

    ''' <summary>
    ''' Crée un label, lui donne une valeure et une position sur la fenetre
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub creerLabel(indexDepart As Integer)
        Dim txt As New System.Windows.Forms.Label()
        txt.TextAlign = ContentAlignment.MiddleRight
        Me.Controls.Add(txt)
        txt.Top = numPositionLabelTxtbox * 40
        txt.Left = 80
        txt.Name = "LB_" & idEnTete
        txt.Text = FE_accueil.dg_donnee.Columns(idEnTete - indexDepart).HeaderCell.Value.ToString
    End Sub

    'Genere des labels et des texts box 
    'et les positionne sur la fenêtre
    Public Sub genererLabelsTextbox()
        If FE_accueil.isTableAssociative Then
            For i = 0 To FE_accueil.dg_donnee.ColumnCount - 1
                creerLabel(0)
                creerTxtBox()
                idEnTete += 1
            Next
            FE_accueil.Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "generation du/des labels et textboxes pour une table associative")
        Else
            idEnTete = 1
            For i = 1 To FE_accueil.dg_donnee.ColumnCount - 1
                creerLabel(0)
                creerTxtBox()
                idEnTete += 1
            Next
            FE_accueil.Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "generation du/des labels et textboxes pour une table non associative")

        End If
    End Sub

    ''' <summary>
    ''' Se charge de remplir une liste avec 
    ''' le type de données des colonnes de la table 
    ''' affichée dans le dataGridView
    ''' </summary>
    ''' <returns> 
    ''' une liste remplie avec 
    ''' le type de données des colonnes de la table 
    ''' affichée dans le dataGridView
    ''' </returns>
    ''' <remarks></remarks>
    Public Function remplirListeTypeDonneeCellules()
        listeTypeDonneeCellules.Clear()
        Dim Query As String
        Dim Reader As MySqlDataReader
        Dim command As MySqlCommand
        Query = "show columns from " & FE_accueil.cb_tables.Text.ToString & " from " & FE_accueil.ST_donneeConnection.database.ToString
        command = New MySqlCommand(Query, FE_accueil.getConnexion)
        Reader = command.ExecuteReader
        While Reader.Read
            listeTypeDonneeCellules.Add(Reader.GetString(1))
        End While
        Reader.Close()
        Return listeTypeDonneeCellules
    End Function

    'Rempli les textboxs avec les valeurs de la table.
    Public Sub remplirTxtBox()
        Dim index As Integer = 1
        If FE_accueil.isTableAssociative Then
            index = 0
        End If

        For i As Integer = index To idEnTete - 1
            Me.Controls("TBX_" & (i)).Text = FE_accueil.dg_donnee.CurrentRow.Cells(FE_accueil.dg_donnee.Columns(i).HeaderCell.Value.ToString).Value.ToString
        Next
    End Sub

End Class