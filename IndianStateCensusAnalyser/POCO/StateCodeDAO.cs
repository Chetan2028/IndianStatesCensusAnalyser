using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.POCO
{
    public class StateCodeDAO
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateCodeDAO"/> class.
        /// </summary>
        /// <param name="v1">The v1.</param>
        /// <param name="v2">The v2.</param>
        /// <param name="v3">The v3.</param>
        /// <param name="v4">The v4.</param>
        public StateCodeDAO(string v1, string v2, string v3, string v4)
        {
            this.serialNumber = Convert.ToInt32(v1);
            this.stateName = v2;
            this.tin = Convert.ToInt32(v3);
            this.stateCode = v4;
        }

    }
}
