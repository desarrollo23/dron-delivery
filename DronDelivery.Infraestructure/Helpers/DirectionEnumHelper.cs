using DronDelivery.Domain.Enum;
using DronDelivery.Domain.Model.Delivery;

namespace DronDelivery.Infraestructure.Helpers
{
    public static class DirectionEnumHelper
    {
        public static DirectionEnum NextDirection(bool isRight, DirectionEnum direction)
        {
            if(isRight)
            {
                if (direction == DirectionEnum.NORTH)
                    return DirectionEnum.EAST;

                if (direction == DirectionEnum.EAST)
                    return DirectionEnum.SOUTH;

                if (direction == DirectionEnum.SOUTH)
                    return DirectionEnum.WEST;

                if (direction == DirectionEnum.WEST)
                    return DirectionEnum.NORTH;
            }
            else
            {
                if (direction == DirectionEnum.NORTH)
                    return DirectionEnum.WEST;

                if (direction == DirectionEnum.WEST)
                    return DirectionEnum.SOUTH;

                if (direction == DirectionEnum.SOUTH)
                    return DirectionEnum.EAST;

                if (direction == DirectionEnum.EAST)
                    return DirectionEnum.NORTH;
            }

            return DirectionEnum.UNDEFINED;
        }

        public static void GoAHead(ref Dron dron)
        {
            if (dron.Coordinates.Direction == DirectionEnum.NORTH)
                dron.Coordinates.YAxis++;

            else if (dron.Coordinates.Direction == DirectionEnum.WEST)
                dron.Coordinates.XAxis--;

            else if (dron.Coordinates.Direction == DirectionEnum.SOUTH)
                dron.Coordinates.YAxis--;

            else if (dron.Coordinates.Direction == DirectionEnum.EAST)
                dron.Coordinates.XAxis++;
        }
    }
}
