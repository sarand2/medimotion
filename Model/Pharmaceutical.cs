using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediMotion.Model
{
    public class Pharmaceutical
    {
        private static Random random = new Random();
        public string Name { get; set; }
        public string Category { get; set; }

        public string Color { get; set; }
        public static ObservableCollection<Pharmaceutical> getPharmaceuticals(int numberOfPharmaceuticals)
        {
            ObservableCollection<Pharmaceutical> pharmaceuticals = new ObservableCollection<Pharmaceutical>();

            for (int i = 0; i < numberOfPharmaceuticals; i++)
            {
                pharmaceuticals.Add(GetNewPharmaceutical());
            }
            return pharmaceuticals;
        }
        public static ObservableCollection<GroupInfoList> GetPharmaceuticalsGrouped(int numberOfContacts)
        {
            ObservableCollection<GroupInfoList> groups = new ObservableCollection<GroupInfoList>();

            var query = from item in getPharmaceuticals(numberOfContacts)
                        group item by item.Name.Substring(0, 1).ToUpper() into g
                        orderby g.Key
                        select new { GroupName = g.Key, Items = g };

            foreach (var g in query)
            {
                GroupInfoList info = new GroupInfoList();
                info.Key = g.GroupName;
                foreach (var item in g.Items)
                {
                    info.Add(item);
                }
                groups.Add(info);
            }

            return groups;
        }

        private static string GenerateName()
        {
            List<string> names = new List<string>() { "Amiodarone","Advil","Aspirin","Azathioprine","Bacitracin","Baclofen","Belbuca","Benazepril","Budenoside","Botox","Claritin","Codeine","Clindamycin","Celexa","Coreg","Debrox","Docusaete","Dulera","Enbrel","Entecavir","Euflexxa","Evista","Fish Oil", "Femara", "Fluzone", "Fluoxetine", "Macrobid", "Meloxicam","Meclizine","MiraLAX","Runexa","Relafen","Rituxan","Risperdal", "Ritalin" };
            return names[random.Next(0, names.Count)];
        }

        private static string GenerateCategory()
        {
            List<string> categories = new List<string>() { "Antipyretics","Analgesics","Antimalarial drugs","Antibiotics","Antiseptics","Mood stabilizers","Hormone replacements","Oral contraceptives", "Stimulants", "Tranquilizers", "Statins"};
            return categories[random.Next(0, categories.Count)];
        }
        public static Pharmaceutical GetNewPharmaceutical()
        {

            string name = GenerateName();
            string category = GenerateCategory();
            string color = "LightGray";
            switch (category)
            {
                case "Antipyretics":
                    color = "LightGray";
                    break;
                case "Analgesics":
                    color = "Aquamarine";
                    break;
                case "Antimalarial drugs":
                    color = "Chartreuse";
                    break;
                case "Antibiotics":
                    color = "Crimson";
                    break;
                case "Mood stabilizers":
                    color = "DarkOrchid";
                    break;
                case "Hormone replacements":
                    color = "PaleVioletRed";
                    break;
                case "Oral contraceptives":
                    color = "Yellow";
                    break;
                case "Stimulants":
                    color = "Pink";
                    break;
                case "Tranquilizers":
                    color = "Goldenrod";
                    break;
                case "Statins":
                    color = "LightSeaGreen";
                    break;    
            }
            return new Pharmaceutical()
            {
                Name = name,
                Category = category,
                Color = color
            };
        }
    }
}
