using System;
using System.Web;

namespace ApiLibrary
{
    public static class HttpStatusCodes
    {
        private static void returnHttpStatusCode(int statusCode, string desc)
        {
            HttpContext context = HttpContext.Current;
            context.Response.StatusCode = statusCode;
            context.Response.StatusDescription = desc;
            context.Response.End();
        }

        public static void ReturnBadRequest()
        {
            returnHttpStatusCode(400, "Bad Request");
        }

        public static void ReturnUnauthorized()
        {
            returnHttpStatusCode(401, "Unauthorized");
        }

        public static void ReturnForbidden()
        {
            returnHttpStatusCode(403, "Forbidden");
        }

        public static void ReturnNotFound()
        {
            returnHttpStatusCode(404, "Not Found");
        }

        public static void ReturnMethodNotAllowed()
        {
            returnHttpStatusCode(405, "Method Not Allowed");
        }

        public static void ReturnInternalServerError()
        {
            returnHttpStatusCode(500, "Internal Server Error");
        }

        public static void ReturnNotImplemented()
        {
            returnHttpStatusCode(501, "Not Implemented");
        }
    }
}
