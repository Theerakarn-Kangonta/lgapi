namespace lgapi.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public int Price { get; set; }
        public int CategoryGroup { get; set; }
        public int MonthSubscription { get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
