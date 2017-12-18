using SacramentApp.Models;
using System;
using System.Linq;

namespace SacramentApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(MeetingContext context)
        {
            context.Database.EnsureCreated();

            //check for seed
            if (context.Prayers.Any())
            {
                return;
            }

            var Meetings = new Models.Meeting[]
            {
                new Models.Meeting{MeetingDate = DateTime.Parse("2016-09-01"),Conductor="Br. Worthington"}
            };
            foreach (Models.Meeting m in Meetings)
            {
                context.Meetings.Add(m);
            }
            context.SaveChanges();

            var Hymns = new Hymn[]
            {
                new Hymn{Number=20,Title="Come, Come Ye Saints",Order=HymnOrder.Open},
                new Hymn{Number=175,Title="O God, The Eternal Father",Order=HymnOrder.Sacrament},
                new Hymn{Number=81,Title="Press Forward, Saints",Order=HymnOrder.Optional},
                new Hymn{Number=2,Title="The Spirit of God",Order=HymnOrder.Close}
            };
            foreach (Hymn h in Hymns)
            {
                context.Hymns.Add(h);
            }
            context.SaveChanges();

            var Speakers = new Speaker[]
            {
                new Speaker{SpeakerName="Gordon Smith",Subject="Baptism",Order=1},
                new Speaker{SpeakerName="Jennifer Smith",Subject="The Gift of the Holy Ghost",Order=2},
                new Speaker{SpeakerName="Doug Smith",Subject="Endure to the End",Order=3}
            };
            foreach (Speaker s in Speakers)
            {
                context.Speakers.Add(s);
            }
            context.SaveChanges();

            var Prayers = new Prayer[]
            {
                new Prayer{PrayerName="Celeste Smith",Order=PrayerOrder.Open},
                new Prayer{PrayerName="Vernon Smith",Order=PrayerOrder.Close}
            };
            foreach (Prayer p in Prayers)
            {
                context.Prayers.Add(p);
            }
            context.SaveChanges();
        }
    }
}

