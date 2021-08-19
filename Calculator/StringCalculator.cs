using System;

namespace Calculator
{
	public static class StringCalculator
	{
		public static int Add(string parameters)
		{
			if (parameters.Length == 0)
			{
				return 0;
			}

			return SumNumbers(parameters);
			
		}

		public static int GetNumber(string str, out string substr)
		{
			substr = null;
			if (str.Contains(',') || str.Contains('\n'))
				{
					substr = str.Substring(LastIndex(str) + 1);
					return int.Parse(str.Substring(0, StartIndex(str)));
				}
			return int.Parse(str);
		}

		public static int SumNumbers(string param)
		{
			string substr = param;
			int summ = 0;
			while (substr.Contains(',') || substr.Contains('\n'))
			{
				summ = summ + GetNumber(substr, out substr);
			}
			summ = summ + GetNumber(substr, out substr);
			return summ;
		}

		public static int StartIndex(string param)
		{
			int indexComma = param.IndexOf(',');
			int indexNewLine = param.IndexOf('\n');

			if (indexComma != -1)
			{
				if ((indexComma < indexNewLine) || (indexNewLine == -1))
				{
					return indexComma;
				}
			}				
			else if (indexNewLine != -1)
			{
				return (indexNewLine); // because we need index of '\' in "\n" 
			}
			return 0;
		}

		public static int LastIndex(string param)
		{
			int indexComma = param.IndexOf(',');
			int indexNewLine = param.IndexOf('\n');

			if (indexComma != -1)
			{
				if ((indexComma < indexNewLine) || (indexNewLine == -1))
				{
					return indexComma;
				}
			}
			else if (indexNewLine != -1)
			{
				return indexNewLine; 
			}
			return 0;
		}
	}
} 