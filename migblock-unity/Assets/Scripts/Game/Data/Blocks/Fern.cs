
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort Fern = 12;
}

public class Fern : BlockData {

    public override ushort Id => BlockId.Fern;

    public override string Name => "Fern Block";

    public override bool Erodable => false;
    public override bool Flamable => false;
    public override bool Solid => false;
    public override bool Selectable => true;
    public override bool CanBePlacedOn => true;
    public override bool Extendable => false;

    public override MeshUVSet UVSet => new MeshUVSet {
        PX_X = 6,
        PX_Y = 3,

        NX_X = 6,
        NX_Y = 3,

        PY_X = 6,
        PY_Y = 3,

        NY_X = 6,
        NY_Y = 3,

        PZ_X = 6,
        PZ_Y = 3,

        NZ_X = 6,
        NZ_Y = 3,
    };

    public override void Draw (Chunk chunk, int x, int y, int z) {

        BaseMeshing.Cross(chunk, x, y, z, UVSet);
    }

    public override void SingleVoxelDraw (Mesh mesh) {

        SVBaseMeshing.Cross(mesh, UVSet);
    }
}
