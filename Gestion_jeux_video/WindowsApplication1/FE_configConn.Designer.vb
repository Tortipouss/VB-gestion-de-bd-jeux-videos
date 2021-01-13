<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FE_configConn
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.bt_testConnection = New System.Windows.Forms.Button()
        Me.lb_nom_BD = New System.Windows.Forms.Label()
        Me.lb_mdp = New System.Windows.Forms.Label()
        Me.lb_nom_utilisateur = New System.Windows.Forms.Label()
        Me.lb_serveur = New System.Windows.Forms.Label()
        Me.cp_adresse = New System.Windows.Forms.TextBox()
        Me.cp_user = New System.Windows.Forms.TextBox()
        Me.cp_password = New System.Windows.Forms.TextBox()
        Me.cp_bd_name = New System.Windows.Forms.TextBox()
        Me.bt_annuler = New System.Windows.Forms.Button()
        Me.bt_valider = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'bt_testConnection
        '
        Me.bt_testConnection.AccessibleName = "bt_testConnection"
        Me.bt_testConnection.Location = New System.Drawing.Point(42, 278)
        Me.bt_testConnection.Name = "bt_testConnection"
        Me.bt_testConnection.Size = New System.Drawing.Size(149, 44)
        Me.bt_testConnection.TabIndex = 3
        Me.bt_testConnection.Text = "&Tester la connection"
        Me.bt_testConnection.UseVisualStyleBackColor = True
        '
        'lb_nom_BD
        '
        Me.lb_nom_BD.AccessibleName = "lb_nom_BD"
        Me.lb_nom_BD.AutoSize = True
        Me.lb_nom_BD.BackColor = System.Drawing.SystemColors.Control
        Me.lb_nom_BD.Location = New System.Drawing.Point(39, 169)
        Me.lb_nom_BD.Name = "lb_nom_BD"
        Me.lb_nom_BD.Size = New System.Drawing.Size(179, 17)
        Me.lb_nom_BD.TabIndex = 5
        Me.lb_nom_BD.Text = "Nom de la base de donnée"
        '
        'lb_mdp
        '
        Me.lb_mdp.AccessibleName = "lb_mdp"
        Me.lb_mdp.AutoSize = True
        Me.lb_mdp.Location = New System.Drawing.Point(39, 139)
        Me.lb_mdp.Name = "lb_mdp"
        Me.lb_mdp.Size = New System.Drawing.Size(101, 17)
        Me.lb_mdp.TabIndex = 6
        Me.lb_mdp.Text = "Mot de passe :"
        '
        'lb_nom_utilisateur
        '
        Me.lb_nom_utilisateur.AccessibleName = "lb_nom_utilisateur"
        Me.lb_nom_utilisateur.AutoSize = True
        Me.lb_nom_utilisateur.Location = New System.Drawing.Point(39, 108)
        Me.lb_nom_utilisateur.Name = "lb_nom_utilisateur"
        Me.lb_nom_utilisateur.Size = New System.Drawing.Size(121, 17)
        Me.lb_nom_utilisateur.TabIndex = 7
        Me.lb_nom_utilisateur.Text = "Nom d'utilisateur :"
        '
        'lb_serveur
        '
        Me.lb_serveur.AccessibleName = "lb_serveur"
        Me.lb_serveur.AutoSize = True
        Me.lb_serveur.Location = New System.Drawing.Point(39, 74)
        Me.lb_serveur.Name = "lb_serveur"
        Me.lb_serveur.Size = New System.Drawing.Size(120, 17)
        Me.lb_serveur.TabIndex = 8
        Me.lb_serveur.Text = "Adresse serveur :"
        '
        'cp_adresse
        '
        Me.cp_adresse.AccessibleName = "cp_adresse"
        Me.cp_adresse.Location = New System.Drawing.Point(249, 74)
        Me.cp_adresse.Name = "cp_adresse"
        Me.cp_adresse.Size = New System.Drawing.Size(143, 22)
        Me.cp_adresse.TabIndex = 9
        '
        'cp_user
        '
        Me.cp_user.AccessibleName = "cp_user"
        Me.cp_user.Location = New System.Drawing.Point(249, 105)
        Me.cp_user.Name = "cp_user"
        Me.cp_user.Size = New System.Drawing.Size(143, 22)
        Me.cp_user.TabIndex = 10
        '
        'cp_password
        '
        Me.cp_password.AccessibleName = "cp_password"
        Me.cp_password.Location = New System.Drawing.Point(249, 139)
        Me.cp_password.Name = "cp_password"
        Me.cp_password.Size = New System.Drawing.Size(143, 22)
        Me.cp_password.TabIndex = 11
        '
        'cp_bd_name
        '
        Me.cp_bd_name.AccessibleName = "cp_bd_name"
        Me.cp_bd_name.Location = New System.Drawing.Point(249, 169)
        Me.cp_bd_name.Name = "cp_bd_name"
        Me.cp_bd_name.Size = New System.Drawing.Size(143, 22)
        Me.cp_bd_name.TabIndex = 12
        '
        'bt_annuler
        '
        Me.bt_annuler.AccessibleName = "bt_annuler"
        Me.bt_annuler.CausesValidation = False
        Me.bt_annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_annuler.Location = New System.Drawing.Point(480, 278)
        Me.bt_annuler.Name = "bt_annuler"
        Me.bt_annuler.Size = New System.Drawing.Size(134, 44)
        Me.bt_annuler.TabIndex = 13
        Me.bt_annuler.Text = "&Annuler"
        Me.bt_annuler.UseVisualStyleBackColor = True
        '
        'bt_valider
        '
        Me.bt_valider.AccessibleName = "bt_valider"
        Me.bt_valider.Location = New System.Drawing.Point(260, 278)
        Me.bt_valider.Name = "bt_valider"
        Me.bt_valider.Size = New System.Drawing.Size(149, 45)
        Me.bt_valider.TabIndex = 14
        Me.bt_valider.Text = "&Valider"
        Me.bt_valider.UseVisualStyleBackColor = True
        '
        'FE_configConn
        '
        Me.AcceptButton = Me.bt_valider
        Me.AccessibleName = "FE_configConn"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.bt_annuler
        Me.ClientSize = New System.Drawing.Size(679, 457)
        Me.Controls.Add(Me.bt_valider)
        Me.Controls.Add(Me.bt_annuler)
        Me.Controls.Add(Me.cp_bd_name)
        Me.Controls.Add(Me.cp_password)
        Me.Controls.Add(Me.cp_user)
        Me.Controls.Add(Me.cp_adresse)
        Me.Controls.Add(Me.lb_serveur)
        Me.Controls.Add(Me.lb_nom_utilisateur)
        Me.Controls.Add(Me.lb_mdp)
        Me.Controls.Add(Me.lb_nom_BD)
        Me.Controls.Add(Me.bt_testConnection)
        Me.Name = "FE_configConn"
        Me.Text = "Configuration de la connection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_testConnection As System.Windows.Forms.Button
    Friend WithEvents lb_nom_BD As System.Windows.Forms.Label
    Friend WithEvents lb_mdp As System.Windows.Forms.Label
    Friend WithEvents lb_nom_utilisateur As System.Windows.Forms.Label
    Friend WithEvents lb_serveur As System.Windows.Forms.Label
    Friend WithEvents cp_adresse As System.Windows.Forms.TextBox
    Friend WithEvents cp_user As System.Windows.Forms.TextBox
    Friend WithEvents cp_password As System.Windows.Forms.TextBox
    Friend WithEvents cp_bd_name As System.Windows.Forms.TextBox
    Friend WithEvents bt_annuler As System.Windows.Forms.Button
    Friend WithEvents bt_valider As System.Windows.Forms.Button

End Class
