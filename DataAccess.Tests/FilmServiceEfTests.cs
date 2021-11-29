using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using DataAccessEF.Repositories;
using Moq;
using NewWebAPIdotnet6.Models;
using NewWebAPIdotnet6.Services;
using NUnit.Framework;

namespace DataAccess.Tests;

public class FilmServiceEfTests
{
    private IFixture _fixture;
    
    [SetUp]
    public void Setup()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
    }

    [Test]
    public void GetFilms_ShouldCallRepositoryOnce()
    {
        var filmRepositoryMock = _fixture.Freeze<Mock<IFilmRepositoryEf>>();
        
        var sut = _fixture.Create<FilmServiceEf>();
    
        sut.GetFilms();
        
        filmRepositoryMock.Verify(mock => mock.GetFilms(), Times.Once());
    }

    [Test]
    public void GetFilms_ValidateIfListNotUpdated()
    {
        var expectedValues = _fixture.Build<Film>()
            .With(x => x.Description, "Test Description")
            .CreateMany(5)
            .ToList();

        var expectedCount = expectedValues.Count;
        
        var filmRepositoryMock = _fixture.Freeze<Mock<IFilmRepositoryEf>>();

        filmRepositoryMock.Setup(x => x.GetFilms()).Returns(expectedValues);

        var sut = _fixture.Create<FilmServiceEf>();

        var actualValues = sut.GetFilms();

        var actualValuesCount = actualValues.Count;
        
        Assert.AreEqual(expectedCount, actualValuesCount);
    }
    
}