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

		public static int SumNumbers(string param)
				{
					string substr = param;
					int summ = 0;
					char[] delimeter = Delimeter(param);
					while (Index(substr, delimeter) < substr.Length)
					{
						summ = summ + GetNumber(substr, delimeter, out substr);
					}
					summ = summ + GetNumber(substr, delimeter, out substr);
					return summ;
				}

		public static int GetNumber(string str, char[] delimeter, out string substr)
		{
			substr = null;			
			if (Index(str, delimeter) < str.Length)
				{
					substr = str.Substring(Index(str, delimeter) + 1);
					string number = str.Substring(0, Index(str, delimeter));
					if (!number.Contains('/') && number.Length > 0)
				    {
						return int.Parse(number);
					}
					else
					{
						return 0;
					}
				}
			return int.Parse(str);
		}
	
		public static int Index(string param, char[] delimeter)
		{			
			int index = param.Length;
			foreach(char delim in delimeter){
				if ((param.IndexOf(delim) != -1) && param.IndexOf(delim) < index)
				{
					index = param.IndexOf(delim);
				} 
			}			
			return index;
		}

		public static char[] Delimeter(string param)
		{
			if (param.StartsWith("//"))
			{
				char[] delim = {param.Substring(2, 1).ToCharArray()[0], ',', '\n'};
				return  delim;
			}
			char[] withoutDelim = {',', '\n' };
			return withoutDelim;
		}
	}
} 