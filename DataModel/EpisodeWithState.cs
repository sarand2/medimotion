using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediMotion.DataModel
{
    public class EpisodeWithState
    {
        public Episode Episode { get; set; }

        public EpisodePlaybackState PlaybackState { get; set; }
    }
}
