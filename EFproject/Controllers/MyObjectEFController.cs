using System.Collections.Generic;
using System.Linq;
using EFproject.DTOs;
using EFproject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFproject.Controllers
{
    [Route("api/MyObjectsEF")]
    [ApiController]
    public class MyObjectEFController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<MyObject>> Get()
        {
            List<MyObject> myObjects;

            using (var context = new twoormonedbContext())
            {
                myObjects = context.MyObject.ToList();
            }

            return myObjects;
        }

        [HttpGet("{code}")]
        public ActionResult<MyObject> Get(string code)
        {
            MyObject myObject;

            using (var context = new twoormonedbContext())
            {
                myObject = context.MyObject.SingleOrDefault(mo => mo.Code == code);
            }

            return myObject;
        }

        [HttpPost]
        public void Post([FromBody] MyObjectDTO myObjectDto)
        {
            var myObject = new MyObject() {
                Code = myObjectDto.Code,
                Description = myObjectDto.Description
            };

            using (var context = new twoormonedbContext())
            {
                context.Add(myObject);
                context.SaveChanges();
            }
        }

        [HttpPut("{code}")]
        public void Put(string code, [FromBody] MyObjectDTO myObjectDto)
        {
            MyObject myObject;

            using (var context = new twoormonedbContext())
            {
                myObject = context.MyObject.SingleOrDefault(mo => mo.Code == code);

                myObject.Code = myObjectDto.Code;
                myObject.Description = myObjectDto.Description;

                context.SaveChanges();
            }
        }
    }
}
