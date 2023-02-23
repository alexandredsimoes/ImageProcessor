using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using PromptSharp;
using SixLabors.ImageSharp.Formats.Webp;
using System.Reflection;

var fullPath = Directory.GetCurrentDirectory();
var file = Prompt.Input<string>("Inform source image file");
Console.WriteLine($"Source image selected file: {file}");

var imageBytes = await File.ReadAllBytesAsync(file);

using var inStream = new MemoryStream(imageBytes);

using var myImage = await Image.LoadAsync(inStream);

using var outStream = new MemoryStream();

var newFile = $"{Path.GetFileNameWithoutExtension(file)}.webp";
await myImage.SaveAsync(Path.Combine(fullPath, newFile), new WebpEncoder());



