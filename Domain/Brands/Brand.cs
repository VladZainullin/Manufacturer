using Domain.Brands.Parameters;

namespace Domain.Brands;

public sealed class Brand
{
    private Guid _id = Guid.NewGuid();
    
    private string _title = default!;
    private string _description = default!;
    
    private Brand()
    {
    }

    public Brand(CreateBrandParameters parameters) : this()
    {
        SetTitle(new SetBrandTitleParameters
        {
            Title = parameters.Title
        });
        
        SetDescription(new SetBrandDescriptionParameters
        {
            Description = parameters.Description
        });
    }

    public Guid Id => _id;

    public string Title => _title;

    public void SetTitle(SetBrandTitleParameters parameters)
    {
        _title = parameters.Title.Trim();
    }
    
    public string Description => _description;
    
    public void SetDescription(SetBrandDescriptionParameters parameters)
    {
        _description = parameters.Description.Trim();
    }
}