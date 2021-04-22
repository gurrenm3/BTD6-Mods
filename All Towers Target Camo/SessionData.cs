using All_Towers_Target_Camo.AntiCheat;

namespace All_Towers_Target_Camo
{
    internal class SessionData
    {
        public BloonModifier BloonModifier { get; set; }
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
