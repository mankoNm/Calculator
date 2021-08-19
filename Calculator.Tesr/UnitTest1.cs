using NUnit.Framework;

namespace Calculator.Tesr
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Add_EmptyString_0Expected()
		{
			string parameters = "";
			int expected = 0;

			int actual = StringCalculator.Add(parameters);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Add_1String_1Expected()
		{
			string parameters = "1";
			int expected = 1;

			int actual = StringCalculator.Add(parameters);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Add_1_2String_3Expected()
		{
			string parameters = "1,2";
			int expected = 3;

			int actual = StringCalculator.Add(parameters);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Add_1_2_3String_6Expected()
		{
			string parameters = "1,2,3";
			int expected = 6;

			int actual = StringCalculator.Add(parameters);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Add_1_newLine_2_3String_6Expected()
		{
			string parameters = "1\n3";
			int expected = 4;

			int actual = StringCalculator.Add(parameters);

			Assert.AreEqual(expected, actual);
		}
	}
}