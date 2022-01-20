using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services
{
    public interface IAdministratorService : IServiceAsync<Administrator>
    {

    }

    public class AdministratorService : ServiceAsync<Administrator> , IAdministratorService
    {
        public AdministratorService(IRepositoryAsync<Administrator> repository) : base(repository)
        {
        }
    }
}
