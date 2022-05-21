using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mime;
using System.Reflection;
using OpenGL;
using static OpenGL.GL;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace Napicu.Engine;

public class Texture
{
    public uint Id { get; protected set; }
    //TODO
    public int Width;
    public int Height;
    
    public Texture(string fileName)
    {
        string path = System.IO.Directory.GetCurrentDirectory() + fileName;
        try
        {
            Bitmap bitmap = new Bitmap(path);    
            
            Id = glGenTexture();
            
            glBindTexture(GL_TEXTURE_2D, Id);
            
            // glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
            // glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
            //glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_BORDER);
            //glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_BORDER);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);	
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
            
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);;
            glTexImage2D((int)TextureTarget.Texture2d, 0, GL_RGBA, bmpData.Width, bmpData.Height, 0, (int)OpenGL
            .PixelFormat.Bgra, (int)OpenGL.PixelType.UnsignedByte, bmpData.Scan0);
            glGenerateMipmap( GL_TEXTURE_2D );
            glBindTexture(GL_TEXTURE_2D, 0);
        }
        catch (Exception e)
        {
            Console.WriteLine("Could not load texture path: " + path);
            throw;
        }
        
    }
    
}