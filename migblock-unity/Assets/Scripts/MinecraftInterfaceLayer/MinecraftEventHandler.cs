
using UnityEngine;

using Qublock.FloatingOrigin;

public class MinecraftEventHandler : MonoBehaviour {

    private void Update () {

        StdEvent(); ErrEvent();
    }

    private void StdEvent () {

        if (MinecraftInterfaceLayer.outputQueue.Count != 0) {

            switch (MinecraftInterfaceLayer.outputQueue.Dequeue()) {

                case "spawn": {

                    float x = float.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    float y = float.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    float z = float.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    float yaw = float.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    float pitch = float.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());

                    Debug.Log("spawned! location: " + x + " " + y + " " + z + " " + yaw + " " + pitch);

                    // swap x and z to invert minecraft to qublock matrix
                    PlayerRef.transform.position = new Vector3(z, y, x);
                    PlayerRef.head.eulerAngles = new Vector3(
                        -( (180/Mathf.PI) * pitch), -( (180/Mathf.PI) * yaw), 0
                    ); //convert minecraft radians to unity degrees, and adjust matrixes with inversion

                break; }

                case "chat": {

                    string username = MinecraftInterfaceLayer.outputQueue.Dequeue();
                    string message = MinecraftInterfaceLayer.outputQueue.Dequeue();

                    Debug.Log(username + ": " + message);

                break; }

                case "blockUpdate": {

                    int x = int.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    int y = int.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    int z = int.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    ushort id = ushort.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());

                    // Debug.Log("block update! " + x + " " + y + " " + z + " " + id);

                    // swap x and z to invert minecraft to qublock matrix
                    try { Qublock.Core.World.ChangeBlock(z, y, x, id); } catch {}

                break; }

                case "move": {

                    float x = float.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    float y = float.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    float z = float.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());

                    // Debug.Log("position update! " + x + " " + y + " " + z);

                    // swap x and z to invert minecraft to qublock matrix
                    PlayerRef.transform.position = Origin.OffsetToUnity(new Vector3(z, y, x));

                break; }
            }
        }
    }

    private void ErrEvent () {

        if (MinecraftInterfaceLayer.errputQueue.Count != 0) {

            switch (MinecraftInterfaceLayer.errputQueue.Dequeue()) {

                case "chunkLoad": {

                    // System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    // sw.Start();

                    int chunkX = int.Parse(MinecraftInterfaceLayer.errputQueue.Dequeue());
                    int chunkZ = int.Parse(MinecraftInterfaceLayer.errputQueue.Dequeue());
                    string chunkData = MinecraftInterfaceLayer.errputQueue.Dequeue();

                    string[] blocks = chunkData.Split(',');
                    ushort[] values = new ushort[blocks.Length];

                    for (int i = 0; i < blocks.Length; ++i)
                        values[i] = ushort.Parse(blocks[i]);

                    // swap x and z to invert minecraft to qublock matrix
                    ChunkLoadController.OnChunkLoad(chunkZ, chunkX, values);

                    // sw.Stop(); Debug.Log(sw.ElapsedMilliseconds + "ms");
                    //
                    // Debug.Log(values.Length + " length");

                break; }

                case "chunkUnload": {

                    int chunkX = int.Parse(MinecraftInterfaceLayer.errputQueue.Dequeue());
                    int chunkZ = int.Parse(MinecraftInterfaceLayer.errputQueue.Dequeue());

                    // swap x and z to invert minecraft to qublock matrix
                    ChunkLoadController.OnChunkUnload(chunkZ, chunkX);

                break; }
            }
        }
    }
}
