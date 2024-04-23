using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace WSSistemaUniversitario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneradorDePDFController : ControllerBase
    {
        [HttpGet]

            public IActionResult generarPdf()
            {
                var data = Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(20));

                        page.Header()
                            .Text("Hello PDF!")
                            .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                        page.Content()
                            .PaddingVertical(1, Unit.Centimetre)
                            .Column(x =>
                            {
                                x.Spacing(20);

                                x.Item().Text(Placeholders.LoremIpsum());
                                x.Item().Image(Placeholders.Image(200, 100));
                            });

                        page.Footer()
                            .AlignCenter()
                            .Text(x =>
                            {
                                x.Span("Page ");
                                x.CurrentPageNumber();
                            });
                    });
                })
                .GeneratePdf();

                Stream stream = new MemoryStream(data);
                return File(stream, "application/pdf", "detalleventa.pdf");
            }
        }
    }



    