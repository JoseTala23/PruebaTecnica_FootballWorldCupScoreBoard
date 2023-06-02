Public Class Match
    Public teamLocal As Team
    Public teamVisitante As Team
    Public scoreLocal As Integer
    Public scoreVisitante As Integer
    Public ReadOnly date_ As Date

    Public ReadOnly Property TotalScore As Integer
        Get
            Return scoreLocal + scoreVisitante
        End Get
    End Property

    Public Sub New(equipoLocal As Team, equipoVisitante As Team)
        Me.teamLocal = equipoLocal
        Me.teamVisitante = equipoVisitante
        date_ = Now
    End Sub

End Class
