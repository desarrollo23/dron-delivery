using DronDelivery.Domain.Interfaces;
using DronDelivery.Domain.Model.Delivery;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace DronDelivery.Infraestructure.Delivery
{
    public class DronHandler : IDronHandler
    {
        private IFileDronDelivery _fileDronDelivery;


        public DronHandler(IFileDronDelivery fileDronDelivery)
        {
            _fileDronDelivery = fileDronDelivery;
        }
        public void Operate()
        {
            // leer desde archivo de config
            var dronesFiles = _fileDronDelivery.GetFiles();
            int dronNumber = 1;

            foreach (var dronFile in dronesFiles)
            {
                var dron = new Dron
                {
                    Id = dronNumber
                };

                _fileDronDelivery.SetParameters(dronFile, dron.FileNameResult);

                var commands = _fileDronDelivery.ReadFile();

                var result = Movements(commands, dron);

                _fileDronDelivery.WriteFile(result);

                dronNumber++;
            }
        }

        private string [] Movements(string[] commands, Dron dron)
        {
            List<string> result = new List<string>();

            foreach (var command in commands)
            {
                foreach (var letter in command)
                {
                    switch (letter)
                    {
                        case 'A':
                            if (dron.Coordinates.Direction == Domain.Enum.DirectionEnum.NORTH)
                                dron.Coordinates.YAxis += 1;

                            else if (dron.Coordinates.Direction == Domain.Enum.DirectionEnum.WEST)
                                dron.Coordinates.XAxis -= 1;

                            else if (dron.Coordinates.Direction == Domain.Enum.DirectionEnum.SOUTH)
                                dron.Coordinates.YAxis -= 1;

                            else if (dron.Coordinates.Direction == Domain.Enum.DirectionEnum.EAST)
                                dron.Coordinates.XAxis += 1;
                            break;

                        case 'I':
                            if (dron.Coordinates.Direction == Domain.Enum.DirectionEnum.NORTH)
                                dron.Coordinates.Direction = Domain.Enum.DirectionEnum.WEST;

                            else if (dron.Coordinates.Direction == Domain.Enum.DirectionEnum.EAST)
                                dron.Coordinates.Direction = Domain.Enum.DirectionEnum.NORTH;

                            else if (dron.Coordinates.Direction == Domain.Enum.DirectionEnum.SOUTH)
                                dron.Coordinates.Direction = Domain.Enum.DirectionEnum.EAST;

                            else if (dron.Coordinates.Direction == Domain.Enum.DirectionEnum.WEST)
                                dron.Coordinates.Direction = Domain.Enum.DirectionEnum.SOUTH;
                            break;

                        case 'D':
                            if (dron.Coordinates.Direction == Domain.Enum.DirectionEnum.NORTH)
                                dron.Coordinates.Direction = Domain.Enum.DirectionEnum.EAST;

                            else if (dron.Coordinates.Direction == Domain.Enum.DirectionEnum.EAST)
                                dron.Coordinates.Direction = Domain.Enum.DirectionEnum.SOUTH;

                            else if (dron.Coordinates.Direction == Domain.Enum.DirectionEnum.SOUTH)
                                dron.Coordinates.Direction = Domain.Enum.DirectionEnum.WEST;

                            else if (dron.Coordinates.Direction == Domain.Enum.DirectionEnum.WEST)
                                dron.Coordinates.Direction = Domain.Enum.DirectionEnum.NORTH;
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
