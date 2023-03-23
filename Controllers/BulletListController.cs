using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assessmentsitecore.Models;
using Sitecore.Data.Fields;
using Sitecore.Data;
using Sitecore.Mvc.Presentation;

namespace Assessmentsitecore.Controllers
{
    public class BulletListController : Controller
    {
        // GET: BulletList
        public ActionResult Index()
        {
             BulletListModel bulletListModel = new BulletListModel();

             var datasourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;

             var dataSource = Sitecore.Context.Database.GetItem(datasourceId);

             var Title = dataSource.Fields["Title"].ToString();
             var Content = dataSource.Fields["Content"].ToString();

            bulletListModel.Titile = Title;
            bulletListModel.Content = Content;



            MultilistField ls1 = dataSource.Fields["list1"];

            if (ls1 != null)
            {
                foreach (var childSource in ls1.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childSource));
                    var cta = (LinkField)childItem.Fields["CTA"];
                    bulletListModel.lsob1.Add(new list1()
                    {
                        CTA = cta.Text,
                        URL = cta.Url
                    });
                }
            }

            MultilistField ls2 = dataSource.Fields["list2"];

            if (ls1 != null)
            {
                foreach (var childSource in ls2.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childSource));
                    var cta = (LinkField)childItem.Fields["CTA"];
                    bulletListModel.lsob2.Add(new list2()
                    {
                        CTA = cta.Text,
                        URL = cta.Url
                    });
                }
            }

            MultilistField ls3 = dataSource.Fields["list3"];

            if (ls1 != null)
            {
                foreach (var childSource in ls3.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childSource));
                    var cta = (LinkField)childItem.Fields["CTA"];
                    bulletListModel.lsob3.Add(new list3()
                    {
                        CTA = cta.Text,
                        URL = cta.Url
                    });
                }
            }

            MultilistField ls4 = dataSource.Fields["list4"];

            if (ls1 != null)
            {
                foreach (var childSource in ls4.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childSource));
                    var cta = (LinkField)childItem.Fields["CTA"];
                    bulletListModel.lsob4.Add(new list4()
                    {
                        CTA = cta.Text,
                        URL = cta.Url
                    });
                }
            }

            return View("~/Views/BulletList/BulletListRendering.cshtml", bulletListModel);
        }
    }
}