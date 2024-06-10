using System.Security.Cryptography;
using System.Text;
namespace SquentialGUID;

public static class UuidGenerator
{
    private static readonly DateTime UuidEpoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private static object lockObject = new object();
    public static Guid NewSequentialGuid(this string input)
    {
        lock (lockObject)
        {
            using var sha256 = new SHA256CryptoServiceProvider();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            // Get the current timestamp
            long timestamp = (DateTime.UtcNow - UuidEpoch).Ticks;

            // Convert the timestamp to a byte array (8 bytes)
            byte[] timestampBytes = BitConverter.GetBytes(timestamp);

            // Reverse the array to match the endianness of the UUID
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(timestampBytes);
            }

            // Create a 16-byte array for the UUID
            byte[] uuidBytes = new byte[16];

            // Copy the first 8 bytes of the hash into the UUID
            Array.Copy(hashBytes, 0, uuidBytes, 0, 8);

            // Copy the timestamp into the UUID
            Array.Copy(timestampBytes, 0, uuidBytes, 8, 8);

            // Set the version to a hypothetical version (e.g., 0xA0 for a custom version)
            uuidBytes[7] = (byte)(uuidBytes[7] & 0x0F | 0xA0);

            // Set the variant bits (the two most significant bits of the 9th byte, to 0b10)
            uuidBytes[8] = (byte)(uuidBytes[8] & 0x3F | 0x80);

            return new Guid(uuidBytes);
        }
    }
}
