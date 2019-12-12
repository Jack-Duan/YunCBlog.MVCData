using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YunCBlog.MVCData.Areas.Admin.Models.CommonViewModels
{
    public class CommonPagerViewModel
    {
        public int? page { get; set; }
        public int? size { get; set; }
    }
}