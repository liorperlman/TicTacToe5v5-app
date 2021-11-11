using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using TicTacToeGame.Model;

namespace TicTacToeGame
{
    public partial class RestoreWindow : Form
    {
        private HttpClient client;
        public int MyPlayerId;
        BindingList<Game> GameList = new BindingList<Game>();
        BindingSource source = new BindingSource();


        public RestoreWindow(int playerId)
        {
            MyPlayerId = playerId;
            GetGamesByPlayerId();
            source.DataSource = GameList;
            InitializeComponent();
            MyGridView.DataSource = source;
        }

        private void RestoreGame(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = MyGridView.SelectedRows[0];
            int gameId = (int)SelectedRow.Cells[0].Value;
            GameRestoreWindow restoredGame = new GameRestoreWindow(MyPlayerId, gameId);
            restoredGame.ShowDialog();
        }

        private async void GetGamesByPlayerId()
        {
            client = Program.client;
            string path = "api/Games";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Game> Games = await response.Content.ReadAsAsync<IEnumerable<Game>>();
                foreach (Game g in Games)
                {
                    if (g.PlayerId == MyPlayerId){ GameList.Add(g); }
                }
            }
            else
            {
                MessageBox.Show($"Error: '{response.ReasonPhrase}'");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .2; // 20%
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {
                this.Close();
            }
            Opacity -= .2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }
    }
}
