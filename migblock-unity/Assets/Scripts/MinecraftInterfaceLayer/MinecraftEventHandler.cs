
using UnityEngine;

using Qublock.FloatingOrigin;

public class MinecraftEventHandler : MonoBehaviour {

    private void Update () {

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
                    Camera.main.gameObject.transform.position = new Vector3(z, y, x);
                    Camera.main.gameObject.transform.eulerAngles = new Vector3(
                        -( (180/Mathf.PI) * pitch), -( (180/Mathf.PI) * yaw), 0
                    ); //convert minecraft radians to unity degrees, and adjust matrixes with inversion

                break; }

                case "chat": {

                    string username = MinecraftInterfaceLayer.outputQueue.Dequeue();
                    string message = MinecraftInterfaceLayer.outputQueue.Dequeue();

                    Debug.Log(username + ": " + message);

                break; }

                case "chunkLoad": {

                    // System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    // sw.Start();

                    int chunkX = int.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    int chunkZ = int.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    string chunkData = MinecraftInterfaceLayer.outputQueue.Dequeue();

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

                    int chunkX = int.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    int chunkZ = int.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());

                    // swap x and z to invert minecraft to qublock matrix
                    ChunkLoadController.OnChunkUnload(chunkZ, chunkX);

                break; }

                case "blockUpdate": {

                    int x = int.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    int y = int.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    int z = int.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    ushort id = ushort.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());

                    Debug.Log("block update! " + x + " " + y + " " + z + " " + id);

                    // swap x and z to invert minecraft to qublock matrix
                    Qublock.Core.World.ChangeBlock(z, y, x, id);

                break; }

                case "move": {

                    float x = float.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    float y = float.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    float z = float.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());

                    // Debug.Log("position update! " + x + " " + y + " " + z);

                    // swap x and z to invert minecraft to qublock matrix
                    Camera.main.gameObject.transform.position = Origin.OffsetToUnity(new Vector3(z, y, x));

                break; }
            }
        }
    }
}
