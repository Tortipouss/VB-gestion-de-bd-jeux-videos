Imports System.IO
Imports System.IO.File
Public Class CL_LOG

    Dim cheminFichier As String = Application.StartupPath & "\journal\log.txt"
    ''' <summary>
    ''' Crée le fichier des logs si celui-ci n'existe pas
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub creerFichierText()
        If Not Exists(cheminFichier) Then
            Dim fs As FileStream = File.Create(cheminFichier)
            fs.Close()
        End If
    End Sub

    ''' <summary>
    ''' Ajoute une ligne au fichier des logs 
    ''' contenant la date, l'heure et le texte 
    ''' contenu dans la variable texteLog.
    ''' </summary>
    ''' <param name="texteLog">Le texte qui sera ajouté dans le fichier des logs, juste après le nom de la fenêtre</param>
    ''' <remarks>
    ''' La fonction est conçue pour être rappelée ailleur dans
    ''' le programme, afin de faciliter les entrées dans le fichier des logs 
    ''' </remarks>
    Public Sub ecritureFichierLog(texteLog)
        Dim sw As StreamWriter = AppendText(cheminFichier)
        sw.WriteLine(Now() & " " & texteLog)
        sw.Close()
    End Sub

    ''' <summary>
    ''' Ouvre le fichier .txt contenant les logs
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub afficherFichier()
        Process.Start(cheminFichier)
    End Sub
End Class
