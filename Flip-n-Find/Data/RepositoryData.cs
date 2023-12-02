using Flip_n_Find.Models;
using SQLite;
using System.Diagnostics;

namespace Flip_n_Find.Data
{
    public class RepositoryData
    {
        string _dbPath;
        private SQLiteAsyncConnection _connect;

        public RepositoryData(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task Init()
        {
            if (_connect != null)
            {
                return;
            }

            // data encryption with sqlite-net-sqlcipher (uninstall sqlite-net-pcl first if you have it installed)
            var options = new SQLiteConnectionString(_dbPath, true, "password", postKeyAction: c =>
            {
                c.Execute("PRAGMA cypher_compatibility = 3"); // lets the encryption operating on compatibility version 3 (db3)
            });
            _connect = new SQLiteAsyncConnection(options);

            await _connect.CreateTableAsync<EasyScores>();
            await _connect.CreateTableAsync<MediumScores>();
            await _connect.CreateTableAsync<HardScores>();
        }

        // add scores from each level
        public async Task AddScoreEasy(EasyScores data)
        {
            int result = default;
            try
            {
                await Init();
                result = await _connect.InsertAsync(new EasyScores()
                {
                    TimeTaken = data.TimeTaken,
                    MoveCount = data.MoveCount,
                    DateAchieved = data.DateAchieved,
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex}");
            }
        }

        public async Task AddScoreMedium(MediumScores data)
        {
            int result = default;
            try
            {
                await Init();
                result = await _connect.InsertAsync(new MediumScores()
                {
                    TimeTaken = data.TimeTaken,
                    MoveCount = data.MoveCount,
                    DateAchieved = data.DateAchieved,
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex}");
            }
        }
        public async Task AddScoreHard(HardScores data)
        {
            int result = default;
            try
            {
                await Init();
                result = await _connect.InsertAsync(new HardScores()
                {
                    TimeTaken = data.TimeTaken,
                    MoveCount = data.MoveCount,
                    DateAchieved = data.DateAchieved,
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex}");
            }
        }

        // retrieve the saved scores into lists
        public async Task<List<EasyScores>> GetEasyScoreList()
        {
            try
            {
                await Init();
                var list = await _connect.Table<EasyScores>().ToListAsync();
                return list;
            }
            catch (Exception) { }
            return new List<EasyScores> { };
        }
        public async Task<List<MediumScores>> GetMediumScoreList()
        {
            try
            {
                await Init();
                var list = await _connect.Table<MediumScores>().ToListAsync();
                return list;
            }
            catch (Exception) { }
            return new List<MediumScores> { };
        }
        public async Task<List<HardScores>> GetHardScoreList()
        {
            try
            {
                await Init();
                var list = await _connect.Table<HardScores>().ToListAsync();
                return list;
            }
            catch (Exception) { }
            return new List<HardScores> { };
        }
    }
}
