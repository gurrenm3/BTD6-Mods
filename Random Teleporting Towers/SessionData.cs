using Random_Teleporting_Towers.AntiCheat;
using System;

namespace Random_Teleporting_Towers
{
    internal class SessionData
    {
        public TowerTeleporter Teleporter { get; set; } = new TowerTeleporter();
        public int TimeToNextRandom { get; set; }
        public int RoundsSinceLastRandom { get; set; }
        public Random Rand { get; set; } = new Random();
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
