namespace Backend.Infra.Identity.Control
{
    public class CreateControl
    {
        public Guid ControlTypeId { get; set; }
        public Guid BranchId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Transported { get; set; }
        public decimal LitersSpent { get; set; }
        public decimal Cost { get; set; }
        public decimal CostPerCubicMeter { get; set; }
        public decimal CostPerLiter { get; set; }
    }
}
