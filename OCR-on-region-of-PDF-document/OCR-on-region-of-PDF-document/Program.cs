// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;
using System.Reflection.Metadata;

//Initialize the OCR processor.
using (OCRProcessor processor = new OCRProcessor())
{
    //Load a PDF document.
    FileStream inputPDFStream = new FileStream("../../../Input.pdf", FileMode.Open);
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputPDFStream);
    //Set OCR language to process.
    processor.Settings.Language = "lat";
    RectangleF rectangle = new RectangleF(0, 100, 950, 150);
    //Assign rectangles to the page.
    List<PageRegion> pageRegions = new List<PageRegion>();
    PageRegion region = new PageRegion();
    region.PageIndex = 0;
    region.PageRegions = new RectangleF[] { rectangle };
    pageRegions.Add(region);
    processor.Settings.Regions = pageRegions;
    //Process OCR by providing the PDF document.
    processor.PerformOCR(loadedDocument, "../../../Tessdata/");
    //Create file stream.
    using (FileStream outputFileStream = new FileStream("../../../Output.pdf", FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        loadedDocument.Save(outputFileStream);
    }
}

