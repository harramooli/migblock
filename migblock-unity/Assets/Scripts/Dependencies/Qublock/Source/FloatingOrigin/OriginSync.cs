
using UnityEngine;

using System.Collections.Generic;

using Qublock.FloatingOrigin;
using Qublock.Core;

public class OriginSync : MonoBehaviour {

    public static OriginSync instance;

    private void Awake () {

        instance = this;
        syncCache.Clear();
    }

    private void Start () {

        Origin.ResetOffset();

        controller = GetComponent<CharacterController>();
    }

    private void Update () {

        while (transform.position.x > 16)
            Recenter(new Vector3(-16, 0, 0));

        while (transform.position.x < -16)
            Recenter(new Vector3(16, 0, 0));


        while (transform.position.y > 64)
            Recenter(new Vector3(0, -64, 0));

        while (transform.position.y < -64)
            Recenter(new Vector3(0, 64, 0));


        while (transform.position.z > 16)
            Recenter(new Vector3(0, 0, -16));

        while (transform.position.z < -16)
            Recenter(new Vector3(0, 0, 16));
    }

    private CharacterController controller;

    public Transform[] objectsToSync;

    public List<Transform> syncCache = new List<Transform>();

    public void Recenter (Vector3 newOffset) {

        //Offset local player
        if (controller != null) controller.gameObject.SetActive(false);
        transform.position += newOffset;
        if (controller != null) controller.gameObject.SetActive(true);

        //Offset chunks
        foreach (Chunk chunk in World.data.chunks.Values) {

            chunk.chunkObject.transform.position += newOffset;
        }

        //Offset objectsToSync
        foreach (Transform ts in objectsToSync) {

            ts.position += newOffset;
        }

        //offset cached transforms
        foreach (Transform ts in syncCache) {

            ts.position += newOffset;
        }

        Origin.AddToOffset(newOffset);
    }
}
