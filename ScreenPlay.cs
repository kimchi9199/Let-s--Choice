using CoreLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;


namespace Project_Group_10
{
    public partial class Start : Form
    {
        int Time = 60;
        int NumberOfQuestion;
        int QuestionCount = 0;
        int id_question = 1;
        int Score = 0;
        int Life = 5;
        bool UsedHint = false;
        int Level = 0;
        ArrayList CheckedID = new ArrayList();


        //In project Project_Group_10 has a class name Question as well.
        //To avoid ambiguity, the following format let we know that we are using class 
        //Question in CoreLogic projec
        CoreLogic.Question CurrentQuestion = new CoreLogic.Question();
        Answer CurrentAnswer = new Answer();


        CorrectAnswer correctAnswer = new CorrectAnswer();
        protected SoundPlayer soundPlayer;
        public Start()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer("sound_game_LetChoice.wav");
            //soundPlayer.Play();
            // soundPlayer.SoundLocation = @".\sound_game_LetChoice";
            timer1.Start();
            GetQuestion();
        }

        private void GetQuestion()
        {
            QuestionDAO question = new QuestionDAO();
            AnswerDAO answer = new AnswerDAO();
            NumberOfQuestion = Convert.ToInt32(question.GetNumberOfQuestion());
            Random ranID = new Random();
            id_question = ranID.Next(1, 101);

            //textBox_Level.Text = NumberOfQuestion.ToString();

            while (CheckDuplicate.IsApear(id_question, CheckedID) == true && CheckedID.Count < NumberOfQuestion)
            {
                id_question = ranID.Next(1, 101);
            }
            CheckedID.Add(id_question);

            CurrentQuestion = question.GetQuestion(id_question);
            question2.Text = CurrentQuestion.GetND_CauHoi;

            //question2.Text = question.GetQuestion(id_question);
            //MessageBox.Show(id_question.ToString());


            CurrentAnswer = answer.GetAnswer(id_question);
            answerBox1A.Text = CurrentAnswer.GetChoice_A;
            answerBox2B.Text = CurrentAnswer.GetChoice_B;
            answerBox3C.Text = CurrentAnswer.GetChoice_C;
            answerBox4D.Text = CurrentAnswer.GetChoice_D;

            CorrectAnswerDAO correctanswerDAO = new CorrectAnswerDAO();
            correctAnswer = correctanswerDAO.GetCorrectAnswer(id_question);
            UsedHint = false;
            QuestionCount++;
        }

        private void AnswerEventHandler(AnswerBox ansBox, CorrectAnswer crrAns)
        {
            if (ansBox.Text == crrAns.GetNoiDung_CorrectionAnswer)
            {
                if (UsedHint == false)
                {
                    Score++;
                    MessageBox.Show("Correct");
                }
                Level++;
                Time = 60;
                GetQuestion();
            }
            else if (ansBox.Text != crrAns.GetNoiDung_CorrectionAnswer)
            {
                Life--;
                Time = 60;
                MessageBox.Show("Incorrect");
                GetQuestion();
            }
        }

        private void btn_Home_Click_1(object sender, EventArgs e)
        {
            ScreenStart reset = new ScreenStart() ;
            reset.Show();
            this.Hide();
        }

        private void questionBox1_Load(object sender, EventArgs e)
        {

        }
        
           
        private void buttonSound1_CheckedChanged(object sender, EventArgs e)
        {
            if(buttonSound1.Checked)
            {
                buttonSound1.Text = "0";
                try
                {
                    soundPlayer.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                buttonSound1.Text = "1";
                soundPlayer.Stop();
            }
        }

        private void Start_Load(object sender, EventArgs e)
        {

        }

       

        private void buttonStart_Next_Click(object sender, EventArgs e)
        {
            //GetQuestion();
            
        }

        

        private void button_Hint_Click(object sender, EventArgs e)
        {
            if(Score >=3)
            {
                UsedHint = true;
                Score = Score - 3;
                MessageBox.Show(correctAnswer.GetNoiDung_CorrectionAnswer);
            }
            else
            {
                MessageBox.Show("Not enough score to use hint.");
            }
        }



        private void answerBox1A_Click(object sender, EventArgs e)
        {
            if(QuestionCount <= NumberOfQuestion)
            {
                var answerBox = sender as AnswerBox;
                AnswerEventHandler(answerBox, correctAnswer);
            }
            else
            {
                MessageBox.Show("End game");
            }
            
        }

        private void answerBox2B_Click(object sender, EventArgs e)
        {
            if(QuestionCount <= NumberOfQuestion)
            {
                var answerBox = sender as AnswerBox;
                AnswerEventHandler(answerBox, correctAnswer);
            }
            else
            {
                MessageBox.Show("End game");
            }
        }

        private void answerBox3C_Click(object sender, EventArgs e)
        {
            if (QuestionCount <= NumberOfQuestion)
            {
                var answerBox = sender as AnswerBox;
                AnswerEventHandler(answerBox, correctAnswer);
            }            else
            {
                MessageBox.Show("End game");
            }        }

        private void answerBox4D_Click(object sender, EventArgs e)
        {
            if (QuestionCount <= NumberOfQuestion)
            {
                var answerBox = sender as AnswerBox;
                AnswerEventHandler(answerBox, correctAnswer);
            }            else
            {
                MessageBox.Show("End game");
            }        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Life > 0)
            {
                if (QuestionCount <= NumberOfQuestion)
                {
                    Time--;
                    label_Time.Text = Time.ToString();
                    label_Score.Text = Score.ToString();
                    label_Life.Text = Life.ToString();
                    label_Level.Text = "Level: " + Level.ToString();
                    if (Score <= 0)
                    {
                        Score = 0;
                    }
                    if (Time <= 0)
                    {
                        Time = 60;
                        Life--;
                        GetQuestion();
                    }
                }
                else if (QuestionCount > NumberOfQuestion)
                {
                    timer1.Stop();
                    answerBox1A.Enabled = false;
                    answerBox2B.Enabled = false;
                    answerBox3C.Enabled = false;
                    answerBox4D.Enabled = false;
                    button_Hint.Enabled = false;
                    MessageBox.Show("End game");
                }
            }
            if (Life <= 0)
            {
                Life = 0;
                label_Life.Text = "0";
                answerBox1A.Enabled = false;
                answerBox2B.Enabled = false;
                answerBox3C.Enabled = false;
                answerBox4D.Enabled = false;
                button_Hint.Enabled = false;
                timer1.Stop();
                MessageBox.Show("You lose");
            }
            
            
        }

        private void Start_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ScreenStart scrStart = new ScreenStart();
            //scrStart.ShowDialog();
            ////this.Close();
            Application.Exit();
        }
    }
}
