using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mego.Test.Serch.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<SerchResponse> Serch(int wait, int randomMin, int randomMax)
        {          
            if (randomMin < 0 || randomMax < 0 || wait < 0)
                return BadRequest("Передаваемые параметры должны быть больше 0");
            if(randomMin< randomMax)
                return BadRequest("параметр randomMin должен быть меньше randomMax");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            var responses = new List<Response>();
            var Externals = new IRequest[3] {
                new ExternalA("ExternalA"),
                new ExternalB("ExternalB"),
                new ExternalC("ExternalC")
            };
            Externals = Externals
                .Select(i => new MetricDecarator(i))
                .ToArray();

            var ExternalTasks = Externals.Select(ext => ext.Request(randomMin, randomMax)).ToArray();

            if (Task.WaitAll(ExternalTasks, wait))
            {
                responses = ExternalTasks.Where(i => i != null).Select(i => i.Result).ToList();
                if (responses[2].Value == "OK")
                {
                    var d = new ExternalD("ExternalD").Request(randomMin, randomMax);
                    if (d.Wait(wait))
                        responses.Add(d.Result);
                }
            }
            else
            {
                responses = ExternalTasks.Where(i => i.IsCompleted && i.Result != null).Select(i => i.Result).ToList();
                if (ExternalTasks[2].IsCanceled && ExternalTasks[2].Result.Value == "OK")
                {
                    var externalD = new ExternalD("ExternalD").Request(randomMin, randomMax);
                    if (externalD.Wait(wait))
                        responses.Add(externalD.Result);
                }
            }
            stopWatch.Stop();
            var res = new SerchResponse() { Responses = responses, AllTime = (int)stopWatch.ElapsedMilliseconds };
            return res;


        }
        [HttpGet]
        public IEnumerable<MetricsResponse> Metrics()
        {
            var res = ResponseMetric.Responses.ToLookup(i => i.TimeProcessing / 1000)
               .Select(lr => new MetricsResponse
               {
                   TimeRange = lr.Key,
                   Metrics = lr.GroupBy(j => j.Name).Select(k => new MetricsResponseItem { Name = k.Key, Count = k.Count() }).ToList()
               }).ToList();

            return res;
        }
    }
}
