Option Strict On

''' <summary>
''' Name:  Abdee Buhary
''' Date:  12-July-2019
''' Description:  Windows form that keeps track of Inventory    
''' </summary>
Public Class frmCarInventory

    Private inventoryList As New SortedList                           ' list of vehicles 
    Private selectInventoryNumber As String = String.Empty            ' selected inventory number
    Private editData As Boolean = False

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        'Variables

        Dim vehicle As clsVehicle
        Dim vehicleItem As ListViewItem

        'Validation

        If IsValidInput() = True Then

            editData = True

            lblResult.Text = "Works"

            If selectInventoryNumber.Trim.Length = 0 Then

                vehicle = New clsVehicle(txtPrice.Text, txtModel.Text, cmbMake.Text, cmbYear.Text, chkNew.Checked)

                inventoryList.Add(vehicle.VerifyNumber.ToString(), vehicle)

            Else
                vehicle = CType(inventoryList.Item(selectInventoryNumber), clsVehicle)


                vehicle.Make = cmbMake.Text
                vehicle.Model = txtModel.Text
                vehicle.Year = cmbYear.Text
                vehicle.Price = txtPrice.Text
                vehicle.newStatus = chkNew.Checked

            End If


            lswVehicles.Items.Clear()


            For Each vehicleEntry As DictionaryEntry In inventoryList


                vehicleItem = New ListViewItem()


                vehicle = CType(vehicleEntry.Value, clsVehicle)


                vehicleItem.Checked = vehicle.newStatus
                vehicleItem.SubItems.Add(vehicle.VerifyNumber.ToString())
                vehicleItem.SubItems.Add(vehicle.Make)
                vehicleItem.SubItems.Add(vehicle.Model)
                vehicleItem.SubItems.Add(vehicle.Year)
                vehicleItem.SubItems.Add(FormatCurrency(vehicle.Price.ToString))


                lswVehicles.Items.Add(vehicleItem)

            Next vehicleEntry



            Reset()


            editData = False

        End If

    End Sub
    Private Sub Reset()


        txtModel.Text = String.Empty
        txtPrice.Text = String.Empty
        chkNew.Checked = False
        cmbMake.SelectedIndex = -1
        cmbYear.SelectedIndex = -1
        lblResult.Text = String.Empty

        selectInventoryNumber = String.Empty

    End Sub
    Private Function IsValidInput() As Boolean
        Dim returnValue As Boolean = True
        Dim DisplayMessage As String = String.Empty


        If cmbMake.SelectedIndex = -1 Then
            DisplayMessage += "Select the Vehicle Make" & vbCrLf

            returnValue = False
        End If


        If txtModel.Text.Trim.Length = 0 Then
            DisplayMessage += "Enter the Vehicle Model." & vbCrLf

            returnValue = False
        End If


        If cmbYear.SelectedIndex = -1 Then
            DisplayMessage += "Select the Year." & vbCrLf

            returnValue = False
        End If


        If txtPrice.Text.Trim.Length = 0 Then
            DisplayMessage += "Enter the price." & vbCrLf

            returnValue = False
        End If


        If returnValue = False Then

            lblResult.Text = "Error" & vbCrLf & DisplayMessage

        End If


        Return returnValue

    End Function
    Private Sub lswVehicles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lswVehicles.SelectedIndexChanged

        Const identificationIndex As Integer = 1

        selectInventoryNumber = lswVehicles.Items(lswVehicles.FocusedItem.Index).SubItems(identificationIndex).Text

        Dim vehicle As clsVehicle = CType(inventoryList.Item(selectInventoryNumber), clsVehicle)


        cmbMake.Text = vehicle.Make
        txtModel.Text = vehicle.Model
        cmbYear.Text = vehicle.Year
        txtPrice.Text = vehicle.Price
        chkNew.Checked = vehicle.newStatus


        lblResult.Text = vehicle.GetSalutation()

    End Sub
    Private Sub lswVehicles_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lswVehicles.ItemCheck

        If editData = False Then
            e.NewValue = e.CurrentValue
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
