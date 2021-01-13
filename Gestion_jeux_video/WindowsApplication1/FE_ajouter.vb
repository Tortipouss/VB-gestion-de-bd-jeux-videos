Imports MySql.Data.MySqlClient
Public Class FE_ajouter
    Public Sub FE_ajouter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FE_accueil.Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "ouverture de la fenêtre")
        genererLabelsTextbox()
    End Sub

    Dim numPositionLabelTxtbox As Integer = 1
    Public listeTypeDonneeCellules As New List(Of String)
    Public idEnTete As Integer = 1

    'Utilisé lors de la creation de la requête INSERT INTO. Sert à memoriser si une erreur champ vide à été rencontrée.
    'Si la variable à une valeur TRUE, c'est qu'une erreur de champ vide à été détecté
    Public isVide As Boolean = False

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

    Private Sub BT_annuler_Click(sender As Object, e As EventArgs) Handles BT_annuler.Click
        Me.Close()
        FE_accueil.Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "fermeture de la fenêtre")
    End Sub

    'Genere des labels et des texts box 
    'et les positionne sur la fenêtre
    Public Sub genererLabelsTextbox()

        'Si il s'agit d'une table associative
        If FE_accueil.isTableAssociative Then
            For i = 0 To FE_accueil.dg_donnee.ColumnCount - 1
                creerLabel(1)
                creerTxtBox()
                idEnTete += 1
            Next
            FE_accueil.Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "generation du/des labels et textboxes pour une table associative")
        Else

            For i = 1 To FE_accueil.dg_donnee.ColumnCount - 1
                creerLabel(0)
                creerTxtBox()
                idEnTete += 1
            Next
            FE_accueil.Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "generation du/des labels et textboxes pour une table non associative")

        End If
    End Sub

    Private Sub BT_valider_Click(sender As Object, e As EventArgs) Handles BT_valider.Click
        requeteValider()
    End Sub


    ''' <summary>
    ''' Execute la requête d'ajout d'éléments à la BD
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub requeteValider()
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Try
            If FE_accueil.isTableAssociative = True Then

                'Si il s'agit d'une table associative la clé primaire aura une valeur entrée par l'utilisateur
                query = "INSERT INTO " & FE_accueil.ST_donneeConnection.database & "." & FE_accueil.cb_tables.Text.ToString & " VALUES " & "(" & genererValeursQueryValider(remplirListeTypeDonneeCellules) & ")"
                FE_accueil.Log.ecritureFichierLog("[Requête]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & query.ToString)

            Else

                'Si il ne s'agit pas d'une table associative, la valeur par défault 
                'que la requête enverra sera 'NULL'
                query = "INSERT INTO " & FE_accueil.ST_donneeConnection.database & "." & FE_accueil.cb_tables.Text.ToString & " VALUES " & "(NULL," & genererValeursQueryValider(remplirListeTypeDonneeCellules) & ")"
                FE_accueil.Log.ecritureFichierLog("[Requête]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & query.ToString)

            End If
            Dim mycommand As New MySqlCommand(query, FE_accueil.getConnexion)
            READER = mycommand.ExecuteReader
            READER.Close()
            FE_accueil.actualiserDataGrid()
            Me.Close()
            FE_accueil.Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "ajout dans la table '" & FE_accueil.cb_tables.Text & "'")

        Catch

            If isVide = True Then
                MsgBox("Certains champs n'ont pas été remplis !", vbCritical, "Ajout impossible")
                FE_accueil.Log.ecritureFichierLog("[Echec]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "ajout dans la table: un champ obligatoire n'a pas été rempli")

            Else

                'Les types de données des saisies dans les champs remplis par l'utilisateur ne correspondent pas a ceux de la BD
                'ou alors une contrainte de clé étrangère n'a pas été respectée
                MsgBox("Contrainte non respectée OU au moins une de vos saisies a un type de donnée qui ne correspond pas à ceux de la base de donnée", vbCritical, "Ajout impossible")
                FE_accueil.Log.ecritureFichierLog("[Echec]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "ajout dans la table: contrainte non respectée ou mauvais type de donnée saisie dans un champs")

            End If
        End Try
    End Sub

    ''' <summary>
    ''' Génère et stock dans une variable la fin de la requête
    ''' d'ajout d'enregistrement à la base
    ''' </summary>
    ''' <returns>
    ''' Sous forme d'une chaine de caractères 
    ''' la fin de la requête d'jout d'elements dans la BD
    ''' </returns>
    ''' <remarks></remarks>
    Public Function genererValeursQueryValider(listeTypeDonneeCellules As List(Of String))
        isVide = False
        Dim valuesRequeteAjout As String = ""

        'L'index de la boucle commence a 1 pour, par défault, ne pas inclure la clé primaire
        For i As Integer = 1 To idEnTete - 1

            'Teste si la table est de type associative ET si la
            'colonne que l'on traite n'est pas la dernière de la table
            If FE_accueil.isTableAssociative = True And i <> idEnTete - 1 Then

                'Teste si le champs n'est pas est vide
                If Me.Controls("TBX_" & i).Text.ToString <> "" Then

                    'Si il n'est pas vide, on affiche ce qui a été entré suivi d'une virgule
                    valuesRequeteAjout += Me.Controls("TBX_" & i).Text + ","
                Else

                    'Si le champs est vide on signale une erreur champ vide 
                    isVide = True
                    Return ""
                End If

            ElseIf i = idEnTete - 1 Then 'Si l'on traite la dernière cellule

                'Teste si le champs n'est pas vide.
                If Me.Controls("TBX_" & i).Text.ToString <> "" Then

                    'Teste si il ne s'agit pas d'une table associative
                    If FE_accueil.isTableAssociative = False Then

                        'Si la cellule à remplir est de type varchar, on met entre guillmets
                        'ce que l'utilisateur a entré
                        If listeTypeDonneeCellules(i).Substring(0, listeTypeDonneeCellules(i).IndexOf("(")) = "varchar" Then
                            valuesRequeteAjout += """" + Me.Controls("TBX_" & i).Text + """"
                        Else
                            'Sinon on l'ajoute tel qu'il est, sans modifications
                            valuesRequeteAjout += Me.Controls("TBX_" & i).Text
                        End If
                    Else
                        'Si elle est de type associative, l'ajoute sans guillmets
                        valuesRequeteAjout += Me.Controls("TBX_" & i).Text
                    End If

                Else 'Si le champs est vide

                    'Test si il s'agit d'une table associative
                    If FE_accueil.isTableAssociative = False Then

                        'Si ce n'est pas le cas ET que le champs est vide on 
                        'ajoute des guimmets et une virgule à la requête
                        valuesRequeteAjout += " ''"
                    Else

                        'Sinon on signale une erreur champs obligatoire vide
                        isVide = True
                    End If
                End If

            Else 'Si la table n'est pas de type associative

                'Teste si le champs n'est pas vide.
                If Me.Controls("TBX_" & i).Text.ToString <> "" Then

                    'Si la cellule à remplir est de type varchar, on met entre guillmets
                    'ce que l'utilisateur a entré dans le champs de saisie
                    If listeTypeDonneeCellules(i).Substring(0, listeTypeDonneeCellules(i).IndexOf("(")) = "varchar" Then
                        valuesRequeteAjout += """" + Me.Controls("TBX_" & i).Text + """" + ","
                    Else

                        'Sinon on ajoute à ce qui a été saisi sans guillmets avec une virgule à la fin
                        valuesRequeteAjout += Me.Controls("TBX_" & i).Text + ","
                    End If
                Else
                    'Si le champs est vide on ajoute des guimmets et une virgule à la requête
                    valuesRequeteAjout += " '' " + ","

                End If
            End If
        Next
        Return valuesRequeteAjout
    End Function

    ''' <summary>
    ''' Remplit une liste par le type de données 
    ''' de toutes les cellules de la ligne selectionnées
    ''' </summary>
    ''' <returns>La liste contenant le type de données des cellules de la ligne selectionnée</returns>
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
End Class