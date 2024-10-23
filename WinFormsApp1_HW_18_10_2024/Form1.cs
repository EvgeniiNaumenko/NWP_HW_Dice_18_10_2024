using Newtonsoft.Json;
using System.Media;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using static WinFormsApp1_HW_18_10_2024.Form1;
using NAudio.Wave;

namespace WinFormsApp1_HW_18_10_2024
{
    public partial class Form1 : Form
    {
        private bool MultipModeCheck = false;
        private int player1Result = 0;
        private int player2Result = 0;
        private int PCResult = 0;
        private bool isPlayer1Turn = true;
        private IWavePlayer waveOutDevice;  // Для воспроизведения MP3
        private Mp3FileReader mp3Reader;    // Для чтения MP3 файла

        public Form1()
        {
            InitializeComponent();
            waveOutDevice = new WaveOut();
        }

        private void ChangeModeButton_Click(object sender, EventArgs e)
        {
            if (!MultipModeCheck)
            {
                MultipModeCheck = true;
                ModeLable.Text = "Pl vs Pl";
            }
            else
            {
                MultipModeCheck = false;
                ModeLable.Text = "Pl vs PC";
            }
        }

        private async void ThrowButton_Click(object sender, EventArgs e)
        {
            await AnimateDice();
            int diceResult = await RollDiceAsync();

            if(!MultipModeCheck)
            {
                player1Result = diceResult;
                SetDiceImage(DiceImage, player1Result);
                MessageBox.Show($"Player 1 rolled a {player1Result}!");
                await AnimateDice();
                diceResult = await RollDiceAsync();
                PCResult = diceResult;
                SetDiceImage(DiceImage, PCResult);
                MessageBox.Show($"PC rolled a {PCResult}!");
                DetermineWinner();
            }
            else
            {
                if (isPlayer1Turn)
                {
                    player1Result = diceResult;
                    SetDiceImage(DiceImage, player1Result); 
                    MessageBox.Show($"Player 1 rolled a {player1Result}!");
                    isPlayer1Turn = false;
                    
                }
                else
                {
                    player2Result = diceResult;
                    SetDiceImage(DiceImage, player2Result);
                    MessageBox.Show($"Player 2 rolled a {player2Result}!"); 
                    isPlayer1Turn = true;
                    DetermineWinner();
                }
            }
        }

        private async Task AnimateDice()
        {
            Random rnd = new Random();
            PlaySound(@"Resources/dice.mp3", 1f);
            for (int i = 0; i < 10; i++)
            {
                int tempResults = rnd.Next(1, 7);
                SetDiceImage(DiceImage, tempResults);
                await Task.Delay(70);  
            }
        }

        public void SetDiceImage(PictureBox box, int diceValue)
        {
            string path = Path.Combine(Application.StartupPath, "Resources", $"{diceValue}.png");
            box.Image = Image.FromFile(path);
        }

        public static async Task<int> RollDiceAsync()
        {
            string apiKey = "19c33816-f9ec-4e89-ad95-7d17bdca0732";
            string url = "https://api.random.org/json-rpc/2/invoke";
            using (var client = new HttpClient())
            {
                var content = new StringContent($@"
                {{
                    ""jsonrpc"": ""2.0"",
                    ""method"": ""generateIntegers"",
                    ""params"": {{
                        ""apiKey"": ""{apiKey}"",
                        ""n"": 1,
                        ""min"": 1,
                        ""max"": 6,
                        ""replacement"": true
                    }},
                    ""id"": 1
                }}", Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(json);
                    int diceValue = result.result.random.data[0];
                    return diceValue;
                }
                else
                {
                    throw new Exception("Failed generation");
                }
            }
        }
        private void DetermineWinner()
        {
            if(!MultipModeCheck)
            {
                if (player1Result > PCResult)
                {
                    PlaySound(@"Resources/winer.mp3",0.6f);
                    MessageBox.Show("Player 1 wins!");
                }
                else if (PCResult > player1Result)
                {
                    PlaySound(@"Resources/lose.mp3", 0.4f);
                    MessageBox.Show("PC wins!");
                }
                else
                {
                    MessageBox.Show("It's a draw!");
                }
            }
            else
            {
                if (player1Result > player2Result)
                {
                    MessageBox.Show("Player 1 wins!");
                }
                else if (player2Result > player1Result)
                {
                    MessageBox.Show("Player 2 wins!");
                }
                else
                {
                    MessageBox.Show("It's a draw!");
                }
            }

            player1Result = 0;
            player2Result = 0;
            PCResult = 0;
            isPlayer1Turn = true; 
        }
        private void PlaySound(string filePath, float volume)
        {
            if (waveOutDevice.PlaybackState == PlaybackState.Playing)
            {
                waveOutDevice.Stop();
            }

            mp3Reader = new Mp3FileReader(filePath);
            waveOutDevice.Init(mp3Reader);
            waveOutDevice.Volume = volume;
            waveOutDevice.Play();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (mp3Reader != null)
            {
                mp3Reader.Dispose();
            }
            if (waveOutDevice != null)
            {
                waveOutDevice.Dispose();
            }

            base.OnFormClosing(e);
        }
    }
}
