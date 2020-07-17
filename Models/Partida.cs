using System;

namespace E_Players_ASPNETCORE.Models
{
    public class Partida
    {
        public int IdPartida { get; set; }
        public int IdEquipe { get; set; }
        public int IdEquipe2 { get; set; }
        public DateTime HorarioInicio { get; set; }
    }
}