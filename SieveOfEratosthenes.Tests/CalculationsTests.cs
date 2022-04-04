using NUnit.Framework;
using SieveOfEratosthenes.Classes;

namespace SieveOfEratosthenes.Tests
{
	[TestFixture]
	internal class CalculationsTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		[TestCase(2, 3, 2)]
		//[TestCase(2, 4, 3)]
		[TestCase(2, 5, 3)]
		public void Test1(int start, int end, int result)
		{
			Assert.AreEqual(result, Calculations.SzukajSitemEratostenesaLP(start, end));
		}
	}
}
