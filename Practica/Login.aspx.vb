Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)

        Dim email As String = txtEmail.Text
        Dim password As String = txtPass.Text
        Dim Usuario As New Usuario() With {
            .Email = email,
            .Password = password
        }

        Dim helper As New DatabaseHelper()


        If email = "test@example.com" And password = "password" Then

            Response.Redirect("Default.aspx")

        Else

            lblError.Text = "Correo electrónico o contraseña inválidos."

            lblError.Visible = True

        End If


    End Sub
End Class