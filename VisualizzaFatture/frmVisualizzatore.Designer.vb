<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisualizzatore
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnVisualizza = New System.Windows.Forms.Button()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.cmbFogliDiStile = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnVisualizza
        '
        Me.btnVisualizza.Location = New System.Drawing.Point(12, 12)
        Me.btnVisualizza.Name = "btnVisualizza"
        Me.btnVisualizza.Size = New System.Drawing.Size(75, 23)
        Me.btnVisualizza.TabIndex = 0
        Me.btnVisualizza.Text = "Carica"
        Me.btnVisualizza.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(12, 41)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(605, 454)
        Me.WebBrowser1.TabIndex = 1
        '
        'cmbFogliDiStile
        '
        Me.cmbFogliDiStile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFogliDiStile.FormattingEnabled = True
        Me.cmbFogliDiStile.Location = New System.Drawing.Point(431, 14)
        Me.cmbFogliDiStile.Name = "cmbFogliDiStile"
        Me.cmbFogliDiStile.Size = New System.Drawing.Size(186, 21)
        Me.cmbFogliDiStile.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(358, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Foglio di stile"
        '
        'frmVisualizzatore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 507)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbFogliDiStile)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.btnVisualizza)
        Me.Name = "frmVisualizzatore"
        Me.Text = "Visualizzatore Fatture Elettroniche"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnVisualizza As Button
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents cmbFogliDiStile As ComboBox
    Friend WithEvents Label1 As Label
End Class
