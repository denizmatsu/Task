using WebApplication1.DTOs.Talepler;
using WebApplication1.Models.Talepler;
using WebApplication1.Workers;

namespace WebApplication1.Repository
{
    public interface ITaleplerRepository
    {
        Task<Response<List<TalepListesiDTO>>> GetTalepler();
        Task<Response<List<CommentDTO>>> GetComments();
        Task<Response<Talep>> Create(Talep talep);
    }
}