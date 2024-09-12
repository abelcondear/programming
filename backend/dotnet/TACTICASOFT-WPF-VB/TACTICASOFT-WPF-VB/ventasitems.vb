Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class ventasitems
    Public Property ID As Integer

    Public Property IDVenta As Integer

    Public Property IDProducto As Integer

    Public Property PrecioUnitario As Double?

    Public Property Cantidad As Double?

    Public Property PrecioTotal As Double?
End Class
