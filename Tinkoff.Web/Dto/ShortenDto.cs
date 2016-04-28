using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tinkoff.Web.Dto
{
    public class ShortenDto
    {
        public string RawUrl { get; set; }
        public string ShortedUrl { get; set; }
    }
}