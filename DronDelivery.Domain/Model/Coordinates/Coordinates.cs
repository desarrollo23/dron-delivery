using DronDelivery.Domain.Enum;

namespace DronDelivery.Domain.Model.Coordinates
{
    public class Coordinates
    {
        public int XAxis { get; set; }

        public int YAxis { get; set; }

        public DirectionEnum Direction { get; set; }

    }
}
