using System.Text;
using System.Threading.Channels;

public class CsvImportWorker : BackgroundService
{
    private readonly CsvImportChannel _csvChannel;

    public CsvImportWorker(CsvImportChannel csvChannel)
    {
        _csvChannel = csvChannel;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("🟢 CsvImportWorker started... waiting for records...");

        var logFilePath = Path.Combine(AppContext.BaseDirectory, "import-log.txt");

        int processed = 0;

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                // Consumer reads from channel
                var record = await _csvChannel.Channel.Reader.ReadAsync(stoppingToken);

                processed++;

                Console.WriteLine($"🛠️  PROCESSING record #{processed}: {record}");

                // artificial delay (so you can see realtime processing)
                await Task.Delay(1000, stoppingToken);

                var logLine = $"{DateTime.UtcNow:O} | {record}";
                await File.AppendAllTextAsync(logFilePath, logLine + Environment.NewLine, Encoding.UTF8, stoppingToken);

                Console.WriteLine($"📝 Written to file: {logLine}");
            }
            catch (ChannelClosedException)
            {
                Console.WriteLine("🟡 Channel closed. Worker exiting...");
                break;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("🔴 Worker cancelled. Shutting down...");
                break;
            }
        }
    }
}

