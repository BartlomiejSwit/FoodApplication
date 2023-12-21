using FoodApplication.Core.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApplication.Infrastructure.DataInterfaces
{
    public interface IMeasurUnitDao
    {
        List<MeasurUnit> GetData();
        List<MeasurUnit> GetMeasurUnitById(int Id);
        void AddMeasurUnit(MeasurUnit measurUnits);
        void UpdateMeasurUnit(MeasurUnit measurUnits);
        void DeleteMeasurUnit(int id);

    }
}
