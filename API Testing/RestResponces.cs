using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Testing
{
    class RestResponces
    {
        private int statusCode;
        private string responseData;

        // Create a constractor to intalize the veriable 
        public RestResponces(int statusCode, string responseData)
        {
            this.statusCode = statusCode;
            this.responseData = responseData;
        }

        public int StatusCode
        {
            get { return statusCode; }
        }
        public string ResponseData
        {
            get { return responseData; }
        }


        public override string ToString()
        {
            return string.Format("status code:- {0} Responces Data {1}",statusCode, responseData);
        }
    }
}
