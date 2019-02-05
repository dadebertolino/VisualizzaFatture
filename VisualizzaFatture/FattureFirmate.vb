Imports System.IO
Imports System.Text
Imports System.Xml
Imports Org.BouncyCastle.Cms
Imports Org.BouncyCastle.X509
Imports Org.BouncyCastle.X509.Store
Imports Org.BouncyCastle.Security
Module FattureFirmate

    Private Function ReadXmlSigned(ByVal stream As Stream, ByVal OutputFileName As String) As Boolean
        Dim signedFile As CmsSignedData = New CmsSignedData(stream)
        Dim certStore As IX509Store = signedFile.GetCertificates("Collection")
        Dim certs As ICollection = certStore.GetMatches(New X509CertStoreSelector())
        Dim signerStore As SignerInformationStore = signedFile.GetSignerInfos()
        Dim signers As ICollection = signerStore.GetSigners()

        For Each tempCertification As Object In certs
            Dim certification As Org.BouncyCastle.X509.X509Certificate = TryCast(tempCertification, Org.BouncyCastle.X509.X509Certificate)

            For Each tempSigner As Object In signers
                Dim signer As SignerInformation = TryCast(tempSigner, SignerInformation)

                If Not signer.Verify(certification.GetPublicKey()) Then
                    MsgBox("La firma non corrisponde al certificato contenuto nel file", MsgBoxStyle.Critical)
                    Return False
                End If
            Next
        Next

        Using memoryStream = New MemoryStream()
            signedFile.SignedContent.Write(memoryStream)
            'fattura.ReadXml(memoryStream)
        End Using
        Using fs As New IO.FileStream(OutputFileName, FileMode.Create)
            signedFile.SignedContent.Write(fs)
            fs.Flush()
            fs.Close()
        End Using
        Return True
    End Function
    Public Function ReadXmlSignedBase64(ByVal filePath As String, ByVal OutputFileName As String) As Boolean
        Return ReadXmlSigned(New MemoryStream(Convert.FromBase64String(File.ReadAllText(filePath))), OutputFileName)
    End Function
    Public Function ReadXmlSigned(ByVal filePath As String, ByVal OutputFileName As String) As Boolean
        Try

            Using inputStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
                Return ReadXmlSigned(inputStream, OutputFileName)
            End Using

        Catch __unusedCmsException1__ As CmsException
            Try
                Return ReadXmlSignedBase64(filePath, OutputFileName)
            Catch ex As Exception

            End Try

        End Try
        Return False
    End Function
End Module


Public Class FatturaElettronicaSignatureException
    Inherits SignatureException

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
End Class