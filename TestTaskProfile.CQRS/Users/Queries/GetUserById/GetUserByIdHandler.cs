using AutoMapper;
using MediatR;
using TestTaskProfile.Data.Interfaces;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Users.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<GetUserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id);
            return _mapper.Map<GetUserModel>(user);
        }
    }
}
