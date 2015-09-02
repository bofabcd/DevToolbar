Imports System.ServiceProcess

Public Class MySettings

    Private _SqlManagementPath As String = "D:\Program Files (x86)\Microsoft SQL Server\100\Tools\Binn\VSShell\Common7\IDE\ssms.exe"
    Private _Autohide As Boolean = False
    Private _Edge As ApplicationBar.ABEdge = ApplicationBar.ABEdge.abeTop

    Public Event Changed()

    Public Property SqlManagementPath() As String
        Get
            SqlManagementPath = Me._SqlManagementPath
        End Get
        Set(ByVal value As String)
            Me._SqlManagementPath = value
            RaiseEvent Changed()
        End Set
    End Property

    Public Property Autohide() As Boolean
        Get
            Autohide = Me._Autohide
        End Get
        Set(ByVal value As Boolean)
            Me._Autohide = value
            RaiseEvent Changed()
        End Set
    End Property

    Public Property Edge As ApplicationBar.ABEdge
        Get
            Edge = Me._Edge
        End Get
        Set(ByVal value As ApplicationBar.ABEdge)
            Me._Edge = value
            RaiseEvent Changed()
        End Set
    End Property

End Class
