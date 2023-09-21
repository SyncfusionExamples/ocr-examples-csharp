// See https://aka.ms/new-console-template for more information

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
    //Set OCR page auto detection rotation.
    processor.Settings.PageSegment = PageSegMode.AutoOsd;
    //Perform OCR with input document and tessdata (Language packs).
    string extractedText = processor.PerformOCR(document, "../../../Tessdata/");
    //Writes the text to the file.
    File.WriteAllText("../../../OCR.txt", extractedText);
}