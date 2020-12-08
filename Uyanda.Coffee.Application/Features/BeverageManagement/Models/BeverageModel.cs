namespace Uyanda.Coffee.Application.Features.BeverageManagement.Models
{
    public class BeverageModel
    {
        public int Id { get; set; }

        public int BeverageTypeId { get; set; }

        public bool IsActive { get; set; }

        public string Name { get; set; }

        public BeverageTypeModel BeverageType { get; set; }
    }
}
