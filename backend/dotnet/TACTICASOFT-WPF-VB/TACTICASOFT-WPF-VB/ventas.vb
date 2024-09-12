Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class ventas
    Public Property ID As Integer

    Public Property IDCliente As Integer

    Public Property Fecha As Date?

    Public Property Total As Double?
End Class
