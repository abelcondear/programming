Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class ModelDb2
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=ModelDb2")
    End Sub

    Public Overridable Property clientes As DbSet(Of clientes)
    Public Overridable Property productos As DbSet(Of productos)
    Public Overridable Property ventas As DbSet(Of ventas)
    Public Overridable Property ventasitems As DbSet(Of ventasitems)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.Cliente) _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.Telefono) _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.Correo) _
            .IsUnicode(False)

        modelBuilder.Entity(Of productos)() _
            .Property(Function(e) e.Nombre) _
            .IsUnicode(False)

        modelBuilder.Entity(Of productos)() _
            .Property(Function(e) e.Categoria) _
            .IsUnicode(False)
    End Sub
End Class
