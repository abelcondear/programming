﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Namespace TACTICASOFT_WPF_VB

    Partial Public Class pruebademoEntities
        Inherits DbContext
    
        Public Sub New()
            MyBase.New("name=pruebademoEntities")
        End Sub
    
        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
            Throw New UnintentionalCodeFirstException()
        End Sub
    
        Public Overridable Property clientes() As DbSet(Of clientes)
        Public Overridable Property productos() As DbSet(Of productos)
        Public Overridable Property ventas() As DbSet(Of ventas)
        Public Overridable Property ventasitems() As DbSet(Of ventasitems)
    
    End Class

End Namespace
