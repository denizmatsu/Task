using WebApplication1.DTOs.Talepler;
using WebApplication1.Models.Talepler;
using WebApplication1.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class TaleplerRepository : ITaleplerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly HttpClient _httpClient;

        public TaleplerRepository(ApplicationDbContext dbContext, IHttpClientFactory httpClientFactory)
        {
            _dbContext = dbContext;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<Response<List<TalepListesiDTO>>> GetTalepler()
        {
            try
            {
                var talepler = await _dbContext.Talepler.ToListAsync();
                var commentsResponse = await GetComments();

                if (!commentsResponse.Succeeded)
                {
                    return Response<List<TalepListesiDTO>>.Fail(commentsResponse.ErrorMessage);
                }

                var comments = commentsResponse.Data;

                var talepDTOs = talepler.Select(talep => new TalepListesiDTO
                {
                    Id = talep.Id,
                    CustomerId = talep.CustomerId,
                    CustomerName = comments.FirstOrDefault(comment => comment.id == talep.CustomerId)?.name,
                    Complaint = talep.Complaint,
                    Email = comments.FirstOrDefault(comment => comment.id == talep.CustomerId)?.email,
                    Body = comments.FirstOrDefault(comment => comment.id == talep.CustomerId)?.body
                }).ToList();

                return Response<List<TalepListesiDTO>>.Succeed(talepDTOs);
            }
            catch (Exception ex)
            {
                return Response<List<TalepListesiDTO>>.Fail(ex.Message);
            }
        }

        public async Task<Response<List<CommentDTO>>> GetComments()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts/1/comments");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<CommentDTO> comments = JsonSerializer.Deserialize<List<CommentDTO>>(responseBody);

                return Response<List<CommentDTO>>.Succeed(comments);
            }
            catch (Exception ex)
            {
                return Response<List<CommentDTO>>.Fail(ex.Message);
            }
        }

        public async Task<Response<Talep>> Create(Talep talep)
        {
            var response = new Response<Talep>();
            var validator = new TalepValidator();
            var validationResult = await validator.ValidateAsync(talep);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors
                    .Select(error => error.ErrorMessage)
                    .ToList();

                return Response<Talep>.Fail(errorMessages);
            }

            try
            {
                await _dbContext.Talepler.AddAsync(talep);
                await _dbContext.SaveChangesAsync();

                response = Response<Talep>.Succeed(talep);
                return response;
            }
            catch (Exception ex)
            {
                return Response<Talep>.Fail(ex.Message);
            }
        }
    }
}
