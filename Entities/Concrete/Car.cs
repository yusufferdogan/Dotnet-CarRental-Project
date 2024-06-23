using Core.Entities;

namespace Entities.Concrete;

public class Car : IEntity
{
    public Guid CarId { get; set; }
    public Guid BrandId { get; set; }
    public Guid ColorId { get; set; }
    
    public int ModelYear { get; set; }
    public decimal DailyPrice { get; set; }
    public string Description { get; set; }
    
    // Default constructor
    public Car()
    {
        CarId = Guid.NewGuid();
    }

    // Parameterized constructor
    public Car(Guid brandId, Guid colorId, int modelYear, decimal dailyPrice, string description)
    {
        CarId = Guid.NewGuid();
        BrandId = brandId;
        ColorId = colorId;
        ModelYear = modelYear;
        DailyPrice = dailyPrice;
        Description = description;
    }
    
    public override string ToString()
    {
        return $"Id: {CarId,-10} BrandId: {BrandId,-10} ColorId: {ColorId,-10} ModelYear: {ModelYear,-10} DailyPrice: {DailyPrice,-10} Description: {Description,-20}";
    }
}