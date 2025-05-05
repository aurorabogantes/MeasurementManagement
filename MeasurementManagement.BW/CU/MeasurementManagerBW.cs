
using MeasurementManagement.BC.Models;
using MeasurementManagement.BC.ReglasDeNegocio;
using MeasurementManagement.BW.Interfaces.BW;
using MeasurementManagement.BW.Interfaces.DA;

namespace MeasurementManagement.BW.CU
{
    public class MeasurementManagerBW : IMeasurementManagementBW
    {
        private readonly IMeasuremetManagementDA measuremetManagementDA;
        public MeasurementManagerBW(IMeasuremetManagementDA measuremetManagementDA)
        {
            this.measuremetManagementDA = measuremetManagementDA;
        }
        public Task<bool> addMeasure(Measure measure)
        {
            return MeasuresRules.theMeasureIsValid(measure) ?
                measuremetManagementDA.addMeasure(measure) :
                Task.FromResult(false);
        }

        public Task<bool> updateMeasure(int id, Measure measure)
        {
            if(!MeasuresRules.IdIsValid(id) || !MeasuresRules.theMeasureIsValid(measure))
            {
                return Task.FromResult(false);
            }

            return measuremetManagementDA.updateMeasure(id, measure);
        }

        public Task<bool> deleteMeasure(int id)
        {
            return MeasuresRules.IdIsValid(id) ?
                measuremetManagementDA.deleteMeasure(id) :
                Task.FromResult(false);
        }

        public async Task<Measure> getMeasure(int id)
        {
            if(!MeasuresRules.IdIsValid(id))
            {
                return null;
            }

            return await measuremetManagementDA.getMeasure(id);
        }

        public Task<List<Measure>> getAllMeasures()
        {
            return measuremetManagementDA.getAllMeasures();
        } 
    }
}
