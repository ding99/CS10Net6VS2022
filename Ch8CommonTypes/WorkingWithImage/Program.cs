using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

WriteLine($"current directory [{Environment.CurrentDirectory}]");

//string imageFolder = Path.Combine(Environment.CurrentDirectory, "images");
string imageFolder = @"..\..\..\images";
string targetFolder = @"..\..\..\target";
IEnumerable<string> images = Directory.EnumerateFiles(imageFolder);
foreach(string imagePath in images)
{
    string thumbnailPath = Path.Combine(targetFolder, Path.GetFileNameWithoutExtension(imagePath) + "-thumbnail" + Path.GetExtension(imagePath));
    //string thumbnailPath = Path.Combine("images", Path.GetFileNameWithoutExtension(imagePath) + "-thumbnail" + Path.GetExtension(imagePath));

    using Image image = Image.Load(imagePath);
    image.Mutate(x => x.Resize(image.Width / 10, image.Height / 10));
    image.Mutate(x => x.Grayscale());
    image.Save(thumbnailPath);
}
WriteLine("Image processing complete. View the images folder.");

ResetColor();
