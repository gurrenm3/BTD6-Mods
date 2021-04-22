using Random_Tower_Speed_and_Range.AntiCheat;
using System;

namespace Random_Tower_Speed_and_Range
{
    internal class SessionData
    {
        public TowerModifier TowerModifier { get; set; } = new TowerModifier();
        public int RoundSinceLastRandom { get; set; } = 0;
        public Random Random { get; set; } = new Random();
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
