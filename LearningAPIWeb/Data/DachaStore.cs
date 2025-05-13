using LearningAPIWeb.Models;
using LearningAPIWeb.Models.DTO;

namespace LearningAPIWeb.Data
{
    public class DachaStore
    {
        public static List<DachaDTO> dachaList = new List<DachaDTO>
        {
            new DachaDTO { Id = 1, Name = "Katta Dacha", Price = 10, Area = 100},
            new DachaDTO { Id = 2, Name = "Kichkina dacha", Price = 20, Area = 200}
        };
    }
}
