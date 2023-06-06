using System.ComponentModel.DataAnnotations;

namespace projeto.Models
{
    public class Curso
    {
        public int CursoID { get; set; }
        [Required(ErrorMessage = "O nome do curso é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do curso deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A ementa é obrigatória.")]
        [MaxLength(150, ErrorMessage = "A ementa do curso deve ter no máximo 150 caracteres.")]
        public string Ementa { get; set; }
        public int ProfessorID { get; set; }
        public Professor? Professor { get; set; }
    }
}
