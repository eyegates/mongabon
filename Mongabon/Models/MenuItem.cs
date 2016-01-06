using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Mongabon.Models
{
    public class MenuItem
    {
        public string Title { get; set; }
        public string ItemUrl { get; set; }
        public bool IsCurrent { get; set; }
        public IList<MenuItem> SubmenuItems { get; set; }
        public bool HasChild 
        { 
            get 
            { 
                return this.SubmenuItems != null && this.SubmenuItems.Count > 0; 
            } 
        }
        public Item Item { get; set; }
        public int Order { get; set; }
    }
}