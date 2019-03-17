using SmartHome.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartHome.API.Repositories
{
    public class MeterReadingRepository : Repository<MeterReading>, IMeterReadingRepository
    {
        public MeterReadingRepository(SmartHomeContext context) : base(context)
        {

        }

        public IEnumerable<MeterReading> GetMeterReading()
        {
            IEnumerable<MeterReading> data = (from meterReading in DbSet
                                              select new MeterReading
                                              {
                                                  Id = meterReading.Id,
                                                  MeterNumber = meterReading.MeterNumber,
                                                  ReadingVolt = meterReading.ReadingVolt,
                                                  ReadingWatt = meterReading.ReadingWatt,
                                                  IsActive = meterReading.IsActive,
                                                  Date = meterReading.Date
                                              }).ToList();
            return data;
        }

        public MeterReading GetMeterReadingById(int meterReadingId)
        {
            MeterReading meterReadingDetails = DbSet.Where(x => x.Id == meterReadingId).FirstOrDefault();
            return meterReadingDetails;
        }

        public MeterReading GetMeterReadingByMeterNumber(string meterNumber)
        {
            MeterReading meterReadingDetails = DbSet.Where(x => x.MeterNumber == meterNumber).FirstOrDefault();
            return meterReadingDetails;
        }

        public int SaveMeterReading(MeterReading meterReading)
        {
            Add(meterReading);
            return SaveChanges();
        }

        public int UpdateMeterReading(MeterReading meterReading)
        {
            Update(meterReading);
            return SaveChanges();
        }

        public int DeleteMeterReading(int meterReadingId)
        {
            Remove(meterReadingId);
            return SaveChanges();
        }
    }
}
