using BikeStore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Service
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
