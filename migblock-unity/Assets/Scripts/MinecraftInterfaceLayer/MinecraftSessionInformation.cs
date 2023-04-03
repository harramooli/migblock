
public class MinecraftSessionInformation {

    public string serverAddress;
    public int serverPort;
    public string serverVersion;

    public string username;

    public MinecraftSessionInformation (string a, int b, string c, string d) {

        serverAddress = a;
        serverPort = b;
        serverVersion = c;
        username = d;
    }

    public MinecraftSessionInformation () {}
}
