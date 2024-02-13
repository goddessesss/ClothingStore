﻿using ClothingStoreApi.DTO;
using ClothingStoreApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService _advertisementService;

        public AdvertisementController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        [HttpPost("createAdvertisement")]
        public async Task<IActionResult> CreateAdvertisement([FromBody] AdvertisementDTO advertisementDTO)
        {
            try
            {
                var createdAdvertisement = await _advertisementService.CreateAdvertisement(advertisementDTO);
                return Ok(createdAdvertisement);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getAdvertisementById/{id}")]
        public async Task<IActionResult> GetAdvertisementById(int id)
        {
            try
            {
                var advertisement = await _advertisementService.GetAdvertisementById(id);
                return Ok(advertisement);
            }
            catch (Exception ex)
            {
                return NotFound($"Advertisement with ID {id} not found: {ex.Message}");
            }
        }

        [HttpGet("getAllAdvertisements")]
        public async Task<IActionResult> GetAllAdvertisements()
        {
            try
            {
                var advertisements = await _advertisementService.GetAllAdvertisements();
                return Ok(advertisements);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("deleteAdvertisement/{id}")]
        public async Task<IActionResult> DeleteAdvertisement(int id)
        {
            try
            {
                var result = await _advertisementService.DeleteAdvertisement(id);
                if (result)
                {
                    return Ok($"Advertisement with ID {id} has been deleted successfully");
                }
                else
                {
                    return NotFound($"Advertisement with ID {id} not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}