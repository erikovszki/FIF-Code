using FIF.Application.DTOs;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIF.Application.Services
{
    public interface IPersonService
    {
        Task AddPersonAsync(PersonDto person);
        Task<Result<bool>> PersonExistsAsync(string email);
    }
}
