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
    
    //Perform OCR with input document and tessdata (Language packs).
    processor.PerformOCR(document, "../../../Tessdata/");
    
    //Create file stream.
    using (FileStream outputFileStream = new FileStream("../../../Output.pdf", FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        document.Save(outputFileStream);
    }
    //Close the document.
    document.Close(true);
}
