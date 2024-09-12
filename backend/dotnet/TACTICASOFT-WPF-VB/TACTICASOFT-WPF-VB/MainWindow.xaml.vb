
Class MainWindow
    Private Sub CmdSaleCommit_Click(sender As Object, e As RoutedEventArgs) Handles CmdSaleCommit.Click
        Dim ModelDb As ModelDb2 = New ModelDb2()

        REM -----------------------------------------
        REM Nuevo Venta
        REM -----------------------------------------

        Dim ItemProductos As IQueryable(Of productos)

        Dim ItemCliente As clientes = New clientes()
        Dim ItemVenta As ventas = New ventas()
        Dim ItemProducto As productos = New productos()
        Dim ItemVentaItems As ventasitems = New ventasitems()

        ItemCliente.ID = 3

        ItemProductos = ModelDb.productos.Where(Function(i) i.ID = 2 Or i.ID = 1)

        Dim ItemProductosList As List(Of productos) = ItemProductos.ToList()

        ItemProducto.ID = ItemProductosList(0).ID
        ItemProducto.Precio = ItemProductosList(0).Precio
        Dim IdProductoItem1 As Integer = ItemProducto.ID
        Dim PrecioUnitarioItem1 As Double = ItemProducto.Precio
        Dim CantidadItem1 As Integer = 10
        Dim PrecioTotalItem1 As Double = PrecioUnitarioItem1 * CantidadItem1

        ItemProducto.ID = ItemProductosList(1).ID
        ItemProducto.Precio = ItemProductosList(1).Precio
        Dim IdProductoItem2 As Integer = ItemProducto.ID
        Dim PrecioUnitarioItem2 As Double = ItemProducto.Precio
        Dim CantidadItem2 As Integer = 5
        Dim PrecioTotalItem2 As Double = PrecioUnitarioItem2 * CantidadItem2

        Dim Total As Double = PrecioTotalItem1 + PrecioTotalItem2

        ItemVenta.IDCliente = ItemCliente.ID
        ItemVenta.Fecha = Now()
        ItemVenta.Total = Total

        ModelDb.ventas.Add(ItemVenta)
        ModelDb.SaveChanges()

        REM -----------------------------------------
        REM Fin: Nuevo Venta
        REM -----------------------------------------


        REM -----------------------------------------
        REM Nuevo Venta Items
        REM -----------------------------------------

        Dim IdVenta As Integer = ItemVenta.ID

        ItemVentaItems.IDVenta = IdVenta
        ItemVentaItems.IDProducto = IdProductoItem1
        ItemVentaItems.PrecioUnitario = PrecioUnitarioItem1
        ItemVentaItems.Cantidad = CantidadItem1
        ItemVentaItems.PrecioTotal = PrecioTotalItem1

        ModelDb.ventasitems.Add(ItemVentaItems)
        ModelDb.SaveChanges()

        ItemVentaItems.IDVenta = IdVenta
        ItemVentaItems.IDProducto = IdProductoItem2
        ItemVentaItems.PrecioUnitario = PrecioUnitarioItem2
        ItemVentaItems.Cantidad = CantidadItem2
        ItemVentaItems.PrecioTotal = PrecioTotalItem2

        ModelDb.ventasitems.Add(ItemVentaItems)
        ModelDb.SaveChanges()

        REM -----------------------------------------
        REM Fin: Nuevo Venta Items
        REM -----------------------------------------

        MessageBox.Show("Venta completa realizada.", "Información", MessageBoxButton.OK, MessageBoxImage.Information)

        REM ----------------------------------------

    End Sub

    Private Sub CmdFind_Click(sender As Object, e As RoutedEventArgs) Handles CmdFind.Click
        REM TODO 

        Dim ModelDb As ModelDb2 = New ModelDb2()
        Dim ItemClientes As IQueryable(Of clientes)
        Dim ItemProductos As IQueryable(Of productos)


        ItemClientes = ModelDb.clientes.Where(Function(i) i.Cliente.IndexOf("Juan") <> -1)
        ItemProductos = ModelDb.productos.Where(Function(i) i.Nombre.IndexOf("4") <> -1)

        For Each item In ItemClientes
            MessageBox.Show(item.Cliente, "Encontrar", MessageBoxButton.OK, MessageBoxImage.Information)
        Next

        For Each item In ItemProductos
            MessageBox.Show(item.Nombre, "Encontrar", MessageBoxButton.OK, MessageBoxImage.Information)
        Next
    End Sub

    Private Sub CmdCreateReport_Click(sender As Object, e As RoutedEventArgs) Handles CmdCreateReport.Click
        Dim ModelDb As ModelDb2 = New ModelDb2()

        Dim ItemCliente As clientes = New clientes()
        Dim ItemVenta As ventas = New ventas()
        Dim ItemProducto As productos = New productos()
        Dim ItemVentaItems As ventasitems = New ventasitems()

        Dim IdProductos As New List(Of Integer)

        IdProductos.AddRange(New Integer() {1}) REM Nombre: producto 2 | producto 3

        ItemProducto.Nombre = "producto 1"

        ItemCliente.Cliente = "Modificado"
        ItemVenta.ID = -1 REM Fecha: 2024-09-09 15:18:05.067

        REM Busco productos (obligatorio) y clientes (opcional)
        Dim ItemBusquedaProductos = (
            From p In ModelDb.productos.Where(Function(i) i.Nombre.IndexOf(ItemProducto.Nombre) <> -1)
            Join v In ModelDb.ventasitems On p.ID Equals v.IDProducto
            Join b In ModelDb.ventas On v.IDVenta Equals b.ID
            Join c In ModelDb.clientes
            On v.IDVenta Equals c.ID
        )

        If ItemBusquedaProductos.Count() = 0 Then
            ItemBusquedaProductos = (
                From p In ModelDb.productos
                Join v In ModelDb.ventasitems On p.ID Equals v.IDProducto
                Join b In ModelDb.ventas On v.IDVenta Equals b.ID
                Join c In ModelDb.clientes.Where(Function(i) i.Cliente.IndexOf(ItemCliente.Cliente) <> -1)
                On v.IDVenta Equals c.ID
            )
        End If


        If ItemBusquedaProductos.Count() = 0 Then
            MessageBox.Show("No hay resultados.", "Información", MessageBoxButton.OK, MessageBoxImage.Information)
        Else
            For Each Item In ItemBusquedaProductos
                MessageBox.Show(Item.p.Nombre, "Información", MessageBoxButton.OK, MessageBoxImage.Information)
            Next
        End If

    End Sub

    Private Sub CmdCRUD_Click(sender As Object, e As RoutedEventArgs) Handles CmdCRUD.Click
        Dim ModelDb As ModelDb2 = New ModelDb2()

        Dim ItemCliente As clientes = New clientes()
        Dim ItemVenta As ventas = New ventas()
        Dim ItemProducto As productos = New productos()
        Dim ItemVentaItems As ventasitems = New ventasitems()


        Dim IdProductos As New System.Collections.Generic.List(Of Integer)

        IdProductos.AddRange(New Integer() {4}) REM Nombre: producto 2 | producto 3

        ItemCliente.ID = 3 REM Cliente: Modificado...
        ItemVenta.ID = 2 REM Fecha: 2024-09-09 15:18:05.067
        ItemVentaItems.PrecioUnitario = 32.2
        ItemVentaItems.Cantidad = 5
        ItemVentaItems.PrecioTotal = 161

        Dim ItemBusquedaVentaItems As IQueryable(Of ventasitems)

        ItemBusquedaVentaItems = ModelDb.ventasitems.Where _
        (
            Function(i) i.IDVenta = ItemVenta.ID Or
            IdProductos.Contains(i.IDProducto) Or
            i.Cantidad = ItemVentaItems.Cantidad Or
            i.PrecioUnitario = ItemVentaItems.PrecioUnitario Or
            i.PrecioTotal = ItemVentaItems.PrecioTotal
        )

        ModelDb.ventasitems.RemoveRange(ItemBusquedaVentaItems)

        ModelDb.SaveChanges()

        REM ----------------------------------------

        MessageBox.Show("Venta eliminada.", "Información", MessageBoxButton.OK, MessageBoxImage.Information)

        REM ----------------------------------------

    End Sub

    Private Sub CmdClose_Click(sender As Object, e As RoutedEventArgs) Handles CmdClose.Click
        Me.Close()
    End Sub

    Private Sub CmdSaleFind_Click(sender As Object, e As RoutedEventArgs) Handles CmdSaleFind.Click
        Dim ModelDb As ModelDb2 = New ModelDb2()

        Dim ItemCliente As clientes = New clientes()
        Dim ItemVenta As ventas = New ventas()
        Dim ItemProducto As productos = New productos()
        Dim ItemVentaItems As ventasitems = New ventasitems()

        Dim IdProductos As New List(Of Integer)

        IdProductos.AddRange(New Integer() {1}) REM Nombre: producto 2 | producto 3

        ItemProducto.Nombre = "producto" REM Nombre: producto 2
        ItemCliente.ID = 3 REM Cliente: Modificado
        ItemVenta.ID = 2 REM Fecha: 2024-09-09 15:18:05.067
        ItemVentaItems.PrecioUnitario = 30.2
        ItemVentaItems.Cantidad = 10
        ItemVentaItems.PrecioTotal = 302

        Dim ItemBusquedaProductos = (
            From p In ModelDb.productos.Where(Function(i) i.Nombre.IndexOf(ItemProducto.Nombre) <> -1)
            Join v In ModelDb.ventasitems.Where _
            (
                Function(i) i.IDVenta = ItemVenta.ID Or
                IdProductos.Contains(i.IDProducto) Or
                i.Cantidad = ItemVentaItems.Cantidad Or
                i.PrecioUnitario = ItemVentaItems.PrecioUnitario Or
                i.PrecioTotal = ItemVentaItems.PrecioTotal
            ) On p.ID Equals v.IDProducto
        )

        If ItemBusquedaProductos.Count() = 0 Then
            MessageBox.Show("No hay resultados.", "Información", MessageBoxButton.OK, MessageBoxImage.Information)
        Else
            For Each Item In ItemBusquedaProductos
                MessageBox.Show(Item.p.Nombre, "Información", MessageBoxButton.OK, MessageBoxImage.Information)
            Next
        End If
    End Sub
End Class
