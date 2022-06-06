using System;
using System.Drawing;
using System.Threading.Tasks;
using TwitterUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y publica una copia de la misma en Twitter.
    /// </remarks>
    public class FilterTwitter : IFilter
    {   
        
        public string Path {get; set;}
        /// <summary>
        /// Método añadido para poder cambiar el directorio en el que se 
        /// guarda la copia de la imagen y para poder acceder a la misma.
        /// </summary>
        /// <param name="path"></param>
        public void ChangePath(string path)
        {
            this.Path = path;
        }

        /// Un filtro que retorna una copia de la imagen recibida y la publica en twitter
        /// mediante el directorio en la que esta se guardó previamente en un FilterSave.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida en un directorio indicado.</returns>
        public IPicture Filter(IPicture image)
        {
            IPicture result = image.Clone();
            
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("Hello world!", Path));

            return result;
        }
    }
}
