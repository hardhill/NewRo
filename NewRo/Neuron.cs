using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace NewRo
{
    class Neuron
    {
        private decimal weight;
        private decimal output;
        public delegate void TrainEvent(object sender, decimal weight);
        public event TrainEvent OnTrain;
        public decimal LastError { get; private set; }
        public Neuron(decimal w)
        {
            weight = w;
        }
        public Neuron()
        {
            
            weight = 0.5m;
        }
        public decimal InputProcessData(decimal inp)
        {
            output = inp * weight;
            return output;
        }
        public decimal RestoreData(decimal output)
        {
            this.output = output;
            return this.output / weight;
        }
        public void ResetNeuron()
        {
            weight = 0.5m;
        }
        public void Train(decimal input,decimal expectedResult)
        {
            var actualResult = input * weight;
            LastError = expectedResult - actualResult;
            var correction = LastError / actualResult;
            weight += correction;
            OnTrain?.Invoke(this, weight);
        }
    }
}
