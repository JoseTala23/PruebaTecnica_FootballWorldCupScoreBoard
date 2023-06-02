Imports System.Collections.Concurrent
Imports System.Linq.Expressions

Public Class MatchRepositories
    Implements IMatch

    Private data As DataBBDD

    Public Sub New()
        Me.data = New DataBBDD
    End Sub

    Public Sub New(dataTest As DataBBDD)
        Me.data = dataTest
    End Sub

    Public Function GetAllMatches() As List(Of Match) Implements IMatch.GetAllMatches
        Return data.listOfMatch.Values.ToList()
    End Function

    Public Function GetAllMatchesOrderByPoint() As List(Of Match) Implements IMatch.GetAllMatchesOrderByPoint

        Dim ret As List(Of Match) = data.listOfMatch.Values _
            .OrderByDescending(Function(game) game.TotalScore) _
            .ThenByDescending(Function(game) game.fecha) _
            .ToList()

        Return ret
    End Function

    Public Sub UpdateScore(scoreLocal As Integer, scoreVisitante As Integer, pos As Integer) Implements IMatch.UpdateScore

        Dim match As Match

        match = GetMatchByPos(pos)
        match.puntuacionLocal = scoreLocal
        match.puntuacionVisitante = scoreVisitante

    End Sub

    Public Sub FinishMatch(idMatch As Integer) Implements IMatch.FinishMatch
        Dim match As Match
        Try
            match = GetMatchByPos(idMatch)
            If Not IsNothing(match) Then
                data.listOfMatch.Remove(idMatch, match)
            End If
        Catch ex As Exception
            Console.WriteLine("Se ha producido un error al finalizar el partido. (" + ex.Message + ")")
        End Try

    End Sub

    Private Function GetMatchByPos(idMatch As Integer) As Match
        'Obtenermos el elemento por la posicion que tenga en la lista
        Dim ret = data.listOfMatch.ElementAt(idMatch - 1)

        Return ret.Value
    End Function

    Public Function GetMatch(idMatch As Integer) As Match
        'Obtenemos el id de partido por la id que pasamos por parametro
        'que identifica al partido en la lista de partidos que hay en memoria

        Dim ret = data.listOfMatch.FirstOrDefault(Function(item) item.Key = idMatch)

        Return ret.Value
    End Function

    Public Sub StartMatch(teamLocal As Team, teamVisitante As Team) Implements IMatch.StartMatch
        Dim match As Match = New Match(teamLocal, teamVisitante)
        data.listOfMatch.TryAdd(data.asignId(), match)
    End Sub
End Class



