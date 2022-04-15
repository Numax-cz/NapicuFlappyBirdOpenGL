using System.Drawing;
using System.Drawing.Imaging;
using OpenGL;
using static OpenGL.GL;

namespace Napicu.Engine;

public class Texture
{
    public uint Id { get; protected set; }
    public int Width;
    public int Height;
    
    public Texture(string fileName)
    {
        try
        {
            Bitmap bitmap = new Bitmap(fileName);
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            Id = glGenTexture();
            glBindTexture((int)TextureTarget.Texture2d, Id);
            
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            glTexImage2D((int)TextureTarget.Texture2d, 0, GL_RGBA, bmpData.Width, bmpData.Height, 0, (int)OpenGL
            .PixelFormat.Bgra, (int)OpenGL.PixelType.UnsignedByte, bmpData.Scan0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
}