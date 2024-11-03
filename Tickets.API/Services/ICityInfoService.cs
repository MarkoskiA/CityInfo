using AutoMapper.Configuration.Conventions;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Tickets.API.Models;

namespace Tickets.API.Services
{
    public interface ICityInfoService
    {

        Task<string> GetAuthToken();

        Task<PointOfInterest> GetPointOfInterest(int cityId, int pointOfInterest, string accessToken);
    }
}
