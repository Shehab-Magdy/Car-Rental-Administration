Imports System.Data
Imports System.Data.SqlClient
Module GM

    Public connection As New SqlConnection("Data Source=(local);Initial Catalog=CarRentalDB;Persist Security Info=True;User ID=sa;Password=Shalabi")

    Public pubcod, query, str, cod, lognam, logpass, custcode, carcode As String

    Public CustomerFrmLoad As Integer = 0
    Public usercod As Integer = 1
    Public CarsFrmLoad As Integer = 0
    Public returncarFrmLoad As Integer = 0 
    Public FindWhat As Integer = 0
    Public contractcode As Integer = 0
    Public cashfrmload As Integer = 0
    Public cashcode, usercode, branchcode, Findcode, ownercode As String
    Public contno, CompanyNameAR, usernam, Duration, Start_KM, End_KM As String
    Public DLicEndDate, IdEndDate, ContractDate, StartDate, EndDate As Date
    Public Amount, Total_Expected As Decimal
    Public CustomerName, Nationality, IdNo, IdSource, DLicNo, DLicSource, CustPhone, Address As String

    Public OwnerName, CarType, CarModel, CarColor, CarLicNo, MotorNo, ChaseeNo As String


End Module
