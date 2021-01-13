<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FE_update
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
        Me.bt_annuler = New System.Windows.Forms.Button()
        Me.bt_valider = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'bt_annuler
        '
        Me.bt_annuler.AccessibleName = "bt_annuler"
        Me.bt_annuler.CausesValidation = False
        Me.bt_annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_annuler.Location = New System.Drawing.Point(522, 358)
        Me.bt_annuler.Name = "bt_annuler"
        Me.bt_annuler.Size = New System.Drawing.Size(126, 56)
        Me.bt_annuler.TabIndex = 1
        Me.bt_annuler.Text = "&Annuler"
        Me.bt_annuler.UseVisualStyleBackColor = True
        '
        'bt_valider
        '
        Me.bt_valider.AccessibleName = "bt_annuler"
        Me.bt_valider.Location = New System.Drawing.Point(46, 358)
        Me.bt_valider.Name = "bt_valider"
        Me.bt_valider.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.bt_valider.Size = New System.Drawing.Size(126, 56)
        Me.bt_valider.TabIndex = 2
        Me.bt_valider.Text = "&Valider"
        Me.bt_valider.UseVisualStyleBackColor = True
        '
        'FE_update
        '
        Me.AcceptButton = Me.bt_valider
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.bt_annuler
        Me.ClientSize = New System.Drawing.Size(710, 463)
        Me.Controls.Add(Me.bt_valider)
        Me.Controls.Add(Me.bt_annuler)
        Me.Name = "FE_update"
        Me.Text = "Mettre à jour une donnée"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bt_annuler As System.Windows.Forms.Button
    Friend WithEvents bt_valider As System.Windows.Forms.Button
End Class
