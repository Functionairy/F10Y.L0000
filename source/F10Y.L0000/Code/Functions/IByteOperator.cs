using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IByteOperator
    {
        public bool Are_Equal(
            byte[] bytesA,
            byte[] bytesB)
        {
            var byteCountA = bytesA.Length;
            var byteCountB = bytesB.Length;

            var sameByteCount = byteCountA == byteCountB;
            if (!sameByteCount)
            {
                return false;
            }

            for (int iByte = 0; iByte < bytesA.Length; iByte++)
            {
                var byteIsEqual = bytesA[iByte] == bytesB[iByte];
                if (!byteIsEqual)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Byte-by-byte, verify that two byte arrays are equal.
        /// </summary>
        /// <remarks>
        /// This is useful in testing file byte-level equality.
        /// </remarks>
        public void Verify_AreEqual(
            byte[] bytesA,
            byte[] bytesB)
        {
            var byteCountA = bytesA.Length;
            var byteCountB = bytesB.Length;

            var sameByteCount = byteCountA == byteCountB;
            if (!sameByteCount)
            {
                throw new Exception($"Differing byte counts: A is {byteCountA}, and B is {byteCountB}.");
            }

            for (int iByte = 0; iByte < bytesA.Length; iByte++)
            {
                var byteIsEqual = bytesA[iByte] == bytesB[iByte];
                if (!byteIsEqual)
                {
                    throw new Exception($"Byte number {iByte} was unequal.");
                }
            }
        }
    }
}
