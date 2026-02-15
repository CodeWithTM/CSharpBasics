using System.Threading.Channels;

public class CsvImportChannel
{
    public Channel<string> Channel { get; }
        = System.Threading.Channels.Channel.CreateUnbounded<string>();
}


