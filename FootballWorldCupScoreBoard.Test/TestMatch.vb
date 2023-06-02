Imports FootballWorldCupScoreBoard_
Imports NUnit.Framework

Namespace FootballWorldCupScoreBoard.Test

    Public Class TestMatch

        Private ReadOnly mockData As New DataBBDD()

        <SetUp>
        Public Sub Setup()
        End Sub

        <Test>
        Public Sub Test1()
            Assert.Pass()
        End Sub

        <Test>
        Public Sub GetAllMatches_ReturnsAllMatches()


            ' Arrange
            Dim match1 As New Match(New Team("Equipo A"), New Team("Equipo B"))
            Dim match2 As New Match(New Team("Equipo C"), New Team("Equipo D"))
            Dim match3 As New Match(New Team("Equipo E"), New Team("Equipo F"))
            mockData.listOfMatch.TryAdd(1, match1)
            mockData.listOfMatch.TryAdd(2, match2)
            mockData.listOfMatch.TryAdd(3, match3)

            Dim matchService As New MatchRepositories(mockData)

            ' Act
            Dim matches As List(Of Match) = matchService.GetAllMatches()

            ' Assert
            Assert.AreEqual(3, matches.Count)
            Assert.IsTrue(matches.Contains(match1))
            Assert.IsTrue(matches.Contains(match2))
            Assert.IsTrue(matches.Contains(match3))
        End Sub

        <Test>
        Public Sub GetAllMatchesOrderByPoint_ReturnsMatchesOrderedByPoint()
            ' Arrange
            Dim match1 As New Match(New Team("Equipo A"), New Team("Equipo B"))
            match1.puntuacionLocal = 3
            match1.puntuacionVisitante = 1
            Dim match2 As New Match(New Team("Equipo C"), New Team("Equipo D"))
            match2.puntuacionLocal = 2
            match2.puntuacionVisitante = 0
            Dim match3 As New Match(New Team("Equipo E"), New Team("Equipo F"))
            match3.puntuacionLocal = 1
            match3.puntuacionVisitante = 1
            mockData.listOfMatch.TryAdd(1, match1)
            mockData.listOfMatch.TryAdd(2, match2)
            mockData.listOfMatch.TryAdd(3, match3)

            Dim matchService As New MatchRepositories(mockData)

            ' Act
            Dim matches As List(Of Match) = matchService.GetAllMatchesOrderByPoint()

            ' Assert
            Assert.AreEqual(3, matches.Count)
            Assert.AreEqual(match1, matches(0))
            Assert.AreEqual(match3, matches(1))
            Assert.AreEqual(match2, matches(2))
        End Sub

        <Test>
        Public Sub UpdateScore_ModifiesMatchScore()
            ' Arrange
            Dim match As New Match(New Team("Equipo A"), New Team("Equipo B"))
            match.puntuacionLocal = 1
            match.puntuacionVisitante = 2
            mockData.listOfMatch.TryAdd(1, match)

            Dim matchService As New MatchRepositories(mockData)

            ' Act
            matchService.UpdateScore(3, 1, 1)

            ' Assert
            Assert.AreEqual(3, match.puntuacionLocal)
            Assert.AreEqual(1, match.puntuacionVisitante)
        End Sub

        <Test>
        Public Sub FinishMatch_RemovesMatchFromList()
            ' Arrange
            Dim match As New Match(New Team("Equipo A"), New Team("Equipo B"))
            mockData.listOfMatch.TryAdd(1, match)

            Dim matchService As New MatchRepositories(mockData)

            ' Act
            matchService.FinishMatch(1)

            ' Assert
            Assert.AreEqual(0, mockData.listOfMatch.Count)
        End Sub

        <Test>
        Public Sub StartMatch_AddsMatchToList()
            ' Arrange
            Dim matchService As New MatchRepositories(mockData)
            Dim teamLocal As New Team("Equipo A")
            Dim teamVisitante As New Team("Equipo B")

            ' Act
            matchService.StartMatch(teamLocal, teamVisitante)

            ' Assert
            Assert.AreEqual(1, mockData.listOfMatch.Count)
            Dim match As Match = mockData.listOfMatch(1)
            Assert.IsNotNull(match)
            Assert.AreEqual(teamLocal, match.equipoLocal)
            Assert.AreEqual(teamVisitante, match.equipoVisitante)
        End Sub

    End Class

End Namespace