Imports System.Collections.Concurrent

Public Class DataBBDD

    Public listOfMatch As ConcurrentDictionary(Of Integer, Match)

    Public Sub New()
        listOfMatch = New ConcurrentDictionary(Of Integer, Match)

    End Sub

    Friend Function asignId() As Integer
        Dim lastIdAsign = listOfMatch.LastOrDefault().Key
        Return lastIdAsign + 1
    End Function
End Class
