using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace MazeRemote
{
    public partial class Main : Form
    {
        mazeCOMM m;
        float stepSize;
        float angle;
        double xPos, yPos, zPos,anglePos;
        double mazeTime;
        int scoreValue;

        private void getInternalValues()
        {
            if (m.connected)
                m.connected = mazeCOMM.Connected() > 0 ? true : false;

            int.TryParse(portTextBox.Text, out m.port);
            if (m.port <= 0 || m.port > 50000)
            {
                MessageBox.Show("Invalid Port number");
                portTextBox.Text = "6350";
                m.port = 6350;
                return;
            }
            float.TryParse(stepsizeText.Text, out stepSize);
            if (stepSize<0)
            {
                MessageBox.Show("Invalid StepSize");
                stepsizeText.Text = "5";
                stepSize = 5;
                return;
            }
            float.TryParse(turnSizeText.Text, out angle);
            if (angle < 0)
            {
                MessageBox.Show("Invalid Turn Size");
                turnSizeText.Text = "90";
                angle = 90;
                return;
            }

            double.TryParse(xTextBox.Text, out xPos);
            double.TryParse(yTextBox.Text, out yPos);
            double.TryParse(zTextBox.Text, out zPos);
            double.TryParse(angleTextBox.Text, out anglePos);
            int.TryParse(scoreTextBox.Text, out scoreValue);
            
        }

        public Main()
        {
            InitializeComponent();

            m = new mazeCOMM();
            ConnectButton.Text = "Start";
            toolStripStatusLabel1.Text = "Disconnected";
            statusStrip1.BackColor = Color.Red;
            getInternalValues();
            EnableDisable();
        }

        private void EnableDisable()
        {
            forwardButton.Enabled = m.connected;
            backwardButton.Enabled = m.connected;
            turnLeftButton.Enabled = m.connected;
            turnRightButton.Enabled = m.connected;
            strafeLeftButton.Enabled = m.connected;
            strafeRightButton.Enabled = m.connected;
            jumpButton.Enabled = m.connected;
            cueButton.Enabled = m.connected;
            messageButton.Enabled = m.connected;
            getPositionButton.Enabled = m.connected;
            setPositionButton.Enabled = m.connected;
            nextButton.Enabled = m.connected;
            boundedCheck.Enabled = m.connected;
            getScoreButton.Enabled = m.connected;
            setScoreButton.Enabled = m.connected;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (m.connected)
            {
                mazeCOMM.Disconnect();
                m.connected = false;
                
                ConnectButton.Text = "Start";
                toolStripStatusLabel1.Text = "Disconnected";
                statusStrip1.BackColor=Color.Red;
                EnableDisable();
                return;
            }
            getInternalValues();
            
            if (!m.connected)
            {
                ConnectButton.Text = "Connecting...";
                toolStripStatusLabel1.Text = "Connecting...";
                statusStrip1.BackColor=Color.Yellow;
                
                mazeCOMM.Listen(m.port);
                m.connected = (mazeCOMM.Connected()==1);
                if (m.connected)
                {
                    //mazeCOMM.SetMoveSpeed(false,100);
                    ConnectButton.Text = "Disconnect";
                    toolStripStatusLabel1.Text = "Connected";
                    statusStrip1.BackColor=Color.Green;
                }
                else
                {
                    MessageBox.Show("Could not connect");
                    toolStripStatusLabel1.Text = "Disconnected";
                    statusStrip1.BackColor=Color.Red;
                }
            }
            EnableDisable();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            getInternalValues();
            mazeCOMM.MoveForward(stepSize);
        }

        private void backwardButton_Click(object sender, EventArgs e)
        {
            getInternalValues();
            mazeCOMM.MoveBackward(stepSize);
        }

        private void strafeLeftButton_Click(object sender, EventArgs e)
        {
            getInternalValues();
            mazeCOMM.StrafeLeft(stepSize);
        }

        private void strafeRightButton_Click(object sender, EventArgs e)
        {
            getInternalValues();
            mazeCOMM.StrafeRight(stepSize);
        }

        private void jumpButton_Click(object sender, EventArgs e)
        {
            getInternalValues();
            mazeCOMM.Jump();
        }

        private void turnRightButton_Click(object sender, EventArgs e)
        {
            getInternalValues();
            mazeCOMM.LookRight(angle);
        }

        private void turnLeftButton_Click(object sender, EventArgs e)
        {
            getInternalValues();
            mazeCOMM.LookLeft(angle);
        }

        private void cueButton_Click(object sender, EventArgs e)
        {
            getInternalValues();
            mazeCOMM.SendCue();
        }

        private void messageButton_Click(object sender, EventArgs e)
        {
            getInternalValues();
            unsafe
            {
                //fixed (char* s = messageText.Text)
                //{
                    
                //    mazeCOMM.SendAlert(s, 1000);

                //}
                //byte[] s= Convert.FromBase64String(messageText.Text);
                StringBuilder message = new StringBuilder(messageText.Text);
                mazeCOMM.SendAlert(message, 1000);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            getInternalValues();

            mazeCOMM.SetPosition(xPos, yPos, zPos, anglePos);
        }

        private void getPositionButton_Click(object sender, EventArgs e)
        {
            getInternalValues();
            double[] vec;
            vec = new double[5];
            mazeCOMM.GetPosition(vec);
            xPos = vec[0];
            yPos = vec[1];
            zPos = vec[2];
            anglePos = vec[3];
            mazeTime = vec[4];
            xTextBox.Text = xPos.ToString();
            yTextBox.Text = yPos.ToString();
            zTextBox.Text = zPos.ToString();
            angleTextBox.Text = anglePos.ToString();
            updateText.Text = "Last Updated at " + mazeTime;
        }

        private void getScoreButton_Click(object sender, EventArgs e)
        {
            getInternalValues();

            scoreValue=mazeCOMM.GetScore();

            xTextBox.Text = scoreValue.ToString();
            updateText.Text = "Score Updated at " + mazeTime;
        }

        private void setScoreButton_Click(object sender, EventArgs e)
        {
            getInternalValues();
            mazeCOMM.SetScore(scoreValue);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            getInternalValues();
            mazeCOMM.NextLevel();
        }

        private void boundedCheck_CheckedChanged(object sender, EventArgs e)
        {
            getInternalValues();
            mazeCOMM.BoundedMovement(boundedCheck.Checked);
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }


        
    }
}
