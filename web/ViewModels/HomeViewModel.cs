using Core.Entities;

namespace web.ViewModels
{
    public class HomeViewModel {
        public Owner Owner { get; set; }
        public List<PortfolioItem> PortfolioItems { get; set; }

    }
}
