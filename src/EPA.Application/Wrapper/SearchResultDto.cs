namespace AB.Inventory.Application.Wrapper
{
    public class SearchResultDto<TModel>
    {
        public SearchResultDto() : this(0, 0, 0, new List<TModel>())
        {
        }

        public SearchResultDto(int totalItems, int index, int limit, List<TModel> items)
        {
            TotalItems = totalItems;
            Index = index;
            Limit = limit;
            Items = items;
        }

        public int TotalItems { get; set; }
        public int Index { get; set; }
        public int Limit { get; set; }

        public int TotalPage
        {
            get
            {
                return int.Parse(Math.Ceiling(TotalItems / (decimal)Limit).ToString());
            }
        }

        public List<TModel> Items { get; set; }
        public Guid? SessionKey { get; set; }

        public SearchResultDto<TNewModel> ConvertTo<TNewModel>(Func<TModel, TNewModel> selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            return new SearchResultDto<TNewModel>()
            {
                Index = Index,
                Items = Items.Select(selector).ToList(),
                Limit = Limit,
                TotalItems = TotalItems,
            };
        }
    }
}