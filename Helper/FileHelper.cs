using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Helper
{
    public class FileHelper
    {
        public static async Task<string> ReadResourceFile(string filename)
        {
            var assembly = Assembly.GetEntryAssembly();
            var resourceStream = assembly.GetManifestResourceStream(filename);
            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
