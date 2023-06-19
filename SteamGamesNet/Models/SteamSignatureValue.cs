using System;
using System.Linq;

namespace SteamGamesNet.Models
{
    public class SteamSignatureValue
    {
        public SteamSignatureValue(string filePath, string hashAlgorithmName, string hashValue, string crcValue, bool isDigestValue)
        {
            FilePath = filePath;
            HashAlgorithmName = hashAlgorithmName;
            HashValue = hashValue;
            CrcValue = crcValue;
            IsDigestValue = isDigestValue;
        }

        public string FilePath { get; set; }

        public string HashAlgorithmName { get; set; }

        public string HashValue { get; set; }

        public string CrcValue { get; set; }

        public bool IsDigestValue { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(FilePath)}={FilePath}, {nameof(HashAlgorithmName)}={HashAlgorithmName}, {nameof(HashValue)}={HashValue}, {nameof(CrcValue)}={CrcValue}, {nameof(IsDigestValue)}={IsDigestValue.ToString()}}}";
        }
    }
}
