<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FE_accueil
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
        Me.lb_etat_conn = New System.Windows.Forms.Label()
        Me.lb_fond_etat_connexion = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.bt_configConnection = New System.Windows.Forms.Button()
        Me.dg_donnee = New System.Windows.Forms.DataGridView()
        Me.lb_liste_bases = New System.Windows.Forms.Label()
        Me.cb_tables = New System.Windows.Forms.ComboBox()
        Me.bt_supprimer = New System.Windows.Forms.Button()
        Me.bt_ajouter = New System.Windows.Forms.Button()
        Me.bt_log = New System.Windows.Forms.Button()
        CType(Me.dg_donnee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_etat_conn
        '
        Me.lb_etat_conn.AccessibleName = "lb_etat_conn"
        Me.lb_etat_conn.AutoSize = True
        Me.lb_etat_conn.Location = New System.Drawing.Point(12, 84)
        Me.lb_etat_conn.Name = "lb_etat_conn"
        Me.lb_etat_conn.Size = New System.Drawing.Size(149, 17)
        Me.lb_etat_conn.TabIndex = 0
        Me.lb_etat_conn.Text = "Etat de la connection :"
        '
        'lb_fond_etat_connexion
        '
        Me.lb_fond_etat_connexion.AccessibleName = "lb_fond_etat_connexion"
        Me.lb_fond_etat_connexion.AutoSize = True
        Me.lb_fond_etat_connexion.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lb_fond_etat_connexion.Location = New System.Drawing.Point(174, 84)
        Me.lb_fond_etat_connexion.Name = "lb_fond_etat_connexion"
        Me.lb_fond_etat_connexion.Size = New System.Drawing.Size(132, 17)
        Me.lb_fond_etat_connexion.TabIndex = 1
        Me.lb_fond_etat_connexion.Text = "                               "
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'bt_configConnection
        '
        Me.bt_configConnection.AccessibleName = "bt_configConnection"
        Me.bt_configConnection.Location = New System.Drawing.Point(353, 46)
        Me.bt_configConnection.Name = "bt_configConnection"
        Me.bt_configConnection.Size = New System.Drawing.Size(126, 55)
        Me.bt_configConnection.TabIndex = 2
        Me.bt_configConnection.Text = "&Configurer la connection"
        Me.bt_configConnection.UseVisualStyleBackColor = True
        '
        'dg_donnee
        '
        Me.dg_donnee.AccessibleName = "dg_donnee"
        Me.dg_donnee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg_donnee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_donnee.Location = New System.Drawing.Point(34, 202)
        Me.dg_donnee.Name = "dg_donnee"
        Me.dg_donnee.ReadOnly = True
        Me.dg_donnee.RowTemplate.Height = 24
        Me.dg_donnee.Size = New System.Drawing.Size(1658, 654)
        Me.dg_donnee.TabIndex = 3
        '
        'lb_liste_bases
        '
        Me.lb_liste_bases.AccessibleName = "lb_liste_bases"
        Me.lb_liste_bases.AutoSize = True
        Me.lb_liste_bases.Location = New System.Drawing.Point(12, 127)
        Me.lb_liste_bases.Name = "lb_liste_bases"
        Me.lb_liste_bases.Size = New System.Drawing.Size(115, 17)
        Me.lb_liste_bases.TabIndex = 4
        Me.lb_liste_bases.Text = "Liste des tables :"
        '
        'cb_tables
        '
        Me.cb_tables.AccessibleName = "cb_bases"
        Me.cb_tables.FormattingEnabled = True
        Me.cb_tables.Location = New System.Drawing.Point(133, 124)
        Me.cb_tables.Name = "cb_tables"
        Me.cb_tables.Size = New System.Drawing.Size(252, 24)
        Me.cb_tables.TabIndex = 5
        '
        'bt_supprimer
        '
        Me.bt_supprimer.AccessibleName = "bt_supprimer"
        Me.bt_supprimer.Location = New System.Drawing.Point(537, 124)
        Me.bt_supprimer.Name = "bt_supprimer"
        Me.bt_supprimer.Size = New System.Drawing.Size(139, 44)
        Me.bt_supprimer.TabIndex = 6
        Me.bt_supprimer.Text = "&Supprimer"
        Me.bt_supprimer.UseVisualStyleBackColor = True
        '
        'bt_ajouter
        '
        Me.bt_ajouter.AccessibleName = "bt_ajouter"
        Me.bt_ajouter.Location = New System.Drawing.Point(537, 57)
        Me.bt_ajouter.Name = "bt_ajouter"
        Me.bt_ajouter.Size = New System.Drawing.Size(139, 44)
        Me.bt_ajouter.TabIndex = 7
        Me.bt_ajouter.Text = "&Ajouter"
        Me.bt_ajouter.UseVisualStyleBackColor = True
        '
        'bt_log
        '
        Me.bt_log.AccessibleName = "bt_ajouter"
        Me.bt_log.Location = New System.Drawing.Point(718, 57)
        Me.bt_log.Name = "bt_log"
        Me.bt_log.Size = New System.Drawing.Size(139, 44)
        Me.bt_log.TabIndex = 8
        Me.bt_log.Text = "A&fficher les logs"
        Me.bt_log.UseVisualStyleBackColor = True
        '
        'FE_accueil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1744, 1055)
        Me.Controls.Add(Me.bt_log)
        Me.Controls.Add(Me.bt_ajouter)
        Me.Controls.Add(Me.bt_supprimer)
        Me.Controls.Add(Me.cb_tables)
        Me.Controls.Add(Me.lb_liste_bases)
        Me.Controls.Add(Me.dg_donnee)
        Me.Controls.Add(Me.bt_configConnection)
        Me.Controls.Add(Me.lb_fond_etat_connexion)
        Me.Controls.Add(Me.lb_etat_conn)
        Me.Name = "FE_accueil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Accueil"
        CType(Me.dg_donnee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_etat_conn As System.Windows.Forms.Label
    Friend WithEvents lb_fond_etat_connexion As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents bt_configConnection As System.Windows.Forms.Button
    Friend WithEvents dg_donnee As System.Windows.Forms.DataGridView
    Friend WithEvents lb_liste_bases As System.Windows.Forms.Label
    Friend WithEvents cb_tables As System.Windows.Forms.ComboBox
    Friend WithEvents bt_supprimer As System.Windows.Forms.Button
    Friend WithEvents bt_ajouter As System.Windows.Forms.Button
    Friend WithEvents bt_log As System.Windows.Forms.Button

End Class
