using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Mappers;
using Xunit;
using System.Collections.Generic;
using System.Linq;

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
        public void MapToDto_ShouldMapVehicleToVehicleDto()
        {
            var vehicle = new Vehicle { Id = 1, Type = "Truck", Capacity = 1000.5m, IsAvailable = true };

            var vehicleDto = _mapper.MapToDto(vehicle);

            Assert.Equal(vehicle.Id, vehicleDto.Id);
            Assert.Equal(vehicle.Type, vehicleDto.Type);
            Assert.Equal(vehicle.Capacity, vehicleDto.Capacity);
            Assert.Equal(vehicle.IsAvailable, vehicleDto.IsAvailable);
        }

        [Fact]
        public void MapToEntity_ShouldMapVehicleDtoToVehicle()
        {
            var vehicleDto = new VehicleDto { Id = 1, Type = "Truck", Capacity = 1000.5m, IsAvailable = true };

            var vehicle = _mapper.MapToEntity(vehicleDto);

            Assert.Equal(vehicleDto.Id, vehicle.Id);
            Assert.Equal(vehicleDto.Type, vehicle.Type);
            Assert.Equal(vehicleDto.Capacity, vehicle.Capacity);
            Assert.Equal(vehicleDto.IsAvailable, vehicle.IsAvailable);
        }

        [Fact]
        public void MapToDtoList_ShouldMapVehicleListToVehicleDtoList()
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle { Id = 1, Type = "Truck", Capacity = 1000.5m, IsAvailable = true },
                new Vehicle { Id = 2, Type = "Van", Capacity = 500.0m, IsAvailable = false }
            };

            var vehicleDtos = _mapper.MapToDtoList(vehicles);

            Assert.Equal(vehicles.Count(), vehicleDtos.Count());
            Assert.Equal(vehicles[0].Id, vehicleDtos.ElementAt(0).Id);
            Assert.Equal(vehicles[1].Id, vehicleDtos.ElementAt(1).Id);
        }

        [Fact]
        public void MapToEntityList_ShouldMapVehicleDtoListToVehicleList()
        {
            var vehicleDtos = new List<VehicleDto>
            {
                new VehicleDto { Id = 1, Type = "Truck", Capacity = 1000.5m, IsAvailable = true },
                new VehicleDto { Id = 2, Type = "Van", Capacity = 500.0m, IsAvailable = false }
            };

            var vehicles = _mapper.MapToEntityList(vehicleDtos);

            Assert.Equal(vehicleDtos.Count(), vehicles.Count());
            Assert.Equal(vehicleDtos[0].Id, vehicles.ElementAt(0).Id);
            Assert.Equal(vehicleDtos[1].Id, vehicles.ElementAt(1).Id);
        }
    }
}
