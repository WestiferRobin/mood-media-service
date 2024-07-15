using Microsoft.EntityFrameworkCore;
using MoodLibraryApi.Db;
using MoodLibraryApi.Models;

namespace MoodLibraryApi.Repositories
{
    public class StationRepository : IStationRepository
    {
        private readonly PostgresContext context;

        public StationRepository(PostgresContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Station>> GetAll()
        {
            return await context.Stations.ToListAsync();
        }

        public async Task<Station> Get(Guid stationId)
        {
            return await context.Stations.FindAsync();
        }

        public async Task Add(Station station)
        {
            context.Stations.Add(station);
            await context.SaveChangesAsync();
        }

        public async Task Update(Station station)
        {
            context.Stations.Update(station);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Station station)
        {
            context.Stations.Remove(station);
            await context.SaveChangesAsync();
        }

    }
}