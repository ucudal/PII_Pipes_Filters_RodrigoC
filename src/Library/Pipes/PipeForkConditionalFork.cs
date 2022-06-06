using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CompAndDel.Filters;


namespace CompAndDel.Pipes
{
    public class PipeConditionalFork : IPipe
    {
        public FilterConditional filtrocondicional;
        IPipe IsTruePipe;
        IPipe IsFalsePipe;
        
        /// <summary>
        /// La cañería recibe una imagen, la clona y envìa la original por una cañeria y la clonada por otra.
        /// </summary>
        /// <param name="tipoFiltro">Tipo de filtro que se debe aplicar sobre la imagen. Se crea un nuevo filtro con los parametros por defecto</param>
        /// <param name="nextPipe">Siguiente cañeria con filtro</param>
        /// <param name="next2Pipe">Siguiente cañeria sin filtro</param>
        public PipeConditionalFork(FilterConditional filtrocondicional, IPipe IsTruePipe, IPipe IsFalsePipe) 
        {
            this.filtrocondicional = filtrocondicional;
            this.IsTruePipe = IsTruePipe;
            this.IsFalsePipe = IsFalsePipe;           
        }
        
        /// <summary>
        /// La cañería recibe una imagen, comprueba que la misma tenga o no una cara
        /// mediante el FilterConditional y en caso de tener una cara envia la imagen por una
        /// cañeria y en caso de no tenerla la envia por otra.
        /// </summary>
        /// <param name="picture">imagen a filtrar y enviar a las siguientes cañerías</param>
        public IPicture Send(IPicture picture)
        {
            picture = this.filtrocondicional.Filter(picture);
            if (filtrocondicional.IsTrueFace == true)
            {
                return this.IsTruePipe.Send(picture);
            }
            else
            {
                return this.IsFalsePipe.Send(picture);
            }
        }
    }
}
