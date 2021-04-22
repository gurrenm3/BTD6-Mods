namespace Random_Tower_Speed_and_Range
{
    class TowerModifier
    {
        public float GetRandomRange()
        {
            var tier = GetModifierTier();

            int min = Settings.LoadedSettings.MinRandomRange / tier;
            int max = Settings.LoadedSettings.MaxRandomRange / tier;

            return SessionData.CurrentSession.Random.Next(min, max) / tier;
        }

        public float GetRandomSpeed()
        {
            var tier = GetModifierTier();
            int min = Settings.LoadedSettings.MinSpeedDelay / tier;
            int max = Settings.LoadedSettings.MaxSpeedDelay / tier;
            return SessionData.CurrentSession.Random.Next(min, max) / tier;
        }


        private int GetModifierTier()
        {
            var settings = Settings.LoadedSettings;
            var rand = SessionData.CurrentSession.Random;
            var max = settings.ChanceForOP + settings.ChanceForBalanced + settings.ChanceForTrash;
            var roll = rand.Next(0, max);

            var tier1 = settings.ChanceForOP;
            var tier2 = tier1 + settings.ChanceForBalanced;
            var tier3 = tier2 + settings.ChanceForTrash;

            var tier = 0;

            if (roll <= tier1)
                tier = 1;
            else if (roll > tier1 && roll < tier2)
                tier = 2;
            else
                tier = 3;

            return tier;
        }
    }
}
