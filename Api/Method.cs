using System;
using System.Web;
using System.Collections.Specialized;

namespace ApiLibrary
{
    public class Method
    {
        private DbEntity entity;
        private ApiMethod method;

        private bool isVisible;
        private bool forAutorized;

        private void HttpStatusCode(HttpResponse response, int statusCode)
        {
            response.StatusCode = statusCode;
            response.End();
        }

        public DbEntity Entity
        {
            get { return entity; }
        }

        public bool IsVisible
        {
            get { return isVisible; }
        }

        public bool ForAutorized
        {
            get { return forAutorized; }
        }

        public Method(DbEntity entity, ApiMethod method, bool isVisible, bool forAutorized)
        {
            this.entity = entity;
            this.method = method;
            this.isVisible = isVisible;
            this.forAutorized = forAutorized;
        }

        public object Invoke(HttpContext context, NameValueCollection queryStringCollection, NameValueCollection formCollection)
        {
            if (!isVisible)
                HttpStatusCode(context.Response, 404);
            if (forAutorized && context.User.Identity.IsAuthenticated)
                HttpStatusCode(context.Response, 403);

            return method(queryStringCollection, formCollection);
        }
    }
}

