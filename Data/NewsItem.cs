using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediMotion.Data
{
    public class NewsItem
    {
        private static string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam imperdiet iaculis porta. Morbi tortor sem, lobortis sed vulputate vitae, pulvinar at tortor. Vestibulum faucibus consectetur augue, sit amet congue ante commodo vitae. ";
        private static string loremShort = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam imperdiet iaculis porta.";
        private static string imageHome = "http://adx.azureedge.net/Images/Watermark";
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Protocol { get; set; }
        public DateTime Timestamp { get; set; }
        public int Category { get; set; }
        public string HeroImage { get; set; }
        public string DescImage { get; set; }
        public bool IsHero { get; set; } = false;
        public static Random random = new Random();
        public static List<NewsItem> GetData()
        {
            var items = new List<NewsItem>();
           
            var titles = new List<string>()
            {
                "Auscultation", "Palpation", "Biopsy test",
                "Electrocardiography",
                "Electroencephalography",
                "Endoscopy",
                "Laryngoscopy",
                "Ophthalmoscopy",
                "Angiography",
                "Pulmonary angiography",
                "Ventriculography",
                "Chest photofluorography",
                "Computed tomography",
                "Echocardiography",
                "Electrical impedance tomography",
                "Fluoroscopy",
                "Magnetic resonance imaging",
                "Diffuse optical imaging",
                "Diffusion tensor imaging",
                "Cerebral angiography",
                "Coronary angiography",
                "Lymphangiography"};

            for(int i = 0; i < 10; i++)
            {
                items.Add(new NewsItem()
                {
                    Title = titles[i],
                    Category = random.Next(6),
                    HeroImage = string.Format("ms-appx:///Images/Procedures/procedure{0}.png", (i+1)),
                    DescImage = string.Format("ms-appx:///Images/Procedures/procedure{0}{1}.png", (i + 1), (i+1)),
                    Summary= loremShort,
                    Description = lorem,
                    Protocol = GetDescription()
                });
            }
            for (int i = 10; i < titles.Count; i++)
            {
               var imageNumber = random.Next(10);
               items.Add(new NewsItem()
                {
                    Title = titles[i],
                    Category = random.Next(6),
                    HeroImage = string.Format("ms-appx:///Images/Procedures/procedure{0}.png", (imageNumber + 1)),
                    DescImage = string.Format("ms-appx:///Images/Procedures/procedure{0}{1}.png", (imageNumber + 1), (imageNumber + 1)),
                    Description = lorem,
                    Summary = loremShort,
                    Protocol = GetDescription()
               }); 
            }
            return items;
        }
        public static string GetDescription()
        {
            List<string> biographies = new List<string>()
            {
                @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat.",
                @"Maecenas eu sapien ac urna aliquam dictum.",
                @"Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
                @"Quisque accumsan pretium ligula in faucibus. Mauris sollicitudin augue vitae lorem cursus condimentum quis ac mauris. Pellentesque quis turpis non nunc pretium sagittis. Nulla facilisi. Maecenas eu lectus ante. Proin eleifend vel lectus non tincidunt. Fusce condimentum luctus nisi, in elementum ante tincidunt nec.",
                @"Aenean in nisl at elit venenatis blandit ut vitae lectus. Praesent in sollicitudin nunc. Pellentesque justo augue, pretium at sem lacinia, scelerisque semper erat. Ut cursus tortor at metus lacinia dapibus.",
                @"Ut consequat magna luctus justo egestas vehicula. Integer pharetra risus libero, et posuere justo mattis et.",
                @"Proin malesuada, libero vitae aliquam venenatis, diam est faucibus felis, vitae efficitur erat nunc non mauris. Suspendisse at sodales erat.",
                @"Aenean vulputate, turpis non tincidunt ornare, metus est sagittis erat, id lobortis orci odio eget quam. Suspendisse ex purus, lobortis quis suscipit a, volutpat vitae turpis.",
                @"Duis facilisis, quam ut laoreet commodo, elit ex aliquet massa, non varius tellus lectus et nunc. Donec vitae risus ut ante pretium semper. Phasellus consectetur volutpat orci, eu dapibus turpis. Fusce varius sapien eu mattis pharetra.",
                @"Nam vulputate eu erat ornare blandit. Proin eget lacinia erat. Praesent nisl lectus, pretium eget leo et, dapibus dapibus velit. Integer at bibendum mi, et fringilla sem."
            };
            return biographies[random.Next(0, biographies.Count)];
        }
    }
}
