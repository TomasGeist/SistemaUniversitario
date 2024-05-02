# Sistema de gestion universitario.
Se desarrolla un sistema que permite gestionar una Universidad. Va a contemplar un panel de administración donde se puede hacer el ingreso de nuevos alumnos, administar las carreras, profesores, materias, crear y actualizar planes de estudio, verificar notas de exámenes, entre otras funcionalidades necesarias en un sistema de este tipo.

---------
## Índice

- [Bibliotecas externas utilizadas](#bibliotecas-externas-utilizadas)
- [Clase EmailService](#clase-emailservice)
- [Clase PdfPagoService](#clase-pdfpagoservice)

-------------
## Bibliotecas externas utilizadas
<details>
<summary>MimeKit</summary>
[**MimeKit**](https://mimekit.net/) es una biblioteca de correo electrónico de código abierto para .NET. Proporciona una API fácil de usar para enviar y recibir correos electrónicos utilizando el protocolo SMTP
</details>

<summary>Quest Pdf</summary>
[**QuestPDF**](https://www.questpdf.com/) es una biblioteca de .NET que te permite generar documentos PDF utilizando C#. Podés agregarle texto, imágenes, gráficos y otros elementos, y es ideal para crearlo dinamicamente.
</details>


## Clase EmailService
<details open>
<summary>Breve introducción a la clase</summary>
Es una clase que proporciona la funcionalidad para enviar correos electrónicos a los alumnos de una universidad. Se utiliza para notificar a los alumnos sobre el procesamiento exitoso de un pago de cuota, adjuntando un comprobante de pago en formato PDF al correo electrónico. Esta clase utiliza la configuración de la aplicación y el contexto de la base de datos para obtener la información necesaria para enviar el correo electrónico, como la dirección de correo electrónico del alumno. Luego, utiliza la biblioteca MimeKit para crear y enviar el correo electrónico a través de un servidor SMTP, autenticándose con las credenciales proporcionadas.
</details>

```
EnviarEmail(EmailDTO correo, MemoryStream pdf);
```

Este metodo esta gestionando el contenido del email, obtiene datos de una base de datos inyectada en la clase y utiliza estos datos para saber a quien le debe enviar el correo. Define el asunto, el cuerpo y le agrega un documento PDF que corresponde a un comprobante de pago.

Los datos necesarios para la conexión los extra deun archivo privado -appsettings.json-

```
var email = new MimeMessage();
email.From.Add(MailboxAddress.Parse(_config.GetSection("Email:Username").Value));
email.To.Add(MailboxAddress.Parse(correo.Para));
email.Subject = correo.Asunto;
var builder = new BodyBuilder
{
    HtmlBody = correo.Contenido
};

builder.Attachments.Add("ComprobanteCuota.pdf", pdf.ToArray());

email.Body = builder.ToMessageBody();
```
1- Se instancia un objeto MimeMessage para representar el correo electrónico.
2- Se añade la dirección de correo del remitente obtenida de la configuración.
3- Se añade la dirección del destinatario especificada en correo.Para.
4- Se establece el asunto del correo como correo.Asunto.
5- Se crea un constructor de cuerpo (BodyBuilder) para construir el cuerpo del correo.
6- Se establece el cuerpo del correo en formato HTML usando el contenido proporcionado en correo.Contenido.
7- Se adjunta un archivo PDF llamado "ComprobanteCuota.pdf" utilizando los datos de pdf.ToArray().
8- Se establece el cuerpo del correo electrónico utilizando el constructor de cuerpo.
>***El protocolo SMTP corre sobre el puerto 587***
- Para más información: [Mimekit docs](https://mimekit.net/docs/html/Introduction.html) 

```
builder.Attachments.Add("ComprobanteCuota.pdf", pdf.ToArray());
```
Cuando trabajas con un MemoryStream, como en este caso con el objeto pdf, ToArray() se utiliza para convertir los datos almacenados en el MemoryStream en un arreglo de bytes (byte[]). Esto es necesario porque el método Add de Attachments espera un arreglo de bytes como segundo argumento para adjuntar un archivo.

[**MemoryStream.ToArray()**](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream.toarray?view=net-8.0): Más información.


--------------------


## Clase PdfPagoService
<details open>
<summary>Breve introducción a la clase</summary>
Es responsable de crear un documento en formato PDF que actúa como un comprobante de pago para un alumno en una universidad. Utiliza información sobre el alumno, la carrera y la cuota asociada a esa carrera para generar el documento. Este documento PDF incluirá detalles importantes como el nombre de la carrera, la fecha del comprobante (que es la fecha actual), el monto de la cuota, el nombre y apellido del alumno, y posiblemente una imagen representativa. Una vez que se genera el documento PDF, se almacena en un formato de flujo de memoria (MemoryStream), que puede ser utilizado para diferentes propósitos, como enviarlo por correo electrónico o guardar una copia en el sistema de archivos. 
</details>


```
public MemoryStream generarPdf(int id);
```
Se encarga de crear y diseñar un archivo pdf. La biblioteca utilizada hace bastante visual y entendible el codigo que estas escribiendo. Si estas familiarizado con css entonces puede que se haga mucho mas facil diseñar el PDF.


```
 var stream = new MemoryStream(data);
```
MemoryStream es útil cuando necesitas trabajar con datos en la memoria sin la sobrecarga de acceder a un medio externo, lo que puede ser más rápido y eficiente, especialmente para operaciones de lectura y escritura intensivas. 

- Almacena los datos en la memoria RAM del equipo.
- Los datos están disponibles en la memoria y pueden ser leídos y escritos con facilidad.

[**MemoryStream**](https://learn.microsoft.com/es-es/dotnet/api/system.io.memorystream?view=net-8.0): Más informacion sobre la clase
