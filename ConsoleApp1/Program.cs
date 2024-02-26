using System;
using System.Diagnostics;
using System.Security.Cryptography;



namespace Tilfældigheder
{
	internal class Program
	{

		static int TotalRandomNumber = 0;
		static int TotalCryptoNumber = 0;




		static void Main(string[] args)
		{
			Console.WriteLine("Øvelse 1:");
			RandomUsingRandom(100);
			Console.WriteLine("using crypto: ");
			RandomUsingCrypto(100);
			Console.WriteLine($"random average: {TotalRandomNumber / 100}\ncrypto average: {TotalCryptoNumber / 100}");


			Console.WriteLine("øvelse 2:");
			RandomUsingRandom(1_000_000);
			Console.WriteLine("using crypto: ");
			RandomUsingCrypto(1_000_000);
			Console.WriteLine($"random average: {TotalRandomNumber / 1_000_000}\ncrypto average: {TotalCryptoNumber / 1_000_000}");


			Console.WriteLine("øvelse 3:");
			//Using a lambda expression so that i can run my methods with their parameters.
			RunBenchmark((param) => RandomUsingRandom(param), "RandomUsingRandom", 1_000_000);
			RunBenchmark((param) => RandomUsingCrypto(param), "RandomUsingCrypto", 1_000_000);



			Console.WriteLine("øvelse 4");

			Encrypter encrypter = new Encrypter();
			Stopwatch sw = new Stopwatch();

			string encryptTest = "abcdefghijklmnopqrstuvwxyzæøåABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
			string encryptedTest = encrypter.Encrypt(encryptTest);


			Console.WriteLine($"original: {encryptTest} | encrypted: {encryptedTest} | decrypted: {encrypter.Decrypt(encryptedTest)}");


			sw.Start();
			encryptTest = encrypter.Encrypt(encryptedTest);
			sw.Stop();
			Console.WriteLine($"ticks elapsed for encrypting: {sw.ElapsedTicks}");
			sw.Start();
			encryptTest = encrypter.Decrypt(encryptedTest);
			sw.Stop();
            Console.WriteLine($"ticks elapsed for decrypting: {sw.ElapsedTicks}");



			Console.Read();

		}

		static private void RandomUsingRandom(int maxLength)
		{
			Console.WriteLine("using random;");
			Random random = new Random();

			for (int i = 0; i < maxLength; i++)
			{
				byte[] rBytes = new byte[4];

				random.NextBytes(rBytes);

				int randomInt = BitConverter.ToInt32(rBytes, 0);


				randomInt %= 1000;
				TotalRandomNumber += Math.Abs(randomInt);
				//Console.WriteLine($"Random Test {i + 1}: {BitConverter.ToString(rBytes).Replace("-", "")} => {randomInt.ToString().Replace("-", "")}");
			}
		}


		private static void RandomUsingCrypto(int length)
		{

			for (int i = 0; i < length; i++)
			{
				byte[] rBytes = new byte[4];

				using (var generator = RandomNumberGenerator.Create())
				{
					generator.GetBytes(rBytes);
				}

				int randomInt = BitConverter.ToInt32(rBytes, 0);
				randomInt %= 1000;
				TotalCryptoNumber += Math.Abs(randomInt);
				//Console.WriteLine($"Crypto Test {i + 1}: {BitConverter.ToString(rBytes).Replace("-", "")} => {randomInt.ToString().Replace("-", "")}");
			}

		}


		private static void RunBenchmark(Action<int> benchmarkMethod, string methodName, int methodParam)
		{

			Stopwatch sw = new Stopwatch();


			sw.Start();
			benchmarkMethod(methodParam);
			sw.Stop();


			Console.WriteLine($"{methodName} tid (ticks): {sw.ElapsedTicks}");

		}

	}
	}
