namespace GissaEttTal
{
    public partial class MainPage : ContentPage
    {
        private int randomNumber;
        private int numberOfGuesses;
        private int score = 0;
        private bool gameOver = false;

        public MainPage()
        {
            InitializeComponent();
            Btn_PlayAgain.IsVisible = false;
            GenerateNumbers();
        }

        private void GenerateNumbers()
        {
            Random random = new Random();
            randomNumber = random.Next(1, 10);
            numberOfGuesses = 0;
        }

        private void OnEnterKey(object sender, EventArgs e)
        {
            if(!gameOver)
                OnGuessButtonClicked(sender, e);
        }
        private void OnGuessButtonClicked(object sender, EventArgs e)
        {
            bool numeric = int.TryParse(UserGuess.Text, out int userGuess);
            

            if (!numeric || userGuess < 1 || userGuess > 10)
            { 
                HintLabel.Text = "Ange ett heltal mellan 1 till 20";
                return;
            }
            numberOfGuesses++;

            if (userGuess < randomNumber) 
            {
                HintLabel.Text = $"Ditt tal: {userGuess}. För lågt. Försök {numberOfGuesses}.";
                UserGuess.Text = "";
            }
            else if(userGuess > randomNumber)
            {
                HintLabel.Text = $"Ditt tal: {userGuess}. För högt. Försök {numberOfGuesses}.";
                UserGuess.Text = "";
            }
            else 
            {
                HintLabel.Text = $"Korrekt! Talet var {randomNumber}, du gissade rätt på {numberOfGuesses} försök!";
                score = 10 - numberOfGuesses;
                UserGuess.Text = "";
                Btn_Guess.IsEnabled = false;
                Btn_PlayAgain.IsVisible = true;
                gameOver = true;
                UserGuess.IsEnabled = false;
            }
        }

        private void PlayAgainButtonClicked(object sender, EventArgs e)
        {
            GenerateNumbers();
            HintLabel.Text = "";
            UserGuess.Text = "";
            Btn_Guess.IsEnabled = true;
            Btn_PlayAgain.IsVisible = false;
            gameOver = false;
            UserGuess.IsEnabled = true;
        }
    }
}