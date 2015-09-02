Namespace My
    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Public exceptionListOfExceptionsToNotPauseOn As New List(Of ApplicationServices.UnhandledExceptionEventArgs)

        Private Sub MyApplication_UnhandledException(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Dim msgboxResult As MsgBoxResult
            Dim booleanExceptionFoundInList As Boolean = False

            'Dim trace As System.Diagnostics.StackTrace = New System.Diagnostics.StackTrace(ex, True)
            'Dim exceptionLineNumber = trace.GetFrame(0).GetFileLineNumber()

            For x = 0 To exceptionListOfExceptionsToNotPauseOn.Count - 1
                If exceptionListOfExceptionsToNotPauseOn(x).Exception.Message = e.Exception.Message Then
                    booleanExceptionFoundInList = True
                End If
            Next

            If Not booleanExceptionFoundInList Then
                msgboxResult = MessageBox.Show("An exception error has occured." & vbCrLf & "Error message: " & e.Exception.Message & vbCrLf & "Do you wish to pause on this exception again?", "Exception", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                If msgboxResult = Microsoft.VisualBasic.MsgBoxResult.No Then
                    exceptionListOfExceptionsToNotPauseOn.Add(e)
                End If
            End If

            e.ExitApplication = False
        End Sub
    End Class


End Namespace

