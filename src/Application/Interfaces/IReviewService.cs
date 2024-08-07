﻿using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IReviewService
    {
        Review Add(ReviewForRequest reviewDto, int clientId);
        Review GetById(int reviewId);
        List<Review> GetByProduct(int id);
        Review UpdateContent(int clientId, int reviewId, string content);
    }
}
