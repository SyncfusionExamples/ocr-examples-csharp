// See https://aka.ms/new-console-template for more information

using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;

//Initialize the OCR processor.
using (OCRProcessor processor = new OCRProcessor())
{
    //Get stream from an image file. 
    FileStream imageStream = new FileStream(@"../../../Input.jpg", FileMode.Open);
    //Set OCR language to process.
    processor.Settings.Language = Languages.English;
    //Process OCR by providing the bitmap image.  
    PdfDocument document = processor.PerformOCR(imageStream);
    //Create file stream.
    using (FileStream outputFileStream = new FileStream(@"../../../Output.pdf", FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        document.Save(outputFileStream);
    }
}