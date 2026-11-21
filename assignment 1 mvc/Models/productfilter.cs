namespace assignment_1_mvc.Models
{
    public class productfilter
    {
        public string? term { get; set; }

        public double? minprice { get; set; }

        public int page { get; set; } = 1;
    }
}
