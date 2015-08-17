using System;
using System.Collections.Specialized;

namespace ApiLibrary
{
    public interface IRepository
    {
        [Name("get")]
        object Get(NameValueCollection queryStringCollection, NameValueCollection formCollection);

        [Name("set")]
        object Set(NameValueCollection queryStringCollection, NameValueCollection formCollection);

        [Name("add")]
        object Add(NameValueCollection queryStringCollection, NameValueCollection formCollection);

        [Name("delete")]
        object Delete(NameValueCollection queryStringCollection, NameValueCollection formCollection);
    }
}

