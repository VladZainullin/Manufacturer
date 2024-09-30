using Domain.Brands;
using Domain.Brands.Parameters;
using Domain.Manufacturers.Parameters;

namespace Domain.Manufacturers;

public sealed class Manufacturer
{
    private Guid _id = Guid.NewGuid();
    private string _title = default!;
    private string _description = default!;

    private readonly List<Brand> _brands = [];
    
    private DateTimeOffset _updatedAt;
    private DateTimeOffset _createdAt;
    
    private Manufacturer()
    {
    }

    public Manufacturer(CreateManufacturerParameters parameters) : this()
    {
        SetTitle(new SetManufacturerTitleParameters
        {
            Title = parameters.Title,
            TimeProvider = parameters.TimeProvider
        });
        
        SetDescription(new SetManufacturerDescriptionParameters
        {
            Description = parameters.Description,
            TimeProvider = parameters.TimeProvider
        });

        _createdAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;

    public string Title => _title;

    public void SetTitle(SetManufacturerTitleParameters parameters)
    {
        _title = parameters.Title;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public string Description => _description;
    
    public void SetDescription(SetManufacturerDescriptionParameters parameters)
    {
        _description = parameters.Description;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public IReadOnlyCollection<Brand> Brands => _brands.AsReadOnly();

    public void AddBrands(AddManufacturerBrandsParameters parameters)
    {
        var addableBrands = parameters.Brands
            .DistinctBy(static b => b.Title)
            .ExceptBy(_brands.Select(static b => b.Title), static b => b.Title)
            .Select(b => new Brand(new CreateBrandParameters
            {
                Title = b.Title,
                Description = b.Description,
                TimeProvider = parameters.TimeProvider,
                Manufacturer = this
            }))
            .ToArray();
        
        _brands.AddRange(addableBrands);
    }

    public void RemoveBrands(RemoveManufacturerBrandsParameters parameters)
    {
        var removableBrands = _brands
            .Intersect(parameters.Brands)
            .ToArray();
        
        foreach (var measurementUnitPosition in removableBrands)
        {
            _brands.Remove(measurementUnitPosition);
        }

        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public DateTimeOffset CreatedAt => _createdAt;
    
    public DateTimeOffset UpdatedAt => _updatedAt;
}