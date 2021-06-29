using System;

namespace CarDataPlatformIngestor.Application.Interfaces.Services
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
