using System.Threading.Tasks;

namespace Mego.Test.Serch
{
    public interface IRequest
    {
        Task<Response> Request(int randomMin, int randomMax);
    }
}

