Imports System.Data.SqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub

    Function cargarDatos()
        Dim conexion As New SqlConnection(
            My.Settings.CONEXION_SQLSERVER)
        Dim consulta As String
        consulta = "Select * from productos"
        Dim comandoSql As New SqlCommand(
            consulta, conexion)
        Dim adapter As New SqlDataAdapter(comandoSql)
        Dim datosTablaProducto As New DataSet
        adapter.Fill(datosTablaProducto, "PRODUCTOS")
        DataGridView1.DataSource =
            datosTablaProducto.Tables("PRODUCTOS")
    End Function

    Private Sub agregarProducto(sender As Object, e As EventArgs) Handles Button1.Click
        Dim producto As New articulo
        producto.id = CInt(Me.TextBox1.Text)
        producto.descripcion = Me.TextBox2.Text
        producto.precio = CDbl(Me.TextBox3.Text)
        agregar(producto)
        cargarDatos()
    End Sub

    Function agregar(valor As articulo)
        Dim conexion As New SqlConnection(
           My.Settings.CONEXION_SQLSERVER)
        conexion.Open()
        Dim consulta As String
        consulta = "insert into 
productos (id,descripcion,precio) 
values (" & valor.id & ", '" & valor.descripcion _
        & "'," & valor.precio & ")"
        Dim comandoSql As New SqlCommand(
            consulta, conexion)
        comandoSql.ExecuteNonQuery()
    End Function
End Class
