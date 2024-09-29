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
    
    private Manufacturer()
    {
    }

    public Manufacturer(CreateManufacturerParameters parameters) : this()
    {
        SetTitle(new SetManufacturerTitleParameters
        {
            Title = parameters.Title
        });
        
        SetDescription(new SetManufacturerDescriptionParameters
        {
            Description = parameters.Description
        });
    }

    public Guid Id => _id;

    public string Title => _title;

    public void SetTitle(SetManufacturerTitleParameters parameters)
    {
        _title = parameters.Title;
    }
    
    public string Description => _description;
    
    public void SetDescription(SetManufacturerDescriptionParameters parameters)
    {
        _description = parameters.Description;
    }

    public IReadOnlyCollection<Brand> Brands => _brands.AsReadOnly();

    public void AddBrands(AddManufacturerBrandsParameters parameters)
    {
        var newBrands = parameters.Brands
            .DistinctBy(static b => b.Title)
            .ExceptBy(_brands.Select(static b => b.Title), static b => b.Title)
            .Select(b => new Brand(new CreateBrandParameters
            {
                Title = b.Title,
                Description = b.Description,
                Manufacturer = this
            }))
            .ToArray();
        
        _brands.AddRange(newBrands);
    }
}