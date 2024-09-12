Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class clientes
    Public Property ID As Integer

    <Required>
    <StringLength(255)>
    Public Property Cliente As String

    <StringLength(255)>
    Public Property Telefono As String

    <StringLength(255)>
    Public Property Correo As String
End Class
