using System;
using System.IO;

using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    //이미지 올릴 떄
    public class PacketMediaUpload : BasePacket, IDisposable
    {
        public PacketMediaUpload()
        {
            this.url = "https://upload.twitter.com/1.1/media/upload.json";
            this.method = "POST";
        }

        //public string media { get { return dicParams["media"]; } set { dicParams["media"] = value.ToString(); } }
		public string additional_owners { get { return dicParams["additional_owners"]; } set { dicParams["additional_owners"] = value.ToString(); } }

        public string extension { get; set; }

        private readonly MemoryStream _mediaStream = new MemoryStream();
        public Stream mediaStream { get { return _mediaStream; } }

        ~PacketMediaUpload()
        {
            this.Dispose(false);
        }
        public void Dispose()
        {
            this.Dispose(true);
        }
        private bool m_disposed = false;
        protected void Dispose(bool disposing)
        {
            if (this.m_disposed) return;
            this.m_disposed = true;

            this._mediaStream.Dispose();
        }
    }
}