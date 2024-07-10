using GuideMeApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideMeApp.Data
{
    public class GuideMeDatabase
    {
        SQLiteAsyncConnection Database;

        public GuideMeDatabase()
        {

        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.CreateTableAsync<Trip>();
            //await Database.CreateTableAsync<User>();
            //await Database.CreateTableAsync<Address>();
            //await Database.CreateTableAsync<Role>();
            //await Database.CreateTableAsync<TripDetail>();
            //await Database.CreateTableAsync<UserSetting>();
        }

        public async Task<List<Trip>> GetTripsAsync()
        {
            await Init();
            return await Database.Table<Trip>().ToListAsync();
        }

        public async Task<Trip> GetTripByIdAsync(int id)
        {
            await Init();
            return await Database.Table<Trip>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> CreateTripAsync(Trip trip)
        {
            await Init();
            if (trip.Id != 0)
                return await Database.UpdateAsync(trip);
            else
                //trip.Guide = new User() { FirstName = "Patrick", LastName = "Egli" };
               
                return await Database.InsertAsync(trip);
        }

        public async Task<int> DeleteItemAsync(Trip item)
        {
            await Init();
            return await Database.UpdateAsync(item);
        }
    }
}
