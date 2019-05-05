<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStartup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnTokenizer = New System.Windows.Forms.Button()
        Me.btnSpelling = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnTokenizer
        '
        Me.btnTokenizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTokenizer.Location = New System.Drawing.Point(12, 12)
        Me.btnTokenizer.Name = "btnTokenizer"
        Me.btnTokenizer.Size = New System.Drawing.Size(164, 46)
        Me.btnTokenizer.TabIndex = 0
        Me.btnTokenizer.Text = "Tokenizer"
        Me.btnTokenizer.UseVisualStyleBackColor = True
        '
        'btnSpelling
        '
        Me.btnSpelling.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSpelling.Location = New System.Drawing.Point(12, 69)
        Me.btnSpelling.Name = "btnSpelling"
        Me.btnSpelling.Size = New System.Drawing.Size(164, 46)
        Me.btnSpelling.TabIndex = 1
        Me.btnSpelling.Text = "Spelling"
        Me.btnSpelling.UseVisualStyleBackColor = True
        '
        'frmStartup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(188, 127)
        Me.Controls.Add(Me.btnSpelling)
        Me.Controls.Add(Me.btnTokenizer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmStartup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnTokenizer As System.Windows.Forms.Button
    Friend WithEvents btnSpelling As System.Windows.Forms.Button
End Class
