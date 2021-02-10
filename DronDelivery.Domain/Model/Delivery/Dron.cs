using System;
using System.Collections.Generic;
using System.Text;

namespace DronDelivery.Domain.Model.Delivery
{
    public class Dron
    {
        public Dron()
        {
            Coordinates = new Coordinates.Coordinates
            {
                Direction = Enum.DirectionEnum.NORTH
            };
        }

        public int Id { get; set; }

        public Coordinates.Coordinates Coordinates { get; set; }


        public string DeliveryResult
        {
            get { return $"({Coordinates.XAxis}, {Coordinates.YAxis}) dirección {Coordinates.Direction}"; }
        }

        public string FileNameResult { get { return $"out{Id}.txt"; } }

    }
}
