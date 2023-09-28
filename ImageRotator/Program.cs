using ImageRotator;
using System.Drawing;
using System.IO;


List<string> filePaths = Directory.GetFiles("Images", "*.jpg", SearchOption.TopDirectoryOnly).ToList<string>();

Console.WriteLine("Starter...\n");

foreach (var file in filePaths)
{
	MyImageConverter.ConvertImage(file);
}


Console.WriteLine("\nFærdig :-)");