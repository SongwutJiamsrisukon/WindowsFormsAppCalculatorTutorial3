﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppCalculatorTutorial
{
    //Holds information about a single step of calculation
    public class Operation
    {

        public string LeftSide { get; set; }
        public string RightSide { get; set; }
        public OperationType OperationType { get; set; }
        public Operation InnerOperation{ get; set; }

        public Operation()
        {
            this.LeftSide = "";
            this.RightSide = "";
        }
    }
}
