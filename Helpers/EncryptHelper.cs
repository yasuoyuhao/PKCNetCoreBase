using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Base.Helpers
{
    public static class EncryptHelper
    {
        #region Encrypt using SHA256Managed.
        /// <summary>
        /// Encrypt using SHA256Managed.
        /// </summary>
        /// <param name="input">this string.</param>
        /// <returns>Encrypt string.</returns>
        public static string SHA256Encrypt(this string input)
        {
            using (var sha256 = new SHA256Managed())
            {
                byte[] raw = Encoding.Default.GetBytes(input);
                return string.Format("{0}", Convert.ToBase64String(sha256.ComputeHash(raw)));
            }
        }
        #endregion
    }
}
