using CoursesManager.Application.Abstractions;
using CoursesManager.Application.Dtos.Courses;
using CoursesManager.Application.Services;
using CoursesManager.Domain.Entities;
using Moq;
using Xunit;

public class CourseServiceTests
{
    //Testar create, dvs att när jag skapar en kurs så får jag tillbaka samma info som jag skickade in
    [Fact]
    public async Task CreateCourseAsync_Should_Return_Created_Course()
    {
        // Arrange
        var mockRepo = new Mock<ICourseRepository>();

        var dto = new CreateCourseDto
        {
            CourseCode = "TEST101",
            Title = "Test Course",
            Description = "Test Description"
        };

        mockRepo.Setup(repo => repo.AddAsync(It.IsAny<CourseEntity>()))
                .ReturnsAsync((CourseEntity c) => c);

        var service = new CourseService(mockRepo.Object);

        // Act
        var result = await service.CreateCourseAsync(dto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("TEST101", result.CourseCode);
        Assert.Equal("Test Course", result.Title);
        Assert.Equal("Test Description", result.Description);
    }

    // Testar update, dvs att en kurs får nya värden när jag uppdaterar den
    [Fact]
    public async Task UpdateCourseAsync_Should_Update_Values()
    {
        // Arrange
        var mockRepo = new Mock<ICourseRepository>();

        var existingCourse = new CourseEntity
        {
            Id = 1,
            CourseCode = "OLD",
            Title = "Old Title",
            Description = "Old Description"
        };

        var updateDto = new UpdateCourseDto
        {
            CourseCode = "NEW",
            Title = "New Title",
            Description = "New Description"
        };

        mockRepo.Setup(repo => repo.UpdateAsync(1, It.IsAny<CourseEntity>()))
                .ReturnsAsync((int id, CourseEntity c) =>
                {
                    c.Id = id;
                    return c;
                });

        var service = new CourseService(mockRepo.Object);

        // Act
        var result = await service.UpdateCourseAsync(1, updateDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("NEW", result.CourseCode);
        Assert.Equal("New Title", result.Title);
        Assert.Equal("New Description", result.Description);
    }


    // Testar delete, dvs att jag får false om jag försöker ta bort en kurs som inte finns
    [Fact]
    public async Task DeleteCourseAsync_Should_Return_False_When_Not_Found()
    {
        // Arrange
        var mockRepo = new Mock<ICourseRepository>();

        mockRepo.Setup(repo => repo.DeleteAsync(99))
                .ReturnsAsync(false);

        var service = new CourseService(mockRepo.Object);

        // Act
        var result = await service.DeleteCourseAsync(99);

        // Assert
        Assert.False(result);
    }

    // Testar att repository, addasync, anropas när jag skapar en kurs
    [Fact]
    public async Task CreateCourseAsync_Should_Call_Repository_AddAsync_Once()
    {
        // Arrange
        var mockRepo = new Mock<ICourseRepository>();

        var dto = new CreateCourseDto
        {
            CourseCode = "TEST101",
            Title = "Test Course",
            Description = "Test Description"
        };

        mockRepo.Setup(repo => repo.AddAsync(It.IsAny<CourseEntity>()))
                .ReturnsAsync(new CourseEntity());

        var service = new CourseService(mockRepo.Object);

        // Act
        await service.CreateCourseAsync(dto);

        // Assert
        mockRepo.Verify(
            repo => repo.AddAsync(It.IsAny<CourseEntity>()),
            Times.Once);
    }

}





