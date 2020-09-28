Imports System
Imports System.Windows.Forms

Namespace MyFormsHugeProgressJob
    Public Partial Class ProgressWindow
        Inherits Form

        Public Event Cancel As EventHandler


        ''' <summary>
        ''' Constructor
        ''' </summary>
        Public Sub New()
            Me.InitializeComponent()
            FormBorderStyle = FormBorderStyle.FixedToolWindow
            StartPosition = FormStartPosition.CenterParent
        End Sub


        ''' <summary>
        ''' ProgressWindow_Load
        ''' </summary>
        ''' <paramname="sender"></param>
        ''' <paramname="e"></param>
        Private Sub ProgressWindow_Load(ByVal sender As Object, ByVal e As EventArgs)
        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <paramname="sender"></param>
        ''' <paramname="e"></param>
        Private Sub button_Cancel_Click(ByVal sender As Object, ByVal e As EventArgs)
            RaiseEvent Cancel(Nothing, Nothing)
        End Sub


        ''' <summary>
        ''' ProgressWindow_VisibleChanged
        ''' </summary>
        ''' <paramname="sender"></param>
        ''' <paramname="e"></param>
        Private Sub ProgressWindow_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
            Top = Owner.Top + (Owner.Height - Height) / 2
            Left = Owner.Left + (Owner.Width - Width) / 2
        End Sub


        ''' <summary>
        ''' ProgressWindow_FormClosing
        ''' </summary>
        ''' <paramname="sender"></param>
        ''' <paramname="e"></param>
        Private Sub ProgressWindow_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
            e.Cancel = True
            Hide()
        End Sub


        ''' <summary>
        ''' UpDate
        ''' </summary>
        Public Sub ProgressBarUpDate()
            Me.progressBar1.Invoke(CType(Sub() Math.Min(Threading.Interlocked.Increment(Me.progressBar1.Value), Me.progressBar1.Value - 1), Action))
        End Sub


        ''' <summary>
        ''' ProgressBarReset
        ''' </summary>
        Public Sub ProgressBarReset()
            Me.progressBar1.Value = Me.progressBar1.Minimum
        End Sub


        ''' <summary>
        ''' ProgressSet
        ''' </summary>
        ''' <paramname="max"></param>
        ''' <paramname="min"></param>
        Public Sub ProgressSet(ByVal max As Integer, ByVal Optional min As Integer = 0)
            Me.progressBar1.Maximum = max
            Me.progressBar1.Minimum = min
        End Sub
    End Class
End Namespace
