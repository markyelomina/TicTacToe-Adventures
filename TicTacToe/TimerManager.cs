using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public class TimerManager
    {
        private Timer turnTimer;
        private int timeLeft;
        private Action onTimerEnd;
        private Label timerLabel;

        public TimerManager(int initialTime, Action onTimerEnd, Label timerLabel)
        {
            this.timeLeft = initialTime;
            this.onTimerEnd = onTimerEnd;
            this.timerLabel = timerLabel;

            turnTimer = new Timer();
            turnTimer.Interval = 1000;
            turnTimer.Tick += TimerTick;
        }

        public void StartTimer()
        {
            timeLeft = 11; // Reset the timer to 10 seconds
            turnTimer.Start();
        }

        public void StopTimer()
        {
            turnTimer.Stop();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                timerLabel.Text = $"Time Left: {timeLeft}s";
            }
            else
            {
                turnTimer.Stop();
                onTimerEnd?.Invoke();
            }
        }

        public int GetTimeLeft()
        {
            return timeLeft;
        }
    }
}
