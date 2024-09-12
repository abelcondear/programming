Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class productos
    Public Property ID As Integer

    <Required>
    <StringLength(255)>
    Public Property Nombre As String

    Public Property Precio As Double?

    <StringLength(255)>
    Public Property Categoria As String
End Class
