using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assessmentsitecore.Models
{
    public class FooterModel
    {
        public string logo { get; set; }

        public string CopyRightText { get; set; }

        public List<List1> ls1 { get; set;}=new List<List1>();
        public List<List2> ls2 { get; set; } = new List<List2>();
        public List<List3> ls3 { get; set; } = new List<List3>();
        public List<List4> ls4 { get; set; } = new List<List4>();

        public List<List5> ls5 { get; set; } = new List<List5>();
    }
    public class List1
    {
        public string CTA { get; set; }
        public string URL { get; set; }
    }
    public class List2
    {
        public string Img_src { get; set; }
    }
    public class List3
    {
        public string CTA { get; set; }
        public string URL { get; set; }
    }
    public class List4
    {
        public string CTA { get; set; }
        public string URL { get; set; }
    }
    public class List5
    {
        public string CTA { get; set; }
        public string URL { get; set; }
    }

}