
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BlockId {

    public const ushort Air = 0;
};

public class AirBlock : BlockData {

    public override ushort Id => BlockId.Air;

    public override string Name => "Air Block";

    public override bool Erodable => true;
    public override bool Flamable => false;
    public override bool Solid => false;
    public override bool Selectable => false;
    public override bool CanBePlacedOn => true;
    public override bool Extendable => false;

    public override void Draw (Chunk chunk, int x, int y, int z) {

        return;
    }

    public override void SingleVoxelDraw (Mesh mesh) {

        return;
    }
}
