
using MeasurementManagement.BC.Models;

namespace MeasurementManagement.BW.Interfaces.DA
{
    public interface IMeasuremetManagementDA
    {
        Task<bool> addMeasure(Measure measure);
        Task<bool> updateMeasure(int id, Measure measure);
        Task<bool> deleteMeasure(int id);
        Task<Measure> getMeasure(int id);
        Task<List<Measure>> getAllMeasures();
    }
}
