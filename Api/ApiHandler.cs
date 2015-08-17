using System;
using System.Linq;
using System.Web;
using ApiLibrary.Serializing;

namespace ApiLibrary
{
    public class ApiHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            // getting data
            var queryStringCollection = context.Request.QueryString;
            var formCollection = context.Request.Form;

            // getting entity name
            var UrlSeglength = context.Request.Url.Segments.Length;
            var prop = context.Request.Url.Segments[UrlSeglength - 1];
            var a = prop.Split('.');

            if (a.Length != 2)
                HttpStatusCodes.ReturnBadRequest();
            
            var entityName = a[0];
            var methodName = a[1];

            // getting free entity
            var app = context.ApplicationInstance as ApiApplication;
            if (app == null)
                throw new InvalidOperationException("application is not api");

            var entities = app.EntityPool.GetFree();

            if (entities == null)
				HttpStatusCodes.ReturnInternalServerError();

            var entity = entities.SingleOrDefault(e => e.Name == entityName);
			if (entity == null)
				HttpStatusCodes.ReturnNotFound();
			
            var method = entity.Methods.SingleOrDefault(m => m.Method.Name.ToLower() == methodName.ToLower());
            object result = method.Invoke(queryStringCollection, formCollection);
            JsonObject obj;
            Type objType = result.GetType();
            if (objType.GetType().IsPrimitive)
            {
                obj = new JsonObject(1);
                obj.Add("result", new JsonPrimitive(result.ToString(), JsonValue.GetPrimitiveType(objType)));
            }
            else
                obj = JsonSerializer.SerializeObject(result);

            context.Response.Write(obj.ToString());
        }
    }
}

