
using System;
using System.Collections.Generic;

using Qublock.Data.Storage.Structures;
using Qublock.Data.Serialization.Compression;
using Qublock.Core;

public static class ChunkLoadController {

    private static List<ChunkLoc> chunkCache = new List<ChunkLoc>();

    public static void OnChunkLoad (int chunkX, int chunkZ, ushort[] chunkData) {

        chunkX = chunkX >> 4; chunkZ = chunkZ >> 4;

        //if not already loaded, load it
        // if (!chunkCache.Contains(new ChunkLoc(chunkX, 0, chunkZ))) {
        if (!World.ChunkLoaded(new ChunkLoc(chunkX, 0, chunkZ))) {

            for (int y = 0; y < 4; ++y)
                World.CreateChunk(new ChunkLoc(chunkX, y, chunkZ));
        }

        //then update it
        chunkData = RunLengthEncoding.Decode(chunkData);
        ushort[] tempBuffer = new ushort[16384];
        for (int y = 0; y < 4; ++y) {

            tempBuffer = new ushort[16384];
            for (int i = 0; i < 16384; ++i) tempBuffer[i] = chunkData[i + (y * 16384)];
            World.data.chunks[new ChunkLoc(chunkX, y, chunkZ)].SetValues(tempBuffer);
        }

        //then render it
        for (int y = 0; y < 4; ++y)
            World.RenderChunk(new ChunkLoc(chunkX, y, chunkZ));

        //then render neighbor chunks
            //maybe in future have surrounded checks, if this causes bad performance
        for (int y = 0; y < 4; ++y) {

            World.RenderIfVisible(new ChunkLoc(chunkX + 1, y, chunkZ));
            World.RenderIfVisible(new ChunkLoc(chunkX - 1, y, chunkZ));
            World.RenderIfVisible(new ChunkLoc(chunkX, y, chunkZ + 1));
            World.RenderIfVisible(new ChunkLoc(chunkX, y, chunkZ - 1));
        }
    }

    public static void OnChunkUnload (int chunkX, int chunkZ) {

        chunkX = chunkX >> 4; chunkZ = chunkZ >> 4;

        if (!World.ChunkLoaded(new ChunkLoc(chunkX, 0, chunkZ))) return;

        for (int y = 0; y < 4; ++y)
            World.DestroyChunk(new ChunkLoc(chunkX, y, chunkZ));
    }
}
