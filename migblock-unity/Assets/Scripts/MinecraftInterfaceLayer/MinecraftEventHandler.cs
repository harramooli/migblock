
using UnityEngine;

public class MinecraftEventHandler : MonoBehaviour {

    private void Update () {

        if (MinecraftInterfaceLayer.outputQueue.Count != 0) {

            switch (MinecraftInterfaceLayer.outputQueue.Dequeue()) {

                case "spawn": {

                    float x = float.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    float y = float.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());
                    float z = float.Parse(MinecraftInterfaceLayer.outputQueue.Dequeue());

                    Debug.Log("spawned! location: " + x + " " + y + " " + z);

                    Camera.main.gameObject.transform.position = new Vector3(x, y, z);

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

                    ChunkLoadController.OnChunkLoad(chunkX, chunkZ, values);

                    // sw.Stop(); Debug.Log(sw.ElapsedMilliseconds + "ms");
                    //
                    // Debug.Log(values.Length + " length");

                break; }
            }
        }
    }
}
