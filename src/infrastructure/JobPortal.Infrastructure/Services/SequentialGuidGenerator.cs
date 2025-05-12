using JobPortal.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Services
{
    public class SequentialGuidGenerator : ISequentialGuidGenerator
    {
        public Guid GenerateSequentialGuid()
        {
            byte[] guidBytes = Guid.NewGuid().ToByteArray();
            DateTime now = DateTime.UtcNow;
            long timestamp = now.Ticks - new DateTime(1900, 1, 1).Ticks;

            byte[] timestampBytes = BitConverter.GetBytes(timestamp);
            Array.Copy(timestampBytes, 0, guidBytes, 0, Math.Min(timestampBytes.Length, guidBytes.Length));
            return new Guid(guidBytes);
        }
    }
}
