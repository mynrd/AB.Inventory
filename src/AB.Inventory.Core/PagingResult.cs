namespace AB.Inventory.Core
{
    public class PagingResult<TModel>
    {
        private int _totalCount;
        private int _page;
        private int _pageSize;

        public PagingResult() : this(0, 0, 0, new List<TModel>())
        {
        }

        public PagingResult(int totalCount, int page, int pageSize) : this(totalCount, page, pageSize, new List<TModel>())
        {
        }

        public PagingResult(int totalItems, int index, int limit, List<TModel> items)
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

        public PagingResult<TNewModel> ConvertTo<TNewModel>(Func<TModel, TNewModel> selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            return new PagingResult<TNewModel>()
            {
                Index = Index,
                Items = Items.Select(selector).ToList(),
                Limit = Limit,
                TotalItems = TotalItems,
            };
        }
    }
}