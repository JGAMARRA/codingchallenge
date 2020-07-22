using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IEngineSearch
    {
        string Name { get; }
        
        Task<long> GetTotalResults(string query);
    }
}
