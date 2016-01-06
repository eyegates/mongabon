using System.Web.Mvc;
using Mongabon.Models;
using Sitecore.Mvc.Presentation;
using System.Text;

namespace Mongabon.Controllers
{
    public class HeaderBlocController : Controller
    {
        //
        // GET: /HeaderBloc/

        public ActionResult HeaderBloc()
        {
            var sb = new StringBuilder();

            var header = new HeaderBlocModel();

            foreach (var param in RenderingContext.Current.Rendering.Parameters)
            {
                if (!string.IsNullOrEmpty(param.Value))
                {
                    var item = RenderingContext.Current.ContextItem.Database.GetItem(param.Value);
                    if (item != null)
                    {
                        sb.AppendFormat("{0};", item["Value"]);
                    }
                }
            }
            header.CssClass = sb.ToString().Replace(";", " ");
            return View(header);
        }
    }
}
