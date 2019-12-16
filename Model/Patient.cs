using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Media.Imaging;

namespace MediMotion.Model
{
    public class Patient
    {
        private static Random random = new Random();

        #region Properties
        private string initials;
        public string Initials
        {
            get
            {
                if (initials == string.Empty && FirstName != string.Empty && LastName != string.Empty)
                {
                    initials = FirstName[0].ToString() + LastName[0].ToString();
                }
                return initials;
            }
        }
        private string name;
        public string Name
        {
            get
            {
                if (name == string.Empty && FirstName != string.Empty && LastName != string.Empty)
                {
                    name = FirstName + " " + LastName;
                }
                return name;
            }
        }
        private string email;
        public string Email
        {
            get
            {
                if (FirstName != string.Empty)
                {
                    email = FirstName + "@gmail.com";
                }
                return email;
            }
        }
        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                initials = string.Empty; // force to recalculate the value 
                name = string.Empty; // force to recalculate the value 
            }
        }
        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                initials = string.Empty; // force to recalculate the value 
                name = string.Empty; // force to recalculate the value 
            }
        }
        private string education;
        public string Education
        {
            get
            {
                return education;
            }
            set
            {
                education = value;
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        private string occupation;
        public string Occupation
        {
            get
            {
                return occupation;
            }
            set
            {
                occupation = value;
            }
        }
        private string postalCode;
        public string PostalCode
        {
            get
            {
                return postalCode;
            }
            set
            {
                postalCode = value;
            }
        }
        private string age;
        public string Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        private string middleName;
        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
            }
        }
        private string region;
        public string Region
        {
            get
            {
                return region;
            }
            set
            {
                region = value;
            }
        }
        private string marital;
        public string Marital
        {
            get
            {
                return marital;
            }
            set
            {
                marital = value;
            }
        }
        private string birthDate;
        public string BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
            }
        }
        private string childrenCount;
        public string ChildrenCount
        {
            get
            {
                return childrenCount;
            }
            set
            {
                childrenCount = value;
            }
        }
        private string id;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Biography { get; set; }
        #endregion
        private BitmapImage personPicture;
        public BitmapImage PersonPicture
        {
            get
            {
                return personPicture;
            }

            set
            {
                personPicture = value;
            }
        }

        private static List<BitmapImage> personPictures = Patient.generatePictures();
        private static List<BitmapImage> generatePictures()
        {
            string dir_start = "ms-appx:///Images/personPictures/face";
            var sources = new List<BitmapImage>();
            for(int i = 0; i < 20; i++)
            {
                sources.Add(new BitmapImage(new Uri(String.Format("{0}{1}.png", dir_start, (i + 1))))); 
            }
            return sources;
        }

        private static BitmapImage GenerateImage()
        {
            return personPictures[random.Next(0, personPictures.Count)];
        }

        public Patient()
        {
            // default values for each property.
            initials = string.Empty;
            name = string.Empty;
            LastName = string.Empty;
            Title = string.Empty;
            FirstName = string.Empty;
            Position = string.Empty;
            PhoneNumber = string.Empty;
            Biography = string.Empty;
            Occupation = string.Empty;
            PostalCode = string.Empty;
            MiddleName = string.Empty;
            Age = string.Empty;
            BirthDate = string.Empty;
            Marital = string.Empty;
            Region = string.Empty;
            Id = string.Empty;
            PersonPicture = null;
            ChildrenCount = string.Empty;
        }

        #region Public Methods
        public static Patient GetNewContact()
        {
            return new Patient()
            {
                FirstName = GenerateFirstName(),
                LastName = GenerateLastName(),
                Biography = GetBiography(),
                PhoneNumber = GeneratePhoneNumber(),
                Position = GeneratePosition(),
                Title = GenerateTitle(),
                Education = GenerateEducation(),
                Occupation = GenerateOccupaton(),
                PersonPicture = GenerateImage(),
                PostalCode = GeneratePostalCode(),
                MiddleName = GenerateFirstName(),
                Region = GenerateRegions(),
                Age = GenerateAge(),
                BirthDate = GenerateBirtDate(),
                Marital = GenerateMarital(),
                Id = GenerateID(),
                ChildrenCount = GenerateChildrenCount()
            };
        }
        public static ObservableCollection<Patient> GetPatients(int numberOfPatients)
        {
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>();

            for (int i = 0; i < numberOfPatients; i++)
            {
                patients.Add(GetNewContact());
            }
            return patients;
        }
        public static ObservableCollection<GroupInfoList> GetPatientsGrouped(int numberOfContacts)
        {
            ObservableCollection<GroupInfoList> groups = new ObservableCollection<GroupInfoList>();

            var query = from item in GetPatients(numberOfContacts)
                        group item by item.LastName.Substring(0, 1).ToUpper() into g
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

        public override string ToString()
        {
            return Name;
        }
        #endregion

        #region Helpers
        private static string GenerateAge()
        {
            return random.Next(0, 99).ToString();
        }
        private static string GeneratePosition()
        {
            List<string> positions = new List<string>() { "Category 1", "Category 2", "Category 3", "Category 4" };
            return positions[random.Next(0, positions.Count)];
        }
        private static string GenerateEducation()
        {
            List<string> positions = new List<string>() { "Bachelor in Computer Science", "Major in Engineering", "PhD in Physiology", "Major in management", "PhD in Mathematics", "Bachelor in Desing", "Bachelor in Information Systems", "Bachelor in Statistics", "Major in Data Science"
            , "PhD in History", "Bachelor in Sociology", "Bachelor in Psychology", "Bachelor in Fundamental Science", "Major in Electrical Engineering", "Law Bachelor", "Law PhD", "Master in Astrology", "PhD in Physics", "Master in Astronomy"};
            return positions[random.Next(0, positions.Count)];
        }
        private static string GenerateTitle()
        {
            List<string> positions = new List<string>() { "Mr", "Mrs", "Ms" };
            return positions[random.Next(0, positions.Count)];
        }
        private static string GetBiography()
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

        private static string GeneratePhoneNumber()
        {
            return string.Format("{0:(###)} {1:###}-{2:####}", random.Next(100, 999), random.Next(100, 999), random.Next(1000, 9999));
        }
        private static string GenerateID()
        {
            return string.Format("{0:(##)}-{1:###}", random.Next(10, 99), random.Next(100, 999));
        }
        private static string GeneratePostalCode()
        {
            return string.Format("US {0:####} {1:##}", random.Next(100, 9999), random.Next(10, 99));
        }
        private static string GenerateMarital()
        {
            List<string> names = new List<string>() { "Married", "Divorced", "Single", "Engaged" };
           return names[random.Next(0, names.Count)];
        }
        private static string GenerateBirtDate()
        {
            DateTime start = new DateTime(1960, 1, 1);
            int range = (DateTime.Parse("2000-12-12") - start).Days;
            return string.Format("{0:yyyy-MM-dd}", start.AddDays(random.Next(range)));
        }
        private static string GenerateChildrenCount()
        {
            return random.Next(0, 10).ToString();
        }
        private static string GenerateFirstName()
        {
            List<string> names = new List<string>() { "Lilly", "Mukhtar", "Sophie", "Femke", "Abdul-Rafi'", "Chirag-ud-D", "Mariana", "Aarif", "Sara", "Ibadah", "Fakhr", "Ilene", "Sardar", "Hanna", "Julie", "Iain", "Natalia", "Henrik", "Rasa", "Quentin", "Gadi", "Pernille", "Ishtar", "Jimme", "Justina", "Lale", "Elize", "Rand", "Roshanara", "Rajab", "Bijou", "Marcus", "Marcus", "Alima", "Francisco", "Thaqib", "Andreas", "Mariana", "Amalie", "Rodney", "Dena", "Fadl", "Ammar", "Anna", "Nasreen", "Reem", "Tomas", "Filipa", "Frank", "Bari'ah", "Parvaiz", "Jibran", "Tomas", "Elli", "Carlos", "Diego", "Henrik", "Aruna", "Vahid", "Eliana", "Roxane", "Amanda", "Ingrid", "Wander", "Malika", "Basim", "Eisa", "Alina", "Andreas", "Deeba", "Diya", "Parveen", "Bakr", "Celine", "Bakr", "Marcus", "Daniel", "Mathea", "Edmee", "Hedda", "Maria", "Maja", "Alhasan", "Alina", "Hedda", "Victor", "Aaftab", "Guilherme", "Maria", "Kai", "Sabien", "Abdel", "Fadl", "Bahaar", "Vasco", "Jibran", "Parsa", "Catalina", "Fouad", "Colette" };
            return names[random.Next(0, names.Count)];
        }
        private static string GenerateRegions()
        {
            List<string> names = new List<string>() {
                        "Connecticut", "Maine", "Massachusetts", "New Hampshire", "Rhode Island", "Vermont",
                    "New Jersey", "New York", "Puerto Rico", "US Virgin Islands",
                         "Delaware", "District of Columbia", "Maryland", "Pennsylvania", "Virginia", "West Virginia",
                         "Alabama", "Florida", "Georgia", "Kentucky", "Mississippi", "North Carolina", "South Carolina", "Tennessee",
                       "Illinois", "Indiana", "Michigan, Minnesota, Ohio, Wisconsin",
                       "Arkansas", "Louisiana", "New Mexico, Oklahoma, Texas",
                       "Iowa", "Kansas", "Missouri", "Nebraska",
                       " Colorado", "Montana", "North Dakota", "South Dakota", "Utah", "Wyoming",
                        "Arizona", "California", "Hawaii", "Nevada", "American Samoa", "Guam", "Northern Mariana Islands",
                       "Alaska", "Idaho", "Oregon", "Washington" };
            return names[random.Next(0, names.Count)];
        }
        private static string GenerateLastName()
        {
            List<string> lastnames = new List<string>() { "Carlson", "Attia", "Quint", "Hollenberg", "Khoury", "Araujo", "Hakimi", "Seegers", "Abadi", "al", "Krommenhoek", "Siavashi", "Kvistad", "Sjo", "Vanderslik", "Fernandes", "Dehli", "Sheibani", "Laamers", "Batlouni", "Lyngvær", "Oveisi", "Veenhuizen", "Gardenier", "Siavashi", "Mutlu", "Karzai", "Mousavi", "Natsheh", "Seegers", "Nevland", "Lægreid", "Bishara", "Cunha", "Hotaki", "Kyvik", "Cardoso", "Pilskog", "Pennekamp", "Nuijten", "Bettar", "Borsboom", "Skistad", "Asef", "Sayegh", "Sousa", "Medeiros", "Kregel", "Shamoun", "Behzadi", "Kuzbari", "Ferreira", "Van", "Barros", "Fernandes", "Formo", "Nolet", "Shahrestaani", "Correla", "Amiri", "Sousa", "Fretheim", "Van", "Hamade", "Baba", "Mustafa", "Bishara", "Formo", "Hemmati", "Nader", "Hatami", "Natsheh", "Langen", "Maloof", "Berger", "Ostrem", "Bardsen", "Kramer", "Bekken", "Salcedo", "Holter", "Nader", "Bettar", "Georgsen", "Cunha", "Zardooz", "Araujo", "Batalha", "Antunes", "Vanderhoorn", "Nader", "Abadi", "Siavashi", "Montes", "Sherzai", "Vanderschans", "Neves", "Sarraf", "Kuiters" };
            return lastnames[random.Next(0, lastnames.Count)];
        }
        private static string GenerateOccupaton()
        {
            List<string> names = new List<string>() { "Delivery driver", "Aircraft engineer", "Counsellor", "Crown prosecutor", "Musician",  "Porter", "Orthodontist", "General practitioner", "Film producer", "Meteorologist", "Travel agent", "Sales manager", "Driving instructor", "Historian", "Garden designer", "Solicitor", "Salesperson" };
            return names[random.Next(0, names.Count)];
        }
        #endregion
    }
}