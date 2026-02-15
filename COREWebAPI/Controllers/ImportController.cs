using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/import")]
public class ImportController : ControllerBase
{
    private readonly CsvImportChannel _csvChannel;

    public ImportController(CsvImportChannel csvChannel)
    {
        _csvChannel = csvChannel;
    }

    [HttpPost("csv")]
    public async Task<IActionResult> UploadCsv(IFormFile file, CancellationToken ct)
    {
        Console.WriteLine("📥 UploadCsv endpoint called...");

        if (file == null || file.Length == 0)
            return BadRequest("CSV file is required.");

        Console.WriteLine($"✅ File received: {file.FileName} ({file.Length} bytes)");

        using var stream = file.OpenReadStream();
        using var reader = new StreamReader(stream);

        // optional: skip header
        var header = await reader.ReadLineAsync();
        Console.WriteLine($"🟦 Header: {header}");

        int count = 0;

        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync();

            if (string.IsNullOrWhiteSpace(line))
                continue;

            count++;

            Console.WriteLine($"➡️  QUEUEING line #{count}: {line}");

            // Producer writes into channel
            await _csvChannel.Channel.Writer.WriteAsync(line, ct);
        }

        Console.WriteLine($"🎉 Finished queueing {count} records.");

        return Ok($"CSV queued: {count} records.");
    }
}
