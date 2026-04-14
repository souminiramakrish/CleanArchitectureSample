using Application.Commands;
using Application.DTOs;
using Application.Interfaces;
using NSubstitute;

namespace TestProject_xUnit.Application_Tests.Manufacturer
{
    public class CreateManufacturerCommandTests
    {
        private readonly IUnitOfWork _unitOfWorkMock;
        private readonly CreateManufacturerCommandHandler _handler;
        public CreateManufacturerCommandTests()
        {
            _unitOfWorkMock = Substitute.For<IUnitOfWork>();
            _handler = new CreateManufacturerCommandHandler(_unitOfWorkMock);
        }
        [Fact]
        public void create_manufacturer_should_fail_if_manufacturer_already_exists()
        {
            //Arrange
            var existingManufacturerName = "Existing Manufacturer";
            _unitOfWorkMock.ManufacturerRepository.CheckManufacturerExistsByNameAsync(existingManufacturerName).Returns(true);
            var command = new CreateManufacturerCommand(new ManufacturerDTO(0, existingManufacturerName));

            //Act
            var result = _handler.Handle(command, CancellationToken.None).Result;

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Manufacturer with the same name already exists.", result.Message);
            _unitOfWorkMock.DidNotReceive().SaveChangesAsync(); // Also assert that SaveChangesAsync was not called.
        }
        [Fact]
        public void create_manufacturer_should_succeed_if_manufacturer_does_not_already_exists()
        {
            //Arrange
            var newManufacturerName = "New Manufacturer";
            _unitOfWorkMock.ManufacturerRepository.CheckManufacturerExistsByNameAsync(newManufacturerName).Returns(false);
            var command = new CreateManufacturerCommand(new ManufacturerDTO(0, newManufacturerName));

            //Act
            var result = _handler.Handle(command, CancellationToken.None).Result;

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("Manufacturer created successfully.", result.Message);
            _unitOfWorkMock.ManufacturerRepository.Received(1).Add(Arg.Is<Domain.Entities.Manufacturer>(m => m.Name == newManufacturerName));
            _unitOfWorkMock.Received(1).SaveChangesAsync();
        }
    }
}
