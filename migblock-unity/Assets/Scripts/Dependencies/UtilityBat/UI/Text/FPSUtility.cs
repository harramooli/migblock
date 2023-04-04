
using UnityEngine;
using UnityEngine.UI;

public class FPSUtility : MonoBehaviour {

    private Text text;

    private float timer;

    private void Awake () {

        text = GetComponent<Text>();
    }

    private void Update () {

        timer -= Time.deltaTime;
        if (timer < 0) timer = 1; else return;

        text.text = "Frame Rate: " +
            (1 / Time.smoothDeltaTime).ToString("0") + " / Target: " +
            Application.targetFrameRate.ToString()
        ;
    }
}
