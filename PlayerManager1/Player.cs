namespace PlayerManager1
{
    public class Player
    {
        public string Name {get;}
        public int Score {get;set;}

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}