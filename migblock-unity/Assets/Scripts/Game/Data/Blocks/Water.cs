
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort Water = 17;
}

public class Water : BlockData {

    public override ushort Id => BlockId.Water;

    public override string Name => "Water Block";

    public override bool Erodable => false;
    public override bool Flamable => false;
    public override bool Solid => false;
    public override bool Selectable => false;
    public override bool CanBePlacedOn => true;
    public override bool Extendable => false;

    public override MeshUVSet UVSet => new MeshUVSet {
        PX_X = 3,
        PX_Y = 0,

        NX_X = 3,
        NX_Y = 0,

        PY_X = 3,
        PY_Y = 0,

        NY_X = 3,
        NY_Y = 0,

        PZ_X = 3,
        PZ_Y = 0,

        NZ_X = 3,
        NZ_Y = 0,
    };

    public override void Draw (Chunk chunk, int x, int y, int z) {

        BaseMeshing.BasicLiquid(chunk, x, y, z, UVSet, Id, 0.32f);
    }
}
