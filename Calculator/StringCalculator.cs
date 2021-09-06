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
			string substr = param, delimCurrent;
			int number, countNumbers = 1;
			string[] delimeter = Delimeter(param);
			while (Index(substr, delimeter, out delimCurrent) < substr.Length)
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
			string delimCurrent;
			int index = Index(str, delimeter, out delimCurrent);
			if (index < str.Length)
				{
					substr = str.Substring(index + delimCurrent.Length);
					string number = str.Substring(0, index);
					if (!number.Contains('/') && number.Length > 0 && !number.Contains(']'))
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
	
		public static int Index(string param, string[] delimeter, out string delimCurrent)
		{
			delimCurrent = null;
			int index = param.Length;
			int delimIndex;
			foreach(string delim in delimeter){
				delimIndex = param.IndexOf(delim);
				if (delimIndex != -1 && delimIndex < index)
				{
					index = delimIndex;
					delimCurrent = delim;
				} 
			}			
			return index;
		}

		public static string[] Delimeter(string param)
		{
			if (param.StartsWith("//["))
			{
				string[] delim = {param.Substring(param.IndexOf('[') + 1, (param.IndexOf(']') - param.IndexOf('[') - 1)), ",", "\n" };
				return delim;
			}
			else if (param.StartsWith("//"))
			{
				string[] delim = {param.Substring(2, 1), ",", "\n"};
				return  delim;
			}
			string[] withoutDelim = {",", "\n" };
			return withoutDelim;
		}
	}
} 