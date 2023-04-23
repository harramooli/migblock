
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort Grass = 2;
};

public class GrassBlock : BlockData {

    public override ushort Id => BlockId.Grass;

    public override string Name => "Grass Block";

    public override bool Erodable => false;
    public override bool Flamable => false;
    public override bool Solid => true;
    public override bool Selectable => true;
    public override bool CanBePlacedOn => false;
    public override bool Extendable => true;

    public override MeshUVSet UVSet => new MeshUVSet {
        PX_X = 1,
        PX_Y = 1,

        NX_X = 1,
        NX_Y = 1,

        PY_X = 0,
        PY_Y = 1,

        NY_X = 1,
        NY_Y = 0,

        PZ_X = 1,
        PZ_Y = 1,

        NZ_X = 1,
        NZ_Y = 1,
    };
}
