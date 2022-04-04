Namespace My
    Partial Friend Class MyApplication

        Protected Overrides Function OnInitialize(
            ByVal commandLineArgs As _
              System.Collections.ObjectModel.ReadOnlyCollection(Of String)) As Boolean
            ' Set the display time to 5000 milliseconds (5 seconds).
            Me.MinimumSplashScreenDisplayTime = 3000
            Return MyBase.OnInitialize(commandLineArgs)
        End Function
    End Class
End Namespace
