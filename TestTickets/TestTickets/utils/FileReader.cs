using System;
using System.IO;

public class FileReader {
    public static string readFile(string dir, string fileName) {
        return System.IO.File.ReadAllText(Path.Combine(dir, fileName));
    }

    public static List<string> getFolderContent(string dir, List<string> filenames) {
        List<string> content = new List<string>();
        filenames
            .ForEach(fn => content.Add(readFile(dir, fn)));
        return content;
    }

    public static List<string> getFolderFilenames(string dir) {
        List<string> filenames = new List<string>();
        Directory
            .GetFiles(dir, "*", SearchOption.AllDirectories)
            .ToList()
            .ForEach(f => filenames.Add(Path.GetFileName(f)));
        return filenames;
    }
}