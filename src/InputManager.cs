using System;
using System.Collections.Generic;

namespace LTShowcase
{
    public class InputManager
    {
        public InputManager() { }

        public List<int> ParseInput(string input)
        {
            input += ','; //ensures last token is processed.
            List<int> output = new List<int>();
            string number = "";
            string rangeEnd = "";
            bool parsingRange = false;
            //foreach char in input
            foreach (char ch in input)
            {
                if (ch == ' ')
                {
                    continue;
                }
                if (char.IsDigit(ch))
                {
                    if (parsingRange)
                    {
                        rangeEnd += ch;
                    }
                    else
                    {
                        number += ch;
                    }
                }
                if (ch == ',' && number != "")
                {
                    if (parsingRange)
                    {
                        int start, end;
                        Int32.TryParse(number, out start);
                        Int32.TryParse(rangeEnd, out end);
                        for (; start <= end; start++)
                        {
                            output.Add(start);
                        }
                    }
                    else
                    {
                        int num;
                        Int32.TryParse(number, out num);
                        output.Add(num);
                    }
                    number = rangeEnd = "";
                    parsingRange = false;
                }
                if (ch == '-')
                {
                    parsingRange = true;
                }
            }
            return output;
        }
    }
}