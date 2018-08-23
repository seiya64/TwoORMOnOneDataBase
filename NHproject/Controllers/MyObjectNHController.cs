using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NHproject.DTOs;
using NHproject.Entities;

namespace NHproject.Controllers
{
    [Route("api/MyObjectsNH")]
    [ApiController]
    public class MyObjectNHController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<MyObject>> Get()
        {

            var session = NHibernateSession.OpenSession();

            return session.QueryOver<MyObject>().List().ToList();
        }

        [HttpGet("{code}")]
        public ActionResult<MyObject> Get(string code)
        {
            var session = NHibernateSession.OpenSession();

            return session.QueryOver<MyObject>().Where(mo => mo.Code == code).List().FirstOrDefault();
        }

        [HttpPost]
        public void Post([FromBody] MyObjectDTO myObjectDto)
        {
            var myObject = new MyObject {
                Code = myObjectDto.Code,
                Description = myObjectDto.Description
            };

            var session = NHibernateSession.OpenSession();

            using (var transaction = session.BeginTransaction())
            {
                session.Save(myObject);
                transaction.Commit();
            }
        }

        [HttpPut("{code}")]
        public void Put(string code, [FromBody] MyObjectDTO myObjectDto)
        {
            var session = NHibernateSession.OpenSession();

            var myObject = session.QueryOver<MyObject>().Where(mo => mo.Code == code).List().FirstOrDefault();

            myObject.Code = myObjectDto.Code;
            myObject.Description = myObjectDto.Description;

            using (var transaction = session.BeginTransaction())
            {
                session.Save(myObject);
                transaction.Commit();
            }
        }
    }
}
