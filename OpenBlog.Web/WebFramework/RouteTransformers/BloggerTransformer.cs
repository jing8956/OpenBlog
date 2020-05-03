using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

namespace OpenBlog.Web.WebFramework.RouteTransformers
{
    public class BloggerTransformer : DynamicRouteValueTransformer
    {
        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext,
            RouteValueDictionary values)
        {
            values ??= new RouteValueDictionary();
            
            var slug = values["slug"]?.ToString().TrimEnd('/').ToLower();
            if (string.IsNullOrWhiteSpace(slug))
                return values;

            var urlCategoryPart = values["category"]?.ToString().TrimEnd('/').ToLower();
            if (!string.IsNullOrEmpty(urlCategoryPart))
            {
                switch (urlCategoryPart.ToLower())
                {
                    case "category":
                        values.TryAdd("controller", "Post");
                        values.TryAdd("action", "PostListByCategory");
                        values.TryAdd("categoryName", slug);
                        break;
                    case "tag":
                        values.TryAdd("controller", "Post");
                        values.TryAdd("action", "PostListByTag");
                        values.TryAdd("tagName", slug);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                values.TryAdd("controller", "Post");
                values.TryAdd("action", "ViewPostBySlug");
                values.TryAdd("slug", slug);
            }

            await Task.CompletedTask;
            return values;
        }
    }
}