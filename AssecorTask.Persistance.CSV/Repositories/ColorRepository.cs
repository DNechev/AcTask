using AssecorTask.Application.Interfaces;
using AssecorTask.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssecorTask.Persistance.CSV.Repositories
{
    public class ColorRepository : IAsyncRepository<ColorEntity>
    {
        private static string[] Colors = new [] { "blau", "gruen", "violett", "rot", "gelb", "tuerkis", "weiss" };

        public Task<ColorEntity> AddAsync(ColorEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ColorEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ColorEntity>> GetAllAsync()
        {
            var colorEntities = new List<ColorEntity>();

            for (int i = 0; i < Colors.Length; i++)
            {
                var colorEntity = new ColorEntity
                {
                    Id = i + 1,
                    Color = Colors[i]
                };

                colorEntities.Add(colorEntity);
            }

            return Task.FromResult<IEnumerable<ColorEntity>>(colorEntities);
        }

        public async Task<ColorEntity> GetByIdAsync(int id)
        {
            var colors = await GetAllAsync();

            var color = colors.SingleOrDefault(p => p.Id == id);

            return color;
        }

        public Task UpdateAsync(ColorEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
