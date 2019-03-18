﻿using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Civic.Core.Configuration
{
	/// <summary>
	/// Utility for encrypting and decrypting data.
	/// </summary>
	internal static class CryptoHelper
	{
		#region Fields
		private static readonly MethodInfo _EncDecMethod;
		#endregion

		#region Methods
		/// <summary>
		/// Loads methods for encryption using reflection.
		/// </summary>
		/// <remarks>
		/// This method is executed only once, thus reducing
		/// the load of using reflection to a minimum.
		/// </remarks>
		static CryptoHelper()
		{
			try
			{
				// This class is made public but the methods
				// we requiere are made private or internal.
				Type machineKeySection = typeof(System.Web.Configuration.MachineKeySection);

				// Get encryption / decryption method
				// You can look up all the method using Reflector
				// or a simillar tool.
				_EncDecMethod = machineKeySection.GetMethod("EncryptOrDecryptData",
					BindingFlags.NonPublic | BindingFlags.Static, Type.DefaultBinder,
					new[] { typeof(bool), typeof(byte[]), typeof(byte[]), typeof(int), typeof(int) },
					null);
			}
			catch
			{
				throw new Exception("Failed to initialized base encryption method.");
			}
		}


		/// <summary>
		/// Encrypts a string.
		/// </summary>
		/// <param name="data">Data to be encrypted.</param>
		/// <returns>Encrypted string.</returns>
		public static string Encrypt(string data)
		{
			// Try to encrypt data
			try
			{
				// Convert strig to byte array
				byte[] bytes = Encoding.UTF8.GetBytes(data);

				// Invoke the encryption method.
				// The method is basicaly the same for both
				// encryption and decription. You just have to
				// specify the the correct fEncrypt parameter
				// value.
				byte[] encData = (byte[])_EncDecMethod.Invoke(null, new object[] { true, bytes, null, 0, bytes.Length });

				// Return a re-usable string
				return Convert.ToBase64String(encData);
			}
			catch
			{
				// Data was not valid, encryption failed.
				throw new Exception("Failed to encrypt data.");
			}
		}

		/// <summary>
		/// Decrypts a string.
		/// </summary>
		/// <param name="data">Data to be decrypted.</param>
		/// <returns>Decrypted string.</returns>
		public static string Decrypt(string data)
		{
			// Try to decrypt data
			try
			{
				// Convert strig to byte array
				byte[] bytes = Convert.FromBase64String(data);

				// Invoke the decryption method.
				// The method is basicaly the same for both
				// encryption and decription. You just have to
				// specify the the correct fEncrypt parameter
				// value.
				byte[] decData = (byte[])_EncDecMethod.Invoke(null, new object[] { false, bytes, null, 0, bytes.Length });

				// Return a re-usable string
				return Encoding.UTF8.GetString(decData);
			}
			catch
			{
				// Data was not valid, encryption failed.
				throw new Exception("Failed to encrypt data.");
			}


		}

		#endregion
	}

}