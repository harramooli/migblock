
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort Sand = 9;
};

public class SandBlock : BlockData {

    public override ushort Id => BlockId.Sand;

    public override string Name => "Sand Block";

    public override bool Erodable => false;
    public override bool Flamable => false;
    public override bool Solid => true;
    public override bool Selectable => true;
    public override bool CanBePlacedOn => false;
    public override bool Extendable => true;

    public override MeshUVSet UVSet => new MeshUVSet {
        PX_X = 2,
        PX_Y = 0,

        NX_X = 2,
        NX_Y = 0,

        PY_X = 2,
        PY_Y = 0,

        NY_X = 2,
        NY_Y = 0,

        PZ_X = 2,
        PZ_Y = 0,

        NZ_X = 2,
        NZ_Y = 0,
    };
}
