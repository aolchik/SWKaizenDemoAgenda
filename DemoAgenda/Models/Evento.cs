using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;


namespace DemoAgenda.Models
{
    public class Evento
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Você deve informar a data")]
        public string Data { get; set; }
        
        public string Hora { get; set; }
        public string Titulo { get; set; }
        public string Localizacao { get; set; }
        public string Descricao { get; set; }
    }
}