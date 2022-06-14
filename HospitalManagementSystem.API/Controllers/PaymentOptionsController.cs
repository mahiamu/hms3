using AutoMapper;
using HospitalManagementSystem.API.Dtos.PaymentOptions;
using HospitalManagementSystem.API.IRepositories;
using HospitalManagementSystem.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentOptionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PaymentOptionsController> _logger;
        private readonly IMapper _mapper;

        public PaymentOptionsController(
            IUnitOfWork unitOfWork,
            ILogger<PaymentOptionsController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetPaymentOptions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetPaymentOptions()
        {
           try
            {
                var paymentOptions = await _unitOfWork.PaymentOptions.GetAll();
                var result = _mapper.Map<IList<PaymentOptionDisplayDto>>(paymentOptions);
             return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetPaymentOptions)}");
               return StatusCode(500);
            }
        }
        [HttpGet("{id:int}", Name = "GetPaymentOption")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPaymentOption(int id)
        {
            try
            {
                var paymentOption = await _unitOfWork.PaymentOptions.Get(po => po.Id == id);
                var result = _mapper.Map<PaymentOptionDisplayDto>(paymentOption);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetPaymentOption)}");
                return StatusCode(500);
            }
        }
        [HttpPost(Name = "CreatePaymentOption")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePaymentOption([FromBody] PaymentOptionFormDto paymentOptionFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in { nameof(CreatePaymentOption)}");
                return BadRequest(ModelState);
            }
            try
            {
                var paymentOption = _mapper.Map<PaymentOption>(paymentOptionFormDto);
                await _unitOfWork.PaymentOptions.Insert(paymentOption);
                await _unitOfWork.Save();
                return CreatedAtRoute("GetPaymentOption", new { id = paymentOption.Id }, paymentOption);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the { nameof(CreatePaymentOption)}");
                return StatusCode(500);
            }
        }
        [HttpPut("{id:int}", Name = "UpdatePaymentOption")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePaymentOption(int id, [FromBody] PaymentOptionFormDto paymentOptionFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdatePaymentOption)}");
                return BadRequest(ModelState);
            }
            try
            {
                var paymentOption = await _unitOfWork.PaymentOptions.Get(po => po.Id == id);
                if (paymentOption == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdatePaymentOption)}");
                    return BadRequest("Payment option not found");
                }
                _mapper.Map(paymentOptionFormDto, paymentOption);
                _unitOfWork.PaymentOptions.Update(paymentOption);
                await _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdatePaymentOption)}");
                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}", Name = "DeletePaymentOption")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePaymentOption(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeletePaymentOption)}");

                return BadRequest();
            }

            try
            {
                var paymentOption = await _unitOfWork.PaymentOptions.Get(po => po.Id == id);

                if (paymentOption == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in { nameof(DeletePaymentOption)}");

                    return BadRequest("Payment option not found");
                }

                await _unitOfWork.PaymentOptions.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(DeletePaymentOption)}");

                return StatusCode(500);
            }
        }
    }
}