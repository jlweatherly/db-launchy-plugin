Imports LaunchySharp
Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class DBLaunchy
    Implements IPlugin

    Private m_pluginhost As IPluginHost = Nothing
    Private m_catItemFactory As ICatItemFactory = Nothing
    Private m_launchyPaths As ILaunchyPaths = Nothing

    Private m_id As Integer = 0
    Private m_name As String = ""
    Private m_iconpath = ""
    Private m_labelHash As Integer = 0
    Private m_iniPath As String = ""

    Private m_Server As String = ""
    Private m_DB As String = ""
    Private m_User As String = ""
    Private m_Pass As String = ""
    Private m_SQLCommand As String = ""

    Private m_optionsWidget As OptionsWidget = New OptionsWidget

    Private dtApps As DataTable


#Region "Plugin Methods"
    Public Sub init(ByVal pluginHost As IPluginHost) Implements IPlugin.init
        m_pluginhost = pluginHost

        If IsNothing(m_pluginhost) Then
            Return
        End If

        m_catItemFactory = m_pluginhost.catItemFactory
        m_launchyPaths = m_pluginhost.launchyPaths

        m_iniPath = m_pluginhost.launchyPaths.getConfigPath() & "\DBLaunchy.ini"
        ReadINI(m_iniPath)

        m_name = "DBLaunchy"
        m_id = m_pluginhost.hash(m_name)
        m_labelHash = m_id
        m_iconpath = m_launchyPaths.getIconsPath() + "\DBLaunchy.ico"

        If IsNothing(dtApps) Then
            FillApps()
        End If

    End Sub

    Public Function getID() As UInteger Implements IPlugin.getID
        Return m_id
    End Function
    Public Function getName() As String Implements IPlugin.getName
        Return m_name
    End Function
    Public Function getIcon() As String
        Return m_iconpath
    End Function

    Public Sub getCatalog(ByVal catalogItems As List(Of ICatItem)) Implements IPlugin.getCatalog

    End Sub
    Public Sub getLabels(ByVal inputDataList As List(Of IInputData)) Implements IPlugin.getLabels

    End Sub

    Public Sub getResults(ByVal inputDataList As List(Of IInputData), ByVal resultsList As List(Of ICatItem)) Implements IPlugin.getResults

        Dim appToMatch As String = inputDataList(0).getText()

        If (appToMatch = "") Then
            Return
        End If

        appToMatch = appToMatch.Replace(" ", "%") ' make the spaces wildcards

        Dim drMatchingApps() As DataRow = dtApps.Select("cTitle LIKE '%" & appToMatch & "%'")

        For Each dr As DataRow In drMatchingApps
            Dim shortName As String = CStr(dr!cTitle).Trim
            Dim fullPath As String = ""
            fullPath = CStr(dr!cDirectory).Trim & "\" & CStr(dr!cProgram).Trim

            Dim result As ICatItem = m_catItemFactory.createCatItem(fullPath, _
                shortName, getID(), getIcon())

            If Not resultsList.Contains(result) Then
                resultsList.Add(result)
            End If

        Next

    End Sub

    Public Sub launchItem(ByVal inputDataList As List(Of IInputData), ByVal item As ICatItem) Implements IPlugin.launchItem

        Dim catItem As ICatItem = inputDataList(inputDataList.Count - 1).getTopResult

        Try
            'get path to run
            Dim cFullPath As String = catItem.getFullPath.Replace("\\", "\") '' remove dupe \'s 

            Dim exeDelim As String() = New String(1) {".exe", ".EXE"}
            Dim strCommand() As String = cFullPath.Split(exeDelim, StringSplitOptions.None)

            Dim cmd As String = strCommand(0) & ".exe"
            Dim params As String = ""

            If strCommand.Length = 2 Then
                'parameters included after exe
                params = strCommand(1)
            End If

            'and run it
            Dim psi As New System.Diagnostics.ProcessStartInfo(cmd, params)
            psi.UseShellExecute = False
            System.Diagnostics.Process.Start(psi)


        Catch ex As Exception
            'don't catch any exceptions for now..
        End Try


    End Sub

    Public Function hasDialog() As Boolean Implements IPlugin.hasDialog
        Return True
    End Function

    Public Function doDialog() As System.IntPtr Implements IPlugin.doDialog
        m_optionsWidget.User = m_User
        m_optionsWidget.Password = m_Pass
        m_optionsWidget.Server = m_Server
        m_optionsWidget.DB = m_DB
        m_optionsWidget.SQLCommand = m_SQLCommand

        m_optionsWidget.Show()
        Return m_optionsWidget.Handle

    End Function

    Public Sub endDialog(ByVal acceptedByUser As Boolean) Implements IPlugin.endDialog
        If acceptedByUser Then
            m_User = m_optionsWidget.User
            m_Pass = m_optionsWidget.Password
            m_Server = m_optionsWidget.Server
            m_DB = m_optionsWidget.DB
            m_SQLCommand = m_optionsWidget.SQLCommand

            WriteINI(m_iniPath)

        End If

    End Sub

    Public Sub launchyHide() Implements IPlugin.launchyHide

    End Sub

    Public Sub launchyShow() Implements IPlugin.launchyShow

    End Sub

#End Region

    Private Sub ReadINI(ByVal file As String)
        Try
            If IO.File.Exists(file) Then

                Dim cContents() As String = IO.File.ReadAllLines(file)
                For Each line As String In cContents
                    If line.StartsWith("#") Then
                        'handle comments
                        Continue For
                    Else
                        Dim cParams() As String = line.Split("=")
                        If cParams.Length = 2 Then
                            Select Case cParams(0).ToLower
                                Case "server"
                                    m_Server = cParams(1)
                                Case "db"
                                    m_DB = cParams(1)
                                Case "user"
                                    m_User = cParams(1)
                                Case "pass"
                                    m_Pass = cParams(1)
                                Case "cmd"
                                    m_SQLCommand = cParams(1)
                            End Select
                        End If

                    End If
                Next
            End If


        Catch ex As Exception
            MsgBox("DBLaunchy: error reading ini file. " & ex.Message)
        End Try

    End Sub
    Private Sub WriteINI(ByVal file As String)
        Dim cINIContents As String

        Try
            cINIContents = String.Format( _
                "server={0}" & vbCrLf & _
                "db={1}" & vbCrLf & _
                "user={2}" & vbCrLf & _
                "pass={3}" & vbCrLf & _
                "cmd={4}", _
                m_Server, m_DB, m_User, m_Pass, m_SQLCommand)

            IO.File.WriteAllText(file, cINIContents)

        Catch ex As Exception
            MsgBox("DBLaunchy: error writing ini file. " & ex.Message)
        End Try

    End Sub
    Private Sub FillApps()
        dtApps = New DataTable
        dtAuthority = New DataTable

        Dim cnnString As String = String.Format("server = {0}; database = {1}; UID = {2} ; pwd = {3};", _
            m_Server, m_DB, m_User, m_Pass)

        Dim cnn As SqlConnection = New SqlConnection(cnnString)
        Dim cmd As SqlCommand = New SqlCommand(m_SQLCommand)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cnn

        cmd.Parameters.AddWithValue("@cAuthority", "")

        Try
            cnn.Open()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            da.Fill(dtApps)

        Catch ex As Exception

        Finally
            cnn.Close()
        End Try

    End Sub

End Class

