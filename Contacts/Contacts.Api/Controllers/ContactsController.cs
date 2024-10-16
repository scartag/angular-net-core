using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Contacts.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Contacts.Application.UseCases;

namespace Contacts.Api.Controllers
{
    public class ContactsController : BaseController
    {
        private readonly CreateContactUseCase _createContactUseCase;
        public ContactsController(CreateContactUseCase createContactUseCase)
            : base() 
        {
            _createContactUseCase = createContactUseCase;
        }

        /// <summary>
        /// Creates a new contact.
        /// </summary>
        /// <response code="201">Returns the newly created contact.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        [ProducesResponseType(typeof(ContactDto), StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }

            await _createContactUseCase.Execute(contactDto);

            return Created(string.Empty, contactDto); //we should return the created contact and the url to get to the entity (as required by REST but ...)
        }

      
    }
}
