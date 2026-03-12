using System;
using System.Collections.Generic;
using System.Net.ServerSentEvents;
using System.Text;

namespace ProductApiDemo.Entities.RequestFeatures
{
    public class ProductParameters
    {
        public string? Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int PageNumber { get; set; } = 1;
        //Neden default veriyoruz?
        //Çünkü kullanıcı query string’de hiç bir şey vermezse bile sistem çalışsın istiyoruz.
        public int PageSize { get; set; } = 5;
    }
}
//Product verinin kendisini temsil ediyor,
//ProductParameters ise isteğe bağlı filtreleme ve pagination bilgilerini taşıyor.
//Görevleri farklı olduğu için ayrı tuttum.