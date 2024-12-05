﻿using InventoryProvider.Interfaces;
using InventoryProvider.Models;
using InventoryProvider.Responses;
using Microsoft.AspNetCore.Mvc;

namespace InventoryProvider.Controllers
{
    [Route("api/createinventory")]
    [ApiController]
    public class CreateInventoryController(IInventoryService service) : ControllerBase
    {
        private readonly IInventoryService _service = service;
        [HttpPost]
        public async Task<ActionResult> CreateProduct(InventoryModel model)
        {
            try
            {
                var result = await _service.CreateInventoryAsync(model);

                if (result == ResultResponse.Success)
                {
                    return Ok(ResultResponse.SuccessResponse());
                }
                else
                {
                    return StatusCode(500, ResultResponse.FailedResponse());
                }
            }
            catch
            {
                return StatusCode(500, new { message = "An unexpected error occurred" });
            }
        }
    }
}
