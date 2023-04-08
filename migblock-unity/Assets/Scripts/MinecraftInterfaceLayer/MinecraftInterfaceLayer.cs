
using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

using UnityEngine;

public static class MinecraftInterfaceLayer {

    // private const string execName = "./Minecraft/Network/mcil";
    private const string execName = "./mcil";

    private static Process minecraftInterface;
    private static bool running;

    public static void Start (MinecraftSessionInformation sessionInformation) {

        if (running) return;

        string processArguments = "";
        processArguments += sessionInformation.serverAddress;
        processArguments += " " + sessionInformation.serverPort.ToString();
        processArguments += " " + sessionInformation.username;
        processArguments += " " + sessionInformation.serverVersion;

        minecraftInterface = new Process();
        minecraftInterface.StartInfo.FileName = execName;
        minecraftInterface.StartInfo.CreateNoWindow = true;
        minecraftInterface.StartInfo.UseShellExecute = false;
        minecraftInterface.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		minecraftInterface.StartInfo.Arguments = processArguments;
        minecraftInterface.StartInfo.RedirectStandardOutput = true;
        minecraftInterface.StartInfo.RedirectStandardError = true;
        minecraftInterface.StartInfo.RedirectStandardInput = true;

        minecraftInterface.Start();

        new Thread(()=>OutputReadLoop(minecraftInterface.StandardOutput)).Start();
        new Thread(()=>ErrputReadLoop(minecraftInterface.StandardError)).Start();
        new Thread(()=>InputWriteLoop(minecraftInterface.StandardInput)).Start();

        running = true;
    }

    public static void Stop () {

        if (!running) return;

        minecraftInterface.Kill();
        running = false;
    }

    public static ThreadsafeQueue<string> outputQueue = new ThreadsafeQueue<string>();

    private static void OutputReadLoop (StreamReader interfaceOutput) {

        // while (!interfaceOutput.EndOfStream) {
        while (running) {

            string line = interfaceOutput.ReadLine();
            outputQueue.Enqueue(line);
        }

        UnityEngine.Debug.Log("read.exit!");
    }

    public static ThreadsafeQueue<string> errputQueue = new ThreadsafeQueue<string>();

    private static void ErrputReadLoop (StreamReader interfaceErrput) {

        // while (!interfaceOutput.EndOfStream) {
        while (running) {

            string line = interfaceErrput.ReadLine();
            errputQueue.Enqueue(line);
        }

        UnityEngine.Debug.Log("read.err.exit!");
    }

    public static ThreadsafeQueue<string> inputQueue = new ThreadsafeQueue<string>();

    private static void InputWriteLoop (StreamWriter interfaceInput) {

        while (running) {

            if (inputQueue.Size() != 0) {

                interfaceInput.WriteLine(inputQueue.Dequeue());

            } else Thread.Sleep(10);
        }

        UnityEngine.Debug.Log("write.exit!");
    }
}
