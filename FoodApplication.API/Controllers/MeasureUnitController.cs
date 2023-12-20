using FoodApplication.Core.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using FoodApplication.DataAccess;
using Newtonsoft.Json.Linq;

namespace FoodApplication.API.Controllers
{
    public class MeasureUnitController : ApiController
    {
        // GET: api/ProductList/5
        public List<MeasurUnit> Get(string id)
        {
            try
            {
                var all = new List<MeasurUnit>();
                var muDao = new MeasurUnitDao();
                int intId;
                if (int.TryParse(id, out intId))
                {

                    if (intId == 0)
                    {
                        all = muDao.GetData();
                        return all;
                    }
                    else
                    {

                        all = muDao.GetMeasurUnitById(intId);
                        return all;
                    }

                }
                return all;


            }
            catch (Exception ex)
            {
                return new List<MeasurUnit>();
            }
        }

        // POST api/ProductList
        public string Post([FromBody] MeasurUnit value)
        {
            try
            {
                var muDao = new MeasurUnitDao();
                muDao.AddMeasurUnit(value);
                return "Ok";

            }catch (Exception ex)
            {
                return ex.Message;            
            }
        }

        public string Put([FromBody] MeasurUnit value)
        {
            try
            {
                var muDao = new MeasurUnitDao();
                muDao.UpdateMeasurUnit(value);
                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Delete(int value)
        {
            try
            {
                var muDao = new MeasurUnitDao();
                muDao.DeleteMeasurUnit(value);
                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
