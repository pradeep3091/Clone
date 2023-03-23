using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assessmentsitecore.Models;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;

namespace Assessmentsitecore.Controllers
{
    public class FooterController : Controller
    {
        // GET: Footer
        public ActionResult Index()
        {
            FooterModel footerModel = new FooterModel();

            var datasourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;

            var dataSource = Sitecore.Context.Database.GetItem(datasourceId);

            var Image = (ImageField)dataSource.Fields["Footerlogo"];

            var CopyRightText = dataSource.Fields["CopyRightText"];

            footerModel.logo = MediaManager.GetMediaUrl(Image.MediaItem);

            footerModel.CopyRightText= CopyRightText.ToString();

            MultilistField list1 = dataSource.Fields["List1"];

            if (list1 != null)
            {
                foreach (var childSource in list1.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childSource));
                    var cta = (LinkField)childItem.Fields["CTA"];
                    footerModel.ls1.Add(new List1()
                    {
                        CTA = cta.Text,
                        URL = cta.Url
                    });
                }
            }

            MultilistField list2 = dataSource.Fields["List2logo"];

            if (list2 != null)
            {
                foreach (var childSource in list2.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childSource));
                    var imgField = (ImageField)childItem.Fields["Image"];

                    footerModel.ls2.Add(new List2()
                    {
                        Img_src = MediaManager.GetMediaUrl(imgField.MediaItem)
                    });
                }
            }

            MultilistField list3 = dataSource.Fields["List3"];

            if (list3 != null)
            {
                foreach (var childSource in list3.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childSource));
                    var cta = (LinkField)childItem.Fields["CTA"];
                    footerModel.ls3.Add(new List3()
                    {
                        CTA = cta.Text,
                        URL = cta.Url
                    });
                }
            }


            MultilistField list4 = dataSource.Fields["List4"];

            if (list4!= null)
            {
                foreach (var childSource in list4.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childSource));
                    var cta = (LinkField)childItem.Fields["CTA"];
                    footerModel.ls4.Add(new List4()
                    {
                        CTA = cta.Text,
                        URL = cta.Url
                    });
                }
            }

            MultilistField list5 = dataSource.Fields["List5"];

            if (list5 != null)
            {
                foreach (var childSource in list5.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childSource));
                    var cta = (LinkField)childItem.Fields["CTA"];
                    footerModel.ls5.Add(new List5()
                    {
                        CTA = cta.Text,
                        URL = cta.Url
                    });
                }
            }

            return View("~/Views/Footer/FooterRendering.cshtml",footerModel);
        }
    }
}