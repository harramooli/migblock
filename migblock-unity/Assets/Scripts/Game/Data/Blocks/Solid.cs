
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort Solid = 1;
};

public class SolidBlock : BlockData {

    public override ushort Id => BlockId.Solid;

    public override string Name => "Solid Block";

    public override bool Erodable => false;
    public override bool Flamable => false;
    public override bool Solid => true;
    public override bool Selectable => true;
    public override bool CanBePlacedOn => false;
    public override bool Extendable => true;

    public override MeshUVSet UVSet => new MeshUVSet {
        PX_X = 0,
        PX_Y = 0,

        NX_X = 0,
        NX_Y = 0,

        PY_X = 0,
        PY_Y = 0,

        NY_X = 0,
        NY_Y = 0,

        PZ_X = 0,
        PZ_Y = 0,

        NZ_X = 0,
        NZ_Y = 0,
    };
}
