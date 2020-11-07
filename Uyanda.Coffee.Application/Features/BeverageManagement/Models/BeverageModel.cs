namespace Uyanda.Coffee.Application.Features.BeverageManagement.Models
{
    public class BeverageModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public BeverageTypeModel BeverageTypeEntity { get; set; }

    }
}
