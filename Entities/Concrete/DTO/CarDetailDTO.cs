namespace Entities.Concrete.DTO;

public class CarDetailDto
{
    public Guid CarId { get; set; }

    public string BrandName { get; set; }
    public string ColorName { get; set; }

    public int ModelYear { get; set; }
    public decimal DailyPrice { get; set; }
    public string Description { get; set; }
    
    public override string ToString()
    {
        return $"Id: {CarId,-40} BrandName: {BrandName,-20} ColorName: {ColorName,-10}" +
               $" ModelYear: {ModelYear,-10} DailyPrice: {DailyPrice,-10} Description: {Description,-20}";
    }
}