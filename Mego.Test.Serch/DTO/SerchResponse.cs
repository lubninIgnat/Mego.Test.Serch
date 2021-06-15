using System.Collections.Generic;

namespace Mego.Test.Serch
{
    public class SerchResponse
    {
        /// <summary>
        /// Список названий всех систем.
        /// </summary>
        public List<string> SistemsName { get; set; }
        /// <summary>
        /// Результат выполнения запроса в этой системе OK/ERROR и сколько это заняло времени в миллисекундах.
        /// </summary>
        public List<Response> Responses { get; set; }
        /// <summary>
        /// Общая длительность выполнения метода в миллисекундах.
        /// </summary>
        public int AllTime { get; set; }
    }
   
}

