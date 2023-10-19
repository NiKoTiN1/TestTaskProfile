using AutoMapper;
using Isopoh.Cryptography.Argon2;
using MediatR;
using System.Web.Http;
using TestTaskProfile.Data.Interfaces;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, GetUserModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IMapper mapper,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<GetUserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updateModel = request.Model;
            var user = await _userRepository.GetUserById(updateModel.Id);

            if (user == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            if (!string.IsNullOrEmpty(updateModel.Name))
            {
                user.Name = updateModel.Name;
            }

            if (!string.IsNullOrEmpty(updateModel.Email))
            {
                user.Email = updateModel.Email;
            }

            if (!string.IsNullOrEmpty(updateModel.PhoneNumber))
            {
                user.PhoneNumber = updateModel.PhoneNumber;
            }

            if (!string.IsNullOrEmpty(updateModel.Password))
            {
                var hashedPassword = Argon2.Hash(updateModel.Password);
                user.Password = hashedPassword;
            }

            var newUser = await _userRepository.UpdateUser(user);

            if (newUser == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            return _mapper.Map<GetUserModel>(newUser);
        }
    }
}
