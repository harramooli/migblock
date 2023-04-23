
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort Leaves_Birch = 15;
}

public class Leaves_Birch : BlockData {

    public override ushort Id => BlockId.Leaves_Birch;

    public override string Name => "Birch Leaves Block";

    public override bool Erodable => false;
    public override bool Flamable => true;
    public override bool Solid => false;
    public override bool Selectable => true;
    public override bool CanBePlacedOn => false;
    public override bool Extendable => true;

    public override MeshUVSet UVSet => new MeshUVSet {
        PX_X = 5,
        PX_Y = 3,

        NX_X = 5,
        NX_Y = 3,

        PY_X = 5,
        PY_Y = 3,

        NY_X = 5,
        NY_Y = 3,

        PZ_X = 5,
        PZ_Y = 3,

        NZ_X = 5,
        NZ_Y = 3,
    };
}
