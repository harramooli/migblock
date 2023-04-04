
using UnityEngine;

public static class Command {

    public static void Exec (SimpleTitle console, string input) {

        string[] args = input.Contains(" ") ? input.Split(' ') : new string[]{input} ;

        switch (args[0]) {

            case "help": {

                console.Logf("To launch the Game, try the following:");
                console.Logf("start <USERNAME> <IPA> <PORT> <MC_VERSION>");
                console.Logf("or for hard coded values:");
                console.Logf("start default");

            break; }

            case "exit": {

                console.Logf("Exiting.. Thank you and goodbye.");
                Application.Quit();

            break; }

            case "fps": {

                console.Log("Frame Rate: ");
                console.Log((1 / Time.smoothDeltaTime).ToString("0"));
                console.Logf(" FPS.");

            break; }

            case "start": {

                if (args.Length != 5 && args.Length != 2) {

                    console.Logf("start: Invalid arguments! Run help for usage.");

                break; }

                if (args[1] == "default") {

                    GameRuntimeValues.sessionInformation = new MinecraftSessionInformation{

                        serverAddress = "localhost",
                        serverPort = 25565,
                        serverVersion = "1.12.2",

                        username = "steve",
                    };

                } else {

                    GameRuntimeValues.sessionInformation = new MinecraftSessionInformation{

                        serverAddress = args[2],
                        serverPort = int.Parse(args[3]),
                        serverVersion = args[4],

                        username = args[1],
                    };
                }

                console.Logf("<color=cyan>starting Game</color>...");

                UnityEngine.SceneManagement.SceneManager.LoadScene("Game");

            break; }

            // case "stop": {
            //
            //     MinecraftInterfaceLayer.Stop();
            //
            //     console.Logf("MinecraftInterfaceLayer.Stop() called...");
            //
            // break; }

            // case "read": {
            //
            //     while (MinecraftInterfaceLayer.outputQueue.Size() != 0) {
            //
            //         console.Logf(MinecraftInterfaceLayer.outputQueue.Dequeue());
            //     }
            //
            // break; }
            //
            // case "write": {
            //
            //     if (args.Length < 2) return;
            //
            //     string val = args[1];
            //     for (int i = 2; i < args.Length; ++i)
            //         val += " " + args[i];
            //
            //     MinecraftInterfaceLayer.inputQueue.Enqueue(val);
            //
            // break; }
            //
            // case "stats": {
            //
            //     console.Logf($"read count: {MinecraftInterfaceLayer.outputQueue.Size().ToString()}");
            //     console.Logf($"write count: {MinecraftInterfaceLayer.inputQueue.Size().ToString()}");
            //
            // break; }

            default: {

                console.Logf($"{Application.productName}.titleConsole: {args[0]}: <color=red>Unknown command</color>!");

            break;}
        }
    }
}
