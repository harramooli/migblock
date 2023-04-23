
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort Leaves_Oak = 14;
}

public class Leaves_Oak : BlockData {

    public override ushort Id => BlockId.Leaves_Oak;

    public override string Name => "Oak Leaves Block";

    public override bool Erodable => false;
    public override bool Flamable => true;
    public override bool Solid => false;
    public override bool Selectable => true;
    public override bool CanBePlacedOn => false;
    public override bool Extendable => true;

    public override MeshUVSet UVSet => new MeshUVSet {
        PX_X = 4,
        PX_Y = 3,

        NX_X = 4,
        NX_Y = 3,

        PY_X = 4,
        PY_Y = 3,

        NY_X = 4,
        NY_Y = 3,

        PZ_X = 4,
        PZ_Y = 3,

        NZ_X = 4,
        NZ_Y = 3,
    };
}
