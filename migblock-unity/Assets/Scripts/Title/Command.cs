
using UnityEngine;

public static class Command {

    public static void Exec (SimpleTitle console, string input) {

        string[] args = input.Contains(" ") ? input.Split(' ') : new string[]{input} ;

        switch (args[0]) {

            case "help": {

                console.Logf("To launch the Game, try the following:");
                console.Logf("start <USERNAME> <IPA> <PORT> <MC_VERSION>");

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

                if (args.Length != 5) {

                    console.Logf("start: Invalid arguments! Run help for usage.");

                break; }

                console.Logf("<color=red>Exception</color>! Not implemented!");

            break; }

            default: {

                console.Logf($"{Application.productName}.titleConsole: {args[0]}: <color=red>Unknown command</color>!");

            break;}
        }
    }
}
