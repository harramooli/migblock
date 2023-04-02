
using UnityEngine;
using UnityEngine.UI;

using TMPro;

using System;

public class SimpleTitle : MonoBehaviour {

    public TMP_Text text;

    public void Log (string a) {

        Debug.Log(a);

        text.text += a;
    }
    public void Logf (string a) { Log(a+"\n"); }
    public void Logf () { Log("\n"); }

    public InputField inputField;
    public string inputValue;

    public void OnFieldEdit () {

        inputValue += inputField.text;
        char c = text.text[text.text.Length-1];
        text.text = text.text.Remove(text.text.Length - 1);
        text.text += inputField.text + c;
        inputField.text = "";
    }

    public void OnFieldEndEdit () {

        if (inputValue == "") return;

        text.text = text.text.Remove(text.text.Length - 1);
        Logf();

        Command.Exec(this, inputValue);
        inputValue = "";

        Prompt();
    }

    private void Start () {

        Logf("Migblock Client, version " + Application.version);
        Logf(Application.productName);
        Logf();
        Logf("OS: " + Environment.OSVersion.ToString().Replace("Unix", "GNU/Linux"));
        Logf("Machine Type: " + (Environment.Is64BitOperatingSystem ? "x86_64" : "x86"));
        Logf("Machine Name: " + Environment.MachineName);
        Logf("Running in CLI: " + Environment.CommandLine);
        Logf("Running in C# Build: " + Environment.Version);
        Logf("Working Set: " + Environment.WorkingSet);
        Logf("Working in: " + Environment.CurrentDirectory);
        Logf();
        Logf("Migblock, ready to play!");
        Logf("Passing control to User.. Calling Prompt()..");
        Logf();

        Prompt();
    }

    private float timer = .48f;

    private void Update () {

        if (Input.GetKeyDown(KeyCode.Backspace) && inputValue != "") {

            inputValue = inputValue.Remove(inputValue.Length - 1);
            text.text = text.text.Remove(text.text.Length - 1);
        }

        if (timer < 0) { timer = .48f;

            char c = text.text[text.text.Length-1] == ' ' ? '_' : ' ';
            text.text = text.text.Remove(text.text.Length - 1) + c;

        } else timer -= Time.deltaTime;
    }

    private void Prompt () {

        string prompt = $"<color=green>{Environment.UserName}@{Environment.MachineName}</color> > _";

        Log(prompt);

        inputField.ActivateInputField();
    }
}
