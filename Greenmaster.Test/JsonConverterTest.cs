using Greenmaster.Repo.FileTransformers;
using Xunit;

namespace Greenmaster.Test;

public class JsonConverterTest
{
    [Fact]
    public void ConvertedJsons()
    {
        JsonConverter.ConvertJsonsToOne(@"C:\Users\mathi\RiderProjects\Greenmaster\Greenmaster.Repo\Database\JsonData\species");
    }
}