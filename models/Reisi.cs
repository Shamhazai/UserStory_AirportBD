using System;
namespace UserStory_Airport.models
{
    public class Reisi
    {
        public Guid ID { get; set; }
        public int nomer_reisa { get; set; }
        public Types type { get; set; }
        public DateTime prib_time { get; set; }
        public int passagiers_count { get; set; }
        public double ppassagiers__price { get; set; }
        public int ek_count { get; set; }
        public double ek_price { get; set; }
        public double procent { get; set; }
        public double allmoney { get; set; }
        public string testMigration { get; set; }

    }
}
