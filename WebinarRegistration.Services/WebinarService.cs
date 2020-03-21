using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebinarRegistration.Dto;
using WebinarRegistration.Repo;

namespace WebinarRegistration.Services
{
    public interface IWebinarService
    {
        IEnumerable<WebinarRegistrantDto> GetWebinarsByYear(int year);
    }

    public class WebinarService : IWebinarService
    {
        private readonly WebinarRegistrationEntities _entities;

        public WebinarService(WebinarRegistrationEntities entities)
        {
            _entities = entities;
            _entities.Database.Log = message => Debug.WriteLine(message);
        }

        public IEnumerable<WebinarRegistrantDto> GetWebinarsByYear(int year)
        {
            return from webinar in _entities.Webinars
                where webinar.Year == year
                orderby webinar.Date
                select new WebinarRegistrantDto
                {
                    Webinar = webinar,
                    Registrants = from webReg in webinar.WebinarRegistrants
                                  orderby webReg.Registrant.LastName
                                  select new RegistrantDto
                                  {
                                      FirstName = webReg.Registrant.FirstName,
                                      LastName = webReg.Registrant.LastName,
                                      EmailAddress = webReg.Registrant.EmailAddress,
                                      CompanyName = webReg.Registrant.Company.Name
                                  }
                };
        }
    }
}
