using Domain.Manufacturers.Parameters;

namespace Domain.Manufacturers;

public sealed class Manufacturer
{
    private Guid _id = Guid.NewGuid();
    private string _title = default!;
    private string _description = default!;
    
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
}