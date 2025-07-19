Imports System.Data.SqlClient

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Function VerificarUsuario(email As String, password As String) As Boolean
        Try
            Dim helper As New DatabaseHelper()
            Dim parametros As New List(Of SqlParameter) From {
              New SqlParameter("@Email", email),
              New SqlParameter("@Password", password)
          }
            ' Ejecutar la consulta para verificar el usuario
            Dim dataTable As DataTable = helper.ExecuteQuery("SELECT * FROM Usuarios WHERE EMAIL = @Email AND CONTRASEÑA = @Password", parametros)

            ' Verificar si se encontró el usuario
            If dataTable.Rows.Count > 0 Then
                ' Usuario encontrado, puedes redirigir o realizar otra acción
                Session.Add("UsuarioId", dataTable.Rows(0)("Id").ToString())
                Session.Add("UsuarioNombre", dataTable.Rows(0)("Nombre").ToString())
                Session.Add("UsuarioApellido", dataTable.Rows(0)("Apellido").ToString())
                Session.Add("UsuarioEmail", dataTable.Rows(0)("Email").ToString())
            Else
                ' Usuario no encontrado, manejar el error
                Return False

            End If

        Catch ex As Exception
            Return False
        End Try
    End Function
    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)

        Dim email As String = txtEmail.Text
        Dim password As String = txtPass.Text
        Dim usuario As New Usuario() With {
            .Email = email,
            .Password = password
        }

        Dim helper As New DatabaseHelper()
        Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Email", email),
            New SqlParameter("@Password", password)
        }

        Dim datatable As DataTable = helper.ExecuteQuery("SELECT * FROM Usuarios WHERE EMAIL = @Email AND CONTRASEÑA = @Password", parametros)


        If email = "test@example.com" And password = "password" Then

            Response.Redirect("Default.aspx")

        Else

            lblError.Text = "Correo electrónico o contraseña inválidos."

            lblError.Visible = True

        End If


    End Sub
End Class