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
    public class HeaderController : Controller
    {
        // GET: Header

        public ActionResult Index()
        {
            HeaderModel headerModel = new HeaderModel();

            var datasourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;

            var dataSource = Sitecore.Context.Database.GetItem(datasourceId);

            var Image1 = (ImageField)dataSource.Fields["logo"];
            var Image2 = (ImageField)dataSource.Fields["logo1"];



            headerModel.logo1 = MediaManager.GetMediaUrl(Image1.MediaItem);
            headerModel.logo2 = MediaManager.GetMediaUrl(Image2.MediaItem);




            MultilistField nav1 = dataSource.Fields["Nav1"];

            if (nav1 != null)
            {
                foreach (var childSource in nav1.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childSource));
                    var cta = (LinkField)childItem.Fields["CTA"];
                    headerModel.navigation1.Add(new Navigation1()
                    {
                        CTA =cta.Text,
                        URL = cta.Url
                    });
                }
            }




            MultilistField nav2 = dataSource.Fields["Nav2"];

            if (nav2 != null)
            {
                foreach (var childSource in nav2.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childSource));
                    var imgField = (ImageField)childItem.Fields["Image"];
                    var cta = (LinkField)childItem.Fields["CTA"];
                    headerModel.navigation2.Add(new Navigation2()
                    {
                        CTA = cta.Text,
                        URL = cta.Url,
                        Img_src = MediaManager.GetMediaUrl(imgField.MediaItem)
                    });
                }
            }

            MultilistField nav3 = dataSource.Fields["Nav3"];
            if (nav3 != null)
            {
                foreach (var childSource in nav3.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childSource)); var cta = (LinkField)childItem.Fields["CTA"];
                    headerModel.navigation3.Add(new Navigation3()
                    {
                        CTA = cta.Text,
                        URL = cta.Url
                    });
                }
            }

            return View("~/Views/Header/HeaderRendering.cshtml", headerModel);
        }
    }
}