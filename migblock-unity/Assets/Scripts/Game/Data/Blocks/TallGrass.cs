
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort TallGrass = 11;
}

public class TallGrass : BlockData {

    public override ushort Id => BlockId.TallGrass;

    public override string Name => "Tall Grass Block";

    public override bool Erodable => false;
    public override bool Flamable => false;
    public override bool Solid => false;
    public override bool Selectable => true;
    public override bool CanBePlacedOn => true;
    public override bool Extendable => false;

    public override MeshUVSet UVSet => new MeshUVSet {
        PX_X = 4,
        PX_Y = 4,

        NX_X = 4,
        NX_Y = 4,

        PY_X = 4,
        PY_Y = 4,

        NY_X = 4,
        NY_Y = 4,

        PZ_X = 4,
        PZ_Y = 4,

        NZ_X = 4,
        NZ_Y = 4,
    };

    public override void Draw (Chunk chunk, int x, int y, int z) {

        BaseMeshing.Cross(chunk, x, y, z, UVSet);
    }

    public override void SingleVoxelDraw (Mesh mesh) {

        SVBaseMeshing.Cross(mesh, UVSet);
    }
}
