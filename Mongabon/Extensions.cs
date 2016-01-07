using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Mongabon
{
    public static class Extensions
    {
        public static Item GetLinkItem(this Item item, string fieldName)
        {
            ID id;
            if (item != null &&
                ID.TryParse(item[fieldName], out id))
            {
                return item.Database.GetItem(id);
            }
            return null;
        }
    }

    public static class SitecoreHelper
    {
        public static HtmlString DynamicPLaceholer(this Sitecore.Mvc.Helpers.SitecoreHelper helper, string dynamicKey)
        {
            var currentRenderingId = RenderingContext.Current.Rendering.UniqueId;
            return helper.Placeholder(string.Format("{0}_{1}", dynamicKey, currentRenderingId));
        }
    }
}