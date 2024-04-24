using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using WSSistemaUniversitario.Models;

namespace WSSistemaUniversitario.Services
{
    public class PdfPagoService
    {
        private readonly DbSistemauniversitarioContext _db;
        public PdfPagoService(DbSistemauniversitarioContext db)
        {
            _db = db;
        }

        public MemoryStream generarPdf(int id)
        {
            var alumno = _db.Alumno.FirstOrDefault(a => a.IdAlumno == id);
            var cuota = _db.Cuota.FirstOrDefault(c => c.IdCarrera == alumno.IdCarrera);
            var carrera = _db.Carrera.FirstOrDefault(c => c.IdCarrera == alumno.IdCarrera);

            DateTime FechaDeHoy = DateTime.Today;
            



            var data = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .Text("Comprobante de pago")
                        .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(20);

                            x.Item().Text($"Carrera: {carrera.Nombre}");
                            x.Item().Text($"Fecha de comprobante: {FechaDeHoy.ToString("D")}");
                            x.Item().Text($"Monto: {cuota.Costo}");
                            x.Item().Text($"Alumno: {alumno.Apellido}, {alumno.Nombre}");
                            x.Item().Image(Placeholders.Image(200, 100));
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text("Universidad Nacional de Devs");
                });
            })
            .GeneratePdf();

            var stream = new MemoryStream(data);

            return stream;

            }
        }
}

