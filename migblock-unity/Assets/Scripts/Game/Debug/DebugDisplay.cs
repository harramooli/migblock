
using System;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

using Qublock.Core;
using Qublock.FloatingOrigin;

public class DebugDisplay : MonoBehaviour {

    private TMP_Text display;

    private void Start () {

        display = GetComponent<TMP_Text>();
    }

    private float timer;

    private void Update () {

        timer -= Time.deltaTime;
        if (timer < 0) timer = 1; else return;

        //frame rate
        display.text = "FPS: " +
            (1 / Time.smoothDeltaTime).ToString("0") + " / Target: " +
            Application.targetFrameRate.ToString()
        ;

        //position
        display.text += "\n" + "POS: " +
            (PlayerRef.transform.position.x-Origin.worldX).ToString("0.0") + "(" +
                PlayerRef.transform.position.x.ToString("0.0") + ") : " +

            (PlayerRef.transform.position.y-Origin.worldY).ToString("0.0") + "(" +
                PlayerRef.transform.position.y.ToString("0.0") + ") : " +

            (PlayerRef.transform.position.z-Origin.worldZ).ToString("0.0") + "(" +
                PlayerRef.transform.position.z.ToString("0.0") + ")"
        ;
        display.text += "\n" + "POS.Origin.world: " +
            Origin.worldX.ToString("0.0") + " : " +
            Origin.worldY.ToString("0.0") + " : " +
            Origin.worldZ.ToString("0.0")
        ;
        display.text += "\n" + "POS.Origin.chunk: " +
            Origin.chunkX.ToString("0.0") + " : " +
            Origin.chunkY.ToString("0.0") + " : " +
            Origin.chunkZ.ToString("0.0")
        ;
        // display.text += "\n" + "POS.SI: " +
        //     ((int)(PlayerRef.transform.position.x-Origin.worldX) >> 8) + " : " +
        //     ((int)(PlayerRef.transform.position.y-Origin.worldY) >> 8) + " : " +
        //     ((int)(PlayerRef.transform.position.z-Origin.worldZ) >> 8)
        // ;
        display.text += "\n" + "POS.CI: " +
            ((int)(PlayerRef.transform.position.x-Origin.worldX) >> 4) + " : " +
            ((int)(PlayerRef.transform.position.y-Origin.worldY) >> 6) + " : " +
            ((int)(PlayerRef.transform.position.z-Origin.worldZ) >> 4)
        ;

        //runtime info
        display.text += "\n" + "Runtime: " +
            Environment.OSVersion.ToString().Replace("Unix", "GNU/Linux") + ", " +
            (Environment.Is64BitOperatingSystem ? "amd64" : "i386") + ", UE." +
            Application.unityVersion
        ;

        //version info
        display.text += "\n" + "Migblock Version: " +
            Application.version
        ;

        //date time info
        display.text += "\n" + "Date Time: " +
            DateTime.Now.ToString()
        ;

        //chunk count
        display.text += "\n" + "Loaded Chunks: " +
            World.data.chunks.Count.ToString()
        ;

        //compass info
        display.text += "\n" + "Facing: " +
            directions[((int)PlayerRef.transform.eulerAngles.y + 23) / 45]
        ;

        // //connection info
        // display.text += "\n" + "Connection: " +
        //     (Config.Runtime.Values.LocalHosting ? "Host" : "Guest")
        // ;

        //screen info
        display.text += "\n" + "Screen: " +
            Screen.width.ToString() + " x " + Screen.height.ToString()
        ;

        // //epoch info
        // display.text += "\n" + "Epoch: " +
        //     Epoch.Day.ToString()
        // ;

        // //light depth info
        // display.text += "\n" + "Light Depth: " +
        //     DynamicLightPlayerMonitor.depthThickness.ToString()
        // ;

        // //day count info
        // display.text += "\n" + "Day: " +
        //     Epoch.DayCount.ToString()
        // ;

        // //entity count info
        // display.text += "\n" + "Entities: " +
        //     Drifture.EntityManager.Count.ToString()
        // ;
    }

    private static string[] directions = new string[] {
        "North", "North East", "East", "South East", "South", "South West", "West", "North West", "North"
    };
}
