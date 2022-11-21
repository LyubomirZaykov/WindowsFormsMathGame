
using System.Drawing.Text;
using System.Media;

namespace MyNotesApp
{
    public partial class Form1 : Form
    {
        
        //Create random object call randomizer to
        //generate random numbers.
        Random randomizer=new Random();
        //These integers variables store the numbers
        //for the addition problem
        int addend1;
        int addend2;

        //These integers variables store the numbers
        //for the substraction problem
        int minuend;
        int substrahend;

        //These integers variables store the numbers
        //for the multiplication problem
        int multiplicand;
        int multiplier;

        //These integers variables store the numbers
        //for the division problem
        int dividend;
        int divisor;

        public int timeLeft;
        private bool isAdditionTrue;
        private bool isSubstractionTrue;
        private bool isMultiplicationTrue;
        private bool isDivisionTrue;
        private void StartTheQuiz()
        {
        //Fill the addition problem
        //Generate two random numbers to add
        //Store the values in the variables addend1 and addend2
        addend1 = randomizer.Next(51);
        addend2 = randomizer.Next(51);
        //Convert the two randomly generated numbers into strings 
        //so that they can be displayed 
        //in the label controls.
        plusLeftLabel.Text = addend1.ToString();
        plusRightLabel.Text = addend2.ToString();
        //'sum' is the number of the NumericUpDown control.
        //This step makes sure its value is zero before 
        //adding any values to it.
        sum.Value = 0;
            
        //Fill the substraction problem
        //Generate two random numbers to substract, by making sure
        //that first is bigger than second, so that the difference
        //is positive number
        minuend=randomizer.Next(0,100);
        substrahend=randomizer.Next(0,minuend);
        //Convert the two randomly generated numbers into strings 
        //so that they can be displayed in the label controls.
        minusLeftLabel.Text = minuend.ToString();
        minusRightLabel.Text=substrahend.ToString();
        //'difference' is the number of the NumericUpDown control.
        //This step makes sure its value is zero before 
        //adding any values to it.
        difference.Value = 0;

        //Fill the multiplication problem
        //Generate two random numbers to multiply, by making sure
        //that the product cannot be bigger than 100
        multiplier = randomizer.Next(11);
        multiplicand = randomizer.Next(11);
        //Convert the two randomly generated numbers into strings
        //so that they can be displayed in the label controls
        timesLeftLabel.Text = multiplier.ToString();
        timesRightLabel.Text = multiplicand.ToString();
        //'product' is the number of the NumericUpDown control.
        //This step makes sure its value is zero before 
        //adding any values to it.
        product.Value = 0;

        //Fill the multiplication problem
        //Generate two random numbers to divide, by making sure
        //that the quotient is whole number and math operations
        //are valis
        dividend = randomizer.Next(1, 100);
        divisor = randomizer.Next(1, 100);
            while (dividend%divisor!=0
                ||divisor==0
                ||dividend<divisor
                ||dividend/divisor>10)
            {
                dividend = randomizer.Next(1, 100);
                divisor = randomizer.Next(1, 10);
            }
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();

            quotient.Value = 0;
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
        private bool CheckTheAnswer()
        {
            isAdditionTrue = addend1 + addend2 == sum.Value;
            isSubstractionTrue = minuend - substrahend == difference.Value;
            isMultiplicationTrue = multiplicand * multiplier == product.Value;
            isDivisionTrue = dividend / divisor == quotient.Value;
            
            if (isAdditionTrue
                &&isSubstractionTrue
                &&isMultiplicationTrue
                &&isDivisionTrue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                timeLabel.BackColor = Color.White;
                MessageBox.Show("You got all the answers right!",
                    "Congratulations!");
                startButton.Enabled = true;
            }
            else if(timeLeft>0)
            {
                
                timeLeft = timeLeft - 1;
                if (timeLeft<6)
                {
                    timeLabel.BackColor = Color.Red;
                    SystemSounds.Beep.Play();
                }
                timeLabel.Text = timeLeft + "seconds";
            }
            else
            {
                timer1.Stop();
                SystemSounds.Beep.Play();
                SystemSounds.Beep.Play();
                SystemSounds.Beep.Play();
                timeLabel.BackColor = Color.White;
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.",
                    "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - substrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled=true;

            }
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox!=null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0,lengthOfAnswer);
            }
        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {
            CheckTheAnswer();
            if (isAdditionTrue)
            {
                PlayCorrectAnswerSound();
            }
        }

        private void difference_ValueChanged(object sender, EventArgs e)
        {
            CheckTheAnswer();
            if (isSubstractionTrue)
            {
                PlayCorrectAnswerSound();
            }
        }

        private void product_ValueChanged(object sender, EventArgs e)
        {
            CheckTheAnswer();
            if (isMultiplicationTrue)
            {
                PlayCorrectAnswerSound();
            }
        }

        private void quotient_ValueChanged(object sender, EventArgs e)
        {
            CheckTheAnswer();
            if (isDivisionTrue)
            {
                PlayCorrectAnswerSound();
            }
        }
        private void PlayCorrectAnswerSound()
        {
            SystemSounds.Hand.Play();
        }
    }
}