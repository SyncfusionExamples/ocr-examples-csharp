// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;

//Initialize the OCR processor.
using (OCRProcessor processor = new OCRProcessor())
{
    //Load an existing PDF document.
    FileStream stream = new FileStream("../../../Input.pdf", FileMode.Open);
    PdfLoadedDocument document = new PdfLoadedDocument(stream);

    //Set OCR language.
    processor.Settings.Language = "lat";
    //Create the layout result. 
    OCRLayoutResult layoutResult = new OCRLayoutResult();
    //Perform OCR with input document and tessdata (Language packs).
    processor.PerformOCR(document, @"../../../Tessdata/", out layoutResult);
    //Get OCRed line collection from first page.
    OCRLineCollection lines = layoutResult.Pages[0].Lines;
    //Get each OCR'ed line and its bounds.
    foreach (Line line in lines)
    {
        string text = line.Text;
        RectangleF bounds = line.Rectangle;
    }

    //Close the document.
    document.Close(true);
}
