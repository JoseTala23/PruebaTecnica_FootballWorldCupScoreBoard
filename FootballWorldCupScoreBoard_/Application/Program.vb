Imports System
Imports System.Collections.Concurrent

Module Program
    Sub Main(args As String())
        Dim opcion As Integer = 0
        Dim repoMatch As MatchRepositories = New MatchRepositories

        While opcion <> 6
            Dim entrada As String = MostrarMenu()

            If Integer.TryParse(entrada, opcion) Then
                Select Case opcion
                    Case 1
                        Console.WriteLine("")
                        Console.WriteLine("================")
                        StartMatch(repoMatch)
                        Console.WriteLine("================")
                    Case 2
                        Console.WriteLine("")
                        Console.WriteLine("================")
                        FinishMatch(repoMatch)
                        Console.WriteLine("================")
                    Case 3
                        Console.WriteLine("")
                        Console.WriteLine("================")
                        UpdateScore(repoMatch)
                        Console.WriteLine("================")
                    Case 4
                        Console.WriteLine("")
                        Console.WriteLine("================")
                        'Resumen de partidos sin ordenar
                        MostrarPartidosActivos(repoMatch.GetAllMatches())
                        Console.WriteLine("================")
                    Case 5
                        Console.WriteLine("")
                        Console.WriteLine("================")
                        'Resumen de partidos ordenados
                        MostrarPartidosActivos(repoMatch.GetAllMatchesOrderByPoint())
                        Console.WriteLine("================")
                    Case Else
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.")
                End Select
            Else
                Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.")
            End If

            Console.WriteLine()

        End While

        Console.WriteLine("Presione cualquier tecla para salir.")
        Console.ReadKey()
    End Sub

    Private Function MostrarMenu() As String
        Console.WriteLine("==== Menú ====")
        Console.WriteLine("1. Iniciar Partido.")
        Console.WriteLine("2. Finalizar un Partido")
        Console.WriteLine("3. Actualizar puntuación de un Partido")
        Console.WriteLine("4. Obtener resumen de los partidos")
        Console.WriteLine("5. Obtener resumen de los partidos")
        Console.WriteLine("6. Salir")
        Console.WriteLine("================")

        Console.Write("Ingrese una opción: ")
        Dim entrada As String = Console.ReadLine()
        Return entrada
    End Function

    Private Sub StartMatch(repoMatch As MatchRepositories)
        Console.Write("Ingrese el nombre del equipo local: ")
        Dim teamLocal As String = Console.ReadLine()

        Console.Write("Ingrese el nombre del equipo visitante: ")
        Dim teamVisitante As String = Console.ReadLine()

        repoMatch.StartMatch(createTeam(teamLocal), createTeam(teamVisitante))
        Console.WriteLine("Se ha iniciado el partido: " + teamLocal + " " + teamVisitante)
    End Sub

    Private Sub FinishMatch(repoMatch As MatchRepositories)
        MostrarPartidosActivos(repoMatch.GetAllMatches())
        Console.WriteLine("")
        Console.WriteLine("================")
        Console.WriteLine("Selecciona el partido que desea finalizar (Introduce el numero que aparece al lado de cada partido)")
        Dim numPartido As Integer = Console.ReadLine()

        repoMatch.FinishMatch(numPartido)
    End Sub

    Private Sub UpdateScore(repoMatch As MatchRepositories)
        MostrarPartidosActivos(repoMatch.GetAllMatches())
        Console.WriteLine("Selecciona el partido que desea finalizar (Introduce el numero que aparece al lado de cada partido)")
        Dim numPartido As Integer = Console.ReadLine()

        Console.WriteLine("Ingrese la putuación del equipo Local: ")
        Dim scoreLocal As Integer = Console.ReadLine()

        Console.WriteLine("Ingrese la putuación del equipo Visitante: ")
        Dim scoreVisitante As Integer = Console.ReadLine()

        repoMatch.UpdateScore(scoreLocal, scoreVisitante, numPartido)
    End Sub

    Private Sub MostrarPartidosActivos(matches As List(Of Match))
        Dim i = 1
        For Each item In matches
            Console.WriteLine(i.ToString + ".- " + item.teamLocal.nombre + " " + item.scoreLocal.ToString + "-" + item.scoreVisitante.ToString + " " + item.teamVisitante.nombre)
            i = i + 1
        Next
    End Sub

    Private Function createTeam(name As String) As Team
        Dim team As Team = New Team
        team.nombre = name
        Return team
    End Function
End Module
