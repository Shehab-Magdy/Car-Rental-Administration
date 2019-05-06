Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Car_Rental.Functions

Module GM
#Disable Warning BC40000 ' Type or member is obsolete
    Public Property SName As String = ConfigurationSettings.AppSettings.Get("serverName")
#Enable Warning BC40000 ' Type or member is obsolete

#Disable Warning BC40000 ' Type or member is obsolete
    Public Property ReportsPath As String = ConfigurationSettings.AppSettings.Get("reportPath")
#Enable Warning BC40000 ' Type or member is obsolete

#Disable Warning BC40000 ' Type or member is obsolete
    Public Property DbName As String = ConfigurationSettings.AppSettings.Get("dbName")
#Enable Warning BC40000 ' Type or member is obsolete

#Disable Warning BC40000 ' Type or member is obsolete
    Public Property UName As String = ConfigurationSettings.AppSettings.Get("userid")
#Enable Warning BC40000 ' Type or member is obsolete

#Disable Warning BC40000 ' Type or member is obsolete
    Public Property PName As String = ConfigurationSettings.AppSettings.Get("userPassword")
#Enable Warning BC40000 ' Type or member is obsolete


    Private connectionstring As String = "Data Source='" & SName & "';Initial Catalog='" & DbName & "';Persist Security Info=True;User ID='" & Dbusername(UName) & "';Password='" & DbPassword(PName) & "'"
    Public connection As New SqlConnection(connectionstring)

    Public pubcod, query, str, cod, lognam, logpass, custcode, carcode, cashcode, usercode, branchcode, Findcode, ownercode As String
    Public OwnerName, CarType, CarModel, CarColor, CarLicNo, MotorNo, ChaseeNo, contno, CompanyNameAR, usernam, Duration, Start_KM, End_KM As String
    Public CustomerName, Nationality, IdNo, IdSource, DLicNo, DLicSource, CustPhone, Address As String

    Public DLicEndDate, IdEndDate, ContractDate, StartDate, EndDate As Date

    Public CustomerFrmLoad As Integer = 0
    Public usercod As Integer = 1
    Public CarsFrmLoad As Integer = 0
    Public returncarFrmLoad As Integer = 0
    Public FindWhat As Integer = 0
    Public contractcode As Integer = 0
    Public cashfrmload As Integer = 0

    Public Amount, Total_Expected As Decimal

    Public DefaultIdImageString As String = DefaultIdBase
    Public DefaultDriveLicImageString As String = DefaultDriveLicBase
    Public DefaultCarImageString As String = DefaultCarBase

End Module
