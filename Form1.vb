Imports System.IO
Imports System
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports System.Reflection.PortableExecutable
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button

Public Class Form1
    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        ' Mostrar el diálogo para seleccionar la carpeta
        If dlgCarpeta.ShowDialog() = DialogResult.OK Then
            ' Mostrar la ruta seleccionada en un TextBox (debes tener un TextBox para esto)
            txtRutaCarpeta.Text = dlgCarpeta.SelectedPath
        End If
    End Sub

    'INICIO CODIGO PARA LOS RIS

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        ' Obtener la ruta de la carpeta 
        Dim carpetaPDFs As String = txtRutaCarpeta.Text

        ' Obtener el prefijo del TextBox
        Dim prefijo As String = txtPrefijo.Text

        ' Validar si la carpeta existe
        If Directory.Exists(carpetaPDFs) Then
            ' Llamar a la función para renombrar RIS
            RenombrarRIS(carpetaPDFs, prefijo)
            MessageBox.Show("Proceso finalizado.")
        Else
            MessageBox.Show("La carpeta especificada no existe.")
        End If
    End Sub

    Public Shared Sub RenombrarRIS(carpetaPDFs As String, prefijo As String)
        For Each nombreArchivo As String In Directory.GetFiles(carpetaPDFs, "*.pdf")
            Dim rutaArchivo As String = IO.Path.Combine(carpetaPDFs, nombreArchivo)
            Try
                Dim lectorPDF As New PdfReader(rutaArchivo)
                Dim pagina As PdfDictionary = lectorPDF.GetPageN(1) ' Asumiendo que el título está en la primera página

                ' Extraer el contenido de la página como texto
                Dim estrategiaExtraccion As New LocationTextExtractionStrategy()
                Dim contenido As String = PdfTextExtractor.GetTextFromPage(lectorPDF, 1, estrategiaExtraccion)

                ' Dividir el contenido en líneas
                Dim lineasTexto As String() = contenido.Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)

                ' Verificar si el array tiene suficientes elementos
                If lineasTexto.Length >= 5 Then
                    Dim titulo As String = lineasTexto(4).Trim() ' Extraer el texto de la línea 5 (índice 4)

                    ' Eliminar caracteres inválidos del título
                    titulo = New String(titulo.Where(Function(c) Char.IsLetterOrDigit(c) OrElse c = "."c OrElse c = "_"c OrElse c = "-"c OrElse c = " "c).ToArray())

                    ' Usar el prefijo al renombrar
                    Dim nuevoNombre As String = prefijo & titulo & ".pdf"
                    Dim nuevaRuta As String = IO.Path.Combine(carpetaPDFs, nuevoNombre)

                    lectorPDF.Close()
                    File.Move(rutaArchivo, nuevaRuta)

                    Console.WriteLine("Archivo renombrado a: {0}", nuevoNombre)
                Else
                    Console.WriteLine("El archivo PDF {0} no tiene suficientes líneas.", nombreArchivo)
                End If

            Catch ex As Exception
                Console.WriteLine("Error al procesar el archivo {0}: {1}", nombreArchivo, ex.Message)
            End Try
        Next
    End Sub

    'INICIO DEL CODIGO PARA LAS FICHAS TECNICAS

    Dim idioma As String  ' Valor predeterminado
    Private Sub RBEsp_CheckedChanged(sender As Object, e As EventArgs) Handles RBEsp.CheckedChanged
        If RBEsp.Checked Then
            idioma = "Español"
        End If
    End Sub

    Private Sub RBEng_CheckedChanged(sender As Object, e As EventArgs) Handles RBEng.CheckedChanged
        If RBEng.Checked Then
            idioma = "Ingles"
        End If
    End Sub

    Private Sub btnFicha_Click(sender As Object, e As EventArgs) Handles btnFicha.Click
        ' Obtener la ruta de la carpeta 
        Dim carpetaPDFs = txtRutaCarpeta.Text

        ' Obtener el prefijo del TextBox
        Dim prefijo = txtPrefijo.Text

        ' Validar si la carpeta existe
        If Directory.Exists(carpetaPDFs) Then
            ' Llamar a la función para renombrar archivos
            If idioma = "Ingles" Then
                ' Ejecutar la acción para documentos en inglés
                RenombrarFTEng(carpetaPDFs, prefijo)
                MessageBox.Show("Proceso finalizado.")
            ElseIf idioma = "Español" Then
                ' Ejecutar la acción para documentos en español
                RenombrarFTEsp(carpetaPDFs, prefijo)
                MessageBox.Show("Proceso finalizado.")
            End If
        Else
            MessageBox.Show("La carpeta especificada no existe.")
        End If
    End Sub

    Public Shared Sub RenombrarFTEsp(carpetaPDFs As String, prefijo As String)
        For Each nombreArchivo As String In Directory.GetFiles(carpetaPDFs, "*.pdf")
            Dim rutaArchivo As String = IO.Path.Combine(carpetaPDFs, nombreArchivo)

            Try
                Dim lectorPDF As New PdfReader(rutaArchivo)
                Dim pagina As PdfDictionary = lectorPDF.GetPageN(1) ' Asumiendo que el título está en la primera página

                ' Extraer el contenido de la página como texto
                Dim estrategiaExtraccion As New LocationTextExtractionStrategy()
                Dim contenido As String = PdfTextExtractor.GetTextFromPage(lectorPDF, 1, estrategiaExtraccion)

                ' Dividir el contenido en líneas
                Dim lineasTexto As String() = contenido.Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)

                ' Verificar si el array tiene suficientes elementos
                If lineasTexto.Length >= 5 Then
                    Dim lineaCompleta As String = lineasTexto(9).Trim() ' Obtener la línea 5 completa (índice 4)

                    ' Calcular el final del título (último carácter de la línea)
                    Dim inicio As Integer = 30 ' Índice del primer carácter que quieres extraer
                    Dim fin As Integer = lineaCompleta.Length - 1  ' Índice del último carácter

                    ' Extraer el título
                    Dim titulo As String = lineaCompleta.Substring(inicio, fin - inicio + 1)

                    ' Eliminar caracteres inválidos del título
                    titulo = New String(titulo.Where(Function(c) Char.IsLetterOrDigit(c) OrElse c = "."c OrElse c = "_"c OrElse c = "-"c OrElse c = " "c).ToArray())

                    ' Usar el prefijo al renombrar
                    Dim nuevoNombre As String = prefijo & titulo & ".pdf"
                    Dim nuevaRuta As String = IO.Path.Combine(carpetaPDFs, nuevoNombre)

                    lectorPDF.Close()
                    File.Move(rutaArchivo, nuevaRuta)

                    Console.WriteLine("Archivo renombrado a: {0}", nuevoNombre)
                Else
                    Console.WriteLine("El archivo PDF {0} no tiene suficientes líneas.", nombreArchivo)
                End If

            Catch ex As Exception
                Console.WriteLine("Error al procesar el archivo {0}: {1}", nombreArchivo, ex.Message)
            End Try
        Next
    End Sub

    Public Shared Sub RenombrarFTEng(carpetaPDFs As String, prefijo As String)
        For Each nombreArchivo As String In Directory.GetFiles(carpetaPDFs, "*.pdf")
            Dim rutaArchivo As String = IO.Path.Combine(carpetaPDFs, nombreArchivo)

            Try
                Dim lectorPDF As New PdfReader(rutaArchivo)
                Dim pagina As PdfDictionary = lectorPDF.GetPageN(1) ' Asumiendo que el título está en la primera página

                ' Extraer el contenido de la página como texto
                Dim estrategiaExtraccion As New LocationTextExtractionStrategy()
                Dim contenido As String = PdfTextExtractor.GetTextFromPage(lectorPDF, 1, estrategiaExtraccion)

                ' Dividir el contenido en líneas
                Dim lineasTexto As String() = contenido.Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)

                ' Verificar si el array tiene suficientes elementos
                If lineasTexto.Length >= 5 Then
                    Dim lineaCompleta As String = lineasTexto(9).Trim() ' Obtener la línea 5 completa (índice 4)

                    ' Calcular el final del título (último carácter de la línea)
                    Dim inicio As Integer = 23 ' Índice del primer carácter que quieres extraer
                    Dim fin As Integer = lineaCompleta.Length - 1  ' Índice del último carácter

                    ' Extraer el título
                    Dim titulo As String = lineaCompleta.Substring(inicio, fin - inicio + 1)

                    ' Eliminar caracteres inválidos del título
                    titulo = New String(titulo.Where(Function(c) Char.IsLetterOrDigit(c) OrElse c = "."c OrElse c = "_"c OrElse c = "-"c OrElse c = " "c).ToArray())

                    ' Usar el prefijo al renombrar
                    Dim nuevoNombre As String = prefijo & titulo & ".pdf"
                    Dim nuevaRuta As String = IO.Path.Combine(carpetaPDFs, nuevoNombre)

                    lectorPDF.Close()
                    File.Move(rutaArchivo, nuevaRuta)

                    Console.WriteLine("Archivo renombrado a: {0}", nuevoNombre)
                Else
                    Console.WriteLine("El archivo PDF {0} no tiene suficientes líneas.", nombreArchivo)
                End If

            Catch ex As Exception
                Console.WriteLine("Error al procesar el archivo {0}: {1}", nombreArchivo, ex.Message)
            End Try
        Next
    End Sub

End Class
