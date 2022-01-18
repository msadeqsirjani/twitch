using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface IFollowerAwardService : IServiceAsync<FollowerAward>
{

}

public class FollowerAwardService : ServiceAsync<FollowerAward>, IFollowerAwardService
{
    public FollowerAwardService(IRepositoryAsync<FollowerAward> repository) : base(repository)
    {
    }
}