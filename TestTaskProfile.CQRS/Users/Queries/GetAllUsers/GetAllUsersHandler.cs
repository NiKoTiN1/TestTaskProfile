using AutoMapper;
using MediatR;
using TestTaskProfile.Data.Interfaces;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Users.Queries.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<GetUserModel>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<GetUserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsers();
            return _mapper.Map<IEnumerable<GetUserModel>>(users);
        }
    }
}
