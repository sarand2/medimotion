using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MediMotion.Helpers;

namespace MediMotion.DataModel
{
    public class FeedStore
    {
        private static List<Feed> _allFeeds = new List<Feed>();

        static FeedStore()
        {
            AddFeeds();
        }

        public static List<Feed> AllFeeds { get => _allFeeds; }

        public static async Task CheckDownloadsPresent()
        {
            await Task.Run(async () =>
            {
                try
                {
                    using (var db = new LocalStorageContext())
                    {
                        var results2 = from eps in db.EpisodeCache
                                       join state in db.PlaybackState
                                       on eps.Key equals state.EpisodeKey into myJoin
                                       from sub in myJoin.DefaultIfEmpty()
                                       where eps.IsDownloaded == true
                                       select new EpisodeWithState { Episode = eps, PlaybackState = sub ?? new EpisodePlaybackState() };

                        foreach (var item in results2)
                        {
                            if ((await BackgroundDownloadHelper.CheckLocalFileExistsFromUriHash(new Uri(item.Episode.Key))) == null
                            && item.Episode.IsDownloaded)
                            {
                                // Item is flagged as downloaded but isn't in the local cache hence update db
                                Debug.WriteLine($"Episode {item.Episode.Title} is flagged as downloaded but file not present");
                                item.Episode.IsDownloaded = false;
                            }
                        }
                        await db.SaveChangesAsync();

                        await ScanDownloads();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Download scan failed with error {ex.Message}");
                    throw ex;
                }
            });
        }

        private static async Task ScanDownloads()
        {
            using (var db = new LocalStorageContext())
            {
                var items = await BackgroundDownloadHelper.GetAllFiles();
                foreach (var item in items)
                {
                    var found = db.EpisodeCache.Where(e => e.LocalFileName == item.Name).FirstOrDefault();
                    if (found != null && found.IsDownloaded == false)
                    {
                        found.IsDownloaded = true;
                    }
                }

                await db.SaveChangesAsync();
            }
        }

        private static void AddFeeds()
        {
            // Developer
            AllFeeds.Add(
                new Feed(
                    new Uri("ms-appx:///Images/1.jpg"),
                    "Sgymanometer",
                    "Accoson portable aneroid sphygmomanometer range of small, light, robust yet easily portable aneroid sphygmomanometer allowing users to meet the requirements of each of your patients in almost any environment and situation.\nThe Accoson portable aneroid sphygmomanometer is designed with a clear white face with fine pointer which allows for precise indication with the scale graduations starting at zero.\nThis sphygmomanometer is designed for one handed use, being suitable for both left and right hands.\nAneroid (mechanical), devices don’t use mercury but provide accurate results when calibrated. Capable of withstanding 100% overpressure.\nThe Limpet model is designed for use in much the same way as the Duplex. However, this version is much lighter and less bulky.\nSupplied complete with a protective, soft zipper case\nRange: 0-300mmHg \nAccurate to ISO 81061-1 \nAdult Cuff Range: 24cm - 35 cm \nLarge Adult Cuff Range: 34 - 46 cm \nOutsize Adult Cuff Range: 45 - 60 cm \nChild Cuff Range: 18 - 25 cm \nQuantity: 1 \n",
                    new Uri("ms-appx:///Images/1.jpg"), 
                    ""));
          
           AllFeeds.Add(
                new Feed(
                    new Uri("ms-appx:///Images/2.jpg"),
                    "CTCardiopad",
                    "Simply touch the large 10.4 high resolution colour display to record, select and print the highest quality ECGs faster than you can imagine.\nThe Seca CTCardiopad Advanced processing, instant start - up provides immediate availability - ECG processed, interpreted and printed in less than 3 seconds ideal for a busy clinic / emergency use.\nLightweight and portable, together with the high capacity battery, allows easy transport of the Seca CTCardioPad.\nThe CTCardiopad screen is able to clearly display all 12 leads at the same time as well as having a high quality built -in thermal printer.\nEnter patient data quickly and accurately: type on touch screen or scan the bar code(optional).\nGet complete clinical information with the interpretation software.Capture and store 5 minutes of uninterrupted 12 lead data to document intermittent arrhythmias.\nHigh volume internal memory storage of up to 350 ECGs.Seca CTCardioPad can be configured to automatically print, save, transfer and retrieve a previous ECG at the touch of a button.\nFirst high end ECG to support DICOM standard.Supplied complete with mains cable, patient cable, pack of paper, 500 disposable electrodes and alligator clips.\n3 year Seca warranty and technical support helpline.\n",
                    new Uri("ms-appx:///Images/2.jpg"), 
                    ""));

            AllFeeds.Add(
                 new Feed(
                     new Uri("ms-appx:///Images/3.jpg"),
                     "Diagnostic Set",
                     "Keeler Pocket Diagnostic Set with 2.8v Dry Cell Battery is a handy instrument set that powered by a 2.5v dry cell battery.\n The pocket diagnostic set includes a pocket ophthalmoscope head, pocket otoscope head and a handle.",
                      new Uri("ms-appx:///Images/3.jpg"),
                     ""));
            AllFeeds.Add(
                 new Feed(
                     new Uri("ms-appx:///Images/4.jpg"),
                     "Nebuliser",
                     "The unique combination of the OMRON CompA.I.R Compressor with the Virtual Valve Technology (V.V.T.) means more of the aerosol is a respirable size and available to the patient to inhale.\nThe CompA.I.R nebuliser has V.V.T. nebuliser technology and an energy efficient system with water-protected switch.\nFor effective intake, the nebuliser comes in a handy shape chamber and easy to attach and detach tube connectors.\nThe V.V.T.'s unique design means there are fewer parts to lose and fewer parts to clean. Higher hygiene and easier maintenance results.\nWhen not in use, the Nebuliser Kit rests on a hold on the main compressor unit.\nThe OMRON CompA.I.R Compressor comes with a convenient holder for nebuliser kit and a handy carry bag.",
                     new Uri("ms-appx:///Images/4.jpg"),
                     ""));

            AllFeeds.Add(
                 new Feed(
                     new Uri("ms-appx:///Images/5.jpg"),
                     "Respiratory Monitor",
                     "The Vitalograph Lung Age is a motivational tool for smoking intervention by healthcare professionals.\nQuick and simple to use, the Lung Age interprets lung age to help illustrate the impact of smoking on the subject?s lungs.\nThe Lung Age measures FEV and displays as a percentage of predicted values with colour zones that indicate abnormality level.\nThe Vitalograph Lung Age is made with an easy to clean flowhead and can be used with hygienic SafeTway mouthpieces.\n",
                     new Uri("ms-appx:///Images/5.jpg"),
                     ""));

            AllFeeds.Add(
                 new Feed(
                     new Uri("ms-appx:///Images/6.jpg"),
                     "Finger pulse oximeter",
                     "Nonin Medical's Onyx Vantage 9590 finger pulse oximeter with PureSAT technology quickly and accurately captures SpO2 and pulse rate measurements, even on patients where motion and low perfusion are a challenge.\nThe Onyx Vantage 9590 finger pulse oximeter has a scientifically proven performance in the widest range of patient populations and settings as well as versatile with one unit works on the widest range of patients from paediatric to larger adult patients.\nEfficiency and cost effectiveness make the Onyx Vantage 9590 a good buy as it can perform up to 6,000 spot checks on two AAA batteries and durable as it is protected against dropping (withstand a minimum of 50 drops) and water spills (exceeds IP32 water ingress testing).\nNonin Onyx Vantage 9590 finger pulse oximeter comes with an industry leading 4 year warranty\nThe finger pulse oximeter is supplied with a soft carry case for safe transportation.",
                     new Uri("ms-appx:///Images/6.jpg"),
                     ""));

            AllFeeds.Add(
                 new Feed(
                     new Uri("ms-appx:///Images/7.jpg"),
                     "Blood pressure monitor",
                     "The Omron 907 Blood Pressure Monitor is a digital automatic upper arm model for professional clinical use.\n It is versatile in use from fully automatic operation to manual deflation control.\n Oscillometric and auscultatory use is combined in one unit. Using Intellisense technology, the Omron 907 is designed to supply a programmable average of multiple measurements, based on three successive readings.\n White coat hypertension can be reduced or avoided by the 'hide' display function. Clinically validated (International Protocol) the Omron 907 blood pressure monitor is supplied with rechargeable batteries and adapter.\n",
                      new Uri("ms-appx:///Images/7.jpg"),
                     ""));
        



        }
    }
}

