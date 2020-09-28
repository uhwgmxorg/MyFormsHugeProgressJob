Imports System
Imports System.Diagnostics
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace MyFormsHugeProgressJob
    Public Partial Class FormMain
        Inherits Form

        Private _task As Task
        Private _ts As CancellationTokenSource
        Private _ct As CancellationToken
        Const MAX_ITERATIONS As Integer = 20
        Private _progressWindow As MyFormsHugeProgressJob.ProgressWindow


        ''' <summary>
        ''' Constructor
        ''' </summary>
        Public Sub New()
            Me.InitializeComponent()
        End Sub


        ' ***************************
        ' Button Events        
        ' ***************************
#Region "Button Events"

        ''' <summary>
        ''' button_Start_Task_Click
        ''' </summary>
        ''' <paramname="sender"></param>
        ''' <paramname="e"></param>
        Private Sub button_Start_Task_Click(ByVal sender As Object, ByVal e As EventArgs)
            _progressWindow.Show()
            EnableDisableButtons(True)
            _progressWindow.ProgressSet(MAX_ITERATIONS * MAX_ITERATIONS * MAX_ITERATIONS)
            _progressWindow.ProgressBarReset()
            _ts = New CancellationTokenSource()
            _ct = _ts.Token
            _task = Task.Factory.StartNew(Sub() JobManager(), _ct)
        End Sub


        ''' <summary>
        ''' button_Cancel_Task_Click
        ''' </summary>
        ''' <paramname="sender"></param>
        ''' <paramname="e"></param>
        Private Sub button_Cancel_Task_Click(ByVal sender As Object, ByVal e As EventArgs)
            _ts.Cancel()
            EnableDisableButtons(False)
            _progressWindow.Hide()
        End Sub


        ''' <summary>
        ''' button_Toggle_Click
        ''' </summary>
        ''' <paramname="sender"></param>
        ''' <paramname="e"></param>
        Private Sub button_Toggle_Click(ByVal sender As Object, ByVal e As EventArgs)
            If _progressWindow.Visible Then
                _progressWindow.Hide()
            Else
                _progressWindow.Show()
            End If
        End Sub


        ''' <summary>
        ''' button_Close_Click
        ''' </summary>
        ''' <paramname="sender"></param>
        ''' <paramname="e"></param>
        Private Sub button_Close_Click(ByVal sender As Object, ByVal e As EventArgs)
            Close()
        End Sub


#End Region
        ' ***************************
        ' Menu Events          
        ' ***************************
#Region "Menu Events"

#End Region
        ' ***************************
        ' Other Events          
        ' ***************************
#Region "Other Events"

        ''' <summary>
        ''' Form1_Load
        ''' </summary>
        ''' <paramname="sender"></param>
        ''' <paramname="e"></param>
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            EnableDisableButtons(False)
            _progressWindow = New MyFormsHugeProgressJob.ProgressWindow()
            _progressWindow.Owner = Me
            AddHandler _progressWindow.Cancel, AddressOf Me.CancelEvent
        End Sub


        ''' <summary>
        ''' CancelEvent
        ''' </summary>
        ''' <paramname="sender"></param>
        ''' <paramname="e"></param>
        Private Sub CancelEvent(ByVal sender As Object, ByVal e As EventArgs)
            _ts.Cancel()
            EnableDisableButtons(False)
        End Sub


        ''' <summary>
        ''' Form1_FormClosing
        ''' </summary>
        ''' <paramname="sender"></param>
        ''' <paramname="e"></param>
        Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
            _progressWindow.Dispose()
            e.Cancel = False
            RemoveHandler _progressWindow.Cancel, AddressOf Me.CancelEvent
        End Sub


#End Region
        ' ***************************
        ' Other Functions       
        ' ***************************
#Region "Other Functions"

        ''' <summary>
        ''' JobManager
        ''' </summary>
        Public Sub JobManager()

            ' Call the TheHugeJob
            TheHugeJob()
            _progressWindow.Invoke(CType((Sub() _progressWindow.Hide()), Action))
            ' Mange button state
            EnableDisableButtons(False)
            ' give a signal
            Console.Beep()
        End Sub


        ''' <summary>
        ''' TheHugeJob
        ''' </summary>
        Public Sub TheHugeJob()
            Dim i, j, k As Integer
            Dim d As Double = 0.0

            For i = 0 To MAX_ITERATIONS - 1

                For j = 0 To MAX_ITERATIONS - 1

                    For k = 0 To MAX_ITERATIONS - 1

                        If _ct.IsCancellationRequested Then
                            ' UI thread decided to cancel
                            Debug.WriteLine(String.Format("We have a Cancellation Requested "))
                            Return
                        End If

                        d += 1
                        Debug.WriteLine(String.Format("i={0} j={1} k={2} d={3}", i, j, k, d))
                        _progressWindow.ProgressBarUpDate()
                    Next
                Next
            Next
        End Sub


        ''' <summary>
        ''' EnableDisableButtons
        ''' </summary>
        ''' <paramname="running"></param>
        Private Sub EnableDisableButtons(ByVal running As Boolean)
            Me.button_Start_Task.Invoke(CType(Sub() CSharpImpl.__Assign(Me.button_Start_Task.Enabled, Not running), Action))
            Me.button_Start_Task.Invoke(CType(Sub() CSharpImpl.__Assign(Me.button_Cancel_Task.Enabled, running), Action))
        End Sub

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class

#End Region
    End Class
End Namespace
