using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;
namespace Entities.Models
{
    public class Topico
    {
        internal object AutorId; 
        public int TopicoId  { get; set; }
        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        public DateAndTime DtaCriacao { get; set; }

        public string AuthorId { get; set; }
    }   
    

}