﻿//using Microsoft.EntityFrameworkCore;
//using Moq;
//using MoodLibrary.Api.Db;
//using MoodLibrary.Api.Models;
//using MoodLibrary.Api.Repositories;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MoodLibrary.UnitTests.Repositories
//{
//    [TestFixture]
//    public class ArtistRepositoryTests
//    {
//        private DbContextOptions<PostgresContext> dbContextOptions;
//        private PostgresContext context;
//        private ArtistRepository repository;

//        [SetUp]
//        public void SetUp()
//        {
//            dbContextOptions = new DbContextOptionsBuilder<PostgresContext>()
//                .UseInMemoryDatabase(databaseName: "MoodLibraryTestDb")
//                .Options;
//            context = new PostgresContext(dbContextOptions);
//            repository = new ArtistRepository(context);
//        }

//        [TearDown]
//        public void TearDown()
//        {
//            context.Database.EnsureDeleted();
//            context.Dispose();
//        }

//        #region GetAllArtists

//        [Test]
//        public async Task GetAllArtists_ReturnsAllArtists()
//        {
//            var artists = new List<Artist>
//            {
//                new Artist { Id = Guid.NewGuid(), Name = "Artist1" },
//                new Artist { Id = Guid.NewGuid(), Name = "Artist2" }
//            };

//            await context.Artists.AddRangeAsync(artists);
//            await context.SaveChangesAsync();

//            var result = await repository.GetAllArtists();

//            Assert.AreEqual(artists.Count, result.Count());
//        }

//        #endregion

//        #region GetArtist

//        [Test]
//        public async Task GetArtist_ReturnsArtist_WhenArtistExists()
//        {
//            var artist = new Artist { Id = Guid.NewGuid(), Name = "Artist1" };

//            await context.Artists.AddAsync(artist);
//            await context.SaveChangesAsync();

//            var result = await repository.GetArtist(artist.Id);

//            Assert.AreEqual(artist.Id, result.Id);
//            Assert.AreEqual(artist.Name, result.Name);
//        }

//        [Test]
//        public async Task GetArtist_ReturnsNull_WhenArtistDoesNotExist()
//        {
//            var artistId = Guid.NewGuid();

//            var result = await repository.GetArtist(artistId);

//            Assert.IsNull(result);
//        }

//        #endregion

//        #region AddArtist

//        [Test]
//        public async Task AddArtist_AddsArtistSuccessfully()
//        {
//            var artist = new Artist { Id = Guid.NewGuid(), Name = "Artist1" };

//            await repository.AddArtist(artist);

//            var result = await context.Artists.FindAsync(artist.Id);

//            Assert.AreEqual(artist.Id, result.Id);
//            Assert.AreEqual(artist.Name, result.Name);
//        }

//        #endregion

//        #region UpdateArtist

//        [Test]
//        public async Task UpdateArtist_UpdatesArtistSuccessfully()
//        {
//            var artist = new Artist { Id = Guid.NewGuid(), Name = "Artist1" };

//            await context.Artists.AddAsync(artist);
//            await context.SaveChangesAsync();

//            artist.Name = "UpdatedArtist";
//            await repository.UpdateArtist(artist);

//            var result = await context.Artists.FindAsync(artist.Id);

//            Assert.AreEqual(artist.Name, result.Name);
//        }

//        #endregion

//        #region DeleteArtist

//        [Test]
//        public async Task DeleteArtist_DeletesArtistSuccessfully()
//        {
//            var artist = new Artist { Id = Guid.NewGuid(), Name = "Artist1" };

//            await context.Artists.AddAsync(artist);
//            await context.SaveChangesAsync();

//            await repository.DeleteArtist(artist);

//            var result = await context.Artists.FindAsync(artist.Id);

//            Assert.IsNull(result);
//        }

//        #endregion
//    }
//}
