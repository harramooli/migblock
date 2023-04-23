
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort Cactus = 5;
}

public class Cactus : BlockData {

    public override ushort Id => BlockId.Cactus;

    public override string Name => "Cactus Block";

    public override bool Erodable => true;
    public override bool Flamable => false;
    public override bool Solid => false;
    public override bool Selectable => true;
    public override bool CanBePlacedOn => false;
    public override bool Extendable => false;

    public override MeshUVSet UVSet => new MeshUVSet {
        PX_X = 4,
        PX_Y = 5,

        NX_X = 4,
        NX_Y = 5,

        PY_X = 5,
        PY_Y = 5,

        NY_X = 6,
        NY_Y = 5,

        PZ_X = 4,
        PZ_Y = 5,

        NZ_X = 4,
        NZ_Y = 5,
    };

    public override void Draw (Chunk chunk, int x, int y, int z) {

        BaseMeshing.Cactus(chunk, x, y, z, UVSet);
    }

    public override void SingleVoxelDraw (Mesh mesh) {

        SVBaseMeshing.Cactus(mesh, UVSet);
    }
}
