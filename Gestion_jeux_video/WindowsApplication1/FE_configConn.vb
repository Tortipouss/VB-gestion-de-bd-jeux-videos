Imports MySql.Data.MySqlClient

Public Class FE_configConn
    Private MysqlConnTemp As New MySqlConnection

    Private Sub FE_configConn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FE_accueil.Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "ouverture de la fenêtre")
        remplissageAutoChamps()
    End Sub

    Private Sub bt_testConnection_Click(sender As Object, e As EventArgs) Handles bt_testConnection.Click
        validerTest()
    End Sub

    Private Sub bt_valider_Click(sender As Object, e As EventArgs) Handles bt_valider.Click
        validerModif()
    End Sub

    ''' <summary>
    ''' Change la connection pour celles entrée par l'utilisateur si celle-ci est valide
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub validerModif()
        modifConnString()
        Try
            'Si la connection à réussie
            FE_accueil.getConnexion().Open()
            FE_accueil.Couleur_label_de_connection()
            FE_accueil.initCombBox()
            Me.Close()
            FE_accueil.Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "validation des modifications et fermeture de la fenêtre")

        Catch
            MsgTentativeConn()

            'Change les données d'authentification pour celles données par defaut
            donneesConnDefaut()

            'Rend la connection active
            FE_accueil.Etablissement_connection()
            FE_accueil.Log.ecritureFichierLog("[Echec]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "validation des modifications et fermeture de la fenêtre : echec de la connection")

        End Try
    End Sub

    ''' <summary>
    ''' Effectue un test de connection avec les données entrées.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub validerTest()
        modifConnString()
        Try
            FE_accueil.getConnexion().Open()
            FE_accueil.Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "test de connection réussi")
            MsgTentativeConn()
        Catch

            MsgTentativeConn()
            FE_accueil.Etablissement_connection()
            FE_accueil.Log.ecritureFichierLog("[Echec]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "test de connection échoué")

        End Try
    End Sub

    Private Sub bt_annuler_Click(sender As Object, e As EventArgs) Handles bt_annuler.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Affiche un message informant de la réussite ou de l'échec de la connection à la BD
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MsgTentativeConn()
        FE_accueil.fermeConn()
        Try
            FE_accueil.getConnexion().Open()
            MsgBox("Connection à la base réussie", vbInformation, "Connection établie")
            FE_accueil.Log.ecritureFichierLog("[Succes]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "test de connection réussi")

        Catch

            MsgBox("Echec de la connection à la base", vbCritical, "La connection a échoué")
            FE_accueil.Log.ecritureFichierLog("[Echec]" & vbTab & "[" & Me.Name.ToString & "]" & vbTab & "test de connection échoué")

        End Try
    End Sub

    ''' <summary>
    ''' Remplit les champs avec les données présentes dans la BD
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub remplissageAutoChamps()
        cp_adresse.Text = FE_accueil.ST_donneeConnection.server
        cp_bd_name.Text = FE_accueil.ST_donneeConnection.database
        cp_password.Text = FE_accueil.ST_donneeConnection.password
        cp_user.Text = FE_accueil.ST_donneeConnection.user
    End Sub

    ''' <summary>
    ''' Remplit la structure de connection avec les entrées dans les champs
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub remplissageStructValChamps()
        FE_accueil.remplirStruct(cp_adresse.Text, cp_user.Text, cp_password.Text, cp_bd_name.Text)
    End Sub

    ''' <summary>
    ''' Remplit la structure de connection avec les valeurs par default
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub donneesConnDefaut()
        FE_accueil.remplirStruct("localhost", "root", "", "bibliotheque_jeux_video")
    End Sub

    ''' <summary>
    ''' Change les valeurs necessaires pour la connection à la BD
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub modifConnString()
        FE_accueil.fermeConn()
        remplissageStructValChamps()
        FE_accueil.getConnexion().ConnectionString =
           "server=" & FE_accueil.ST_donneeConnection.server & ";uid=" & FE_accueil.ST_donneeConnection.user & ";password=" & FE_accueil.ST_donneeConnection.password & ";database=" & FE_accueil.ST_donneeConnection.database
    End Sub

End Class