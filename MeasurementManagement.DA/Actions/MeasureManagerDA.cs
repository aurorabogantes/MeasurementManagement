
using MeasurementManagement.BC.Models;
using MeasurementManagement.BW.Interfaces.DA;
using MeasurementManagement.DA.Config;
using Microsoft.EntityFrameworkCore;

namespace MeasurementManagement.DA.Actions
{
    public class MeasureManagerDA : IMeasuremetManagementDA
    {
        private readonly MeasurementManagementContext measurementManagementContext;
        public MeasureManagerDA(MeasurementManagementContext context)
        {
            this.measurementManagementContext = context;
        }
        public async Task<bool> addMeasure(Measure measure)
        {
            try
            {
                measurementManagementContext.Measure.Add(measure);
                await measurementManagementContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> deleteMeasure(int id)
        {
            var measure = await measurementManagementContext.Measure.FindAsync(id);
            if (measure == null)
                return false;

            measurementManagementContext.Measure.Remove(measure);
            await measurementManagementContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Measure>> getAllMeasures()
        {
            return await measurementManagementContext.Measure.ToListAsync();
        }

        public async Task<Measure> getMeasure(int id)
        {
            return await measurementManagementContext.Measure.FindAsync(id);
        }

        public async Task<bool> updateMeasure(int id, Measure measure)
        {
            Measure existentMeasure = await measurementManagementContext.Measure.FindAsync(id);

            if(existentMeasure == null)
                return false;

            existentMeasure.Name = measure.Name;
            existentMeasure.Value = measure.Value;
            existentMeasure.Date = measure.Date;

            await measurementManagementContext.SaveChangesAsync();
            return true;
        }
    }
}
