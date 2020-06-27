
public class Chunk
{
    public delegate void ChunkChangedHandler();
    public event ChunkChangedHandler ChunkEventChanged;
}