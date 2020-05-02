using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace ToDoList.Security.Core.Services.Hash
{
    internal class HashProvider : IHashProvider
    {
        private const int NumBytesRequested = 256 / 8;
        private const int IterationCount = 10000;
        private const KeyDerivationPrf Prf = KeyDerivationPrf.HMACSHA1;

        private readonly byte[] _salt = new byte[128 / 8];

        public string GetHash(string input)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: input,
                salt: _salt,
                prf: Prf,
                iterationCount: IterationCount,
                numBytesRequested: NumBytesRequested));
        }
    }
}
