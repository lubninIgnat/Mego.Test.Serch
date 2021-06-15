using System;
using System.Threading.Tasks;

namespace Mego.Test.Serch
{
    public class MetricDecarator : IRequest
    {

        private IRequest Component;

        public MetricDecarator(IRequest component)
        {
            Component = component;
        }

        public async Task<Response> Request(int randomMin, int randomMax)
        {
            if (Component == null) throw new Exception("");

            var res = await Component.Request(randomMin, randomMax);

            ResponseMetric.Responses.Add(res);

            return res;
        }
    }
}

