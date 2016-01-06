using Mongabon.Models;
using Sitecore.Mvc.Presentation;
using System.Text;
using System.Web.Mvc;

namespace Mongabon.Controllers
{
    public class ContentBlocRiteController : Controller
    {
        //
        // GET: /ContentBlocLeft/

        public ActionResult RiteBlocLeft()
        {
            var header = ExtractParameters();

            return View(header);
        }

        public ActionResult ContentBloc()
        {
            var header = ExtractParameters();

            return View(header);
        }

        public ActionResult RiteBlocRight()
        {
            var header = ExtractParameters();

            return View(header);
        }

        public ActionResult GastronomieBlocLeft()
        {
            var header = ExtractParameters();

            return View(header);
        }

        public ActionResult GastronomieBlocRight()
        {
            var header = ExtractParameters();

            return View(header);
        }

        public ActionResult ActiviteBloc()
        {
            var header = ExtractParameters();

            return View(header);
        }

        private static HeaderBlocModel ExtractParameters()
        {
            StringBuilder sb = new StringBuilder();
            var header = new HeaderBlocModel();

            foreach (var param in RenderingContext.Current.Rendering.Parameters)
            {
                if (string.IsNullOrEmpty(param.Value)) continue;
                var item = RenderingContext.Current.ContextItem.Database.GetItem(param.Value);
                if (item != null)
                {
                    sb.AppendFormat("{0};", item["Value"]);
                }
            }
            
            header.CssClass = sb.ToString().Replace(";", " ");
            return header;
        }
    }
}
