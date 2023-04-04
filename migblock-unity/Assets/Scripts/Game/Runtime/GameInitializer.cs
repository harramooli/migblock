
using UnityEngine;

public class GameInitializer : MonoBehaviour {

    private void Awake () {

        //initialize minecraft layer
        MinecraftInterfaceLayer.Start(GameRuntimeValues.sessionInformation);

        //recv and set player position

        //start loading chunks
    }

    private void Start () {

    }

    private void OnDestroy () {

        MinecraftInterfaceLayer.Stop();
    }
}
