Class MainWindow
    Private Sub CmdSale_Click(sender As Object, e As RoutedEventArgs) Handles CmdSale.Click
        Dim ObProducts As ClsProducts = New ClsProducts

        REM -----------------------------------------
        REM New Sale
        REM -----------------------------------------

        Dim QueryProducts As IQueryable(Of Products)

        Dim ItemClients As Clients = New Clients
        Dim ItemSales As Sales = New Sales
        Dim ItemProducts As Products = New Products
        Dim ItemSaleItems As SaleItems = New SaleItems

        Dim Id As Integer
        Dim IdProduct As Integer
        Dim UnitPrice As Double
        Dim Quantity As Integer
        Dim Total As Double

        ItemClients.Id = 1

        QueryProducts = ObProducts.Products.Where(Function(i) i.Id = 1 Or i.Id = 2)

        Dim ItemProductsList As List(Of Products) = QueryProducts.ToList()

        ItemProducts.Id = ItemProductsList(0).Id
        ItemProducts.Price = ItemProductsList(0).Price

        IdProduct = ItemProducts.Id
        UnitPrice = ItemProducts.Price
        Quantity = 1
        Total = UnitPrice * Quantity

        IdProduct = ItemProductsList(1).Id
        ItemProducts.Price = ItemProductsList(1).Price

        IdProduct = ItemProducts.Id
        UnitPrice = ItemProducts.Price
        Quantity = 1
        Total = UnitPrice * Quantity

        ItemSales.IdClient = ItemClients.Id
        ItemSales._Date = Now()
        ItemSales.Total = Total

        ObProducts.Sales.Add(ItemSales)
        ObProducts.SaveChanges()

        REM -----------------------------------------
        REM End: New Sale
        REM -----------------------------------------


        REM -----------------------------------------
        REM New Sale Items
        REM -----------------------------------------

        Id = ItemSales.Id

        ItemSaleItems.IdSale = Id
        ItemSaleItems.IdProduct = IdProduct
        ItemSaleItems.UnitPrice = UnitPrice
        ItemSaleItems.Quantity = Quantity
        ItemSaleItems.TotalPrice = Total

        ObProducts.SaleItems.Add(ItemSaleItems)
        ObProducts.SaveChanges()

        ItemSaleItems.IdSale = Id
        ItemSaleItems.IdProduct = IdProduct
        ItemSaleItems.UnitPrice = UnitPrice
        ItemSaleItems.Quantity = Quantity
        ItemSaleItems.TotalPrice = Total

        ObProducts.SaleItems.Add(ItemSaleItems)
        ObProducts.SaveChanges()

        REM -----------------------------------------
        REM End: New Sale Items
        REM -----------------------------------------

        MessageBox.Show("Sale completed.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)

        REM ----------------------------------------
    End Sub

    Private Sub CmdFind_Click(sender As Object, e As RoutedEventArgs) Handles CmdFind.Click
        Dim ObProduct As ClsProducts = New ClsProducts
        Dim ItemClients As IQueryable(Of Clients)
        Dim ItemProducts As IQueryable(Of Products)

        ItemClients = ObProduct.Clients.Where(Function(i) i.Name.IndexOf("****") <> -1)
        ItemProducts = ObProduct.Products.Where(Function(i) i.Name.IndexOf("1") <> -1)

        For Each item In ItemClients
            MessageBox.Show(item.Name, "Find", MessageBoxButton.OK, MessageBoxImage.Information)
        Next

        For Each item In ItemProducts
            MessageBox.Show(item.Name, "Find", MessageBoxButton.OK, MessageBoxImage.Information)
        Next
    End Sub

    Private Sub CmdFindProduct_Click(sender As Object, e As RoutedEventArgs) Handles CmdFindProduct.Click
        Dim ObProduct As ClsProducts = New ClsProducts

        Dim ItemClients As Clients = New Clients
        Dim ItemSales As Sales = New Sales
        Dim ItemProducts As Products = New Products
        Dim ItemSaleItems As SaleItems = New SaleItems

        Dim IdProductList As New List(Of Integer)

        IdProductList.AddRange(New Integer() {1})

        ItemProducts.Name = "****"
        ItemClients.Id = 1
        ItemClients.Name = "****"
        ItemSales.Id = 1
        ItemSaleItems.UnitPrice = 10.1
        ItemSaleItems.Quantity = 1
        ItemSaleItems.TotalPrice = 1

        REM Search products (mandatory) and clients (optional)
        Dim ItemSearchProducts = (
         From p In ObProduct.Products.Where(Function(i) i.Name.IndexOf(ItemProducts.Name) <> -1)
         Join v In ObProduct.SaleItems On p.Id Equals v.IdProduct
         Join b In ObProduct.Sales On v.IdSale Equals b.Id
         Join c In ObProduct.Clients.Where(Function(i) i.Name.IndexOf(ItemClients.Name) <> -1 Or 1 = 1)
         On b.IdClient Equals c.Id
        )

        If ItemSearchProducts.Count() = 0 Then
            REM Search products (optional) and clients (mandatory)
            ItemSearchProducts = (
                From p In ObProduct.Products.Where(Function(i) i.Name.IndexOf(ItemProducts.Name) <> -1 Or 1 = 1)
                Join v In ObProduct.SaleItems On p.Id Equals v.IdProduct
                Join b In ObProduct.Sales On v.IdSale Equals b.Id
                Join c In ObProduct.Clients.Where(Function(i) i.Name.IndexOf(ItemClients.Name) <> -1)
                On b.IdClient Equals c.Id
            )
        End If


        If ItemSearchProducts.Count() = 0 Then
            MessageBox.Show("There is no result.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
        Else
            For Each Item In ItemSearchProducts
                MessageBox.Show(Item.p.Name, "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Next
        End If
    End Sub

    Private Sub CmdSalePlusRemove_Click(sender As Object, e As RoutedEventArgs) Handles CmdSalePlusRemove.Click
        Dim ObProduct As ClsProducts = New ClsProducts

        REM -----------------------------------------
        REM New Sale
        REM -----------------------------------------

        Dim ItemClients As Clients = New Clients
        Dim ItemSales As Sales = New Sales
        Dim ItemProducts As Products = New Products
        Dim QyItemProducts As IQueryable(Of Products)

        Dim ItemSaleItems As SaleItems = New SaleItems

        ItemClients.Id = 1

        QyItemProducts = ObProduct.Products.Where(Function(i) i.Id = 1 Or i.Id = 2)

        Dim ItemProductsList As List(Of Products) = QyItemProducts.ToList() REM .ToList() does not work 

        ItemProducts.Id = ItemProductsList(0).Id
        ItemProducts.Price = ItemProductsList(0).Price

        Dim Id As Integer
        Dim UnitPrice As Double
        Dim Quantity As Integer
        Dim TotalPrice As Double
        Dim Total As Double

        Id = ItemProducts.Id
        UnitPrice = ItemProducts.Price
        Quantity = 1
        TotalPrice = UnitPrice * Quantity
        Total = TotalPrice

        ItemProducts.Id = ItemProductsList(1).Id
        ItemProducts.Price = ItemProductsList(1).Price

        Id = ItemProducts.Id
        UnitPrice = ItemProducts.Price
        Quantity = 1
        TotalPrice = UnitPrice * Quantity

        Total += TotalPrice

        ItemSales.IdClient = ItemClients.Id
        ItemSales._Date = Now()
        ItemSales.Total = Total

        ObProduct.Sales.Add(ItemSales)
        ObProduct.SaveChanges()

        REM -----------------------------------------
        REM End: New Sales
        REM -----------------------------------------


        REM -----------------------------------------
        REM New Sale Items
        REM -----------------------------------------

        ItemSaleItems.IdSale = ItemSales.Id
        ItemSaleItems.IdProduct = Id REM IdProduct
        ItemSaleItems.UnitPrice = UnitPrice
        ItemSaleItems.Quantity = Quantity
        ItemSaleItems.TotalPrice = TotalPrice

        ObProduct.SaleItems.Add(ItemSaleItems)
        ObProduct.SaveChanges()

        ItemSaleItems.IdSale = ItemSales.Id
        ItemSaleItems.IdProduct = Id REM IdProduct
        ItemSaleItems.UnitPrice = UnitPrice
        ItemSaleItems.Quantity = Quantity
        ItemSaleItems.TotalPrice = TotalPrice

        ObProduct.SaleItems.Add(ItemSaleItems)
        ObProduct.SaveChanges()

        REM -----------------------------------------
        REM End: New Sale Items
        REM -----------------------------------------

        MessageBox.Show("Sale completed.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)

        REM ----------------------------------------

        REM -----------------------------------------
        REM Remove Sale from SaleItems table
        REM -----------------------------------------

        Dim IdProductList As New System.Collections.Generic.List(Of Integer)

        IdProductList.AddRange(New Integer() {4}) REM Nombre: producto 2 | producto 3

        ItemClients.Id = 1
        ItemSales.Id = 1
        ItemSaleItems.UnitPrice = 10.1
        ItemSaleItems.Quantity = 1
        ItemSaleItems.TotalPrice = 1

        Dim QyItemSearchSaleItems As IQueryable(Of SaleItems)

        QyItemSearchSaleItems = ObProduct.SaleItems.Where _
        (
            Function(i) i.IdSale = ItemSales.Id Or
                IdProductList.Contains(i.IdProduct) Or
                    i.Quantity = ItemSaleItems.Quantity Or
                        i.UnitPrice = ItemSaleItems.UnitPrice Or
                            i.TotalPrice = ItemSaleItems.TotalPrice
        )

        ObProduct.SaleItems.RemoveRange(QyItemSearchSaleItems)
        ObProduct.SaveChanges()

        REM -----------------------------------------
        REM End: Remove Sale from SaleItems table
        REM -----------------------------------------

        MessageBox.Show("Sale removed.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)

        REM ----------------------------------------
    End Sub

    Private Sub CmdFindV2_Click(sender As Object, e As RoutedEventArgs) Handles CmdFindV2.Click
        Dim ObProduct As ClsProducts = New ClsProducts

        Dim ItemClients As Clients = New Clients
        Dim ItemSale As Sales = New Sales
        Dim ItemProducts As Products = New Products
        Dim ItemSaleItems As SaleItems = New SaleItems

        Dim IdProductList As New List(Of Integer)

        IdProductList.AddRange(New Integer() {1})

        ItemProducts.Name = "****"
        ItemClients.Id = 1
        ItemSale.Id = 1
        ItemSaleItems.UnitPrice = 10.1
        ItemSaleItems.Quantity = 10
        ItemSaleItems.TotalPrice = 10


        Dim ItemSearchSaleItems = ObProduct.SaleItems.Where _
        (
            Function(i) i.IdSale = ItemSale.Id Or
                IdProductList.Contains(i.IdProduct) Or
                    i.Quantity = ItemSaleItems.Quantity Or
                        i.UnitPrice = ItemSaleItems.UnitPrice Or
                            i.TotalPrice = ItemSaleItems.TotalPrice
        )

        Dim ItemSearchProducts = (
            From p In ObProduct.Products.Where(Function(i) i.Name.IndexOf(ItemProducts.Name) <> -1)
            Join v In ObProduct.SaleItems.Where _
            (
                Function(i) i.IdSale = ItemSale.Id Or
                    IdProductList.Contains(i.IdProduct) Or
                        i.Quantity = ItemSaleItems.Quantity Or
                            i.UnitPrice = ItemSaleItems.UnitPrice Or
                                i.TotalPrice = ItemSaleItems.TotalPrice
            ) On p.Id Equals v.IdProduct
        )

        If ItemSearchProducts.Count() = 0 Then
            MessageBox.Show("There is no result.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
        Else
            For Each Item In ItemSearchProducts
                MessageBox.Show(Item.p.Name, "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Next
        End If
    End Sub
End Class
