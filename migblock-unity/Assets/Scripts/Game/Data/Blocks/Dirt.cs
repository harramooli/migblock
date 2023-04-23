
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort Dirt = 3;
};

public class DirtBlock : BlockData {

    public override ushort Id => BlockId.Dirt;

    public override string Name => "Dirt Block";

    public override bool Erodable => false;
    public override bool Flamable => false;
    public override bool Solid => true;
    public override bool Selectable => true;
    public override bool CanBePlacedOn => false;
    public override bool Extendable => true;

    public override MeshUVSet UVSet => new MeshUVSet {
        PX_X = 1,
        PX_Y = 0,

        NX_X = 1,
        NX_Y = 0,

        PY_X = 1,
        PY_Y = 0,

        NY_X = 1,
        NY_Y = 0,

        PZ_X = 1,
        PZ_Y = 0,

        NZ_X = 1,
        NZ_Y = 0,
    };
}
