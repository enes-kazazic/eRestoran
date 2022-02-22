using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.WinUI.Helpers
{
    public static class ImageHelper
    { 
        public static Image ByteArrayToSystemDrawing(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
            ms.Write(byteArrayIn, 0, byteArrayIn.Length);
            return Image.FromStream(ms, true);
        }

        public static byte[] SystemDrawingToByteArray(Image image)
        {
            MemoryStream stream = new MemoryStream();
            image?.Save(stream, image.RawFormat);
            return stream.ToArray();
        }
    }
}
