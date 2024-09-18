using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{



    
    internal class History
    {

        private int diff;
        private String calculation;
        private float userResponse;
        private float correctResponse;
        private bool correct;

        public History(int difficulty, String calculation, float userResponse, float correctResponse, bool correct) {
            this.diff = difficulty;
            this.calculation = calculation;
            this.userResponse = userResponse;
            this.correctResponse = correctResponse;
            this.correct = correct;
        }

        public int getDiff() { return diff; }
        public String getCalculation() { return calculation;}
        public float getUserResponse() { return userResponse;}
        public float getCorrectResponse() { return correctResponse; }
        public bool isCorrect() { return correct; }


    }
}
