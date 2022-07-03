using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IDataAccessLayer
    {
        Task<OneMonth[]> GetPriceTrends(string tickerSymbol);
    }
}