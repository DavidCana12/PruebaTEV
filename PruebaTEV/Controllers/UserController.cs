using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTEV.Class;
using PruebaTEV.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PruebaTEV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<Object> Get()
        {
            try
            {
                return _userManager.GetList();
            }
            catch (WebException e)
            {
                string Message = "Exception Message :" + e.Message;
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    string statusCode = "Status Code : " + ((HttpWebResponse)e.Response).StatusCode;
                    string statusDescription = "Status Description : " + ((HttpWebResponse)e.Response).StatusDescription;
                }
                throw new Exception(Message);
            }
            catch (Exception e)
            {
                string Message = "Exception Message :" + e.Message;
                throw new Exception(Message);
            }
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public Object Get(int id)
        {
            try
            {
                return _userManager.GetById(id);
            }
            catch (WebException e)
            {
                string Message = "Exception Message :" + e.Message;
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    string statusCode = "Status Code : " + ((HttpWebResponse)e.Response).StatusCode;
                    string statusDescription = "Status Description : " + ((HttpWebResponse)e.Response).StatusDescription;
                }
                throw new Exception(Message);
            }
            catch (Exception e)
            {
                string Message = "Exception Message :" + e.Message;
                throw new Exception(Message);
            }
        }

        // POST: api/User
        [HttpPost]
        public Object Post([FromBody] User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    _userManager.Add(user);
                }

                return Ok("Record created successfully");
            }
            catch (WebException e)
            {
                string Message = "Exception Message :" + e.Message;
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    string statusCode = "Status Code : " + ((HttpWebResponse)e.Response).StatusCode;
                    string statusDescription = "Status Description : " + ((HttpWebResponse)e.Response).StatusDescription;
                }
                throw new Exception(Message);
            }
            catch (Exception e)
            {
                string Message = "Exception Message :" + e.Message;
                throw new Exception(Message);
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public Object Put(int id, [FromBody] User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    _userManager.Update(user);
                }

                return Ok("Record updated successfully");
            }
            catch (WebException e)
            {
                string Message = "Exception Message :" + e.Message;
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    string statusCode = "Status Code : " + ((HttpWebResponse)e.Response).StatusCode;
                    string statusDescription = "Status Description : " + ((HttpWebResponse)e.Response).StatusDescription;
                }
                throw new Exception(Message);
            }
            catch (Exception e)
            {
                string Message = "Exception Message :" + e.Message;
                throw new Exception(Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Object Delete(int id)
        {
            try
            {
                _userManager.Delete(id);

                return Ok("Record deleted successfully");
            }
            catch (WebException e)
            {
                string Message = "Exception Message :" + e.Message;
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    string statusCode = "Status Code : " + ((HttpWebResponse)e.Response).StatusCode;
                    string statusDescription = "Status Description : " + ((HttpWebResponse)e.Response).StatusDescription;
                }
                throw new Exception(Message);
            }
            catch (Exception e)
            {
                string Message = "Exception Message :" + e.Message;
                throw new Exception(Message);
            }
        }
    }
}
