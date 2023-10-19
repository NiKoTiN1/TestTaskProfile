using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TestTaskProfile.Data.Interfaces;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.CQRS.Users.Commands.UpdateUserCard
{
    public class UpdateUserCardHandler : IRequestHandler<UpdateUserCardCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCardHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UpdateUserCardCommand request, CancellationToken cancellationToken)
        {
            request.User.CardId = request.CardId;
            var user = await _userRepository.UpdateUser(request.User);

            if(user == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            return request.User;
        }
    }
}
