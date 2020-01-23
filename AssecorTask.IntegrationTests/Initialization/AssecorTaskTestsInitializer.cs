using System.Linq;
using AssecorTask.Domain;
using AssecorTask.Persistance.EF;

namespace AssecorTask.IntegrationTests.Initialization
{
    public class AssecorTaskTestsInitializer
    {
        public static void Initialize(AssecorTaskDbContext context)
        {
            if (context.Colors.Any())
            {
                return;
            }

            context.Colors.AddRange(new ColorEntity
            {
                Color = "blau",
            }, 
            new ColorEntity
            {
                Color = "rot",
            });

            context.SaveChanges();
        }
    }
}
