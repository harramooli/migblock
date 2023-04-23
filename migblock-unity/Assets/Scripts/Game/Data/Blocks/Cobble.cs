
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort Cobble = 4;
}

public class Cobble : BlockData {

    public override ushort Id => BlockId.Cobble;

    public override string Name => "Cobble Block";

    public override bool Erodable => false;
    public override bool Flamable => false;
    public override bool Solid => true;
    public override bool Selectable => true;
    public override bool CanBePlacedOn => false;
    public override bool Extendable => true;

    public override MeshUVSet UVSet => new MeshUVSet {
        PX_X = 1,
        PX_Y = 2,

        NX_X = 1,
        NX_Y = 2,

        PY_X = 1,
        PY_Y = 2,

        NY_X = 1,
        NY_Y = 2,

        PZ_X = 1,
        PZ_Y = 2,

        NZ_X = 1,
        NZ_Y = 2,
    };
}
