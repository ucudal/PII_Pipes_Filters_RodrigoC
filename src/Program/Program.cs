using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;


namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {   
            //Ejercicio 1

            PictureProvider p = new PictureProvider();
            IPicture picture = p.GetPicture(@"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\beer.jpg");

            PipeNull pipeNull = new PipeNull();
            FilterNegative filterNegative = new FilterNegative();
            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeNull);
            FilterGreyscale filterGreyscale = new FilterGreyscale();
            PipeSerial pipeSerialGreyscale = new PipeSerial(filterGreyscale, pipeSerialNegative);

            IPicture finalimage = pipeSerialGreyscale.Send(picture);
            
            PictureProvider finalprovider = new PictureProvider();
            finalprovider.SavePicture(finalimage, @"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\Filteredbeer.jpg");
            
            //Ejercicio 2

            PictureProvider p2 = new PictureProvider();
            IPicture picture2 = p.GetPicture(@"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\luke.jpg");

            PipeNull pipeNull2 = new PipeNull();
            FilterSave filterSaveNegative2 = new FilterSave();
            PipeSerial pipeSerialNegativeSave2 = new PipeSerial(filterSaveNegative2, pipeNull2);
            FilterNegative filterNegative2 = new FilterNegative();
            PipeSerial pipeSerialNegative2 = new PipeSerial(filterNegative2, pipeSerialNegativeSave2);
            FilterSave filterSaveGreyscale2 = new FilterSave();
            PipeSerial pipeSerialGreyscaleSave2 = new PipeSerial(filterSaveGreyscale2, pipeSerialNegative2);
            FilterGreyscale filterGreyscale2 = new FilterGreyscale();
            PipeSerial pipeSerialGreyscale2 = new PipeSerial(filterGreyscale2, pipeSerialGreyscaleSave2);
            
            filterSaveGreyscale2.ChangePath(@"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\GreyscaleLuke.jpg");
            filterSaveNegative2.ChangePath(@"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\NegativeLuke.jpg");

            IPicture finalimage2 = pipeSerialGreyscale2.Send(picture2);
            
            PictureProvider finalprovider2 = new PictureProvider();
            finalprovider2.SavePicture(finalimage2, @"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\Filteredluke.jpg");

            //Ejercicio 3

            PictureProvider p3 = new PictureProvider();
            IPicture picture3 = p.GetPicture(@"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\luke.jpg");

            PipeNull pipeNull3 = new PipeNull();
            FilterTwitter filterTwitterNegative3 = new FilterTwitter();
            PipeSerial pipeSerialNegativeTwitter3 = new PipeSerial(filterTwitterNegative3, pipeNull3);
            FilterSave filterSaveNegative3 = new FilterSave();
            PipeSerial pipeSerialNegativeSave3 = new PipeSerial(filterSaveNegative3, pipeSerialNegativeTwitter3);
            FilterNegative filterNegative3 = new FilterNegative();
            PipeSerial pipeSerialNegative3 = new PipeSerial(filterNegative3, pipeSerialNegativeSave3);
            FilterTwitter filterTwitterGreyscale3 = new FilterTwitter();
            PipeSerial pipeSerialGreyscaleTwitter3 = new PipeSerial(filterTwitterGreyscale3, pipeSerialNegative3 );
            FilterSave filterSaveGreyscale3 = new FilterSave();
            PipeSerial pipeSerialGreyscaleSave3 = new PipeSerial(filterSaveGreyscale3, pipeSerialGreyscaleTwitter3);
            FilterGreyscale filterGreyscale3 = new FilterGreyscale();
            PipeSerial pipeSerialGreyscale3 = new PipeSerial(filterGreyscale3, pipeSerialGreyscaleSave3);
            
             

            filterSaveGreyscale3.ChangePath(@"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\GreyscaleLuke.jpg");
            filterSaveNegative3.ChangePath(@"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\NegativeLuke.jpg");
            filterTwitterGreyscale3.ChangePath(@"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\GreyscaleLuke.jpg");
            filterTwitterNegative3.ChangePath(@"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\NegativeLuke.jpg");
            

            IPicture finalimage3 = pipeSerialGreyscale3.Send(picture3);
            
            PictureProvider finalprovider3 = new PictureProvider();
            finalprovider3.SavePicture(finalimage3, @"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\Filteredluke.jpg");            

            //Ejercicio 4 Como la imagen utilizada es beer al correr el programa retorna "No face Found"
            // y continua por PipeSerialNegative4.
            
            PictureProvider p4 = new PictureProvider();
            IPicture picture4 = p.GetPicture(@"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\beer.jpg");

            PipeNull pipeNull4 = new PipeNull();
            FilterSave filterSaveNegative4 = new FilterSave();
            PipeSerial pipeSerialNegativeSave4 = new PipeSerial(filterSaveNegative4, pipeNull4);
            FilterNegative filterNegative4 = new FilterNegative();
            PipeSerial pipeSerialNegative4 = new PipeSerial(filterNegative4, pipeSerialNegativeSave4);
            FilterTwitter filterTwitterGreyscale4 = new FilterTwitter();
            PipeSerial pipeSerialGreyscaleTwitter4 = new PipeSerial(filterTwitterGreyscale4, pipeNull4);
            FilterConditional filterConditional = new FilterConditional();
            PipeConditionalFork pipeConditionalFork = new PipeConditionalFork(filterConditional, pipeSerialGreyscaleTwitter4, pipeSerialNegative4);
            FilterSave filterSaveGreyscale4 = new FilterSave();
            PipeSerial pipeSerialGreyscaleSave4 = new PipeSerial(filterSaveGreyscale4, pipeConditionalFork);
            FilterGreyscale filterGreyscale4 = new FilterGreyscale();
            PipeSerial pipeSerialGreyscale4 = new PipeSerial(filterGreyscale4, pipeSerialGreyscaleSave4);
            
             

            filterSaveGreyscale4.ChangePath(@"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\Greyscalebeer.jpg");
            filterSaveNegative4.ChangePath(@"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\Negativebeer.jpg");
            filterConditional.ChangePath(@"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\Greyscalebeer.jpg");
            filterTwitterGreyscale4.ChangePath(@"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\Greyscalebeer.jpg");


            IPicture finalimage4 = pipeSerialGreyscale4.Send(picture4);
            
            PictureProvider finalprovider4 = new PictureProvider();
            finalprovider4.SavePicture(finalimage4, @"C:\Users\FIT\Desktop\Git2\libros\PII_Pipes_Filters_RodrigoC\src\Program\Filteredbeer.jpg");
        }
    }
}
