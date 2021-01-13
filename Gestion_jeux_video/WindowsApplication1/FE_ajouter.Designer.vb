<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FE_ajouter
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
        Me.BT_annuler = New System.Windows.Forms.Button()
        Me.BT_valider = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BT_annuler
        '
        Me.BT_annuler.BackColor = System.Drawing.Color.Transparent
        Me.BT_annuler.CausesValidation = False
        Me.BT_annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BT_annuler.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BT_annuler.Location = New System.Drawing.Point(451, 408)
        Me.BT_annuler.Name = "BT_annuler"
        Me.BT_annuler.Size = New System.Drawing.Size(155, 53)
        Me.BT_annuler.TabIndex = 0
        Me.BT_annuler.Text = "&Annuler"
        Me.BT_annuler.UseVisualStyleBackColor = False
        '
        'BT_valider
        '
        Me.BT_valider.Location = New System.Drawing.Point(43, 408)
        Me.BT_valider.Name = "BT_valider"
        Me.BT_valider.Size = New System.Drawing.Size(155, 53)
        Me.BT_valider.TabIndex = 1
        Me.BT_valider.Text = "&Valider"
        Me.BT_valider.UseVisualStyleBackColor = True
        '
        'FE_ajouter
        '
        Me.AcceptButton = Me.BT_valider
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BT_annuler
        Me.ClientSize = New System.Drawing.Size(665, 507)
        Me.Controls.Add(Me.BT_valider)
        Me.Controls.Add(Me.BT_annuler)
        Me.Name = "FE_ajouter"
        Me.Text = "Ajouter des données"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BT_annuler As System.Windows.Forms.Button
    Friend WithEvents BT_valider As System.Windows.Forms.Button

End Class
