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
    public class CarouselController : Controller
    {
        // GET: Carousel
        public ActionResult Index()
        {
            CarouselModel model = new CarouselModel();


            var datasourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;

            var dataSource = Sitecore.Context.Database.GetItem(datasourceId);

            var img = (ImageField)dataSource.Fields["ImageBackground"];

       
            var AboutPatient = dataSource.Fields["AboutPatient"];

            model.Image = MediaManager.GetMediaUrl(img.MediaItem);





            model.AboutPatient = AboutPatient.ToString();




            MultilistField sideobj = dataSource.Fields["Slides"];

            if (sideobj != null)
            {

                foreach (var childSource in sideobj.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childSource));

                    var Title = childItem.Fields["Title"];
                    var SubTitle = childItem.Fields["SubTitle"];
                    var CTA = (LinkField)childItem.Fields["CTA"];
                    var Name = childItem.Fields["Name"];
                    var Image = (ImageField)childItem.Fields["Image"];
                    model.S1.Add(new Slides()
                    {
                        Title = Title.ToString(),
                        SubTitle = SubTitle.ToString(),
                        CTA = CTA.Text,
                        URL = CTA.Url,
                        Img_src = MediaManager.GetMediaUrl(Image.MediaItem),
                        Name = Name.ToString()

                    });


                }
            }




            return View("~/Views/Carousel/CarouselRendering.cshtml", model);
        }
    }
}