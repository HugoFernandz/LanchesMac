using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Nome")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O tamanho minimo é 10 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição deve ser informada")]
        [Display(Name = "Descrição curta")]
        [MinLength(10, ErrorMessage = "Tamanho minimo para descrição é de 10 caracter")]
        [MaxLength(100, ErrorMessage = "Tamanho maximo para descrição é de 100 caracter")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "A descrição deve ser informada")]
        [Display(Name = "Descrição")]
        [MinLength(20, ErrorMessage = "Tamanho minimo para descrição é de 20 caracter")]
        [MaxLength(200, ErrorMessage = "Tamanho maximo para descrição é de 200 caracter")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "O preço deve ser informado")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,999.99, ErrorMessage = "Tamanho minimo de 1.00 e máximo de 999.99 reais")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho Imagem")]
        [StringLength(200, ErrorMessage = "O tamanho maximo é de 200 caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem miniatura")]
        [StringLength(200, ErrorMessage = "O tamanho maximo é de 200 caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        public int CategoriaId {  get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
