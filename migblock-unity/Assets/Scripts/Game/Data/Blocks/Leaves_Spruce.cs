
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort Leaves_Spruce = 16;
}

public class Leaves_Spruce : BlockData {

    public override ushort Id => BlockId.Leaves_Spruce;

    public override string Name => "Spruce Leaves Block";

    public override bool Erodable => false;
    public override bool Flamable => true;
    public override bool Solid => false;
    public override bool Selectable => true;
    public override bool CanBePlacedOn => false;
    public override bool Extendable => true;

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
}
