using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace TravelClient.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
    
    public static List<Review> GetReviews()
        {
            var apiCallTask = ApiHelper.GetAll();
            string result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Review> reviewList = JsonConvert.DeserializeObject<List<Review>>(jsonResponse.ToString());

            return reviewList;
        }

        public static Review GetDetails(int id)
        {
            var apiCallTask = ApiHelper.Get(id);
            string result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            Review review = JsonConvert.DeserializeObject<Review>(jsonResponse.ToString());

            return review;
        }

        public async static Task Post(Review review)
        {
            string jsonReview = JsonConvert.SerializeObject(review);
            await ApiHelper.Post(jsonReview);
        }

        public async static Task Put(Review review)
        {
            string jsonReview = JsonConvert.SerializeObject(review);
            await ApiHelper.Put(review.ReviewId, jsonReview);
        }

        public async static Task Delete(int id)
        {
            await ApiHelper.Delete(id);
        }
    }
}