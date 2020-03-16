using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NeonTools.Utils
{
    public class TextureUtil
    {
        //https://answers.unity.com/questions/432655/loading-texture-file-from-pngjpg-file-on-disk.html
        public Texture2D LoadPNG(string image)
        {

            Texture2D tex = null;
            byte[] fileData = GetImage(image);

            tex = new Texture2D(50, 50);
            ImageConversion.LoadImage(tex, fileData); 

            return tex;
        }

        private byte[] GetImage(string image)
        {
            switch (image)
            {
                case "speed":
                    var speedIcon = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("NeonTools.Images.speed.png");
                    return ReadToEnd(speedIcon);

                case "checkpoint":
                    var checkpointIcon = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("NeonTools.Images.checkpoint.png");
                    return ReadToEnd(checkpointIcon);

                default:
                    var speedB = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("NeonTools.Images.speed.png");
                    return ReadToEnd(speedB);
            }
        }

        //https://stackoverflow.com/questions/1080442/how-to-convert-an-stream-into-a-byte-in-c
        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
    }
}
