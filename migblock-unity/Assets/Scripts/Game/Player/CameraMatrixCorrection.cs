
//this script will flip the camera rendering to match minecraft

using UnityEngine;

public class CameraMatrixCorrection : MonoBehaviour {

    private void Start () {

        Matrix4x4 matrix = Camera.main.projectionMatrix;
        matrix *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
        Camera.main.projectionMatrix = matrix;
    }
}
