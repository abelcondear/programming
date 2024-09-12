Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class reporte

    Public Property IdVenta As Integer

    Public Property Cliente As String

    Public Property Fecha As DateTime?

    Public Property NombreProducto As String

    Public Property PrecioUnitario As Double?

    Public Property Cantidad As Double?

    Public Property Subtotal As Double?

    Public Property Total As Double?

End Class
