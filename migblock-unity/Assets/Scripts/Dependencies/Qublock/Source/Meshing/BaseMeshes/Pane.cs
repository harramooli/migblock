
using UnityEngine;

using Qublock.Core;
using Qublock.Meshing;

public static partial class BaseMeshing {

    public static void Pane (Chunk chunk, int x, int y, int z, MeshUVSet uvSet, MeshUVSet vertSet, MeshUVSet horiSet, ushort blockId) {

        tempValue = false; //if this becomes true, then SOMETHGIN was renderd, if NOT, then we need to render a post if that make sense bro

        //positive X direction can extend out
        if (chunk.IsExtendable(x + 1, y, z)) { tempValue = true;

            if (!chunk.IsId(x + 1, y, z, blockId) && !chunk.IsSolid(x + 1, y, z)) {
                chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));
                chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f));
                chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f));
                chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));
                chunk.CalculateTriangles();
                chunk.collVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.05f));
                chunk.collVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.05f));
                chunk.collVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.05f));
                chunk.collVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.05f));
                chunk.CalculateCollTriangles();
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X + tileSize, tileSize * vertSet.PX_Y));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X + tileSize, tileSize * vertSet.PX_Y + tileSize));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X, tileSize * vertSet.PX_Y + tileSize));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X, tileSize * vertSet.PX_Y));
            }

            //negitve X direction is not extenable, 0chance of joining with oposite side, extend fully towards teh empty block
            if (!chunk.IsExtendable(x - 1, y, z)) {

                // if (!chunk.IsId(x - 1, y, z, blockId) && !chunk.IsSolid(x - 1, y, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z - 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z - 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.NX_X + tileSize, tileSize * vertSet.NX_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.NX_X + tileSize, tileSize * vertSet.NX_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.NX_X, tileSize * vertSet.NX_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.NX_X, tileSize * vertSet.NX_Y));
                // if (!chunk.IsId(x, y, z + 1, blockId) && !chunk.IsSolid(x, y, z + 1)) {
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.05f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.05f));
                    chunk.visuVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z + 0.05f));
                    chunk.visuVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z + 0.05f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z + 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X+.5f), tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X+.5f), tileSize * uvSet.PZ_Y));
                // if (!chunk.IsId(x, y, z - 1, blockId) && !chunk.IsSolid(x, y, z - 1)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z - 0.05f));
                    chunk.visuVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z - 0.05f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.05f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.05f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.NZ_X-.5f) + tileSize, tileSize * uvSet.NZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.NZ_X-.5f) + tileSize, tileSize * uvSet.NZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.NZ_X, tileSize * uvSet.NZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.NZ_X, tileSize * uvSet.NZ_Y));

                if (!chunk.IsSolid(x, y + 1, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z - 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z - 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X + tileSize, tileSize * vertSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X + tileSize, tileSize * vertSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X, tileSize * vertSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X, tileSize * vertSet.PY_Y));
                }
                if (!chunk.IsSolid(x, y - 1, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z + 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z + 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X + tileSize, tileSize * vertSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X + tileSize, tileSize * vertSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X, tileSize * vertSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X, tileSize * vertSet.PY_Y));
                }

            } else { //negitive X is extendible, only go half way so it can extend

                // if (!chunk.IsId(x, y, z + 1, blockId) && !chunk.IsSolid(x, y, z + 1)) {
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.05f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.05f));
                    chunk.visuVertices.Add(new Vector3(x - 0.0f, y + 0.5f, z + 0.05f));
                    chunk.visuVertices.Add(new Vector3(x - 0.0f, y - 0.5f, z + 0.05f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.0f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.0f, y - 0.5f, z + 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X+.5f), tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X+.5f), tileSize * uvSet.PZ_Y));
                // if (!chunk.IsId(x, y, z - 1, blockId) && !chunk.IsSolid(x, y, z - 1)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.0f, y - 0.5f, z - 0.05f));
                    chunk.visuVertices.Add(new Vector3(x - 0.0f, y + 0.5f, z - 0.05f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.05f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.05f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.0f, y - 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.0f, y + 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.NZ_X-.5f) + tileSize, tileSize * uvSet.NZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.NZ_X-.5f) + tileSize, tileSize * uvSet.NZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.NZ_X, tileSize * uvSet.NZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.NZ_X, tileSize * uvSet.NZ_Y));

                if (!chunk.IsSolid(x, y + 1, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.0f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.0f, y + 0.5f, z - 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.0f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.0f, y + 0.5f, z - 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X + tileSize, tileSize * vertSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X + tileSize, tileSize * vertSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X, tileSize * vertSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X, tileSize * vertSet.PY_Y));
                }
                if (!chunk.IsSolid(x, y - 1, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.0f, y - 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.0f, y - 0.5f, z + 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.0f, y - 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.0f, y - 0.5f, z + 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X + tileSize, tileSize * vertSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X + tileSize, tileSize * vertSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X, tileSize * vertSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X, tileSize * vertSet.PY_Y));
                }
            }
        }

        //negative X direction can extend out
        if (chunk.IsExtendable(x - 1, y, z)) { tempValue = true;

            if (!chunk.IsId(x - 1, y, z, blockId) && !chunk.IsSolid(x - 1, y, z)) {
                chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));
                chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f));
                chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f));
                chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));
                chunk.CalculateTriangles();
                chunk.collVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.05f));
                chunk.collVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.05f));
                chunk.collVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.05f));
                chunk.collVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.05f));
                chunk.CalculateCollTriangles();
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.NX_X + tileSize, tileSize * vertSet.NX_Y));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.NX_X + tileSize, tileSize * vertSet.NX_Y + tileSize));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.NX_X, tileSize * vertSet.NX_Y + tileSize));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.NX_X, tileSize * vertSet.NX_Y));
            }

            //positive X direction is not extenable, 0chance of joining with oposite side, extend fully towards teh empty block
            if (!chunk.IsExtendable(x + 1, y, z)) {

                // if (!chunk.IsId(x + 1, y, z, blockId) && !chunk.IsSolid(x + 1, y, z)) {
                    chunk.visuVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z + 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z + 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X + tileSize, tileSize * vertSet.PX_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X + tileSize, tileSize * vertSet.PX_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X, tileSize * vertSet.PX_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X, tileSize * vertSet.PX_Y));
                // if (!chunk.IsId(x, y, z + 1, blockId) && !chunk.IsSolid(x, y, z + 1)) {
                    chunk.visuVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z + 0.05f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z + 0.05f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.05f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.05f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X-.5f) + tileSize, tileSize * uvSet.PZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X-.5f) + tileSize, tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X, tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X, tileSize * uvSet.PZ_Y));
                // if (!chunk.IsId(x, y, z - 1, blockId) && !chunk.IsSolid(x, y, z - 1)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.05f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.05f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z - 0.05f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z - 0.05f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z - 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X+.5f), tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X+.5f), tileSize * uvSet.PZ_Y));

                if (!chunk.IsSolid(x, y + 1, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X + tileSize, tileSize * vertSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X + tileSize, tileSize * vertSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X, tileSize * vertSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X, tileSize * vertSet.PY_Y));
                }
                if (!chunk.IsSolid(x, y - 1, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X + tileSize, tileSize * vertSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X + tileSize, tileSize * vertSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X, tileSize * vertSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X, tileSize * vertSet.PY_Y));
                }

            } else { //positive X is extendible, only go half way so it can extend

                // if (!chunk.IsId(x, y, z + 1, blockId) && !chunk.IsSolid(x, y, z + 1)) {
                    chunk.visuVertices.Add(new Vector3(x + 0.0f, y - 0.5f, z + 0.05f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0f, y + 0.5f, z + 0.05f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.05f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.05f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x + 0.0f, y - 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X-.5f) + tileSize, tileSize * uvSet.PZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X-.5f) + tileSize, tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X, tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X, tileSize * uvSet.PZ_Y));
                // if (!chunk.IsId(x, y, z - 1, blockId) && !chunk.IsSolid(x, y, z - 1)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.05f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.05f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0f, y + 0.5f, z - 0.05f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0f, y - 0.5f, z - 0.05f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0f, y + 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0f, y - 0.5f, z - 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X+.5f), tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X+.5f), tileSize * uvSet.PZ_Y));

                if (!chunk.IsSolid(x, y + 1, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0f, y + 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0f, y + 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0f, y + 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X + tileSize, tileSize * vertSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X + tileSize, tileSize * vertSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X, tileSize * vertSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X, tileSize * vertSet.PY_Y));
                }
                if (!chunk.IsSolid(x, y - 1, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0f, y - 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.0f, y - 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0f, y - 0.5f, z - 0.05f));
                    chunk.collVertices.Add(new Vector3(x + 0.0f, y - 0.5f, z + 0.05f));
                    chunk.collVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.05f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X + tileSize, tileSize * vertSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X + tileSize, tileSize * vertSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X, tileSize * vertSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PY_X, tileSize * vertSet.PY_Y));
                }
            }
        }

        //positive Z direction can extend out
        if (chunk.IsExtendable(x, y, z + 1)) { tempValue = true;

            if (!chunk.IsId(x, y, z + 1, blockId) && !chunk.IsSolid(x, y, z + 1)) {
                chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));
                chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f));
                chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f));
                chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));
                chunk.CalculateTriangles();
                chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z + 0.5f));
                chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z + 0.5f));
                chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z + 0.5f));
                chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z + 0.5f));
                chunk.CalculateCollTriangles();
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PZ_X + tileSize, tileSize * vertSet.PZ_Y));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PZ_X + tileSize, tileSize * vertSet.PZ_Y + tileSize));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PZ_X, tileSize * vertSet.PZ_Y + tileSize));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PZ_X, tileSize * vertSet.PZ_Y));
            }

            //negitve Z direction is not extenable, 0chance of joining with oposite side, extend fully towards teh empty block
            if (!chunk.IsExtendable(x, y, z - 1)) {

                // if (!chunk.IsId(x, y, z - 1, blockId) && !chunk.IsSolid(x, y, z - 1)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.0625f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z - 0.0625f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z - 0.0625f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z - 0.0625f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z - 0.0625f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.NZ_X + tileSize, tileSize * vertSet.NZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.NZ_X + tileSize, tileSize * vertSet.NZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.NZ_X, tileSize * vertSet.NZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.NZ_X, tileSize * vertSet.NZ_Y));
                // if (!chunk.IsId(x + 1, y, z, blockId) && !chunk.IsSolid(x + 1, y, z)) {
                    chunk.visuVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z - 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z - 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z + 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z - 0.0625f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z - 0.0625f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z + 0.5f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z + 0.5f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.NZ_X-.5f) + tileSize, tileSize * uvSet.NZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.NZ_X-.5f) + tileSize, tileSize * uvSet.NZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.NZ_X, tileSize * uvSet.NZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.NZ_X, tileSize * uvSet.NZ_Y));
                // if (!chunk.IsId(x - 1, y, z, blockId) && !chunk.IsSolid(x - 1, y, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z - 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z - 0.0625f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z + 0.5f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z + 0.5f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z - 0.0625f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z - 0.0625f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X+.5f), tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X+.5f), tileSize * uvSet.PZ_Y));

                if (!chunk.IsSolid(x, y + 1, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.0625f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z + 0.5f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z + 0.5f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z - 0.0625f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z - 0.0625f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y));
                }
                if (!chunk.IsSolid(x, y - 1, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z - 0.0625f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z - 0.0625f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z + 0.5f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z + 0.5f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y));
                }

            } else { //negitice Z is extendible, only go half way so it can extend

                // if (!chunk.IsId(x + 1, y, z, blockId) && !chunk.IsSolid(x + 1, y, z)) {
                    chunk.visuVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z - 0.0f));
                    chunk.visuVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z - 0.0f));
                    chunk.visuVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z + 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z - 0.0f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z - 0.0f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z + 0.5f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z + 0.5f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.NZ_X-.5f) + tileSize, tileSize * uvSet.NZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.NZ_X-.5f) + tileSize, tileSize * uvSet.NZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.NZ_X, tileSize * uvSet.NZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.NZ_X, tileSize * uvSet.NZ_Y));
                // if (!chunk.IsId(x - 1, y, z, blockId) && !chunk.IsSolid(x - 1, y, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z - 0.0f));
                    chunk.visuVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z - 0.0f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z + 0.5f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z + 0.5f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z - 0.0f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z - 0.0f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X+.5f), tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X+.5f), tileSize * uvSet.PZ_Y));

                if (!chunk.IsSolid(x, y + 1, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.0f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.0f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z + 0.5f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z + 0.5f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z - 0.0f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z - 0.0f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y));
                }
                if (!chunk.IsSolid(x, y - 1, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.0f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.0f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z - 0.0f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z - 0.0f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z + 0.5f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z + 0.5f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y));
                }
            }
        }

        //negative Z direction can extend out
        if (chunk.IsExtendable(x, y, z - 1)) { tempValue = true;

            if (!chunk.IsId(x, y, z - 1, blockId) && !chunk.IsSolid(x, y, z - 1)) {
                chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));
                chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f));
                chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f));
                chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));
                chunk.CalculateTriangles();
                chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z - 0.5f));
                chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z - 0.5f));
                chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z - 0.5f));
                chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z - 0.5f));
                chunk.CalculateCollTriangles();
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PZ_X + tileSize, tileSize * vertSet.PZ_Y));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PZ_X + tileSize, tileSize * vertSet.PZ_Y + tileSize));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PZ_X, tileSize * vertSet.PZ_Y + tileSize));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PZ_X, tileSize * vertSet.PZ_Y));
            }

            //positive Z direction is not extenable, 0chance of joining with oposite side, extend fully towards teh empty block
            if (!chunk.IsExtendable(x, y, z + 1)) {

                // if (!chunk.IsId(x, y, z + 1, blockId) && !chunk.IsSolid(x, y, z + 1)) {
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.0625f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z + 0.0625f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z + 0.0625f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z + 0.0625f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z + 0.0625f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.NZ_X + tileSize, tileSize * vertSet.NZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.NZ_X + tileSize, tileSize * vertSet.NZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.NZ_X, tileSize * vertSet.NZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * vertSet.NZ_X, tileSize * vertSet.NZ_Y));
                // if (!chunk.IsId(x + 1, y, z, blockId) && !chunk.IsSolid(x + 1, y, z)) {
                    chunk.visuVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z + 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z + 0.0625f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z - 0.5f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z - 0.5f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z + 0.0625f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z + 0.0625f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X+.5f), tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X+.5f), tileSize * uvSet.PZ_Y));
                // if (!chunk.IsId(x - 1, y, z, blockId) && !chunk.IsSolid(x - 1, y, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z + 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z + 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z - 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z + 0.0625f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z + 0.0625f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z - 0.5f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z - 0.5f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.NZ_X-.5f) + tileSize, tileSize * uvSet.NZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.NZ_X-.5f) + tileSize, tileSize * uvSet.NZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.NZ_X, tileSize * uvSet.NZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.NZ_X, tileSize * uvSet.NZ_Y));

                if (!chunk.IsSolid(x, y + 1, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z + 0.0625f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z + 0.0625f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z - 0.5f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z - 0.5f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y));
                }
                if (!chunk.IsSolid(x, y - 1, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.0625f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z - 0.5f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z - 0.5f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z + 0.0625f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z + 0.0625f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y));
                }

            } else { //negitice Z is extendible, only go half way so it can extend

                // if (!chunk.IsId(x + 1, y, z, blockId) && !chunk.IsSolid(x + 1, y, z)) {
                    chunk.visuVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z + 0.0f));
                    chunk.visuVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z + 0.0f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z - 0.5f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z - 0.5f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z + 0.0f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z + 0.0f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X+.5f), tileSize * uvSet.PZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.PZ_X+.5f), tileSize * uvSet.PZ_Y));
                // if (!chunk.IsId(x - 1, y, z, blockId) && !chunk.IsSolid(x - 1, y, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z + 0.0f));
                    chunk.visuVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z + 0.0f));
                    chunk.visuVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z - 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z + 0.0f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z + 0.0f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z - 0.5f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z - 0.5f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.NZ_X-.5f) + tileSize, tileSize * uvSet.NZ_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * (uvSet.NZ_X-.5f) + tileSize, tileSize * uvSet.NZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.NZ_X, tileSize * uvSet.NZ_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * uvSet.NZ_X, tileSize * uvSet.NZ_Y));

                if (!chunk.IsSolid(x, y + 1, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.0f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.0f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z + 0.0f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z + 0.0f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y + 0.5f, z - 0.5f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y + 0.5f, z - 0.5f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y));
                }
                if (!chunk.IsSolid(x, y - 1, z)) {
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.0f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.0f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z - 0.5f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z - 0.5f));
                    chunk.collVertices.Add(new Vector3(x + 0.05f, y - 0.5f, z + 0.0f));
                    chunk.collVertices.Add(new Vector3(x - 0.05f, y - 0.5f, z + 0.0f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y));
                }
            }
        }

        //if nothing was rendered, then make a post
        if (!tempValue) { // same as if (tempValue == false) {

            // +X
            chunk.visuVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z - 0.5f));
            chunk.visuVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z - 0.5f));
            chunk.visuVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z + 0.5f));
            chunk.visuVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z + 0.5f));
            chunk.CalculateTriangles();
            chunk.collVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z - 0.5f));
            chunk.collVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z - 0.5f));
            chunk.collVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z + 0.5f));
            chunk.collVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z + 0.5f));
            chunk.CalculateCollTriangles();
            chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X + tileSize, tileSize * vertSet.PX_Y));
            chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X + tileSize, tileSize * vertSet.PX_Y + tileSize));
            chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X, tileSize * vertSet.PX_Y + tileSize));
            chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X, tileSize * vertSet.PX_Y));

                // -x
                chunk.visuVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z + 0.5f));
                chunk.visuVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z + 0.5f));
                chunk.visuVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z - 0.5f));
                chunk.visuVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z - 0.5f));
                chunk.CalculateTriangles();
                chunk.collVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z + 0.5f));
                chunk.collVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z + 0.5f));
                chunk.collVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z - 0.5f));
                chunk.collVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z - 0.5f));
                chunk.CalculateCollTriangles();
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X + tileSize, tileSize * vertSet.PX_Y));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X + tileSize, tileSize * vertSet.PX_Y + tileSize));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X, tileSize * vertSet.PX_Y + tileSize));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X, tileSize * vertSet.PX_Y));

                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.0625f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z + 0.0625f));
                    chunk.collVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z + 0.0625f));
                    chunk.collVertices.Add(new Vector3(x + 0.0625f, y + 0.5f, z - 0.0625f));
                    chunk.collVertices.Add(new Vector3(x - 0.0625f, y + 0.5f, z - 0.0625f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y));

                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.0625f));
                    chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.0625f));
                    chunk.CalculateTriangles();
                    chunk.collVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z - 0.0625f));
                    chunk.collVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z - 0.0625f));
                    chunk.collVertices.Add(new Vector3(x + 0.0625f, y - 0.5f, z + 0.0625f));
                    chunk.collVertices.Add(new Vector3(x - 0.0625f, y - 0.5f, z + 0.0625f));
                    chunk.CalculateCollTriangles();
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X + tileSize, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y + tileSize));
                    chunk.visuUVs.Add(new Vector2(tileSize * horiSet.PY_X, tileSize * horiSet.PY_Y));

                chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.0625f));
                chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.0625f));
                chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.0625f));
                chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.0625f));
                chunk.CalculateTriangles();
                chunk.collVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z + 0.0625f));
                chunk.collVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z + 0.0625f));
                chunk.collVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z + 0.0625f));
                chunk.collVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z + 0.0625f));
                chunk.CalculateCollTriangles();
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X + tileSize, tileSize * vertSet.PX_Y));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X + tileSize, tileSize * vertSet.PX_Y + tileSize));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X, tileSize * vertSet.PX_Y + tileSize));
                chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X, tileSize * vertSet.PX_Y));

            chunk.visuVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.0625f));
            chunk.visuVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.0625f));
            chunk.visuVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.0625f));
            chunk.visuVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.0625f));
            chunk.CalculateTriangles();
            chunk.collVertices.Add(new Vector3(x - 0.5f, y - 0.5f, z - 0.0625f));
            chunk.collVertices.Add(new Vector3(x - 0.5f, y + 0.5f, z - 0.0625f));
            chunk.collVertices.Add(new Vector3(x + 0.5f, y + 0.5f, z - 0.0625f));
            chunk.collVertices.Add(new Vector3(x + 0.5f, y - 0.5f, z - 0.0625f));
            chunk.CalculateCollTriangles();
            chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X + tileSize, tileSize * vertSet.PX_Y));
            chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X + tileSize, tileSize * vertSet.PX_Y + tileSize));
            chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X, tileSize * vertSet.PX_Y + tileSize));
            chunk.visuUVs.Add(new Vector2(tileSize * vertSet.PX_X, tileSize * vertSet.PX_Y));
        }
    }
}

