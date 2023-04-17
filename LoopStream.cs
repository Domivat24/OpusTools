using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpusTool
{
    //class that loops the waveStream whenever there are no more bytes to read, 
    //that is to say that the audio has reached an end, so it sets the position back to 0
    public class LoopStream : WaveStream
    {
        private readonly WaveStream sourceStream;

        public LoopStream(WaveStream sourceStream)
        {
            this.sourceStream = sourceStream;
            this.EnableLooping = true;
        }

        public bool EnableLooping { get; set; }

        public override WaveFormat WaveFormat
        {
            get { return sourceStream.WaveFormat; }
        }

        public override long Length
        {
            get { return sourceStream.Length; }
        }

        public override long Position
        {
            get { return sourceStream.Position; }
            set { sourceStream.Position = value; }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);

                if (bytesRead == 0)
                {
                    if (sourceStream.Position == 0 || !EnableLooping)
                    {
                        // End of stream reached
                        break;
                    }
                    // Loop back to the start of the stream
                    sourceStream.Position = 0;
                }

                totalBytesRead += bytesRead;
            }

            return totalBytesRead;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                sourceStream.Dispose();
            }

            base.Dispose(disposing);
        }
    }

}
