using System.Threading.Tasks;
using template.Data.Models;

namespace template.Interface
{
    public interface LogInterface
    {
        Task save(LogModel data);
        Task LogPut(object oldData, object newData);
        Task LogPost(object oldData);
        Task LogDelete(object oldData);
        
    }
}