using AutoMapper;
using Isopoh.Cryptography.Argon2;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.Data.Interfaces;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, GetUserModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public UpdateUserHandler(IMapper mapper,
            IUserRepository userRepository,
            IMediator mediator)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<GetUserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updateModel = request.Model;
            var user = await _userRepository.GetUserById(updateModel.Id);

            if (user == null)
            {
                return null;
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
                return null;
            }

            return _mapper.Map<GetUserModel>(newUser);
        }
    }
}
