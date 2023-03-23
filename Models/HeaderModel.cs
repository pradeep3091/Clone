using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assessmentsitecore.Models
{
    public class HeaderModel
    {
        public string logo1 { get; set; }
        public string logo2 { get; set; }

        public List<Navigation1> navigation1 { get; set;}=new List<Navigation1>();
        public List<Navigation2> navigation2 { get; set; } = new List<Navigation2>();
        public List<Navigation3> navigation3 { get; set; } = new List<Navigation3>();

    }

    public class Navigation1
    {
        public string CTA { get; set; }
        public string URL { get; set; }
    }
    public class Navigation2
    {
        public string Img_src { get; set; }
        public string CTA { get; set; }
        public string URL { get; set; }
    }
    public class Navigation3
    {
        public string CTA { get; set; }
        public string URL { get; set; }
    }
}