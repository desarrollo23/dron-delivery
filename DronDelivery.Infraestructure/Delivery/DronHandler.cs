using DronDelivery.Domain.Interfaces;
using DronDelivery.Domain.Model.Delivery;
using DronDelivery.Infraestructure.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DronDelivery.Infraestructure.Delivery
{
    public class DronHandler : IDronHandler
    {
        private IFileDronDelivery _fileDronDelivery;

        public DronHandler(IFileDronDelivery fileDronDelivery)
        {
            _fileDronDelivery = fileDronDelivery;
        }

        public DronHandler() { }

        public async Task Operate()
        {
            var dronesFiles = _fileDronDelivery.GetFiles();
            int dronNumber = 1;

            foreach (var dronFile in dronesFiles)
            {
                var dron = new Dron
                {
                    Id = dronNumber
                };

                _fileDronDelivery.SetParameters(dronFile, dron.FileNameResult);

                try
                {
                    var commands = await _fileDronDelivery.ReadFile();

                    var result = Movements(commands, dron);

                    await _fileDronDelivery.WriteFile(result);

                    dronNumber++;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string[] Movements(string[] commands, Dron dron)
        {
            List<string> result = new List<string>();

            foreach (var command in commands)
            {
                foreach (var letter in command)
                {
                    switch (letter)
                    {
                        case 'A':
                            DirectionEnumHelper.GoAHead(ref dron);
                            break;

                        case 'I':
                            dron.Coordinates.Direction =
                                DirectionEnumHelper.NextDirection(false, dron.Coordinates.Direction);
                            break;

                        case 'D':
                            dron.Coordinates.Direction =
                                DirectionEnumHelper.NextDirection(true, dron.Coordinates.Direction);
                            break;

                        default:
                            break;
                    }

                }
                result.Add(dron.DeliveryResult);
            }

            return result.ToArray();
        }
    }
}
