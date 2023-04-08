
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public float sensitivity = 6.0f;
    private float pitchCache, pitch, yawCache, yaw, timer;

    private void Update () {

        if (Input.GetKeyDown(KeyCode.Return)) {

            Cursor.visible = !Cursor.visible;

            if (!Cursor.visible) {

                Cursor.lockState = CursorLockMode.Locked;

            } else {

                Cursor.lockState = CursorLockMode.None;
            }
        }

        if (Cursor.visible) return;


        if (Input.GetKeyDown(KeyCode.W))
            MinecraftInterfaceLayer.inputQueue.Enqueue("keyDown W");
        if (Input.GetKeyUp(KeyCode.W))
            MinecraftInterfaceLayer.inputQueue.Enqueue("keyUp W");

        if (Input.GetKeyDown(KeyCode.A))
            MinecraftInterfaceLayer.inputQueue.Enqueue("keyDown A");
        if (Input.GetKeyUp(KeyCode.A))
            MinecraftInterfaceLayer.inputQueue.Enqueue("keyUp A");

        if (Input.GetKeyDown(KeyCode.S))
            MinecraftInterfaceLayer.inputQueue.Enqueue("keyDown S");
        if (Input.GetKeyUp(KeyCode.S))
            MinecraftInterfaceLayer.inputQueue.Enqueue("keyUp S");

        if (Input.GetKeyDown(KeyCode.D))
            MinecraftInterfaceLayer.inputQueue.Enqueue("keyDown D");
        if (Input.GetKeyUp(KeyCode.D))
            MinecraftInterfaceLayer.inputQueue.Enqueue("keyUp D");

        if (Input.GetKeyDown(KeyCode.Space))
            MinecraftInterfaceLayer.inputQueue.Enqueue("keyDown Space");
        if (Input.GetKeyUp(KeyCode.Space))
            MinecraftInterfaceLayer.inputQueue.Enqueue("keyUp Space");


        yaw += sensitivity * Input.GetAxis("Mouse X");
        pitch -= sensitivity * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);

        Camera.main.gameObject.transform.eulerAngles = new Vector3(pitch, yaw, 0);

        if (timer < 0) { timer = 0.1f;

            if (pitchCache != pitch || yawCache != yaw) {

                //convert unity degrees to minecraft radians, and adjust matrixes with inversion
                MinecraftInterfaceLayer.inputQueue.Enqueue($"look {-dtr(90+yaw)} {-dtr(pitch)}");
            }

        } else timer -= Time.deltaTime;

        pitchCache = pitch; yawCache = yaw;
    }

    public float dtr (float d) {

        return (Mathf.PI / 180) * d;
    }

    public float rtd (float r) {

        return (180 / Mathf.PI) * r;
    }
}
