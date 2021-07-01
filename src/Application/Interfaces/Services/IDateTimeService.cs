using System;

namespace CleanArchitectureTemplate.Application.Interfaces.Services
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
