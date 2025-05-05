
using MeasurementManagement.BC.Models;

namespace MeasurementManagement.BC.ReglasDeNegocio
{
    public static class MeasuresRules
    {
        public static bool theMeasureIsValid(Measure measure)
        {
            return measure != null &&
                !string.IsNullOrEmpty(measure.Name) &&
                measure.Date > DateTime.Now &&
                measure.Value > 0 &&
                measure.Id > 0;
        }

        public static bool IdIsValid(int id)
        {
            return id > 0;
        }
    }
}
