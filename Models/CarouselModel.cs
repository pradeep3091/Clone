using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assessmentsitecore.Models
{
    public class CarouselModel
    {
        public string Image { get; set; }
        public string AboutPatient { get; set; }

        public List<Slides> S1 { get; set; } = new List<Slides>();
     

    }

    public class Slides
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string CTA { get; set; }
        public string URL { get; set; }
        public string Img_src { get; set; }

        public string Name { get;set; }
       
    }
    
}