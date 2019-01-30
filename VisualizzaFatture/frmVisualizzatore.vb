Imports System.ComponentModel
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl


Public Class frmVisualizzatore
    Private Sub frmVisualizzatore_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim di As New IO.DirectoryInfo(My.Application.PercorsoFogliStile)
        For Each fi As IO.FileInfo In di.GetFiles("*.xsl")
            Me.cmbFogliDiStile.Items.Add(fi.Name)
        Next
        Me.cmbFogliDiStile.SelectedItem = My.Settings.FoglioDiStile
    End Sub

    Public Sub VisualizzaFatturaElettronica(NomeFile As String, NomeFoglioStile As String)
        Try
            Dim myXPathDocument As XPathDocument = New XPathDocument(NomeFile)
            Dim myXslTransform As XslCompiledTransform = New XslCompiledTransform()
            Dim NomeFileTMP As String = IO.Path.Combine(My.Application.Percorso, "tmp.html")
            Dim writer As XmlTextWriter = New XmlTextWriter(NomeFileTMP, Nothing)
            myXslTransform.Load(NomeFoglioStile)
            myXslTransform.Transform(myXPathDocument, Nothing, writer)
            writer.Close()
            Dim S As String
            Using r As New IO.StreamReader(NomeFileTMP)
                S = r.ReadToEnd
                r.Close()
            End Using
            'Sporco trucco ma funziona
            S = S.Replace("°", "&deg;")
            S = S.Replace("á", "&aacute;")
            S = S.Replace("Á", "&Aacute;")
            S = S.Replace("à", "&agrave;")
            S = S.Replace("À", "&Agrave;")
            S = S.Replace("é", "&eacute;")
            S = S.Replace("É", "&Eacute;")
            S = S.Replace("è", "&egrave;")
            S = S.Replace("È", "&Egrave;")
            S = S.Replace("í", "&iacute;")
            S = S.Replace("Í", "&Iacute;")
            S = S.Replace("ì", "&igrave;")
            S = S.Replace("Ì", "&Igrave;")
            S = S.Replace("ó", "&oacute;")
            S = S.Replace("Ó", "&Oacute;")
            S = S.Replace("ò", "&Ograve;")
            S = S.Replace("Ò", "&Ograve;")
            S = S.Replace("ú", "&aacute;")
            S = S.Replace("Ú", "&Uacute;")
            S = S.Replace("ù", "&ugrave;")
            S = S.Replace("Ù", "&Ugrave;")
            S = S.Replace("€", "&euro;")
            Using w As New IO.StreamWriter(NomeFileTMP)
                w.Write(S)
                w.Flush()
                w.Close()
            End Using
            WebBrowser1.Navigate("file:///" & IO.Path.GetFullPath(NomeFileTMP))
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnVisualizza_Click(sender As Object, e As EventArgs) Handles btnVisualizza.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "xml file|*.xml"
        ofd.Title = "Selezionare la fattura elettronica da visualizzare"
        ofd.InitialDirectory = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, "Fatture Elettroniche")
        If ofd.ShowDialog = DialogResult.OK Then
            VisualizzaFatturaElettronica(ofd.FileName, IO.Path.Combine(My.Application.PercorsoFogliStile, Me.cmbFogliDiStile.SelectedItem))
        End If
    End Sub

    Private Sub frmVisualizzatore_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.FoglioDiStile = Me.cmbFogliDiStile.SelectedItem
    End Sub
End Class

' « &laquo;
' » &raquo;
' – &ndash;
' — &mdash;
' ¡ &iexcl;
' ¿ &iquest;
' " &quot;
' “ &ldquo;
' ” &rdquo;
' ‘ &lsquo;
' ’ &rsquo;
' (blank space) &nbsp;

' & &amp;
' ¢ &cent;
' © &copy;
' ÷ &divide;
' > &gt;
' < &lt;
' µ &micro;
'· &middot;
' ¶ &para;
' ± &plusmn;
' € &euro;
' £ &pound;
' ® &reg;
' § &sect;
' ™ &trade;
' ¥ &yen;

'á &aacute; 
'Á &Aacute;
'à &agrave;  
'À &Agrave;
'â &acirc;
'Â &Acirc;
'å &aring; 
'Å &Aring;
'ã &atilde; 
'Ã &Atilde;
'ä &auml;
'Ä &Auml;
'æ &aelig; 
'Æ'&AElig;
'ç &ccedil; 
'Ç &Ccedil;
'é &eacute;
'É &Eacute;
'è &egrave; 
'È &Egrave;
'ê &ecirc; 
'Ê &Ecirc;
'ë &euml;
'Ë &Euml;
'í &iacute;  
'Í &Iacute;
'ì &igrave;
'Ì &Igrave;
'î &icirc; 
'Î &Icirc;
'ï &iuml;
'Ï &Iuml;
'ñ &ntilde;
'Ñ &Ntilde;
'ó &oacute;
'Ó &Oacute;
'ò &ograve; 
'Ò &Ograve;
'ô &ocirc; 
'Ô &Ocirc;
'ø &oslash;
'Ø &Oslash;
'õ &otilde; 
'Õ &Otilde;
'ö &ouml; 
'Ö &Ouml;
'ú &uacute; 
'Ú &Uacute;
'ù &ugrave;
'Ù &Ugrave;
'û &ucirc;
'Û &Ucirc;
'ü &uuml; 
'Ü &Uuml;
'ß &szlig;
'ÿ &yuml;

