using CarDataPlatformIngestor.Application.Interfaces.Services;
using System;

namespace CarDataPlatformIngestor.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
