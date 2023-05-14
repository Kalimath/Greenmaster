using eu.mbdevelopment.greenmaster.Domain.Renderable.Botanical;
// ReSharper disable ComplexConditionExpression

namespace eu.mbdevelopment.greenmaster.DataAccess.Botanical.Seeding;

public class BotanicalDataInitialiser
{
        private readonly BotanicalContext _dbContext;
        public BotanicalDataInitialiser(BotanicalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> SeedData()
        {
            //stop if data is present in db...
            if (_dbContext.Species.Any())
            {
                return true;
            }
            await SeedDummyDataAsync();
            return true;
        }
        
        private async Task SeedDummyDataAsync()
        {
            var specie1 = new Specie
            {
                Id = Guid.Parse("BFBA5114-F7C5-4B6A-A715-B5D48C122253"),
                Genus = "Strelitzia",
                Species = "Reginae",
                CommonNames = new[]
                {
                    "Paradise flower",
                    "Paradijsvogelbloem"
                },
                Description = "The plant grows to 2 m (6+1⁄2 ft) tall, with large, strong leaves 25–70 cm (10–28 in) long and 10–30 cm (4–12 in) broad, produced on petioles up to 1 m (40 in) long. " +
                              "The leaves are evergreen and arranged in two ranks, making a fan-shaped crown. The flowers stand above the foliage at the tips of long stalks. " +
                              "The hard, beak-like sheath from which the flower emerges is termed the spathe. This is placed perpendicular to the stem, which gives it the appearance of a bird's head and beak; it makes a durable perch for holding the sunbirds which pollinate the flowers. " +
                              "The flowers, which emerge one at a time from the spathe, consist of three orange sepals and three purplish-blue or white petals. Two of the petals are joined together to form an arrow-like nectary. " +
                              "When the sunbirds sit to drink the nectar, the third petal opens to release the anther and cover their feet in pollen."
            };
                
            await _dbContext.Species.AddRangeAsync(specie1);
            await _dbContext.SaveChangesAsync();

        }
}