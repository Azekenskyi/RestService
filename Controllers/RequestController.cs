using RestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RestService.Controllers
{
    public class RequestController : ApiController
    {
        Context db = new Context();
        public IEnumerable<string> Get()
        {
            List<Person> peoples = db.People.ToList();
            List<string> people = new List<string> { };
            for(int i = 0;i<peoples.Count; i++)
            {
                people.Add(peoples[i].FirstName + " " + peoples[i].LastName + " " + peoples[i].Otchestvo + " (" + peoples[i].Iin.ToString() + ") -  " + peoples[i].dateBirthday.ToString("dd/MM/yyyy"));
            }
            return people;
        }

        // GET: Request
        public HttpResponseMessage Get(string text)
        {
            string[] value = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return Request.CreateResponse(HttpStatusCode.OK,value);
           
        }
        public HttpResponseMessage Post([FromBody] Person person)
        {
            try
            {
                if (person.Iin.ToString().Length == 12)
                {

                    var checkIin = db.People.FirstOrDefault(p => p.Iin == person.Iin);
                    if (checkIin == null)
                    {
                        db.People.Add(person);
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Сохранено");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, "Дубликат");
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Ошибка");
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message);
            }

        }

    }
}