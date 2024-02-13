﻿using ClothingStoreApi.DTO;
using ClothingStoreApi.Models;

namespace ClothingStoreApi.Interfaces
{
    public interface IAdvertisementService
    {
        Task<AdvertisementDTO> CreateAdvertisement(AdvertisementDTO advertisementDTO);
        Task<Advertisement> GetAdvertisementById(int id);
        Task<List<Advertisement>> GetAllAdvertisements();
        Task<bool> DeleteAdvertisement(int id);
    }
}