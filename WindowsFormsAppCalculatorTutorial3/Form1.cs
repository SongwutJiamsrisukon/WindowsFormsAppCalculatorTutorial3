using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppCalculatorTutorial
{
    public partial class Form1 : Form
    {
        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
      
        }

        #region Clearing Methods
        private void CEButton_Click(object sender, EventArgs e)
        {
            this.UserInputText.Text = "";//string.Empty;
            FocusInputText();
        }
        private void DelButton_Click(object sender, EventArgs e)
        {
            DeleteTextValue();
        }
        #endregion

        #region Operator Method
        private void EqualButton_Click(object sender, EventArgs e)
        {
            CalculateEquation();
        }


        private void DivideButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("/");
        }

        private void MultipleButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("*");
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("-");
        }

        private void AdditionButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("+");
        }
        #endregion

        #region Number Methods
        private void DotButton_Click(object sender, EventArgs e)
        {
            InsertTextValue(".");
        }

        private void NumButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InsertTextValue(btn.Text);
        }

        #endregion

        #region Helpers
        private void FocusInputText()
        {
            this.UserInputText.Focus();
        }

        private void InsertTextValue(string text)
        {
            int selectionPosition = this.UserInputText.SelectionStart;//get
            this.UserInputText.Text = this.UserInputText.Text.Insert(selectionPosition, text);
            this.UserInputText.SelectionStart = selectionPosition + text.Length;//set
            //this.UserInputText.SelectionLength = 0; // ค่ามากจะถูกลากถมดำตามจำนวนตัว
            FocusInputText();
        }
        private void DeleteTextValue()
        {
            if (this.UserInputText.SelectionStart == 0)
            {
            }
            else
            {
                int selectionPosition = this.UserInputText.SelectionStart;//get
                this.UserInputText.Text = this.UserInputText.Text.Remove(selectionPosition - 1, 1);
                this.UserInputText.SelectionStart = selectionPosition - 1;//set

            }
            FocusInputText();
        }

        private void CalculateEquation()
        {
           
            this.CalculationResultText.Text = ParseOperation();

            FocusInputText();
        }

        private string ParseOperation()
        {
            try
            {
                var input = this.UserInputText.Text;

                //remove all space
                input = input.Replace(" ", "");

                //create a new top level operation
                var operation = new Operation();
                var leftSide = true;

                for(int i = 0; i < input.Length; i++)
                {
                    if("0123456789.".Any(c => input[i] == c))
                    {
                        if (leftSide)
                            operation.LeftSide = AddNumberPart(operation.LeftSide, input[i]);
                    }
                }

                return "";
            }
            catch (Exception ex)
            {
                return $"Invalid equation. {ex.Message}";// == "Invalid equation." + ex.Message
            }
        }

        private string AddNumberPart(string stringNumber, char newChar)
        {
            if (newChar == '.' && stringNumber.Contains('.')) {
                throw new InvalidOperationException($"Number {stringNumber} already contains a. and another cannot be added");
                //throw new InvalidOperationException("Number "+ stringNumber + " already contains a. and another cannot be added");
            }
            return stringNumber + newChar;
        }

        #endregion
    }
}
