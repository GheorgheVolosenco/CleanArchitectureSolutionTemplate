using CleanArchitectureTemplate.Application.Interfaces.Services;
using System;

namespace CleanArchitectureTemplate.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
