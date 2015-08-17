using System;
using System.Collections.Specialized;

namespace ApiLibrary
{
    public delegate object ApiMethod(NameValueCollection queryStringCollection, NameValueCollection formCollection);
}

