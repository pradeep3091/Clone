using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assessmentsitecore.Models
{
    public class BulletListModel
    {

        public string Titile { get; set; }
        public string Content { get; set; }

        public List<list1> lsob1 { get; set; } = new List<list1>();
        public List<list2> lsob2 { get; set; } = new List<list2>();
        public List<list3> lsob3 { get; set; } = new List<list3>();
        public List<list4> lsob4 { get; set; } = new List<list4>();
    }

    public class list1
    {
        public string CTA { get; set; }
        public string URL { get; set; }
    }
    public class list2
    {
        public string CTA { get; set; }
        public string URL { get; set; }
    }
    public class list3
    {
        public string CTA { get; set; }
        public string URL { get; set; }
    }

    public class list4
    {
        public string CTA { get; set; }
        public string URL { get; set; }
    }


}