using System.Text.RegularExpressions;

Console.WriteLine("Enter the notification title:");
string notificationTitle = Console.ReadLine();
ParseNotificationChannels(notificationTitle);
ParseNotificationChannelsRegx(notificationTitle);

static void ParseNotificationChannels(string notificationTitle)
{
    string[] tags = notificationTitle.Split(new[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);

    List<string> notificationChannels = new List<string>();
    
    foreach (string tag in tags)
    {
        switch (tag)
        {
            case "BE":
                notificationChannels.Add("BE");
                break;
            case "FE":
                notificationChannels.Add("FE");
                break;
            case "QA":
                notificationChannels.Add("QA");
                break;
            case "Urgent":
                notificationChannels.Add("Urgent");
                break;
            default:
                break;
        }
    }
    
    Console.WriteLine("Receive channels: " + string.Join(", ", notificationChannels));
}

static void ParseNotificationChannelsRegx(string notificationTitle)
{
    HashSet<string> validChannels = new HashSet<string> { "BE", "FE", "QA", "Urgent" };
    Regex regex = new Regex(@"\[(.*?)\]");
    MatchCollection matches = regex.Matches(notificationTitle);
    
    List<string> channels = new List<string>();

    foreach (Match match in matches)
    {
        string tag = match.Groups[1].Value;
        if (validChannels.Contains(tag))
        {
            channels.Add(tag);
        }
    }
    
    Console.WriteLine("[Regex] Receive channels: " + string.Join(", ", channels));
}