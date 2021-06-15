using System.Collections.Generic;

namespace Mego.Test.Serch
{
    public class MetricsResponse
    {
        /// <summary>
        /// Список и количество запросов в групировочное время
        /// </summary>
        public List<MetricsResponseItem> Metrics { get; set; }
        /// <summary>
        /// секундная группировка
        /// </summary>
        public int TimeRange { get; set; }
    }
    public class MetricsResponseItem
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}

