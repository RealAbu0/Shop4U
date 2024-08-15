using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shop4UAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly IContactUsRepository _contactUsRepository;

        public PagesController(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        [HttpPost("contact-us-page")]
        public async Task<IActionResult> CreateContactUsPage(ContactUs contactUs)
        {
            try
            {
                if (contactUs.Username == "" || contactUs.Email== "" || contactUs.Category == "" || contactUs.Message == "")
                {
                    return BadRequest(new {Message = "Error, please enter the empty fields"});
                }

                var result = await _contactUsRepository.CreateContactUs(contactUs);


                return Ok(new {Message = "Your issue has been receieved!"});  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
