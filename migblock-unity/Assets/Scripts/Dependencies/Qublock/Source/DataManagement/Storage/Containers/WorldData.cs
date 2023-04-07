
using System;
using System.Collections.Generic;

using Qublock.Core;
using Qublock.Data.Storage.Structures;

namespace Qublock.Data.Storage.Containers {

    public class WorldData {

        public Dictionary<ChunkLoc, Chunk> chunks =
            new Dictionary<ChunkLoc, Chunk>();

        public ushort this[int x, int y, int z] {

            get {

                if (chunks.ContainsKey(ChunkLoc.FromWorldPos(x, y, z)))
                    return chunks[ChunkLoc.FromWorldPos(x, y, z)]
                        [x & 0xF, y & 0x3F, z & 0xF];

                return 1;
            }

            set {

                chunks[ChunkLoc.FromWorldPos(x, y, z)]
                    [x & 0xF, y & 0x3F, z & 0xF] = value;
            }
        }
    }
}
