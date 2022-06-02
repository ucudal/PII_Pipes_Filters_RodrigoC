using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;


namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider p = new PictureProvider();
            IPicture picture = p.GetPicture(@"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\luke.jpg");

            PipeNull pipeNull = new PipeNull();
            FilterNegative filterNegative = new FilterNegative();
            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeNull);
            FilterGreyscale filterGreyscale = new FilterGreyscale();
            PipeSerial pipeSerialGreyscale = new PipeSerial(filterGreyscale, pipeSerialNegative);

            IPicture finalimage = pipeSerialGreyscale.Send(picture);
            
            PictureProvider finalprovider = new PictureProvider();
            finalprovider.SavePicture(finalimage, @"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\Filteredluke.jpg");
        }
    }
}
