using Domain.Brands.Parameters;
using Domain.Manufacturers;

namespace Domain.Brands;

public sealed class Brand
{
    private Guid _id = Guid.NewGuid();
    
    private string _title = default!;
    private string _description = default!;

    private Guid _manufacturerId;
    private Manufacturer _manufacturer = default!;

    private DateTimeOffset _updatedAt;
    private DateTimeOffset _createdAt;
    
    private Brand()
    {
    }

    public Brand(CreateBrandParameters parameters) : this()
    {
        SetTitle(new SetBrandTitleParameters
        {
            Title = parameters.Title,
            TimeProvider = parameters.TimeProvider
        });
        
        SetDescription(new SetBrandDescriptionParameters
        {
            Description = parameters.Description,
            TimeProvider = parameters.TimeProvider
        });
        
        SetManufacturer(new SetBrandManufacturerParameters
        {
            Manufacturer = parameters.Manufacturer,
            TimeProvider = parameters.TimeProvider
        });
        
        _createdAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;

    public string Title => _title;

    public void SetTitle(SetBrandTitleParameters parameters)
    {
        _title = parameters.Title.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public string Description => _description;
    
    public void SetDescription(SetBrandDescriptionParameters parameters)
    {
        _description = parameters.Description.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid ManufacturerId => _manufacturerId;
    public Manufacturer Manufacturer => _manufacturer;

    public void SetManufacturer(SetBrandManufacturerParameters parameters)
    {
        _manufacturerId = parameters.Manufacturer.Id;
        _manufacturer = parameters.Manufacturer;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public DateTimeOffset CreatedAt => _createdAt;
    
    public DateTimeOffset UpdatedAt => _updatedAt;
}