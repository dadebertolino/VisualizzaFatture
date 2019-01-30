Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' I seguenti eventi sono disponibili per MyApplication:
    ' Startup: generato all'avvio dell'applicazione, prima della creazione del form di avvio.
    ' Shutdown: generato dopo la chiusura di tutti i form dell'applicazione. L'evento non è generato se l'applicazione termina in modo anomalo.
    ' UnhandledException: generato se nell'applicazione si verifica un'eccezione non gestita.
    ' StartupNextInstance: generato all'avvio di un'applicazione a istanza singola se l'applicazione è già attiva. 
    ' NetworkAvailabilityChanged: generato se la connessione di rete è connessa o disconnessa.
    Partial Friend Class MyApplication
        Public Percorso As String
        Public PercorsoFogliStile As String
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            Percorso = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "VisualizzaFatture")
            PercorsoFogliStile = IO.Path.Combine(Percorso, "Fogli di stile")
            Dim DI As New IO.DirectoryInfo(Percorso)
            If DI.Exists = False Then
                DI.Create()
                Dim DI2 As New IO.DirectoryInfo(PercorsoFogliStile)
                DI2.Create()
                Dim di1 As New IO.DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory)
                For Each fi As IO.FileInfo In di1.GetFiles("*.xsl")
                    fi.CopyTo(IO.Path.Combine(IO.Path.Combine(Percorso, "Fogli di stile"), fi.Name))
                Next
            End If
        End Sub
    End Class
End Namespace
