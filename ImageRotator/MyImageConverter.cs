using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRotator;

public static class MyImageConverter
{
	public static void ConvertImage(string fileName)
	{
		Console.WriteLine($"Redigere nu {fileName}");
		Bitmap image = new Bitmap(fileName);

		int width = image.Width;
		int height = image.Height;
		// Create a rectangle that represents the top half of the image
		Rectangle topRect = new Rectangle(0, 0, width, height / 2);
		// Create a rectangle that represents the bottom half of the image
		Rectangle bottomRect = new Rectangle(0, height / 2, width, height / 2);
		// Clone the top part of the image
		Bitmap topPart = image.Clone(topRect, image.PixelFormat);
		// Clone the bottom part of the image
		Bitmap bottomPart = image.Clone(bottomRect, image.PixelFormat);

		// Rotate the bottom part of the image by 180 degrees
		topPart.RotateFlip(RotateFlipType.Rotate180FlipNone);

		// Create a new bitmap that has the same size as the original image
		Bitmap result = new Bitmap(width, height);
		// Create a graphics object from the result bitmap
		Graphics g = Graphics.FromImage(result);
		// Draw the top part of the image onto the result bitmap
		g.DrawImage(bottomPart, 0, 0, width, height / 2);
		// Draw the rotated bottom part of the image onto the result bitmap
		g.DrawImage(topPart, 0, height / 2, width, height / 2);
		// Dispose the graphics object
		g.Dispose();

		string newFilename = Path.GetFileName(fileName);

		result.Save(@$"Images\New\{newFilename}");
	}
}
