
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort Log_Spruce = 8;
}

public class Log_Spruce : BlockData {

    public override ushort Id => BlockId.Log_Spruce;

    public override string Name => "Spruce Log Block";

    public override bool Erodable => false;
    public override bool Flamable => true;
    public override bool Solid => true;
    public override bool Selectable => true;
    public override bool CanBePlacedOn => false;
    public override bool Extendable => true;

    public override MeshUVSet UVSet => new MeshUVSet {
        PX_X = 6,
        PX_Y = 0,

        NX_X = 6,
        NX_Y = 0,

        PY_X = 6,
        PY_Y = 1,

        NY_X = 6,
        NY_Y = 1,

        PZ_X = 6,
        PZ_Y = 0,

        NZ_X = 6,
        NZ_Y = 0,
    };
}
