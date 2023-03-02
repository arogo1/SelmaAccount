using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Account.BLL.Exceptions;
using Account.BLL.Interfaces;
using Account.Domain;
using Account.WebAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Account.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<Models.Account>>> GetAll()
        {
            try
            {
                var result = await _accountService.GetAll();

                return Ok(_mapper.Map<IEnumerable<Models.Account>>(result));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        [Route("getById")]
        public ActionResult<Models.Account> GetById([FromQuery] int accountId)
        {
            try {
                if (accountId <= 0)
                {
                    return BadRequest("Invalid account id");
                }

                var serviceResult = _accountService.GetById(accountId);

                if(serviceResult == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<Models.Account>(serviceResult);

                /*var map = new Models.Account()
                {
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    AccountId = result.AccountId,
                    DateBorn = result.DateBorn,
                    Email = result.Email
                };*/

                return Ok(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }        

        [HttpPost]
        public ActionResult Create([FromBody] AccountCreateRequest request)
        {
            try
            {
                var account = _mapper.Map<AccountDTO>(request);

                _accountService.Create(account);

                return Accepted();
            }
            catch (MyException e)
            {
                throw e;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        [HttpPut]
        public ActionResult Update([FromQuery] int accountId, [FromBody] AccountUpdateRequest request)
        {
            if(accountId <= 0)
            {
                return BadRequest("Invalid account id");
            }

            var account = _accountService.GetById(accountId);
            if(account == null)
            {
                return NotFound("Invalid accountId, there is not any account that has provided accountId");
            }

            if(request.FirstName != "")
            {
                account.FirstName = request.FirstName;
            }
            if(request.Password != "")
            {
                account.Password = request.Password;
            }

            _accountService.Update(account);

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromQuery] int accountId)
        {
            if (accountId <= 0)
            {
                return BadRequest("Invalid account id");
            }

            _accountService.Delete(accountId);

            return Ok();
        }

        [HttpGet]
        [Route("search")]
        public IEnumerable<Models.Account> Search([FromBody] AccountSearchRequest request) 
        {
            var result = _accountService.Search(new Domain.AccountDTO());

            return new List<Models.Account>()
            {
                new Models.Account()
                {
                    AccountId = 1,
                    Email = "arnes.rogo@gmail.com",
                    FirstName = "Arnes",
                    LastName = "Rogo",
                    DateBorn = System.DateTime.Now
                },
                new Models.Account()
                {
                    AccountId = 2,
                    Email = "selma.rogo@gmail.com",
                    FirstName = "Selma",
                    LastName = "Rogo",
                    DateBorn = System.DateTime.Now
                }
            };
        }
    }
}
