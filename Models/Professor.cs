using System.ComponentModel.DataAnnotations;

namespace projeto.Models
{
    public class Professor
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "O nome do professor é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do professor deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O cpf do professor é obrigatório.")]
        [MaxLength(11, ErrorMessage = "O cpf do professor deve ter no máximo 11 caracteres (apenas dígitos).")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O logradouro é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O logradouro deve ter no máximo 150 caracteres.")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Número é obrigatório.")]
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        [Required(ErrorMessage = "Bairro é obrigatório.")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Cidade é obrigatório.")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "UF é obrigatória.")]
        [MaxLength(2, ErrorMessage = "A UF deve ter no máximo 2 caracteres.")]
        public string UF { get; set; }
        [Required(ErrorMessage = "País é obrigatório.")]
        public string Pais { get; set; }

        //Navigation property: guarda que entidades estao ligadas a esta entidade. No caso, que cursos estao ligados a este professor
        //Podem ser declaradas como virtual para utilizar de recursos como Lazy Loading
        public virtual ICollection<Curso>? Cursos { get; set; }
    }
}
