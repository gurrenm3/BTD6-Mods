namespace Aim_All_Towers
{
    internal class SessionData
    {

        public TowerModifier TowerModifier { get; set; } = new TowerModifier();
        public bool TowersModded { get; set; }


        private static SessionData currentSession = new SessionData();
        public static SessionData CurrentSession
        {
            get { return currentSession; }
            set { currentSession = value; }
        }
    }
}
