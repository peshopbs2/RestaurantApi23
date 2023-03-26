using RestaurantApi23.Models.Review.Response;

namespace RestaurantApi23.Services.Abstractions
{
    public interface IReviewService
    {
        Task<ReviewResponseDto> CreateReview(string title, string reviewText, string userId, int mealId);
        IEnumerable<ReviewResponseDto> GetAll();
        Task<ReviewResponseDto> GetById(int id);
        Task<ReviewResponseDto> UpdateReview(int id, string title, string reviewText, string userId, int mealId);
        Task<bool> RemoveReview(int id);
        IEnumerable<ReviewResponseDto> GetReviewsByMealId(int mealId);

    }
}
