using System.Web.Mvc;

namespace MvcKnowledgeSystem.Models
{
    public abstract class BaseViewPage : WebViewPage
    {
        public new virtual CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
    }

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public new virtual CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
    }
}