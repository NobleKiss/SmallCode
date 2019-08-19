using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiSwagger.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        //public string Get(int id)
        //{
        //    return "value";
        //}
        /// <summary>
        /// 根据输入的字符串返回.
        /// </summary>
        /// <param name="id">需要输入的id</param>
        /// <param name="str">需要输入的字符串</param>
        /// <returns>拼接后的字符串</returns>
        public string GetStr(int id,string str)
        {
            return "当前输入的是字符串是：" + str + "Id是：" + id;
        }
        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
