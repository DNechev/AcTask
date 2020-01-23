using AssecorTask.Domain;
using System.Linq;

namespace AssecorTask.Persistance.EF.Initialization
{
    public class AssecorTaskInitializer
    {
        private static string[] Colors = new[] { "blau", "gruen", "violett", "rot", "gelb", "tuerkis", "weiss" };

        public static void Initialize(AssecorTaskDbContext context)
        {
            if (context.Colors.Any())
            {
                return;
            }

            for (int i = 0; i < Colors.Length; i++)
            {
                var color = new ColorEntity
                {
                    Color = Colors[i]
                };

                context.Colors.Add(color);
            }

            context.SaveChanges();
        }
    }
}
