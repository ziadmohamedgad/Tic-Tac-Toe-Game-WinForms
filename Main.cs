using System;
using Project.Properties;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlTypes;
using System.Media;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Project
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Controls Code
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            DisableSecondPanel();
            EnableFirstPanel();
            ResetSecondPanel();
        }
        private void ResetSecondPanel()
        {
            DisablePanelPlayerName();
            DisablePanelPlayersNames();
            ResetButton_Play_vs_Computer();
            ResetButton_Play_vs_Friend();
            btn_Back.Visible = false;
            btn_Start.Visible = false;
        }
        private void Reset_btn_Play_vs_Friend_When_Mouse_Leave(Button button)
        {
            if (button.BackColor != Color.Gray)
            {
                btnPlay_vs_Friend.ForeColor = Color.Beige;
                btnPlay_vs_Friend.BackColor = Color.Black;
            }
            else
            {
                btnPlay_vs_Friend.BackColor = button.BackColor;
            }
        }
        private void btnPlay_vs_Friend_Click(object sender, EventArgs e)
        {
            DisablePanelPlayerName();
            EnablePanelPlayersNames();
            Button button = (Button)sender;
            button.BackColor = Color.Gray;
            btnPlay_vs_Friend_MouseLeave(button, e);
            btnPlay_vs_Friend.Enabled = false;
            btn_Back.Visible = true;
            btn_Play_VS_Computer.Enabled = false;
            btn_Play_VS_Computer.Visible = false;
        }

        private void btnPlay_vs_Friend_MouseEnter(object sender, EventArgs e)
        {
            btnPlay_vs_Friend.BackColor = Color.Gold;
            btnPlay_vs_Friend.ForeColor = Color.Black;
        }

        private void btnPlay_vs_Friend_MouseLeave(object sender, EventArgs e)
        {
            Reset_btn_Play_vs_Friend_When_Mouse_Leave((Button)sender);
        }

        private void btn_Play_VS_Computer_MouseEnter(object sender, EventArgs e)
        {
            btn_Play_VS_Computer.BackColor = Color.Red;
            btn_Play_VS_Computer.ForeColor = Color.Black;
        }

        private void btn_Play_VS_Computer_MouseLeave(object sender, EventArgs e)
        {
            btn_Play_VS_Computer.BackColor = Color.Black;
            btn_Play_VS_Computer.ForeColor = Color.Beige;
        }

        private void btn_Play_VS_Computer_Click(object sender, EventArgs e)
        {
            DisablePanelPlayersNames();
            EnablePanelPlayerName();
            btn_Play_VS_Computer.Visible = false;
            btn_Play_VS_Computer.Enabled = false;
            btnPlay_vs_Friend.Text = "Play Vs Computer";
            cbDiffculty.Text = cbDiffculty.Items[0].ToString();
            btnPlay_vs_Friend.BackColor = Color.Gray;
            btnPlay_vs_Friend.Enabled = false;
            btn_Back.Visible = true;
        }


        private void btn_Start_MouseLeave(object sender, EventArgs e)
        {
            btn_Start.ForeColor = Color.GreenYellow;
            btn_Start.BackColor = Color.Black;
        }


        private void btn_Start_MouseEnter(object sender, EventArgs e)
        {
            btn_Start.ForeColor = Color.Black;
            btn_Start.BackColor = Color.GreenYellow;
        }

        private void btn_Back_MouseEnter(object sender, EventArgs e)
        {
            btn_Back.ForeColor = Color.Black;
            btn_Back.BackColor = Color.Red;
        }
        private void btn_Back_MouseLeave(object sender, EventArgs e)
        {
            btn_Back.ForeColor = Color.Red;
            btn_Back.BackColor = Color.Black;
        }
        private void ResetButton_Play_vs_Friend()
        {
            btnPlay_vs_Friend.Text = "Play Vs Friend";
            btnPlay_vs_Friend.Enabled = true;
            btnPlay_vs_Friend.ForeColor = Color.Beige;
            btnPlay_vs_Friend.BackColor = Color.Black;
            btnPlay_vs_Friend.BringToFront();
        }
        private void ResetButton_Play_vs_Computer()
        {
            btn_Play_VS_Computer.Enabled = true;
            btn_Play_VS_Computer.Visible = true;
            btn_Play_VS_Computer.BringToFront();
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            ResetSecondPanel();
        }
        private void txt_Players_Name_TextChanged(object sender, EventArgs e)
        {
            if (txt_Player1Name.Text.Length <= 15 && txt_Player2_Name.Text.Length <= 15)
            {
                if (!string.IsNullOrWhiteSpace(txt_Player1Name.Text) && !string.IsNullOrEmpty(txt_Player1Name.Text))
                {
                    if (!string.IsNullOrWhiteSpace(txt_Player2_Name.Text) && !string.IsNullOrEmpty(txt_Player2_Name.Text))
                    {
                        if (txt_Player1Name.Text.Trim() != txt_Player2_Name.Text.Trim())
                        {
                            btn_Start.Visible = true;
                        }
                        else
                            btn_Start.Visible = false;
                    }
                    else
                    {
                        btn_Start.Visible = false;
                    }
                }
                else
                {
                    btn_Start.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Name Should Be Less Than 15 Chars", "InValid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (txt_Player2_Name.Text.Length > 15) txt_Player2_Name.Text = "";
                else txt_Player1Name.Text = "";
            }

        }

        private void txt_Player_Name_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_Player_Name.Text) && !string.IsNullOrEmpty(txt_Player_Name.Text))
            {
                btn_Start.Visible = true;
                if (txt_Player_Name.Text.Length <= 15)
                    btn_Start.Visible = true;
                else
                {
                    MessageBox.Show("Name Should Be Less Than 15 Chars", "InValid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_Player_Name.Text = "";
                }
            }
            else
                btn_Start.Visible = false;
        }
        private void EnableFirstPanel()
        {
            First_Panel.BringToFront();
            First_Panel.Enabled = true;
            First_Panel.Visible = true;
        }
        private void DisableFirstPanel()
        {
            First_Panel.SendToBack();
            First_Panel.Visible = false;
            First_Panel.Enabled = false;
        }
        private void DisableSecondPanel()
        {
            Second_Panel.SendToBack();
            Second_Panel.Visible = false;
            Second_Panel.Enabled = false;
        }
        private void EnableSecondPanel()
        {
            Second_Panel.BringToFront();
            Second_Panel.Visible = true;
            Second_Panel.Enabled = true;
        }

        private void DisablePanelPlayerName()
        {
            Panel_Play_Vs_Computer.SendToBack();
            cbDiffculty.Text = "";
            Panel_Play_Vs_Computer.Enabled = false;
            Panel_Play_Vs_Computer.Visible = false;
        }
        private void EnablePanelPlayerName()
        {
            txt_Player_Name.Text = "";
            Panel_Play_Vs_Computer.BringToFront();
            Panel_Play_Vs_Computer.Enabled = true;
            Panel_Play_Vs_Computer.Visible = true;
            txt_Player_Name.Focus();
        }
        private void DisablePanelPlayersNames()
        {
            Panel_Players_Names.SendToBack();
            Panel_Players_Names.Enabled = false;
            Panel_Players_Names.Visible = false;
        }
        private void EnablePanelPlayersNames()
        {
            txt_Player1Name.Text = "";
            txt_Player2_Name.Text = "";
            Panel_Players_Names.BringToFront();
            Panel_Players_Names.Enabled = true;
            Panel_Players_Names.Visible = true;
            txt_Player1Name.Focus();
        }
        private void txt_Player_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btn_Start.Visible == true)
            {
                btn_Start.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
        private void btnRestartGame_MouseEnter(object sender, EventArgs e)
        {
            btnRestartGame.ForeColor = Color.Black;
            btnRestartGame.BackColor = Color.Beige;
        }

        private void btnRestartGame_MouseLeave(object sender, EventArgs e)
        {
            btnRestartGame.ForeColor = Color.Beige;
            btnRestartGame.BackColor = Color.Black;
        }

        private void btnBackToMainScr_MouseEnter(object sender, EventArgs e)
        {
            btnBackToMainScr.ForeColor = Color.Black;
            btnBackToMainScr.BackColor = Color.Beige;
        }

        private void btnBackToMainScr_MouseLeave(object sender, EventArgs e)
        {
            btnBackToMainScr.ForeColor = Color.Beige;
            btnBackToMainScr.BackColor = Color.Black;
        }

        private void btnBackToMainScr_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
            Application.Restart();
        }
        /// <summary>
        /// Logical Game Code
        /// </summary>
        enum enPlayers
        {
            ePlayer1, ePlayer2, eComputer
        }
        enum enWinner
        {
            ePlayer1, ePlayer2, Draw, InProgress
        }
        enum enGameDiffculty
        {
            eEasy, eMedium, eHard, eRandom
        }
        struct stGameStatus
        {
            public string Player1Name;
            public string Player2Name;
            public enPlayers PlayerTurn;
            public enGameDiffculty Diffculty;
            public enWinner Winner;
            public byte PlayCount;
            public byte TimerCountDown;
            public bool ForceComputerToPlay;
            public bool GameOver;
        }
        stGameStatus GameStatus;
        private void btn_Start_Click(object sender, EventArgs e)
        {
            DisableFirstPanel();
            EnableSecondPanel();
            if (txt_Player_Name.Text == "")
            {
                // play vs friend mode
                GameStatus.Player1Name = txt_Player1Name.Text.Trim();
                GameStatus.Player2Name = txt_Player2_Name.Text.Trim();
            }
            else
            {
                // play vs computer mode
                GameStatus.Player1Name = txt_Player_Name.Text.Trim();
                GameStatus.Player2Name = "Computer";
                lblLevels.Text = cbDiffculty.Text;
                lblLevel.Visible = true;
                lblLevels.Visible = true;
                switch(cbDiffculty.Text.ToString())
                {
                    case "Easy":
                        {
                            GameStatus.Diffculty = enGameDiffculty.eEasy;
                            break;
                        }
                    case "Medium":
                        {
                            GameStatus.Diffculty = enGameDiffculty.eMedium;
                            lblLevels.ForeColor = Color.Orange;
                            break;
                        }
                    case "Hard":
                        {
                            GameStatus.Diffculty = enGameDiffculty.eHard;
                            lblLevels.ForeColor = Color.IndianRed;
                            break;
                        }
                }
            }
            ResetGame();
        }
        private void ResetTextBoxes()
        {
            txt_Player_Name.Text = "";
            txt_Player1Name.Text = "";
            txt_Player2_Name.Text = "";
            cbDiffculty.Text = "";
            lblLevels.Text = "";
        }
        private void EndGame()
        {
            GameStatus.ForceComputerToPlay = false;
            GameStatus.GameOver = true;
            lblWhoWillPlay.Text = "Game Over";
            lblWhoWillPlay.ForeColor = Color.Red;
            GameStatus.PlayerTurn = enPlayers.ePlayer1;
            ResetTime("00:00");
            switch (GameStatus.Winner)
            {
                case enWinner.ePlayer1:
                    {
                        lblWhoWinedTheGame.Text = GameStatus.Player1Name;
                        lblWhoWinedTheGame.ForeColor = Color.GreenYellow;
                        break;
                    }
                case enWinner.ePlayer2: // maybe computer or player2
                    {
                        lblWhoWinedTheGame.Text = GameStatus.Player2Name;
                        lblWhoWinedTheGame.ForeColor = Color.GreenYellow;
                        break;
                    }
                default:
                    {
                        lblWhoWinedTheGame.Text = "Draw";
                        lblWhoWinedTheGame.ForeColor = Color.LightYellow;
                        break;
                    }
            }
            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void DisableButton(Button btn)
        {
            if (btn.Tag.ToString() != "Win") btn.Enabled = false;
        }
        void DisableButtonsExcept(Button button1, Button button2, Button button3)
        {
            button1.Tag = "Win";
            button2.Tag = "Win";
            button3.Tag = "Win";
            for (byte i = 1; i <= 9; i++)
            {
                DisableButton(GetButtonByNumber(i));
            }
        }
        bool CheckValues(Button button1, Button button2, Button button3)
        {
            char btn1firstchar = button1.Tag.ToString()[0];
            char btn2firstchar = button2.Tag.ToString()[0];
            char btn3firstchar = button3.Tag.ToString()[0];
            if (btn1firstchar != '?' && btn1firstchar == btn2firstchar && btn1firstchar == btn3firstchar)
            {
                button1.BackColor = Color.GreenYellow;
                button2.BackColor = Color.GreenYellow;
                button3.BackColor = Color.GreenYellow;
                if (btn1firstchar == 'X')
                {
                    GameStatus.Winner = enWinner.ePlayer1;
                    DisableButtonsExcept(button1, button2, button3);
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.ePlayer2;
                    DisableButtonsExcept(button1, button2, button3);
                    EndGame();
                    return true;
                }
            }
            return false;
        }
        private bool CheckWinner()
        {
            if (CheckValues(btn1, btn2, btn3)) return true;
            if (CheckValues(btn4, btn5, btn6)) return true;
            if (CheckValues(btn7, btn8, btn9)) return true;
            if (CheckValues(btn1, btn4, btn7)) return true;
            if (CheckValues(btn2, btn5, btn8)) return true;
            if (CheckValues(btn3, btn6, btn9)) return true;
            if (CheckValues(btn1, btn5, btn9)) return true;
            if (CheckValues(btn3, btn5, btn7)) return true;
            return false;
        }
        private Button GetButtonByNumber(byte btnNum)
        {
            Button[] buttons = { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            return buttons[btnNum - 1];
        }
        private void ResetButtonTag(Button btn)
        {
            btn.Tag = "?";
        }
        private void ResetButton(Button btn)
        {
            btn.Enabled = true;
            btn.Image = Resources.question_mark_96;
            btn.BackColor = Color.Transparent;
            ResetButtonTag(btn);
        }
        private void ResetGame()
        {
            for (byte i = 1; i <= 9; i++)
            {
                ResetButton(GetButtonByNumber(i));
            }
            ResetTime();
            GameStatus.PlayerTurn = enPlayers.ePlayer1;
            GameStatus.TimerCountDown = 20;
            GameStatus.Winner = enWinner.InProgress;
            GameStatus.PlayCount = 0;
            lblWhoWillPlay.Text = GameStatus.Player1Name;
            lblWhoWillPlay.ForeColor = Color.Beige;
            lblWhoWinedTheGame.Text = "In Progress";
            lblWhoWinedTheGame.ForeColor = Color.Beige;
            GameStatus.GameOver = false;
            if (string.IsNullOrEmpty(cbDiffculty.Text))
            {
                lblLevel.Visible = false;
                lblLevels.Visible = false;
            }
            timer.Start();
        }
        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
        private bool ValidateChoice(Button btn, string Startwith = "?")
        {
            return btn.Tag.ToString().StartsWith(Startwith);
        }
        private Button GetAValidRandomButton()
        {
            Random random = new Random();
            Button btn;
            while (true)
            {
                btn = GetButtonByNumber(Convert.ToByte(random.Next(1, 10)));
                if (ValidateChoice(btn))
                {
                    break;
                }
            }
            return btn;
        }
        private bool ComputerChoice(Button First, Button Second, Button Third, string StartWith = "X")
        {
            if (ValidateChoice(First, StartWith) && ValidateChoice(Second, StartWith))
            {
                if (ValidateChoice(Third))
                {
                    ChangeImage(Third);
                    return true;
                }
            }
            else if (ValidateChoice(Second, StartWith) && ValidateChoice(Third, StartWith))
            {
                if (ValidateChoice(First))
                {
                    ChangeImage(First);
                    return true;
                }
            }
            else if (ValidateChoice(First, StartWith) && ValidateChoice(Third, StartWith))
            {
                if (ValidateChoice(Second))
                {
                    ChangeImage(Second);
                    return true;
                }
            }
            return false;
        }
        private bool ComputerAttack()
        {
            string StartWith = "O";
            if (GameStatus.ForceComputerToPlay == true) // we wouldn't have to choose a smart choice for a lazy player
            {
                GameStatus.ForceComputerToPlay = false;
                ChangeImage(GetAValidRandomButton());
                return true;
            }
            if (ComputerChoice(btn1, btn2, btn3, StartWith)) return true;
            if (ComputerChoice(btn4, btn5, btn6, StartWith)) return true;
            if (ComputerChoice(btn7, btn8, btn9, StartWith)) return true;
            if (ComputerChoice(btn1, btn4, btn7, StartWith)) return true;
            if (ComputerChoice(btn2, btn5, btn8, StartWith)) return true;
            if (ComputerChoice(btn3, btn6, btn9, StartWith)) return true;
            if (ComputerChoice(btn1, btn5, btn9, StartWith)) return true;
            if (ComputerChoice(btn3, btn5, btn7, StartWith)) return true;
            return false;
        }
        private bool EasyDefence()
        {
            if (ComputerChoice(btn1, btn2, btn3))
                return true;
            else if (ComputerChoice(btn4, btn5, btn6))
                return true;
            return false;
        }
        private bool MediumDefence()
        {
            if (EasyDefence())
                return true;
            else if (ComputerChoice(btn7, btn8, btn9))
                return true;
            else if (ComputerChoice(btn1, btn4, btn7))
                return true;
            else if (ComputerChoice(btn2, btn5, btn8))
                return true;
            return false;
        }
        private bool HardDefence()
        {
            if (MediumDefence())
                return true;
            else if (ComputerChoice(btn3, btn6, btn9))
                return true;
            else if (ComputerChoice(btn1, btn5, btn9))
                return true;
            else if (ComputerChoice(btn3, btn5, btn7))
                return true;
            return false;
        }
        private void ChooseDefendingButtonAccordingToGameDiffculty()
        {
            bool ButtonChecked = false;
            switch (GameStatus.Diffculty)
            {
                case enGameDiffculty.eEasy:
                    {
                        if (EasyDefence())
                            ButtonChecked = true;
                        break;
                    }
                case enGameDiffculty.eMedium:
                    {
                        if (MediumDefence())
                            ButtonChecked = true;
                        break;
                    }
                case enGameDiffculty.eHard:
                    {
                        if (HardDefence())
                            ButtonChecked = true;
                        break;
                    }
            }
            if (!ButtonChecked)
                ChangeImage(GetAValidRandomButton());
        }
        private void ComputerTurn()
        {
            if (!GameStatus.ForceComputerToPlay)
                GameStatus.PlayerTurn = enPlayers.ePlayer2;
            if (!ComputerAttack())
                ChooseDefendingButtonAccordingToGameDiffculty();
        }
        private void ChangeImage(Button btn)
        {
            bool Timer = true;
            if (btn.Tag.ToString().StartsWith("?"))
            {
                switch (GameStatus.PlayerTurn)
                {
                    case enPlayers.ePlayer1:
                        {
                            btn.Image = Resources.X;
                            btn.Tag = "X" + btn.Tag.ToString().Substring(1);
                            lblWhoWillPlay.Text = GameStatus.Player2Name;
                            GameStatus.PlayCount++;
                            if (cbDiffculty.Text != "")
                            {
                                GameStatus.PlayerTurn = enPlayers.eComputer;
                            }
                            else
                            {
                                GameStatus.PlayerTurn = enPlayers.ePlayer2;
                            }
                            if (CheckWinner())
                            {
                                Timer = false;
                            }
                            else
                            {
                                ResetTime();
                            }
                            break;
                        }
                    case enPlayers.ePlayer2:
                        {
                            btn.Image = Resources.O;
                            btn.Tag = "O" + btn.Tag.ToString().Substring(1);
                            GameStatus.PlayCount++;
                            lblWhoWillPlay.Text = GameStatus.Player1Name;
                            GameStatus.PlayerTurn = enPlayers.ePlayer1;
                            if (CheckWinner())
                            {
                                Timer = false;
                            }
                            else
                            {
                                ResetTime();
                            }
                            break;
                        }
                    case enPlayers.eComputer:
                        {
                            ComputerTurn();
                            break;
                        }
                }
                timer.Enabled = Timer;
                if (!GameStatus.GameOver)
                {
                    CheckDraw();
                }
            }
            else
            {
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void DisableButtons()
        {
            for (byte i = 1; i <= 9; i++)
            {
                GetButtonByNumber(i).Enabled = false;
            }
        }
        private bool CheckDraw()
        {
            if (GameStatus.PlayCount == 9)
            {
                GameStatus.Winner = enWinner.Draw;
                DisableButtons();
                EndGame();
                return true;
            }
            return false;
        }
        private void btn_Click(object sender, EventArgs e)
        {
            if (GameStatus.PlayerTurn != enPlayers.eComputer)
                ChangeImage((Button)sender);
        }

        private  void ResetTime(string Time = "00:20")
        {
            timer.Enabled = false;
            if (GameStatus.PlayerTurn == enPlayers.eComputer)
            {
                GameStatus.TimerCountDown = 1;
                Time = "00:01";
                lblCountDown.Visible = false;
                lblTimer.Visible = false;
            }
            else
            { 
                GameStatus.TimerCountDown = 20;
                lblCountDown.Visible = true;
                lblTimer.Visible = true;
            }
            lblCountDown.Text = Time;
            lblCountDown.ForeColor = Color.Beige;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            GameStatus.TimerCountDown--;
            lblCountDown.Text = "00:" + GameStatus.TimerCountDown;
            if (GameStatus.TimerCountDown < 11 && !(GameStatus.PlayerTurn == enPlayers.eComputer))
            {
                lblCountDown.ForeColor = Color.Red;
            }
            if (GameStatus.TimerCountDown == 0)
            {
                GameStatus.ForceComputerToPlay = true;
                ComputerTurn();
                ResetTime();
                if (!GameStatus.GameOver)
                {
                    timer.Enabled = true;
                }
            }
        }
    }
}