namespace DoingABitOfTrolling.JokeEvents
{
    internal class JokeHat
    {
        List<JokeEvent> hat = new List<JokeEvent>();

        public JokeHat()
        {

        }

        public JokeHat Add(JokeEvent punishment)
        {
            hat.Add(punishment);
            return this;
        }

        internal JokeEvent GetRandom()
        {
            Extentions.Random random = new Extentions.Random();
            int index = random.Next(0, hat.Count);
            return hat[index];
        }

        private static List<JokeEvent> SortByClosestWeight(List<JokeEvent> hat, int weight)
        {
            List<JokeEvent> punishments = new List<JokeEvent>();
            List<int> diffList = new List<int>();

            foreach (JokeEvent p in hat)
            {
                int diff = Math.Abs(p.Weight - weight);
                diffList.Add(diff);
            }

            // Lowest first
            diffList.Sort();
            diffList.Reverse();

            for (int i = 0; i < diffList.Count; i++)
            {
                JokeEvent entry = hat[i];
                punishments.Add(entry);
            }

            return punishments;
        }
    }
}
