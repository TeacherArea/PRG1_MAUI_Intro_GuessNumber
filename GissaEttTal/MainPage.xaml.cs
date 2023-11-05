namespace GissaEttTal
{
    public partial class MainPage : ContentPage
    {
        private int randomNumber;
        private int numberOfGuesses;

        public MainPage()
        {
            InitializeComponent();
            GenerateNumbers();
        }

        private void GenerateNumbers()
        {
            Random random = new Random();
            randomNumber = random.Next(1, 10);
            numberOfGuesses = 0;
        }
        private void OnGuessButtonClicked(object sender, EventArgs e)
        {
            bool numeric = int.TryParse(UserGuess.Text, out int userGuess);

            if (!numeric || userGuess < 1 || userGuess > 20)
            { 
                HintLabel.Text = "Ange ett heltal mellan 1 till 20";
                return;
            }
            numberOfGuesses++;

            if (userGuess < randomNumber) 
            {
                HintLabel.Text = "För lågt. Försök igen ...";
            }
            else if(userGuess > randomNumber)
            {
                HintLabel.Text = "För lågt. Försök igen ...";
            }
            else 
            {
                HintLabel.Text = $"Korrekt! Talet var {randomNumber}, du gissade rätt på {numberOfGuesses} försök!";
            }
        }
    }
}