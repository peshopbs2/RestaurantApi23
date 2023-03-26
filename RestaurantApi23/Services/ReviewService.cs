using RestaurantApi23.Data.Entities;
using RestaurantApi23.Models.Meal.Response;
using RestaurantApi23.Models.Restaurant.Responses;
using RestaurantApi23.Models.Review.Response;
using RestaurantApi23.Models.User.Response;
using RestaurantApi23.Repositories.Abstractions;
using RestaurantApi23.Services.Abstractions;

namespace RestaurantApi23.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _reviewRepository;
        public ReviewService(IRepository<Review> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<ReviewResponseDto> CreateReview(string title, string reviewText, string userId, int mealId)
        {
            var item = await _reviewRepository.CreateOrUpdate(new Review()
            {
                Title = title,
                ReviewText = reviewText,
                UserId = userId,
                MealId = mealId
            });



            return new ReviewResponseDto()
            {
                Id = item.Id,
                Title = item.Title,
                ReviewText = item.ReviewText,
                User = new UserPairResponseDto()
                {
                    UserId = item.User.Id,
                    Email = item.User.Email
                },
                Meal = new MealPairResponseDto()
                {
                    Id = mealId,
                    Title = ""
                },
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };

        }

        public IEnumerable<ReviewResponseDto> GetAll()
        {
            return _reviewRepository.GetAll()
                .Select(item => new ReviewResponseDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    ReviewText = item.ReviewText,
                    User = new UserPairResponseDto()
                    {
                        UserId = item.User.Id,
                        Email = item.User.Email
                    },
                    Meal = new MealPairResponseDto()
                    {
                        Id = item.Meal.Id,
                        Title = item.Meal.Title
                    },
                    CreatedAt = item.CreatedAt,
                    ModifiedAt = item.ModifiedAt
                })
                .ToList();
        }

        public async Task<ReviewResponseDto> GetById(int id)
        {
            var item = await _reviewRepository.GetById(id);
            return new ReviewResponseDto()
            {
                Id = item.Id,
                Title = item.Title,
                ReviewText = item.ReviewText,
                User = new UserPairResponseDto()
                {
                    UserId = item.User.Id,
                    Email = item.User.Email
                },
                Meal = new MealPairResponseDto()
                {
                    Id = item.Meal.Id,
                    Title = item.Meal.Title
                },
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };
        }

        public IEnumerable<ReviewResponseDto> GetReviewsByMealId(int mealId)
        {
            return _reviewRepository.Filter(item => item.MealId == mealId)
                .Select(item => new ReviewResponseDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    ReviewText = item.ReviewText,
                    User = new UserPairResponseDto()
                    {
                        UserId = item.User.Id,
                        Email = item.User.Email
                    },
                    Meal = new MealPairResponseDto()
                    {
                        Id = item.Meal.Id,
                        Title = item.Meal.Title
                    },
                    CreatedAt = item.CreatedAt,
                    ModifiedAt = item.ModifiedAt
                })
                .ToList();
        }

        public async Task<bool> RemoveReview(int id)
        {
            return await _reviewRepository.RemoveById(id);
        }

        public async Task<ReviewResponseDto> UpdateReview(int id, string title, string reviewText, string userId, int mealId)
        {
            var item = await _reviewRepository.GetById(id);
            if (item != null)
            {
                item.Id = id;
                item.Title = title;
                item.ReviewText = reviewText;
                item.UserId = userId;
                item.MealId = mealId;

                item = await _reviewRepository.CreateOrUpdate(item);
                return new ReviewResponseDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    ReviewText = item.ReviewText,
                    User = new UserPairResponseDto()
                    {
                        UserId = item.User.Id,
                        Email = item.User.Email
                    },
                    Meal = new MealPairResponseDto()
                    {
                        Id = item.Meal.Id,
                        Title = item.Meal.Title
                    },
                    CreatedAt = item.CreatedAt,
                    ModifiedAt = item.ModifiedAt
                };
            }
            else
            {
                return null;
            }
        }
    }
}
