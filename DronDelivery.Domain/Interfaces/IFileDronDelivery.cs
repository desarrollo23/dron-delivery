using System.Collections.Generic;

namespace DronDelivery.Domain.Interfaces
{
    public interface IFileDronDelivery
    {
        void SetParameters(string path, string fileName);
        string[] ReadFile();

        void WriteFile(string [] result);

        string[] GetFiles();
    }
}
