Imports System.Collections.Concurrent

Public Interface IMatch

    Function GetAllMatches() As List(Of Match)
    Function GetAllMatchesOrderByPoint() As List(Of Match)
    Sub UpdateScore(scoreLocal As Integer, scoreVisitante As Integer, idMatch As Integer)
    Sub FinishMatch(idMatch As Integer)
    Sub StartMatch(teamLocal As Team, teamVisitante As Team)

End Interface
