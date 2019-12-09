using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediMotion.Model
{
   public class ActivePatient : IComparable<ActivePatient>
    {
        private static Random random = new Random();

        public string Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Method { get; set; }
        public string Category { get; set; }
        public static ObservableCollection<ActivePatient> getActivePatients(int numberOfActivePatients)
        {
            ObservableCollection<ActivePatient> activePatients = new ObservableCollection<ActivePatient>();

            for (int i = 0; i < numberOfActivePatients; i++)
            {
                activePatients.Add(GetNewActivePatient());
            }
            return activePatients;
        }
        public static ObservableCollection<GroupInfoList> GetActivePatientsGrouped(int numberOfActivePatients)
        {
            ObservableCollection<GroupInfoList> groups = new ObservableCollection<GroupInfoList>();

            var query = from item in getActivePatients(numberOfActivePatients)
                        group item by item.Date into g
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
        public static ActivePatient GetNewActivePatient()
        {
            return new ActivePatient()
            {
                FirstName = GenerateFirstName(),
                LastName = GenerateLastName(),
                Method = GenerateMethod(),
                Category = GenerateCategory(),
                Date = GenerateDate()
            };
        }
        private static string GenerateFirstName()
        {
            List<string> names = new List<string>() { "Lilly", "Mukhtar", "Sophie", "Femke", "Abdul-Rafi'", "Chirag-ud-D...", "Mariana", "Aarif", "Sara", "Ibadah", "Fakhr", "Ilene", "Sardar", "Hanna", "Julie", "Iain", "Natalia", "Henrik", "Rasa", "Quentin", "Gadi", "Pernille", "Ishtar", "Jimme", "Justina", "Lale", "Elize", "Rand", "Roshanara", "Rajab", "Bijou", "Marcus", "Marcus", "Alima", "Francisco", "Thaqib", "Andreas", "Mariana", "Amalie", "Rodney", "Dena", "Fadl", "Ammar", "Anna", "Nasreen", "Reem", "Tomas", "Filipa", "Frank", "Bari'ah", "Parvaiz", "Jibran", "Tomas", "Elli", "Carlos", "Diego", "Henrik", "Aruna", "Vahid", "Eliana", "Roxane", "Amanda", "Ingrid", "Wander", "Malika", "Basim", "Eisa", "Alina", "Andreas", "Deeba", "Diya", "Parveen", "Bakr", "Celine", "Bakr", "Marcus", "Daniel", "Mathea", "Edmee", "Hedda", "Maria", "Maja", "Alhasan", "Alina", "Hedda", "Victor", "Aaftab", "Guilherme", "Maria", "Kai", "Sabien", "Abdel", "Fadl", "Bahaar", "Vasco", "Jibran", "Parsa", "Catalina", "Fouad", "Colette" };
            return names[random.Next(0, names.Count)];
        }
        private static string GenerateLastName()
        {
            List<string> lastnames = new List<string>() { "Carlson", "Attia", "Quint", "Hollenberg", "Khoury", "Araujo", "Hakimi", "Seegers", "Abadi", "al", "Krommenhoek", "Siavashi", "Kvistad", "Sjo", "Vanderslik", "Fernandes", "Dehli", "Sheibani", "Laamers", "Batlouni", "Lyngvær", "Oveisi", "Veenhuizen", "Gardenier", "Siavashi", "Mutlu", "Karzai", "Mousavi", "Natsheh", "Seegers", "Nevland", "Lægreid", "Bishara", "Cunha", "Hotaki", "Kyvik", "Cardoso", "Pilskog", "Pennekamp", "Nuijten", "Bettar", "Borsboom", "Skistad", "Asef", "Sayegh", "Sousa", "Medeiros", "Kregel", "Shamoun", "Behzadi", "Kuzbari", "Ferreira", "Van", "Barros", "Fernandes", "Formo", "Nolet", "Shahrestaani", "Correla", "Amiri", "Sousa", "Fretheim", "Van", "Hamade", "Baba", "Mustafa", "Bishara", "Formo", "Hemmati", "Nader", "Hatami", "Natsheh", "Langen", "Maloof", "Berger", "Ostrem", "Bardsen", "Kramer", "Bekken", "Salcedo", "Holter", "Nader", "Bettar", "Georgsen", "Cunha", "Zardooz", "Araujo", "Batalha", "Antunes", "Vanderhoorn", "Nader", "Abadi", "Siavashi", "Montes", "Sherzai", "Vanderschans", "Neves", "Sarraf", "Kuiters" };
            return lastnames[random.Next(0, lastnames.Count)];
        }


        private static string GenerateMethod()
        {
            return Char.ConvertFromUtf32(random.Next(65, 90)) + "." + random.Next(1, 1024) + Char.ConvertFromUtf32(random.Next(65, 90)) + random.Next(0, 1024);
        }
        private static string GenerateCategory()
        {
            List<string> lastnames = new List<string>() {"Blood","Cancer and neoplasms", "Cardiovascular", "Congential disorders", "Ear", "Eye", "Infection", "Inflammatory and immune system", "Injuries and accidents", "Mental health", "Metabolic and endocrine", "Musculoskeletal", "Neurological", "Oral and gastrointestinal", "Renal and urogenital","Skin"};
            return lastnames[random.Next(0, lastnames.Count)];
        }
        private static string GenerateDate()
        {
            return "2019-12-"+random.Next(1, 30)+"-"+random.Next(8, 20)+"-"+random.Next(0, 60);
        }


        public  int CompareTo(ActivePatient other)
        {
            int xHour = int.Parse(this.Date.Split(":")[0]);
            int xMinutes = int.Parse(this.Date.Split(":")[1]);
            int yHour = int.Parse(other.Date.Split(":")[0]);
            int yMinutes = int.Parse(other.Date.Split(":")[1]);
            if (xHour < yHour)
            {
                return -1;
            }
            else if (xHour > yHour)
            {
                return 1;
            }
            else
            {
                if (xMinutes < yMinutes)
                {
                    return -1;
                }
                else if (xMinutes > yMinutes)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
       
        }
    }
}
