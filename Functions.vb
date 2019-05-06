Imports System.Reflection
Imports System.IO
Module Functions
    Public Function Dbusername(u)
        If (u = 1) Then
            UName = "sa"
        End If
        Return UName
    End Function
    Public Function DbPassword(p)
        If (p = 10) Then
            PName = "Shalabi"
        End If
        Return PName
    End Function

    Public Function CallBuildingInfo()
        Dim buildDate As DateTime = New FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime
        Return (buildDate.ToString("dd-MMM-yyyy"))
    End Function
    'Public Function DateGood(NumDays As Integer) As Integer

    '    Dim location = Assembly.GetExecutingAssembly().Location
    '    Dim appPath = Path.GetDirectoryName(location)
    '    Dim appName = Path.GetFileName(location)

    '    Dim TmpCRD As Date
    '    Dim TmpLRD As Date
    '    Dim TmpFRD As Date
    '    TmpCRD = Format(Now, "M/d/yy")
    '    TmpLRD = GetSetting(appName, "Param", "LRD", "10/04/2019")
    '    TmpFRD = GetSetting(appName, "Param", "FRD", "10/04/2019")
    '    DateGood = False
    '    'If this is the applications first load, write initial settings to the register
    '    If TmpLRD = "10/04/2019" Then
    '        My.Settings.CRD = TmpCRD
    '        My.Settings.FRD = TmpFRD
    '    End If
    '    'Read LRD and FRD from Settings
    '    TmpLRD = My.Settings.LRD
    '    TmpFRD = My.Settings.FRD

    '    If TmpFRD > TmpCRD Then 'System clock rolled back
    '        Return 1
    '    ElseIf Now > DateAdd("d", NumDays, TmpFRD) Then 'Expiration expired
    '        Return 2
    '    ElseIf TmpCRD >= Format(TmpLRD, "M/d/yy") Then 'Everything OK write New LRD date
    '        My.Settings.FRD = TmpCRD
    '        Return 3
    '    Else
    '        Return 4
    '    End If
    'End Function

    Private Function SystemSerialNumber() As String
        ' Get the Windows Management Instrumentation object.
        Dim wmi As Object = GetObject("WinMgmts:")

        ' Get the "base boards" (mother boards).
        Dim serial_numbers As String = ""
        Dim mother_boards As Object = wmi.InstancesOf("Win32_BaseBoard")

        For Each board As Object In mother_boards
            serial_numbers &= ", " & board.SerialNumber
        Next board
        If serial_numbers.Length > 0 Then
            serial_numbers = serial_numbers.Substring(2)
        End If

        Return serial_numbers
    End Function

    Private Function CpuId() As String
        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:" & "{impersonationLevel=impersonate}!\\" & computer & "\root\cimv2")
        Dim processors As Object = wmi.ExecQuery("Select * from " & "Win32_Processor")
        Dim cpu_ids As String = ""

        For Each cpu As Object In processors
            cpu_ids = cpu_ids & ", " & cpu.ProcessorId
        Next cpu
        If cpu_ids.Length > 0 Then cpu_ids =
            cpu_ids.Substring(2)
        Return cpu_ids
    End Function
End Module
