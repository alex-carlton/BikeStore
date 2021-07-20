using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Service.Interfaces
{
    public interface IDateTimeService
    {
        DateTime Now { get; }
    }
}
