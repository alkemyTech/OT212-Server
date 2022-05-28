﻿using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public static class CategoryMapper
    {
        public static CategoryNameDTO MapToCategoryNameDTO(this Category entity) => new CategoryNameDTO
        {
            Name = entity.Name,
        };
    }
}