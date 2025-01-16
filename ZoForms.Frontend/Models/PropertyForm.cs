namespace ZoForms.Frontend.Models
{
    public class PropertyForm
    {
        public int PrimaryKey { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }
        public string Manufacturer { get; set; }
        public string Location { get; set; }
        public DateOnly DateAcquired { get; set; }
        public decimal Cost { get; set; }
        public decimal CurrentValue { get; set; }
        
    }
}


