using InfoNovitas.LoginSample.Services;
using InfoNovitas.LoginSample.Services.Messaging.Authors;
using InfoNovitas.LoginSample.Web.Api.Helpers;
using InfoNovitas.LoginSample.Web.Api.Mapping;
using InfoNovitas.LoginSample.Web.Api.Models.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace InfoNovitas.LoginSample.Web.Api.Controllers
{
    [Authorize]
    public class AuthorsController : ApiController
    {

        private IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new GetAllAuthorsRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId
            };

            var authorsResponse = _authorService.GetAllAuthors(request);

            if (!authorsResponse.Success)
            {
                return BadRequest(authorsResponse.Message);
            }

            return Ok(
                new
                {
                    authors = authorsResponse.Authors.MapToViewModels()
                }
            );
        }

        [HttpGet]
        public IHttpActionResult Post(AuthorViewModel author)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            return Ok();
        }
    }
}
