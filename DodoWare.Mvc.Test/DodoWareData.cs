using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;

namespace DodoWare.Mvc.Test
{
    [Serializable]
    public class DodoWareData : Dictionary<string, string>
    {
        public HttpContent GetContent()
        {
            return new FormUrlEncodedContent(this);
        }

        public DodoWareData() : base()
        {
        }

        protected DodoWareData(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
