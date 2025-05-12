using LearningAPIWeb.Models;
using LearningAPIWeb.Models.DTO;

namespace LearningAPIWeb.Data
{
    public class DachaStore
    {
        public static List<DachaDTO> dachaList = new List<DachaDTO>
        {
            new DachaDTO { Id = 1, Name = "Katta Dacha"},
            new DachaDTO { Id = 2, Name = "Kichkina dacha" }
        };
    }
}