public static partial class SVBaseMeshing {

    public static void Pane (Mesh mesh, MeshUVSet uvSet) {

        mesh.vertices = new Vector3[] {

            // PX Face.
            new Vector3(0.0f, -0.5f, -0.5f),
            new Vector3(0.0f,  0.5f, -0.5f),
            new Vector3(0.0f,  0.5f,  0.5f),
            new Vector3(0.0f, -0.5f,  0.5f),

            // NX Face.
            new Vector3(-0.0f, -0.5f,  0.5f),
            new Vector3(-0.0f,  0.5f,  0.5f),
            new Vector3(-0.0f,  0.5f, -0.5f),
            new Vector3(-0.0f, -0.5f, -0.5f),

            // PY Face.
            new Vector3(-0.05f, 0.5f,  0.5f),
            new Vector3( 0.05f, 0.5f,  0.5f),
            new Vector3( 0.05f, 0.5f, -0.5f),
            new Vector3(-0.05f, 0.5f, -0.5f),

            // NY Face.
            new Vector3(-0.05f, -0.5f, -0.5f),
            new Vector3( 0.05f, -0.5f, -0.5f),
            new Vector3( 0.05f, -0.5f,  0.5f),
            new Vector3(-0.05f, -0.5f,  0.5f),

            // PZ Face.
            new Vector3( 0.05f, -0.5f, 0.5f),
            new Vector3( 0.05f,  0.5f, 0.5f),
            new Vector3(-0.05f,  0.5f, 0.5f),
            new Vector3(-0.05f, -0.5f, 0.5f),

            // NZ Face.
            new Vector3(-0.05f, -0.5f, -0.5f),
            new Vector3(-0.05f,  0.5f, -0.5f),
            new Vector3( 0.05f,  0.5f, -0.5f),
            new Vector3( 0.05f, -0.5f, -0.5f),
        };

        mesh.triangles = new int[] {

            // PX Face.
            0, 1, 2,  0, 2, 3,

            // NX Face.
            4, 5, 6,  4, 6, 7,

            // PY Face.
            8, 9, 10,  8, 10, 11,

            // NY Face.
            12, 13, 14,  12, 14, 15,

            // PZ Face.
            16, 17, 18,  16, 18, 19,

            // NZ Face.
            20, 21, 22,  20, 22, 23,
        };

        mesh.uv = new Vector2[] {

            // PX Face.
            new Vector2(tileSize * uvSet.PX_X + tileSize, tileSize * uvSet.PX_Y),
            new Vector2(tileSize * uvSet.PX_X + tileSize, tileSize * uvSet.PX_Y + tileSize),
            new Vector2(tileSize * uvSet.PX_X, tileSize * uvSet.PX_Y + tileSize),
            new Vector2(tileSize * uvSet.PX_X, tileSize * uvSet.PX_Y),

            // NX Face.
            new Vector2(tileSize * uvSet.NX_X + tileSize, tileSize * uvSet.NX_Y),
            new Vector2(tileSize * uvSet.NX_X + tileSize, tileSize * uvSet.NX_Y + tileSize),
            new Vector2(tileSize * uvSet.NX_X, tileSize * uvSet.NX_Y + tileSize),
            new Vector2(tileSize * uvSet.NX_X, tileSize * uvSet.NX_Y),

            // PY Face.
            new Vector2(tileSize * uvSet.PY_X + tileSize, tileSize * uvSet.PY_Y),
            new Vector2(tileSize * uvSet.PY_X + tileSize, tileSize * uvSet.PY_Y + tileSize),
            new Vector2(tileSize * uvSet.PY_X, tileSize * uvSet.PY_Y + tileSize),
            new Vector2(tileSize * uvSet.PY_X, tileSize * uvSet.PY_Y),

            // NY Face.
            new Vector2(tileSize * uvSet.NY_X + tileSize, tileSize * uvSet.NY_Y),
            new Vector2(tileSize * uvSet.NY_X + tileSize, tileSize * uvSet.NY_Y + tileSize),
            new Vector2(tileSize * uvSet.NY_X, tileSize * uvSet.NY_Y + tileSize),
            new Vector2(tileSize * uvSet.NY_X, tileSize * uvSet.NY_Y),

            // PZ Face.
            new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y),
            new Vector2(tileSize * uvSet.PZ_X + tileSize, tileSize * uvSet.PZ_Y + tileSize),
            new Vector2(tileSize * uvSet.PZ_X, tileSize * uvSet.PZ_Y + tileSize),
            new Vector2(tileSize * uvSet.PZ_X, tileSize * uvSet.PZ_Y),

            // NZ Face.
            new Vector2(tileSize * uvSet.NZ_X + tileSize, tileSize * uvSet.NZ_Y),
            new Vector2(tileSize * uvSet.NZ_X + tileSize, tileSize * uvSet.NZ_Y + tileSize),
            new Vector2(tileSize * uvSet.NZ_X, tileSize * uvSet.NZ_Y + tileSize),
            new Vector2(tileSize * uvSet.NZ_X, tileSize * uvSet.NZ_Y),
        };
    }
}
