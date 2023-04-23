
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort Log_Birch = 6;
}

public class Log_Birch : BlockData {

    public override ushort Id => BlockId.Log_Birch;

    public override string Name => "Birch Log Block";

    public override bool Erodable => false;
    public override bool Flamable => true;
    public override bool Solid => true;
    public override bool Selectable => true;
    public override bool CanBePlacedOn => false;
    public override bool Extendable => true;

    public override MeshUVSet UVSet => new MeshUVSet {
        PX_X = 5,
        PX_Y = 0,

        NX_X = 5,
        NX_Y = 0,

        PY_X = 5,
        PY_Y = 1,

        NY_X = 5,
        NY_Y = 1,

        PZ_X = 5,
        PZ_Y = 0,

        NZ_X = 5,
        NZ_Y = 0,
    };
}
