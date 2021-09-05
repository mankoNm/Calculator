using System;
using System.Collections;

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

			int[] numbers = GetNumbersList(parameters);
			string messageNegativesAllowed = NegativesAllowed(numbers);

			if (messageNegativesAllowed.Length > 0)
			{
				Console.WriteLine(messageNegativesAllowed);
				return -1;
			}

			return SumNumbers(numbers);

		}
		public static int[] GetNumbersList(string param)
		{
			string substr = param;
			int number, countNumbers = 1;
			string[] delimeter = Delimeter(param);
			while (Index(substr, delimeter) < substr.Length)
			{
				number = GetNumber(substr, delimeter, out substr);
				countNumbers++;
			}

			int[] numbers = new int[countNumbers];
			substr = param;
			for (int i = 0; i < countNumbers; i++)
			{
				number = GetNumber(substr, delimeter, out substr);
				numbers[i] = number;
			}
			return numbers;
		}

		public static int SumNumbers(int[] numbers)
		{			
			int summ = 0;
			foreach (int number in numbers)
			{
				if (number > 1000)
					continue;

				summ += number;
			}
			return summ;
		}



		public static string NegativesAllowed(int[] numbers)
		{
			string message = "";

			foreach (int number in numbers)
			{
				try
				{
					if (number < 0)
					{
						throw new NegativesNotAllowedException(number.ToString());
					}
				}
				catch (Exception ex)
				{
					message = $"{message}, {ex.Message}";
				}
			}

			if (message.Length > 0)
			{
				return $"Negatives allowed ({message})";
			}
			else
			{
				return "";
			}			
		}

		public static int GetNumber(string str, string[] delimeter, out string substr)
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
	
		public static int Index(string param, string[] delimeter)
		{			
			int index = param.Length;
			foreach(string delim in delimeter){
				if ((param.IndexOf(delim) != -1) && param.IndexOf(delim) < index)
				{
					index = param.IndexOf(delim);
				} 
			}			
			return index;
		}

		public static string[] Delimeter(string param)
		{
			if (param.StartsWith("//"))
			{
				string[] delim = {param.Substring(2, 1).ToCharArray()[0].ToString(), ",", "\n"};
				return  delim;
			}
			string[] withoutDelim = {",", "\n" };
			return withoutDelim;
		}
	}
} 