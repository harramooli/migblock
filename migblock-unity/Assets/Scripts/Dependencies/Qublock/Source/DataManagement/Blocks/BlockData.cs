
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort Unknown = 404;
}

public class BlockData {

    public virtual ushort Id => BlockId.Unknown;

    public virtual string Name => "Unknown Block";

    public virtual bool Erodable => false;
    public virtual bool Flamable => false;
    public virtual bool Solid => true;
    public virtual bool Selectable => true;
    public virtual bool CanBePlacedOn => false;
    public virtual bool Extendable => true;

    public virtual MeshUVSet UVSet => new MeshUVSet {
        PX_X = 1,
        PX_Y = 3,

        NX_X = 1,
        NX_Y = 3,

        PY_X = 1,
        PY_Y = 3,

        NY_X = 1,
        NY_Y = 3,

        PZ_X = 1,
        PZ_Y = 3,

        NZ_X = 1,
        NZ_Y = 3,
    };

    public virtual void Draw (Chunk chunk, int x, int y, int z) {

        BaseMeshing.Block(chunk, x, y, z, UVSet);
    }

    public virtual void SingleVoxelDraw (Mesh mesh) {

        SVBaseMeshing.Block(mesh, UVSet);
    }
}
