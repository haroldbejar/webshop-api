using Domain.Models;

namespace Domain.Builder
{
    public class CategoryBuilder : BaseBuilder<Category>
    {
        public CategoryBuilder WithCategoryId(int categoryId) { _entity.CategoryId = categoryId; return this; }
        public CategoryBuilder WithName(string name) { _entity.Name = name; return this; }
    }
}
