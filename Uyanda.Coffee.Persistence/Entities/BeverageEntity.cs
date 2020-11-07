using Uyanda.Coffee.Application.Features.BeverageManagement.Models;

namespace Uyanda.Coffee.Persistence.Entities
{
    public class BeverageEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public BeverageTypeEntity BeverageTypeEntity { get; set; }
    }
}
