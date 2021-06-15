using System;
using System.Threading.Tasks;

namespace Mego.Test.Serch
{
    public abstract class External : IRequest
    {
        protected abstract string Name { get; }


        public async Task<Response> Request(int randomMin, int randomMax)
        {
            if (randomMax < 0 || randomMin < 0) throw new ArgumentException("Время для диапозона задержки не может быть мменьше 0");
            Random rnd = new Random();
            int value = rnd.Next(randomMin, randomMax);
            await Task.Delay(value);
            var res = rnd.Next() % 2 == 1 ? "OK" : "ERROR";


            return new Response() { Name = this.Name, TimeProcessing = value, Value = res };
        }
    }
}

