namespace AccountingApplication.Domain.Entities
{
    public class UniformChartOfAccount : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public char Type { get; set; } //ana grup, grup, muavin
    }
}
