
using UnityEngine;

public class PlayerReference : MonoBehaviour {

    private void Start () {

        PlayerRef.transform = this.transform;
        PlayerRef.head = head;
    }

    public Transform head;
}

public static class PlayerRef {

    public static Transform transform;
    public static Transform head;
}
