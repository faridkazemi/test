using BanjoTwitterExercise.DTO;
using BanjoTwitterExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BanjoTwitterExercise.Repository
{
    public interface ITweetRepository
    {
       Task<TwitterTweetDTO> GetRecentTweetsByHashtagAsync(string hashtag);

    }
}