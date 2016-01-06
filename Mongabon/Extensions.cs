using Sitecore.Data;
using Sitecore.Data.Items;

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
}