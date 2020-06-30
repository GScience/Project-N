using System.Threading.Tasks;
using Common.Utils;
using Unity.Mathematics;

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
        IBlockState GetBlock(int3 rel);
        int GetBlockLightness(int3 rel);
        void SetBlock(IBlockState state, int3 rel);
    }

    public interface IChunkProvider
    {
        Task<IChunk> GetAsync(int3 position);
        Task SaveAsync(IChunk chunk);
    }

    public interface IChunkRetentionManager
    {
        void LoadNow(int3 position);
        Task LoadAsync(int3 position);
        void UnloadNow(int3 position);
        Task UnloadAsync(int3 position);
        void FlushNow(int3 position);
        Task FlushAsync(int3 position);
        IChunk GetNow(int3 position);
        Task<IChunk> GetAsync(int3 position);
    }
}