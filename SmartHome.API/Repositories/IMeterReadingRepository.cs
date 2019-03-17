using SmartHome.API.Models;
using System.Collections.Generic;

namespace SmartHome.API.Repositories
{
    public interface IMeterReadingRepository : IRepository<MeterReading>
    {
        IEnumerable<MeterReading> GetMeterReading();
        MeterReading GetMeterReadingById(int meterReadingId);
        int SaveMeterReading(MeterReading meterReading);
        int UpdateMeterReading(MeterReading meterReading);
        int DeleteMeterReading(int meterReadingId);
        MeterReading GetMeterReadingByMeterNumber(string meterNumber);
    }
}
