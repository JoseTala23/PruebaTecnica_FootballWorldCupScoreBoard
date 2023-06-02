Public Class Match
    Public equipoLocal As Team
    Public equipoVisitante As Team
    Public puntuacionLocal As Integer
    Public puntuacionVisitante As Integer
    Public ReadOnly fecha As Date

    Public ReadOnly Property TotalScore As Integer
        Get
            Return puntuacionLocal + puntuacionVisitante
        End Get
    End Property

    Public Sub New(equipoLocal As Team, equipoVisitante As Team)
        Me.equipoLocal = equipoLocal
        Me.equipoVisitante = equipoVisitante
        fecha = Now
    End Sub

End Class
