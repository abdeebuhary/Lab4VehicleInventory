Option Strict On
Public Class clsVehicle

    Private Shared vehicleCount As Integer                  ' static or shared private variable to hold the number of vehicle
    Private vehicleIdentification As Integer = 0            ' private variable for identification number
    Private vehicleMake As String = String.Empty            ' private variable for make
    Private vehicleModel As String = String.Empty           ' private variable for model
    Private vehicleYear As String = String.Empty            ' private variable for year
    Private vehiclePrice As String = String.Empty           ' private variable for price
    Private vehicleNewStatus As Boolean = False             ' private variable for status


    Public Sub New()

        vehicleCount += 1
        vehicleIdentification = vehicleCount

    End Sub

    ''' <summary>
    ''' Constuctor - Parameterized - creates a new vehicle object
    ''' </summary>
    ''' <param name="make"></param>
    ''' <param name="model"></param>
    ''' <param name="year"></param>
    ''' <param name="price"></param>
    ''' <param name="newStatus"></param>
    Public Sub New(make As String, model As String, year As String, price As String, newStatus As Boolean)

        Me.New()

        vehicleMake = make
        vehicleModel = model
        vehicleYear = year
        vehiclePrice = price
        vehicleNewStatus = newStatus
    End Sub


    Public ReadOnly Property Count() As Integer
        Get
            Return vehicleCount
        End Get
    End Property


    Public ReadOnly Property VerifyNumber() As Integer
        Get
            Return vehicleIdentification
        End Get
    End Property


    Public Property newStatus() As Boolean
        Get
            Return vehicleNewStatus
        End Get
        Set(ByVal value As Boolean)
            vehicleNewStatus = value
        End Set
    End Property

    Public Property Make() As String
        Get
            Return vehicleMake
        End Get
        Set(ByVal value As String)
            vehicleMake = value
        End Set
    End Property


    Public Property Model As String
        Get
            Return vehicleModel
        End Get
        Set(ByVal value As String)
            vehicleModel = value
        End Set
    End Property


    Public Property Year() As String
        Get
            Return vehicleYear
        End Get
        Set(ByVal value As String)
            vehicleYear = value
        End Set
    End Property

    Public Property Price() As String
        Get
            Return vehiclePrice
        End Get
        Set(ByVal value As String)
            vehiclePrice = value
        End Set
    End Property


    Public Function GetSalutation() As String

        Return "It works".ToString()

    End Function

End Class
