using DronDelivery.Domain.Model.Delivery;
using System.Threading.Tasks;

namespace DronDelivery.Domain.Interfaces
{
    public interface IDronHandler
    {
        Task Operate();
    }
}
