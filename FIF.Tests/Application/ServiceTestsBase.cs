using AutoFixture;
using AutoMapper;
using FIF.Application.Profiles;
using FIF.Domain;
using FIF.Domain.Services;
using NSubstitute;

namespace FIF.Tests.Application
{
    public class ServiceTestsBase
    {
        protected Fixture _fixture;
        protected IMapper _mapper;
        protected IPersonRepository _personDomainService;

        public ServiceTestsBase()
        {
            _personDomainService = Substitute.For<IPersonRepository>();
            _fixture = new Fixture();

            var cfg = new MapperConfiguration(c => {
                c.AddProfile<PersonProfile>();
            });
            _mapper = cfg.CreateMapper();

            _fixture.Inject(_mapper);
            _fixture.Inject(_personDomainService);
        }
    }
}
