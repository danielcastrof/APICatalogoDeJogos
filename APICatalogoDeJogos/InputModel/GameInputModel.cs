using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace APICatalogoDeJogos.InputModel
{
    public class GameInputModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome do jogo deve conter entre 3 e 50 caracteres")]
        public string Nome { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome da produtora do jogo deve conter entre 3 e 50 caracteres")]
        public string Produtora { get; set; }
        
        [Required]
        [Range(1, 1000, ErrorMessage = "O preço deve ser no mínimo 1 real e no máximo 1000 reais")]
        public double Preco { get; set; }
    }
}
