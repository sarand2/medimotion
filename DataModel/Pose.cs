using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MediMotion.DataModel
{
    public class Pose : INotifyPropertyChanged
    {
        private string _name;
        private string _position;
        private string _comment;
        private double _score;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }

        public double Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public static List<Pose> GeneratePoses()
        {
            var poses = new List<Pose>();
            poses.Add(new Pose
            {
                Name = "Food quality",
                Score = 50,
                Position = "ms-appx:///Images/food.png",
                Comment = "The overall food quality is average"
            });

            poses.Add(new Pose
            {
                Name = "Exercise rate",
                Score = 90,
                Position = "ms-appx:///Images/exercise.png",
                Comment = "Individual is excersiging in accordance to recomendations"
            });
            poses.Add(new Pose
            {
                Name = "Sleep quality",
                Score = 90,
                Position = "ms-appx:///Images/sleep.png",
                Comment = "Overall sleep quality is good"
            });
            poses.Add(new Pose
            {
                Name = "Psychological eval",
                Score = 60,
                Position = "ms-appx:///Images/psychology.png",
                Comment = "Individual's mental state is in average condition"
            });
            poses.Add(new Pose
            {
                Name = "Overall",
                Score = 80,
                Position = "ms-appx:///Images/overall.png",
                Comment = "Overall, individual is in a good mental and physical state"
            });
            return poses;
        }
    }
}
