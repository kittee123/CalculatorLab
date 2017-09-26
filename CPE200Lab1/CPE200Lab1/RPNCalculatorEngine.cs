using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            Stack<string> rpnStack = new Stack<string>();
            if(str is null)
            {
                return "E";
            }
            List<string> parts = str.Split(' ').ToList<string>();
            string result = null;
            string firstOperand, secondOperand;

            foreach (string token in parts)
            {
                if (isNumber(token))
                {
                    if (double.Parse(token).ToString() != token)
                    {
                        return "E";
                    }
                    rpnStack.Push(token);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?
                    if(rpnStack.Count < 2)
                    {
                        return "E";
                    }
                    secondOperand = rpnStack.Pop();
                    firstOperand = rpnStack.Pop();
                    result = calculate(token, firstOperand, secondOperand, 4);
                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);
                }
                else if (token == "") ;
                else return "E";
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            try
            {
                result = rpnStack.Pop();
            }
            catch(Exception ex)
            {
                return "E";
            }
            if (rpnStack.Count != 0) return "E";
            else return Convert.ToDouble(result).ToString();
        }
    }
}
