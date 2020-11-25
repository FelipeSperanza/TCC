using System.Collections.Generic;

namespace CheckPat.Models.ViewModels
{
    public class PatrimonioViewModel
    {
        public Patrimonio Patrimonio { get; set; }
        public ICollection<Local> Locais { get; set; }
        public ICollection<Equipamento> Equipamentos { get; set; }
    }
}
