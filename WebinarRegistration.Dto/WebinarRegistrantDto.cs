using System.Collections.Generic;
using WebinarRegistration.Repo;

namespace WebinarRegistration.Dto
{
    public class WebinarRegistrantDto
    {
        public Webinar Webinar { get; set; }
        public IEnumerable<RegistrantDto> Registrants { get; set; } 
    }
}
