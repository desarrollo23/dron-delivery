using DronDelivery.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace DronDelivery.Infraestructure.Delivery
{
    public class FileDronDelivery : IFileDronDelivery
    {
        private readonly IConfiguration _configuration;
        private string _pathRead = string.Empty;
        private string _pathResult = string.Empty;
        private string _fileName = string.Empty;

        public FileDronDelivery(IConfiguration configuration)
        {
            _configuration = configuration;
            _pathRead = _configuration.GetSection("pathDeliveries").Value;
            _pathResult = _configuration.GetSection("pathResult").Value;
        }

        public void SetParameters(string pathRead, string fileName)
        {
            _pathRead = pathRead;
            _fileName = fileName;
        }

        public string[] ReadFile()
        {
            return File.ReadAllLines(_pathRead);
        }

        public void WriteFile(string [] result)
        {
            File.WriteAllLines($"{_pathResult}\\{_fileName}", result);
        }

        public string[] GetFiles()
        {
            return Directory.GetFiles(_pathRead);
        }
    }
}
