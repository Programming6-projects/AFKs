using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Mappers;

namespace Pepsi.Tests.Core.Mappers
{
    public class VehicleMapperTests
    {
        private readonly VehicleMapper _mapper;

        public VehicleMapperTests()
        {
            _mapper = new VehicleMapper();
        }

        [Fact]
        public void MapToDtoShouldMapVehicleToVehicleDto()
        {
            var vehicle = new Vehicle { Id = 1, Type = "Truck", Capacity = 1000.5m, IsAvailable = true };

            var vehicleDto = _mapper.MapToDto(vehicle);

            Assert.Equal(vehicle.Id, vehicleDto.Id);
            Assert.Equal(vehicle.Type, vehicleDto.Type);
            Assert.Equal(vehicle.Capacity, vehicleDto.Capacity);
            Assert.Equal(vehicle.IsAvailable, vehicleDto.IsAvailable);
        }

        [Fact]
        public void MapToEntityShouldMapVehicleDtoToVehicle()
        {
            var vehicleDto = new VehicleDto { Id = 1, Type = "Truck", Capacity = 1000.5m, IsAvailable = true };

            var vehicle = _mapper.MapToEntity(vehicleDto);

            Assert.Equal(vehicleDto.Id, vehicle.Id);
            Assert.Equal(vehicleDto.Type, vehicle.Type);
            Assert.Equal(vehicleDto.Capacity, vehicle.Capacity);
            Assert.Equal(vehicleDto.IsAvailable, vehicle.IsAvailable);
        }

        [Fact]
        public void MapToDtoListShouldMapVehicleListToVehicleDtoList()
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle { Id = 1, Type = "Truck", Capacity = 1000.5m, IsAvailable = true },
                new Vehicle { Id = 2, Type = "Van", Capacity = 500.0m, IsAvailable = false }
            };

            var vehicleDtos = _mapper.MapToDtoList(vehicles);

            var enumerable = vehicleDtos as VehicleDto[] ?? vehicleDtos.ToArray();
            Assert.Equal(vehicles.Count, enumerable.Length);
            Assert.Equal(vehicles[0].Id, enumerable.ElementAt(0).Id);
            Assert.Equal(vehicles[1].Id, enumerable.ElementAt(1).Id);
        }

        [Fact]
        public void MapToEntityListShouldMapVehicleDtoListToVehicleList()
        {
            var vehicleDtos = new List<VehicleDto>
            {
                new VehicleDto { Id = 1, Type = "Truck", Capacity = 1000.5m, IsAvailable = true },
                new VehicleDto { Id = 2, Type = "Van", Capacity = 500.0m, IsAvailable = false }
            };

            var vehicles = _mapper.MapToEntityList(vehicleDtos);

            var enumerable = vehicles as Vehicle[] ?? vehicles.ToArray();
            Assert.Equal(vehicleDtos.Count, enumerable.Length);
            Assert.Equal(vehicleDtos[0].Id, enumerable.ElementAt(0).Id);
            Assert.Equal(vehicleDtos[1].Id, enumerable.ElementAt(1).Id);
        }
    }
}
