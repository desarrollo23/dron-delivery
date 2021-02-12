using DronDelivery.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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

        public FileDronDelivery()
        {

        }

        public void SetParameters(string pathRead, string fileName)
        {
            _pathRead = pathRead;
            _fileName = fileName;
        }

        public void SetParameters(string pathRead)
        {
            _pathRead = pathRead;
        }

        public async Task<string[]> ReadFile()
        {
            try
            {
                return await File.ReadAllLinesAsync(_pathRead);
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task WriteFile(string [] result)
        {
            try
            {
                await File.WriteAllLinesAsync($"{_pathResult}\\{_fileName}", result);

            }
            catch (DirectoryNotFoundException ex)
            {
                throw ex;
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string[] GetFiles()
        {
            try
            {
                return Directory.GetFiles(_pathRead);
            }
            catch(DirectoryNotFoundException ex)
            {
                throw ex;
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
