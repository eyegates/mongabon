using Mongabon.Models;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Mongabon.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/

        public ActionResult Index()
        {
            var menu = new List<MenuItem>();
            var menuItem = Sitecore.Context.Database.GetItem("{7C34827C-7113-4CFF-B64E-E3B7310E1C71}");

            if (menuItem != null)
	        {
                foreach (Item item in menuItem.Children)
                {
                    Sitecore.Data.Fields.CheckboxField checkbox = item.Fields["IsGroupingItem"];
                    if (checkbox != null && checkbox.Checked)
                    {
                        var group = new MenuItem();
                        group.Title = item["NavigationTitle"];
                        group.Item = item.GetLinkItem("TargetItem");
                        group.Order = Convert.ToInt32(item["Order"]);
                        var submenuItems = new List<MenuItem>();

                        foreach (Item groupitem in item.Children)
                        {
                            submenuItems.Add(new MenuItem
                            {
                                    Title = groupitem["NavigationTitle"],
                                    IsCurrent = RenderingContext.Current.ContextItem.Name == groupitem.GetLinkItem("TargetItem").Name,
                                    ItemUrl = Sitecore.Links.LinkManager.GetItemUrl(groupitem.GetLinkItem("TargetItem")),
                                    Item = groupitem.GetLinkItem("TargetItem"),
                                    Order = Convert.ToInt32(groupitem["Order"])
                                });
                        }
                        group.SubmenuItems = submenuItems.OrderBy(sub => sub.Order).ToList();
                        menu.Add(group);
                    }
                    else
                    {
                        menu.Add(new MenuItem
                        {
                            Title = item["NavigationTitle"],
                            IsCurrent = RenderingContext.Current.ContextItem.Name == item.GetLinkItem("TargetItem").Name,
                            ItemUrl = Sitecore.Links.LinkManager.GetItemUrl(item.GetLinkItem("TargetItem")),
                            Item = item.GetLinkItem("TargetItem"),
                            Order = Convert.ToInt32(item["Order"])
                        });
                    }
                }
	        }
            
            //Sitecore.Links.LinkManager.GetItemUrl(item);
            return View(menu.OrderBy(sub => sub.Order).ToList());
        }

        public ActionResult Footer()
        {
            var footer = new List<MenuItem>();
            var footermenuItem = Sitecore.Context.Database.GetItem("{55233333-17AE-41EA-B610-02124BDD6013}");

            if (footermenuItem != null)
            {
                foreach (Item item in footermenuItem.Children)
                {
                    Sitecore.Data.Fields.CheckboxField checkbox = item.Fields["IsGroupingItem"];
                    if (checkbox != null && checkbox.Checked)
                    {
                        var group = new MenuItem();
                        group.Title = item["NavigationTitle"];
                        group.Item = item.GetLinkItem("TargetItem");
                        group.Order = Convert.ToInt32(item["Order"]);
                        var submenuItems = new List<MenuItem>();

                        foreach (Item groupitem in item.Children)
                        {
                            submenuItems.Add(new MenuItem
                            {
                                Title = groupitem["NavigationTitle"],
                                IsCurrent = RenderingContext.Current.ContextItem.Name == groupitem.GetLinkItem("TargetItem").Name,
                                ItemUrl = Sitecore.Links.LinkManager.GetItemUrl(groupitem.GetLinkItem("TargetItem")),
                                Item = groupitem.GetLinkItem("TargetItem"),
                                Order = Convert.ToInt32(groupitem["Order"])
                            });
                        }
                        group.SubmenuItems = submenuItems.OrderBy(sub => sub.Order).ToList();
                        footer.Add(group);
                    }
                    else
                    {
                        footer.Add(new MenuItem
                        {
                            Title = item["NavigationTitle"],
                            IsCurrent = RenderingContext.Current.ContextItem.Name == item.GetLinkItem("TargetItem").Name,
                            ItemUrl = Sitecore.Links.LinkManager.GetItemUrl(item.GetLinkItem("TargetItem")),
                            Item = item.GetLinkItem("TargetItem"),
                            Order = Convert.ToInt32(item["Order"])
                        });
                    }
                }
            }

            //Sitecore.Links.LinkManager.GetItemUrl(item);
            return View(footer.OrderBy(sub => sub.Order).ToList());
        }
    }
}
