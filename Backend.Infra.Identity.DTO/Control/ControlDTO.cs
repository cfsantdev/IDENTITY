namespace Backend.Infra.Identity.DTO.Control
{
    public class ControlDTO
    {
        public Guid? Id { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? PublisherId { get; set; }
        public Guid ControlTypeId { get; set; }
        public Guid BranchId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Transported { get; set; }
        public decimal LitersSpent { get; set; }
        public decimal Cost { get; set; }
        public decimal CostPerCubicMeter { get; set; }
        public decimal CostPerLiter { get; set; }
        public string? Hash { get; set; }
        public string? HashAuth { get; set; }
        public bool State { get; set; }
        public DateTime? Insertion { get; set; }
        public DateTime? Change { get; set; }
    }
}
