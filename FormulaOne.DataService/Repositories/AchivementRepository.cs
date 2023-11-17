using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories
{
    public class AchivementRepository : GenericRepository<Achivement>, IAchivementsRepository
    {
        public AchivementRepository(AppDbContext context,ILogger logger):base(context, logger) { }

        public async Task<Achivement> GetDriverAchivementAsync(Guid driverId)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);
            }
            catch (Exception e) 
            {
                _logger.LogError(e,"{Repo} GetDriverAchivementAsync function error",typeof(AchivementRepository));
                throw;
            }
        }
        public override async Task<IEnumerable<Achivement>> All()
        {
            try
            {
                return await _dbSet.Where(x => x.status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.AddedTime)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(AchivementRepository));
                throw;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

                if (result == null)
                    return false;

                result.status = 0;
                result.UpdatedTime = DateTime.UtcNow;

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(AchivementRepository));
                throw;
            }

        }
        public override async Task<bool> Update(Achivement achivement)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == achivement.Id);

                if (result == null)
                    return false;

                result.UpdatedTime = DateTime.UtcNow;
                result.FastestLap=achivement.FastestLap;
                result.PolePosition=achivement.PolePosition;
                result.RaceWins=achivement.RaceWins;
                result.WorldChampionShip=achivement.WorldChampionShip;

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(AchivementRepository));
                throw;
            }

        }
    }
}
