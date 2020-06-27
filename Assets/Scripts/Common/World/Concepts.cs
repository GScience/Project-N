using System.Threading.Tasks;
using Common.Utils;

namespace Common.World
{
    public interface IPalette<T>
    {
        int TryMap(T val);
        T Query(int index);
        bool Mapped(T val);
        T[] Dump();
    }

    public interface IBlockEntity
    {

    }

    public interface IBlockClientFacet
    {

    }

    public interface IBlockServerFacet
    {

    }

    public interface IBlockState
    {
        int Index { get; }
        IBlockClientFacet ClientFacet { get; }
        IBlockServerFacet ServerFacet { get; }
    }

    public interface IChunk
    {
        IBlockState GetBlock(Int3 rel);
        int GetBlockLightness(Int3 rel);
        void SetBlock(IBlockState state, Int3 rel);
    }

    public interface IChunkProvider
    {
        Task<IChunk> GetAsync(Int3 position);
        Task SaveAsync(IChunk chunk);
    }

    public interface IChunkRetentionManager
    {
        void LoadNow(Int3 position);
        Task LoadAsync(Int3 position);
        void UnloadNow(Int3 position);
        Task UnloadAsync(Int3 position);
        void FlushNow(Int3 position);
        Task FlushAsync(Int3 position);
        IChunk GetNow(Int3 position);
        Task<IChunk> GetAsync(Int3 position);
    }
}