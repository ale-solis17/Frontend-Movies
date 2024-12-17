using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Silicon.Models
{
    public class PodcastModel
    {
        public ComentarioModel Comentario { get; set; }

        public PodcastModel()
        {
            Comentario = new ComentarioModel();
        }

        public class ComentarioModel
        {
            public class BlogModel
            {
                public ComentarioModel Comentario { get; set; }

                public BlogModel()
                {
                    Comentario = new ComentarioModel();
                }

                public class ComentarioModel
                {
                    [Key]
                    public int ComentarioId { get; set; }

                    public int MovieId { get; set; }

                    [Required(ErrorMessage = "El comentario no puede estar vacío.")]
                    [StringLength(500, MinimumLength = 5, ErrorMessage = "El comentario debe tener entre 5 y 500 caracteres.")]
                    public string Comment { get; set; }

                    [Required(ErrorMessage = "Debes estar registrado para comentar.")]
                    public int UserId { get; set; }

                    public DateTime PublicationDate { get; set; }

                }
            }
        }
    }
}