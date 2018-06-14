﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Institutions;

namespace Core.Interfaces.Repositories.Business
{
    public interface IInstitutionRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : Institution
    {
        Task<IEnumerable<Institution>> GetAllInstitutionsAsync();
    }
}
