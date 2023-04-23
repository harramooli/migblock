
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort Log_Oak = 7;
}

public class Log_Oak : BlockData {

    public override ushort Id => BlockId.Log_Oak;

    public override string Name => "Oak Log Block";

    public override bool Erodable => false;
    public override bool Flamable => true;
    public override bool Solid => true;
    public override bool Selectable => true;
    public override bool CanBePlacedOn => false;
    public override bool Extendable => true;

    public override MeshUVSet UVSet => new MeshUVSet {
        PX_X = 4,
        PX_Y = 0,

        NX_X = 4,
        NX_Y = 0,

        PY_X = 4,
        PY_Y = 1,

        NY_X = 4,
        NY_Y = 1,

        PZ_X = 4,
        PZ_Y = 0,

        NZ_X = 4,
        NZ_Y = 0,
    };
}
