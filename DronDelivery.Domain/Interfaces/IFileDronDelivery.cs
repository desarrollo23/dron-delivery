using System.Collections.Generic;
using System.Threading.Tasks;

namespace DronDelivery.Domain.Interfaces
{
    public interface IFileDronDelivery
    {
        void SetParameters(string path, string fileName);

        void SetParameters(string pathRead);
        Task<string[]> ReadFile();

        Task WriteFile(string [] result);

        string[] GetFiles();
    }
}
