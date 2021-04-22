using Infinite_5th_Tiers.AntiCheat;

namespace Infinite_5th_Tiers
{
    internal class SessionData
    {
        public bool IsCheating { get { return (OdysseyChecker.IsInOdyssey || RaceChecker.IsInRace || CoopChecker.IsInPublicCoop); } }
        public OdysseyHandler OdysseyChecker { get; set; } = new OdysseyHandler();
        public RaceHandler RaceChecker { get; set; } = new RaceHandler();
        public CoopHandler CoopChecker { get; set; } = new CoopHandler();


        private static SessionData currentSession = new SessionData();
        public static SessionData CurrentSession
        {
            get { return currentSession; }
            set { currentSession = value; }
        }

        public void ResetCheatStatus()
        {
            RaceChecker.IsInRace = false;
            OdysseyChecker.IsInOdyssey = false;
            CoopChecker.IsInPublicCoop = false;
        }
    }
}
