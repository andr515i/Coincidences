

namespace Tilfældigheder
{
	public class Encrypter
	{
		public string Encrypt(string text)
		{
			char[] encryptedChars = new char[text.Length];

			for (int i = 0; i < text.Length; i++)
			{
				char originalChar = text[i];
				char encryptedChar;


				if (originalChar >= 'a' && originalChar <= 'x')
				{
					encryptedChar = (char)(((originalChar - 'a' + 1) % 26) + 'a');
				}
				else if (originalChar >= 'A' && originalChar <= 'X')
				{
					encryptedChar = (char)(((originalChar - 'A' + 1) % 26) + 'A');
				}
				else if (originalChar == 'z' || originalChar == 'Z')
				{
					encryptedChar = char.IsLower(originalChar) ? 'æ' : 'Æ'; // Preserve case for 'z' and 'Z'
				}
				else if (originalChar == 'æ' || originalChar == 'Æ')
				{
					encryptedChar = char.IsLower(originalChar) ? 'ø' : 'Ø'; // Preserve case for 'æ' and 'Æ'
				}
				else if (originalChar == 'ø' || originalChar == 'Ø')
				{
					encryptedChar = char.IsLower(originalChar) ? 'å' : 'Å'; // Preserve case for 'ø' and 'Ø'
				}
				else if (originalChar == 'å' || originalChar == 'Å')
				{
					encryptedChar = char.IsLower(originalChar) ? 'a' : 'A'; // Preserve case for 'å' and 'Å'
				}
				else
				{
					encryptedChar = originalChar; // Non-alphabetic characters remain unchanged
				}


				encryptedChars[i] = encryptedChar;
			}

			return new string(encryptedChars);
		}

		public string Decrypt(string encryptedText)
		{
			char[] decryptedChars = new char[encryptedText.Length];

			for (int i = 0; i < encryptedText.Length; i++)
			{
				char originalChar = encryptedText[i];
				char decryptedChar;

				if (originalChar == 'a' || originalChar == 'A')
				{
					decryptedChar = char.IsLower(originalChar) ? 'å' : 'Å'; // 'a' decrypted to 'å'
				}
				else if (originalChar >= 'a' && originalChar <= 'z')
				{
					decryptedChar = (char)(((originalChar - 'a' - 1 + 26) % 26) + 'a');
				}
				else if (originalChar >= 'A' && originalChar <= 'Z')
				{
					decryptedChar = (char)(((originalChar - 'A' - 1 + 26) % 26) + 'A');
				}
				else if (originalChar == 'æ' || originalChar == 'Æ')
				{
					decryptedChar = char.IsLower(originalChar) ? 'z' : 'Z'; // Preserve case for 'æ' and 'Æ'
				}
				else if (originalChar == 'ø' || originalChar == 'Ø')
				{
					decryptedChar = char.IsLower(originalChar) ? 'æ' : 'æ'; // Preserve case for 'ø' and 'Ø'
				}
				else if (originalChar == 'å' || originalChar == 'Å')
				{
					decryptedChar = char.IsLower(originalChar) ? 'ø' : 'Ø'; // Preserve case for 'å' and 'Å'
				}
				else
				{
					decryptedChar = originalChar; // Non-alphabetic characters remain unchanged
				}

				decryptedChars[i] = decryptedChar;
			}

			return new string(decryptedChars);
		}
	}
}
