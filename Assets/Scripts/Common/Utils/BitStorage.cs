namespace Common.Utils
{
    public class BitDenseStorage
    {
        private const int Word = 64;
        private const int WordSar = 6;
        private const int WordMask = 63;
        private readonly ulong[] _data;
        private ulong _mask;
        private int _bits;

        public void Set(int index, ulong val) {
            var bitOffset = index*_bits;
            var hByteBegin = bitOffset >> WordSar;
            var hByteEnd = (bitOffset+(_bits-1u)) >> WordSar;
            var headBitLoc = bitOffset & WordMask;
            var lowerRemains = _data[hByteBegin] & ~(_mask << headBitLoc);
            var lowerChanged = (val & _mask) << headBitLoc;
            _data[hByteBegin] = lowerRemains | lowerChanged;
            if (hByteBegin == hByteEnd) return;
            var bitsLower = Word-headBitLoc;
            var bitsUpper = _bits-bitsLower;
            var upperRemains = (_data[hByteEnd] >> bitsUpper) << bitsUpper;
            var upperChanged = (val & _mask) >> bitsLower;
            _data[hByteEnd] = upperRemains | upperChanged;
        }

        public int Get(int index)  {
            var bitOffset = index*_bits;
            var hByteBegin = bitOffset >> WordSar;
            var hByteEnd = (bitOffset+(_bits-1u)) >> WordSar;
            var headBitLoc = bitOffset & WordMask;
            if (hByteBegin==hByteEnd) return (int) ((_data[hByteBegin] >> headBitLoc) & _mask);
            var bitsLower = Word-headBitLoc;
            var upper = (_data[hByteEnd] << bitsLower) & _mask;
            var lower = _data[hByteBegin] >> headBitLoc;
            return (int) (upper | lower);
        }
    }

    public class BitSparseStorage
    {
        private readonly object _data;
        private readonly int _type;

        public int Get(int index)
        {
            switch (_type)
            {
                case 1: return ((byte[]) _data)[index];
                case 2: return ((ushort[]) _data)[index];
                case 3: return ((int[]) _data)[index];
            }
            return 0;
        }

        public void Set(int index, int val)
        {
            switch (_type)
            {
                case 1:
                    ((byte[]) _data)[index] = (byte) val;
                    break;
                case 2:
                    ((ushort[]) _data)[index] = (ushort) val;
                    break;
                case 3:
                    ((int[]) _data)[index] = val;
                    break;
            }
        }
    }
}