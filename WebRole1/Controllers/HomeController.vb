Imports Microsoft.ApplicationInsights
Imports Microsoft.ApplicationInsights.SnapshotCollector

Public Class HomeController
    Inherits Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."
        Throw New Exception("something bad happened")
        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."
        Dim x = GetType(SnapshotCollectorTelemetryProcessor)
        Try
            Throw New Exception("something bad happened")
        Catch ex As Exception
            Dim ai = New TelemetryClient()
            Dim props = New Dictionary(Of String, String)() From {{"property1", "a test property"}}
            ai.TrackException(ex, props)
        End Try

        Return View()
    End Function
End Class
