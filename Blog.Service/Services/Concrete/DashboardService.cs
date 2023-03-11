using Blog.Data.UnitOfWork;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;

namespace Blog.Service.Services.Concrete
{
    public class DashboardService: IDashboardService
    {
        private readonly IUnitOfWorked _unitOfWorked;
       

        public DashboardService(IUnitOfWorked unitOfWorked)
        {
            this._unitOfWorked = unitOfWorked;            
        }
        public async Task<List<int>> GetYearlyArticleCounts()
        {
            var articles = await _unitOfWorked.GetRepository<Article>().GetAllAsync(x => x.IsDeleted);

            var startDate = DateTime.Now.Date;
            startDate = new DateTime(startDate.Year, 1, 1);

            List<int> datas = new();

            for (int i = 1; i <= 12; i++)
            {
                var startedDate = new DateTime(startDate.Year, i, 1);
                var endedDate = startedDate.AddMonths(1);
                var data = articles.Where(x => x.CreatedDate >= startedDate && x.CreatedDate < endedDate).Count();
                datas.Add(data);
            }

            return datas;
        }
        public async Task<int> GetTotalArticleCount()
        {
            var articleCount = await _unitOfWorked.GetRepository<Article>().CountAsync();
            return articleCount;
        }
        public async Task<int> GetTotalCategoryCount()
        {
            var categoryCount = await _unitOfWorked.GetRepository<Category>().CountAsync();
            return categoryCount;
        }

    }
}
