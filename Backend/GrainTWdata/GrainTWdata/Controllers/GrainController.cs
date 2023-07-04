using GrainTWdata.DB;
using GrainTWdata.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GrainTWdata.Controllers
{
    [ApiController]
    [Route("Grain")]
    public class GrainController : ControllerBase
    {
        [HttpPost("UploadDataFromJson")]
        public async Task<IActionResult> UploadDataFromJson()
        {
            TextReader tr = new StreamReader(Request.Body);
            string data_json = await tr.ReadToEndAsync();
            tr.Dispose();

            List<GrainInput> newData = new List<GrainInput>();
            if (!string.IsNullOrEmpty(data_json))
            {
                var rz = JsonConvert.DeserializeObject<List<GrainInput>>(data_json);
                if (rz != null && rz.Count > 0)
                {
                    newData.AddRange(rz);
                }
            }

            GrainTwContext db = new GrainTwContext();
            if (newData != null && newData.Count() > 0)
            {
                try
                {
                    db.TblGrainReceipts.AddRange(newData.Select(d => new TblGrainReceipt
                    {
                        Amount = d.Amount,
                        BranchId = d.BranchId,
                        ContractId = d.ContractId,
                        CounterpartyId = d.CounterpartyId,
                        CounterpartyName = d.CounterpartyName,
                        CropYear = d.CropYear,
                        Garbage = d.Garbage,
                        Id = d.Id,
                        Infection = d.Infection,
                        Price = d.Price,
                        Process = d.Process,
                        Product = d.Product,
                        RecordDate = d.RecordDate,
                        Wetness = d.Wetness
                    }));
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }

            return new OkResult();
        }
        [AllowAnonymous]

        [HttpPost("GetGrainData")]
        public IActionResult GetGrainData([FromBody] GetGrainDataArgs args)
        {
            return Ok(GrainDataClass.GetData(args));
        }
        [HttpPost("GetGrainCount")]
        public IActionResult GetGrainCount()
        {
            return Ok(GrainDataClass.GetDataCount());
        }
        [HttpPost("DeleteGrainData")]
        public IActionResult DeleteGrainData([FromBody] DeleteGrainDataArgs args) 
        {
            GrainDataClass.DeleteGrainData(args);
            return new OkResult();
        }
        [HttpPost("GetDataGroups")]
        public IActionResult GetDataGroups([FromBody] GrainOrderByArgs args )
        {
            return Ok(GrainDataClass.GetDataGroups(args));
        }
        [HttpPost("GetDataMerged")]
        public IActionResult GetDataMerged([FromBody] GrainOrderByArgs args)
        {
            return Ok(GrainDataClass.MergeDataGroups(args));
        }
        [HttpPost("MergeDataGroupsCount")]
        public IActionResult MergeDataGroupsCount()
        {
            return Ok(GrainDataClass.MergeDataGroupsCount());
        }
        [HttpPost("SaveGrainInfo")]
        public IActionResult SaveGrainInfo(GrainInput grain)
        {
            GrainDataClass.SaveGrainInfo(grain);
            return new OkResult();
        }
        [HttpPost("EditGrainInfo")]
        public IActionResult EditGrainInfo(GrainInput grain)
        {
            GrainDataClass.EditGrainInfo(grain);
            return new OkResult();
        }
    }
}
